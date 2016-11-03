using RoomMeasureNI.Sources.ButterworthFilterDesign;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomMeasureNI
{
    enum acousticParams
    {
        EDT, T20, T30,
        C50, C80,
        D50, STI
    }

    [Serializable]
    public class acousticParameters
    {
        public DataTable parameters { get; set; }
        public string name { get; set; }
        public NC_Curves nc_curve;
        public Speaker speaker;

        Object lockMe = new Object();

        public acousticParameters()
        {
            parameters = new DataTable();
            parameters.Columns.Add("freqEnum", typeof(Enum));
            parameters.Columns.Add("freqidx", typeof(int));
            parameters.Columns.Add("Frequency", typeof(string));
            parameters.Columns.Add("EDT", typeof(double));
            parameters.Columns.Add("T20", typeof(double));
            parameters.Columns.Add("T30", typeof(double));
            parameters.Columns.Add("C50", typeof(double));
            parameters.Columns.Add("C80", typeof(double));
            parameters.Columns.Add("D50", typeof(double));
            parameters.Columns.Add("STI", typeof(double));

            parameters.Columns[0].ColumnMapping = MappingType.Hidden;
            parameters.Columns[1].ColumnMapping = MappingType.Hidden;

            nc_curve = NC_Curves.NC25;
            speaker = Speaker.mezczyzna;
            parameters.PrimaryKey = new DataColumn[] { parameters.Columns["Frequency"] };
        }

        internal void calcParams(double[] wynik, FilterBank filter, int Fs)
        {
            //find maximum
            double maxVal = wynik.Select(x => Math.Abs(x)).Max();
            int maxIdx = Array.FindIndex(wynik, item => Math.Abs(item) == maxVal);


            //switch sellecting filter bank
            switch (filter)
            {
                case FilterBank.Octave:

                    double[][] STI_input_array = new double[7][];
                    CenterFreqO[] freqSTI = new CenterFreqO []{ CenterFreqO.f125, CenterFreqO.f250, CenterFreqO.f500, CenterFreqO.f1000, CenterFreqO.f2000, CenterFreqO.f4000, CenterFreqO.f8000 };
                    
                    //iterate over frequencies for octave bank
                    Parallel.ForEach((CenterFreqO[])Enum.GetValues(typeof(CenterFreqO)), freq =>
                    {
                        double[] filteredResult;
                        filteredResult=Butterworth.filterResult(FilterBank.Octave, freq, wynik, Fs);

                        double edt = 0;
                        double t20 = 0;
                        double t30 = 0;
                        double c50 = 0;
                        double c80 = 0;
                        double d50 = 0;

                        if (!double.IsNaN(filteredResult[0]))
                        { 
                            edt = EDT(Fs, maxIdx, filteredResult);
                            t20 = T20(Fs, maxIdx, filteredResult);
                            t30 = T30(Fs, maxIdx, filteredResult);
                            c50 = C50(Fs, maxIdx, filteredResult);
                            c80 = C80(Fs, maxIdx, filteredResult);
                            d50 = D50(Fs, maxIdx, filteredResult);
                        }
                        lock (lockMe)
                        {
                            parameters.Rows.Add(
                                freq,
                                (int)freq,
                                freq.GetDescription(),
                                edt,
                                t20,
                                t30,
                                c50,
                                c80,
                                d50,
                                -1);
                        }
                        int idx = Array.IndexOf(freqSTI, freq);
                        if (idx != -1)
                            STI_input_array[idx] = filteredResult;
                    });
                    AverageParameters(Fs, maxIdx, STI_input_array);
                    //end case
                    break;

                case FilterBank.Third_octave:

                    //iterate over frequencies for octave bank
                    Parallel.ForEach((CenterFreqTO[])Enum.GetValues(typeof(CenterFreqTO)), freq =>
                    {
                        double[] filteredResult;
                        filteredResult = Butterworth.filterResult(FilterBank.Third_octave, freq, wynik, Fs);

                        double edt = EDT(Fs, maxIdx, filteredResult);
                        double t20 = T20(Fs, maxIdx, filteredResult);
                        double t30 = T30(Fs, maxIdx, filteredResult);
                        double c50 = C50(Fs, maxIdx, filteredResult);
                        double c80 = C80(Fs, maxIdx, filteredResult);
                        double d50 = D50(Fs, maxIdx, filteredResult);

                        lock (lockMe)
                        {
                            parameters.Rows.Add(
                                freq,
                                (int)freq,
                                freq.GetDescription(),
                                edt,
                                t20,
                                t30,
                                c50,
                                c80,
                                d50,
                                -1);
                        }
                    });
                    parameters.Columns["STI"].ColumnMapping = MappingType.Hidden;
                    //end case
                    break;
            }
            //sort resulting table
            DataView dv = parameters.DefaultView;
            dv.Sort = "freqidx asc";
            parameters = dv.ToTable();
        }

        private double getTimeRange(int Fs, int maxIdx, double[] impulse, int from = 0, int to = 0)
        {
            

            if (from != 0)
                from = (int)(from * 0.001 * Fs);

            if (to == 0)
                to = impulse.Count()-maxIdx-from;
            else
                to = (int)(to * 0.001 * Fs);

            if (to + maxIdx + from > impulse.Count())
            {
                MessageBox.Show("Impulse to short. Could not calculate sum properly.");
                to = impulse.Count() - maxIdx - from;
            }

            double[] trimmedImpulse = new double[to];
            Array.Copy(impulse, maxIdx+from, trimmedImpulse, 0, to);

            return Array.ConvertAll(trimmedImpulse, p => Math.Pow(p,2)).Sum();
        }

        private double[] getSchroederCurve(double[] impulse)
        {
            double[] result = new double[impulse.Length];
            double last = Math.Pow(impulse[impulse.Length - 1],2);

            for (int i=impulse.Length-1; i >= 0; i--)
            {
                result[i] = last;
                last += Math.Pow(impulse[i],2);
            }
            return Array.ConvertAll(result, p2=>10*Math.Log10(p2/Math.Pow(2e-5,2)));
        }

        private double RT(int Fs, int maxIdx, double[] impulse, int dbStart, int dbStop)
        {
            double[] schroeder = getSchroederCurve(impulse);
            double maxdb = schroeder[maxIdx];

            schroeder = Array.ConvertAll(schroeder, p => p - maxdb);

            int start = schroeder.ToList().FindIndex(value => value < dbStart);
            int stop = schroeder.ToList().FindIndex(value => value < dbStop);

            double[] regData = new double[stop - maxIdx];
            Array.Copy(schroeder, maxIdx, regData, 0, stop - maxIdx);

            double a, b, rs;
            usefulFunctions.LinearRegression(usefulFunctions.getTimeVector(stop - maxIdx, Fs), regData, start-maxIdx, regData.Count(),out rs,out b,out a);

            return (-60 - b)/a;
        }

        private double C80(int Fs, int maxIdx, double[] impulse)
        {
            return 10 * Math.Log10(getTimeRange(Fs, maxIdx, impulse, 0, 80) / getTimeRange(Fs, maxIdx, impulse, 80));
        }

        private double C50(int Fs, int maxIdx, double[] impulse)
        {
            return 10 * Math.Log10(getTimeRange(Fs, maxIdx, impulse, 0, 50) / getTimeRange(Fs, maxIdx, impulse, 50));
        }

        private double D50(int Fs, int maxIdx, double[] impulse)
        {
            return getTimeRange(Fs, maxIdx, impulse, 0, 50) / getTimeRange(Fs, maxIdx, impulse);
        }

        private double T20(int Fs, int maxIdx, double[] impulse)
        {
            return RT(Fs, maxIdx, impulse, -5,-20);
        }

        private double T30(int Fs, int maxIdx, double[] impulse)
        {
            return RT(Fs, maxIdx, impulse, -5, -30);
        }

        private double EDT(int Fs, int maxIdx, double[] impulse)
        {
            return RT(Fs, maxIdx, impulse, 0, -10);
        }

        private double STI(int Fs, int maxIdx, double[][] inputData, NC_Curves NC_curve, Speaker gen)
        {
            //tab_wj=p^2 !!!

            ////////////////////////////////////////////////////////////////////////
            //check if all needed frequencies are present
            //std::vector<wxInt32>::const_iterator idx;
            //std::vector<std::vector<wxFloat32>> tab_wj_corr;
            //formatGABE::GABE_Data_Float* newParameter = new formatGABE::GABE_Data_Float(tab_wj.size() + 1); //+1 pour le calcul toute ban
            double[] timeTable = usefulFunctions.getTimeVector(inputData[0].Count(), Fs);
            double[] db_level = new double[7];

            for (int i = 0; i < 7; i++)
            {
                db_level[i] = 10*Math.Log10(getTimeRange(Fs, maxIdx, inputData[i])/Math.Pow(2e-5,2));
            }

            int[] NC = nc_curves.get_nc(NC_curve);
            double[] fm = { 0.63, 0.8, 1.0, 1.25, 1.6, 2.0, 2.5, 3.15, 4.0, 5.0, 6.3, 8.0, 10.0, 12.5 };



            ////////////////////////////////////////////////////////////////////////
            //calc SNR
            double[] SNR = new double[7];
            double[] lvl_SNR = new double[7];
            for (int i = 0; i < 7; i++)
            {
                lvl_SNR[i] = 10 * Math.Log10(Math.Pow(10, db_level[i] / 10.0) + Math.Pow(10, NC[i + 1] / 10.0));
                SNR[i] = lvl_SNR[i] - NC[i + 1];
            }

            ////////////////////////////////////////////////////////////////////////
            //calc modulation transfer function (k,m)
            double[,] mkf = new double[14, 7];
            double mkf_re = 0;
            double mkf_im = 0;
            double mkf_den = 0;

            for (int m = 0; m < 14; m++)
            {
                for (int k = 0; k < 7; k++)
                {
                    for (int t = 0; t < timeTable.Count(); t++)
                    {
                        mkf_re += Math.Pow(inputData[k][t],2) * Math.Cos(2 * Math.PI * fm[m] * (timeTable[t]));
                        mkf_im += Math.Pow(inputData[k][t],2) * Math.Sin(2 * Math.PI * fm[m] * (timeTable[t]));
                        mkf_den += Math.Pow(inputData[k][t],2);
                    }
                    double mkf_num = Math.Sqrt(Math.Pow(mkf_re, 2) + Math.Pow(mkf_im, 2));
                    mkf[m, k] = (mkf_num / mkf_den) / (1 + Math.Pow(10, -SNR[k] / 10));
                    mkf_re = 0;
                    mkf_im = 0;
                    mkf_den = 0;
                }
            }

            ////////////////////////////////////////////////////////////////////////
            //Iamk - intensity correction calculation
            double[] Ik = new double[7];
            double[] Iamk = new double[7];
            double[] amdb = new double[7];
            double[] amf = new double[7];

            Iamk[0] = 0;
            Ik[0] = Math.Pow(10, lvl_SNR[0] / 10);

            for (int m = 0; m < 14; m++)
            {
                for (int k = 1; k < 7; k++)
                {
                    Ik[k] = Math.Pow(10, lvl_SNR[k] / 10);
                    if (lvl_SNR[k] < 63) {
                        amdb[k] = 0.5 * lvl_SNR[k] - 65;
                    } else if (lvl_SNR[k] < 67) {
                        amdb[k] = 1.8 * lvl_SNR[k] - 146.9;
                    } else if (lvl_SNR[k] < 100) {
                        amdb[k] = 0.5 * lvl_SNR[k] - 59.8;
                    } else {
                        amdb[k] = -10;
                    }
                    amf[k] = Math.Pow(10, amdb[k] / 10);
                    Iamk[k] = Ik[k - 1] * amf[k];
                }
            }

            ////////////////////////////////////////////////////////////////////////
            //Irtk - intensity reception treshold

            double[] Irtk = new double[7];

            Irtk[0] = Math.Pow(10, 46 / 10.0);
            Irtk[1] = Math.Pow(10, 27 / 10.0);
            Irtk[2] = Math.Pow(10, 12 / 10.0);
            Irtk[3] = Math.Pow(10, 6.5 / 10.0);
            Irtk[4] = Math.Pow(10, 7.5 / 10.0);
            Irtk[5] = Math.Pow(10, 8 / 10.0);
            Irtk[6] = Math.Pow(10, 12 / 10.0);

            ////////////////////////////////////////////////////////////////////////
            //mkf' - adjusted mkf computation

            double[,] mkf_ = new double[14, 7];

            for (int m = 0; m < 14; m++) {
                for (int k = 0; k < 7; k++) {
                    mkf_[m, k] = mkf[m, k] * (Ik[k]) / (Ik[k] + Iamk[k] + Irtk[k]);
                }
            }

            ////////////////////////////////////////////////////////////////////////
            //SNReff - corrected SNR computation

            double[,] SNReff = new double[14, 7];

            for (int m = 0; m < 14; m++) {
                for (int k = 0; k < 7; k++) {
                    SNReff[m, k] = 10 * Math.Log10(mkf_[m, k] / (1 - mkf_[m, k]));
                    if (SNReff[m, k] > 15) { SNReff[m, k] = 15; }
                    else if (SNReff[m, k] < -15) { SNReff[m, k] = -15; }
                }
            }

            ////////////////////////////////////////////////////////////////////////
            //TIkf - corrected SNR computation

            double[,] TIkf = new double[14, 7];

            for (int m = 0; m < 14; m++)
            {
                for (int k = 0; k < 7; k++)
                {
                    TIkf[m, k] = (SNReff[m, k] + 15) / 30;
                }
            }

            ////////////////////////////////////////////////////////////////////////
            //MTIk - Modulation transfer index
            double[] MTIk = new double[7];


            for (int k = 0; k < 7; k++)
            {
                MTIk[k] = 0;
                for (int m = 0; m < 14; m++)
                {
                    MTIk[k] += TIkf[m, k];
                }
                MTIk[k] = MTIk[k] / 14.0;
            }

            ////////////////////////////////////////////////////////////////////////
            //STI
            double STI = new double();
            double[] alfa = new double[7];
            double[] beta = new double[7];

            if (gen == Speaker.kobieta) {
                alfa[0] = 0; beta[0] = 0;
                alfa[1] = 0.117; beta[1] = 0.099;
                alfa[2] = 0.223; beta[2] = 0.066;
                alfa[3] = 0.216; beta[3] = 0.062;
                alfa[4] = 0.328; beta[4] = 0.025;
                alfa[5] = 0.25; beta[5] = 0.076;
                alfa[6] = 0.194; beta[6] = 0;
            } else {
                alfa[0] = 0.085; beta[0] = 0.085;
                alfa[1] = 0.127; beta[1] = 0.078;
                alfa[2] = 0.23; beta[2] = 0.065;
                alfa[3] = 0.233; beta[3] = 0.011;
                alfa[4] = 0.309; beta[4] = 0.047;
                alfa[5] = 0.224; beta[5] = 0.095;
                alfa[6] = 0.173; beta[6] = 0;
            }

            for (int k = 0; k < 7; k++)
            {
                STI += alfa[k] * MTIk[k];
            }
            for (int k = 0; k < 6; k++)
            {
                STI -= beta[k] * Math.Sqrt(MTIk[k] * MTIk[k + 1]);
            }

            CenterFreqO[] freqSTI = new CenterFreqO[] { CenterFreqO.f125, CenterFreqO.f250, CenterFreqO.f500, CenterFreqO.f1000, CenterFreqO.f2000, CenterFreqO.f4000, CenterFreqO.f8000 };
            for (int i = 0; i < 7; i++)
            {
                try {
                    parameters.Rows.Find(freqSTI[i].GetDescription())["STI"] = MTIk[i];
                } catch(NullReferenceException e)
                {
                    MessageBox.Show("Row for freq " + freqSTI[i].GetDescription() + "Hz not found");
                }
            }

            return STI;
        }

        private void AverageParameters(int Fs, int maxIdx, double[][] STI_input_array)
        {
            DataRow row500 = parameters.Rows.Find(CenterFreqO.f500.GetDescription());
            DataRow row1000 = parameters.Rows.Find(CenterFreqO.f1000.GetDescription());
            DataRow row2000 = parameters.Rows.Find(CenterFreqO.f2000.GetDescription());

            double sti = STI(Fs, maxIdx, STI_input_array, nc_curve, speaker);
            double edt = ((double)row500["EDT"] + (double)row1000["EDT"]) / 2;
            double t20 = ((double)row500["T20"] + (double)row1000["T20"]) / 2;
            double t30 = ((double)row500["T30"] + (double)row1000["T30"]) / 2;

            parameters.Rows.Add(
                            null,
                            parameters.Rows.Count,
                            "Średnia",
                            edt,
                            t20,
                            t30,
                            -1,
                            -1,
                            -1,
                            sti);

        }
    }
}
