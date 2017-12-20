using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoomMeasureNI.Sources.Dependencies;
using RoomMeasureNI.Sources.Dependencies.ButterworthFilterDesign;

namespace RoomMeasureNI.Sources.Results
{
    /// <summary>
    ///     Enum containing list of acoustic parameters to calculate
    /// </summary>
    [Serializable]
    internal enum acousticParams
    {
        EDT,
        T20,
        T30,
        C50,
        C80,
        D50,
        STI
    }

    [Serializable]
    public class acousticParameters
    {
        private readonly object lockMe = new object();
        public NC_Curves nc_curve; //Used Noise Curve (STI calculation)
        public Speaker speaker; //Used speaker type (STI calculation)

        /// <summary>
        ///     Default creator
        /// </summary>
        public acousticParameters()
        {
            parameters = new DataTable();
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
            parameters.PrimaryKey = new[] {parameters.Columns["Frequency"]};
        }

        public DataTable parameters { get; set; } //Table containing acoustics parameters
        public string name { get; set; } //Result set name

        /// <summary>
        ///     Main function for acoustic parameters calculation
        /// </summary>
        /// <param name="impulseResponse">Input impulse response</param>
        /// <param name="filter">Type of filter bank to use</param>
        /// <param name="Fs">IR sampling frequency</param>
        internal void calcParams(double[] impulseResponse, FilterBank filter, int Fs)
        {
            //find maximum
            var maxVal = impulseResponse.Select(x => Math.Abs(x)).Max();
            var maxIdx = Array.FindIndex(impulseResponse, item => Math.Abs(item) == maxVal);


            //switch selecting filter bank
            switch (filter)
            {
                case FilterBank.Octave:

                    var STI_input_array = new double[7][];
                    CenterFreqO[] freqSTI =
                    {
                        CenterFreqO.f125, CenterFreqO.f250, CenterFreqO.f500, CenterFreqO.f1000,
                        CenterFreqO.f2000, CenterFreqO.f4000, CenterFreqO.f8000
                    };

                    bool skip = false;
                    //iterate over frequencies for octave bank
                    Parallel.ForEach((CenterFreqO[]) Enum.GetValues(typeof(CenterFreqO)), freq =>              
                    {                      
                        try
                        {
                            double[] forwardFilt = Butterworth.filterResult(FilterBank.Octave, freq, impulseResponse, Fs);
                            double[] backwardFilt = Butterworth.filterResult(FilterBank.Octave, freq, forwardFilt.Reverse().ToArray(), Fs);
                            double[] filteredResult = backwardFilt.Reverse().ToArray();

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
                            var idx = Array.IndexOf(freqSTI, freq);
                            if (idx != -1)
                                STI_input_array[idx] = filteredResult;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error in parameters calculation \n " + ex.Message);
                            skip = true;
                        }
                    });
                    if (skip)
                        break;
                    AverageParameters(Fs, maxIdx, STI_input_array);
                    //end case
                    break;

                case FilterBank.Third_octave:

                    skip = false;
                    //iterate over frequencies for octave bank
                    Parallel.ForEach((CenterFreqTO[]) Enum.GetValues(typeof(CenterFreqTO)), freq =>
                    {
                        try
                        {
                            double[] forwardFilt = Butterworth.filterResult(FilterBank.Third_octave, freq, impulseResponse, Fs);
                            double[] backwardFilt = Butterworth.filterResult(FilterBank.Third_octave, freq, forwardFilt.Reverse().ToArray(), Fs);
                            double[] filteredResult = backwardFilt.Reverse().ToArray();

                            var edt = EDT(Fs, maxIdx, filteredResult);
                            var t20 = T20(Fs, maxIdx, filteredResult);
                            var t30 = T30(Fs, maxIdx, filteredResult);
                            var c50 = C50(Fs, maxIdx, filteredResult);
                            var c80 = C80(Fs, maxIdx, filteredResult);
                            var d50 = D50(Fs, maxIdx, filteredResult);

                            lock (lockMe)
                            {
                                parameters.Rows.Add(
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
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Error in parameters calculation \n " + ex.Message);
                            skip = true;
                        }
                    });
                    if (skip)
                        break;

                    parameters.Columns["STI"].ColumnMapping = MappingType.Hidden;
                    //end case
                    break;
            }
            //sort resulting table
            var dv = parameters.DefaultView;
            dv.Sort = "freqidx asc";
            parameters = dv.ToTable();
        }

        /// <summary>
        ///     Calculates p^2 sum in specified time range
        /// </summary>
        /// <param name="Fs">IR sampling frequency</param>
        /// <param name="maxIdx">Index of max value</param>
        /// <param name="impulse">Array with impulse response</param>
        /// <param name="from">Start time (ms)</param>
        /// <param name="to">End time (ms)</param>
        /// <returns>Squared pressure sum over specified range</returns>
        private double getTimeRange(int Fs, int maxIdx, double[] impulse, int from = 0, int to = 0)
        {
            if (from != 0)
                from = (int) (from * 0.001 * Fs);

            if (to == 0)
                to = impulse.Count() - maxIdx - from;
            else
                to = (int) (to * 0.001 * Fs);

            if (to + maxIdx + from > impulse.Count())
            {
                MessageBox.Show("Impulse to short. Could not calculate sum properly.");
                to = impulse.Count() - maxIdx - from;
            }

            var trimmedImpulse = new double[to];
            Array.Copy(impulse, maxIdx + from, trimmedImpulse, 0, to);

            return Array.ConvertAll(trimmedImpulse, p => Math.Pow(p, 2)).Sum();
        }

        /// <summary>
        ///     Calculates Schroeder Curve
        /// </summary>
        /// <param name="impulse">Input impulse</param>
        /// <returns>Schroeder Curve for input impulse</returns>
        private double[] getSchroederCurve(double[] impulse)
        {
            var result = new double[impulse.Length];
            var last = Math.Pow(impulse[impulse.Length - 1], 2);

            for (var i = impulse.Length - 1; i >= 0; i--)
            {
                result[i] = last;
                last += Math.Pow(impulse[i], 2);
            }
            return Array.ConvertAll(result, p2 => 10 * Math.Log10(p2 / Math.Pow(2e-5, 2)));
        }

        /// <summary>
        ///     Calculates reverberation time
        /// </summary>
        /// <param name="Fs">IR sampling frequency</param>
        /// <param name="maxIdx">IR max value index</param>
        /// <param name="impulse">Array containing impulse response</param>
        /// <param name="dbStart">Approximation start value (dB)</param>
        /// <param name="dbStop">Approximation end value (dB)</param>
        /// <returns>Reverberation time</returns>
        private double RT(int Fs, int maxIdx, double[] impulse, int dbStart, int dbStop)
        {
           // var envelope = usefulFunctions.calculateEnvelopeFunction(impulse);
            var schroeder = getSchroederCurve(impulse);
            var maxdb = schroeder[maxIdx];

            schroeder = Array.ConvertAll(schroeder, p => p - maxdb);

            var start = schroeder.ToList().FindIndex(value => value < dbStart);
            var stop = schroeder.ToList().FindIndex(value => value < dbStop);

            var regData = new double[stop - maxIdx];
            Array.Copy(schroeder, maxIdx, regData, 0, stop - maxIdx);

            double a, b, rs;
            usefulFunctions.LinearRegression(usefulFunctions.getTimeVector(stop - maxIdx, Fs), regData, start - maxIdx,
                regData.Count(), out rs, out b, out a);

            return (-60 - b) / a;
        }

        /// <summary>
        ///     Calculates C80 parameter
        /// </summary>
        /// <param name="Fs">IR sampling rate</param>
        /// <param name="maxIdx">IR max value index</param>
        /// <param name="impulse">Array containing impulse response</param>
        /// <returns>C80 value</returns>
        private double C80(int Fs, int maxIdx, double[] impulse)
        {
            try
            {
                return 10 * Math.Log10(getTimeRange(Fs, maxIdx, impulse, 0, 80) / getTimeRange(Fs, maxIdx, impulse, 80));
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        ///     Calculates C50 parameter
        /// </summary>
        /// <param name="Fs">IR sampling rate</param>
        /// <param name="maxIdx">IR max value index</param>
        /// <param name="impulse">Array containing impulse response</param>
        /// <returns>Returns C50 value</returns>
        private double C50(int Fs, int maxIdx, double[] impulse)
        {
            try
            {
                return 10 * Math.Log10(getTimeRange(Fs, maxIdx, impulse, 0, 50) / getTimeRange(Fs, maxIdx, impulse, 50));
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        ///     Calculates D50 parameter
        /// </summary>
        /// <param name="Fs">IR sampling rate</param>
        /// <param name="maxIdx">IR max value index</param>
        /// <param name="impulse">Array containing impulse response</param>
        /// <returns>Returns D50 value</returns>
        private double D50(int Fs, int maxIdx, double[] impulse)
        {
            return getTimeRange(Fs, maxIdx, impulse, 0, 50) / getTimeRange(Fs, maxIdx, impulse);
        }

        /// <summary>
        ///     Calculates T20 reverberation time
        /// </summary>
        /// <param name="Fs">IR sampling rate</param>
        /// <param name="maxIdx">IR max value index</param>
        /// <param name="impulse">Array containing impulse response</param>
        /// <returns>Returns T20</returns>
        private double T20(int Fs, int maxIdx, double[] impulse)
        {
            return RT(Fs, maxIdx, impulse, -5, -20);
        }

        /// <summary>
        ///     Calculates T30 reverberation time
        /// </summary>
        /// <param name="Fs">IR sampling rate</param>
        /// <param name="maxIdx">IR max value index</param>
        /// <param name="impulse">Array containing impulse response</param>
        /// <returns>Returns T30</returns>
        private double T30(int Fs, int maxIdx, double[] impulse)
        {
            return RT(Fs, maxIdx, impulse, -5, -30);
        }

        /// <summary>
        ///     Calculates EDT reverberation time
        /// </summary>
        /// <param name="Fs">IR sampling rate</param>
        /// <param name="maxIdx">IR max value index</param>
        /// <param name="impulse">Array containing impulse response</param>
        /// <returns>Returns EDT</returns>
        private double EDT(int Fs, int maxIdx, double[] impulse)
        {
            return RT(Fs, maxIdx, impulse, 0, -10);
        }

        /// <summary>
        ///     Calculates STI parameter
        /// </summary>
        /// <param name="Fs">IR sampling rate</param>
        /// <param name="maxIdx">IR max value index</param>
        /// <param name="inputData">Array of filtered results</param>
        /// <param name="NC_curve">Noise Curve used for STI calculation</param>
        /// <param name="gen">Speaker gender</param>
        /// <returns>Transmission index value</returns>
        private double STI(int Fs, int maxIdx, double[][] inputData, NC_Curves NC_curve, Speaker gen)
        {
            //tab_wj=p^2 !!!

            ////////////////////////////////////////////////////////////////////////
            //check if all needed frequencies are present
            //std::vector<wxInt32>::const_iterator idx;
            //std::vector<std::vector<wxFloat32>> tab_wj_corr;
            //formatGABE::GABE_Data_Float* newParameter = new formatGABE::GABE_Data_Float(tab_wj.size() + 1); //+1 pour le calcul toute ban
            var timeTable = usefulFunctions.getTimeVector(inputData[0].Count(), Fs);
            var db_level = new double[7];

            for (var i = 0; i < 7; i++)
                db_level[i] = 10 * Math.Log10(getTimeRange(Fs, maxIdx, inputData[i]) / Math.Pow(2e-5, 2));

            var NC = nc_curves.get_nc(NC_curve);
            double[] fm = {0.63, 0.8, 1.0, 1.25, 1.6, 2.0, 2.5, 3.15, 4.0, 5.0, 6.3, 8.0, 10.0, 12.5};


            ////////////////////////////////////////////////////////////////////////
            //calc SNR
            var SNR = new double[7];
            var lvl_SNR = new double[7];
            for (var i = 0; i < 7; i++)
            {
                lvl_SNR[i] = 10 * Math.Log10(Math.Pow(10, db_level[i] / 10.0) + Math.Pow(10, NC[i + 1] / 10.0));
                SNR[i] = lvl_SNR[i] - NC[i + 1];
            }

            ////////////////////////////////////////////////////////////////////////
            //calc modulation transfer function (k,m)
            var mkf = new double[14, 7];
            double mkf_re = 0;
            double mkf_im = 0;
            double mkf_den = 0;

            for (var m = 0; m < 14; m++)
            for (var k = 0; k < 7; k++)
            {
                for (var t = 0; t < timeTable.Count(); t++)
                {
                    mkf_re += Math.Pow(inputData[k][t], 2) * Math.Cos(2 * Math.PI * fm[m] * timeTable[t]);
                    mkf_im += Math.Pow(inputData[k][t], 2) * Math.Sin(2 * Math.PI * fm[m] * timeTable[t]);
                    mkf_den += Math.Pow(inputData[k][t], 2);
                }
                var mkf_num = Math.Sqrt(Math.Pow(mkf_re, 2) + Math.Pow(mkf_im, 2));
                mkf[m, k] = mkf_num / mkf_den / (1 + Math.Pow(10, -SNR[k] / 10));
                mkf_re = 0;
                mkf_im = 0;
                mkf_den = 0;
            }

            ////////////////////////////////////////////////////////////////////////
            //Iamk - intensity correction calculation
            var Ik = new double[7];
            var Iamk = new double[7];
            var amdb = new double[7];
            var amf = new double[7];

            Iamk[0] = 0;
            Ik[0] = Math.Pow(10, lvl_SNR[0] / 10);

            for (var m = 0; m < 14; m++)
            for (var k = 1; k < 7; k++)
            {
                Ik[k] = Math.Pow(10, lvl_SNR[k] / 10);
                if (lvl_SNR[k] < 63) amdb[k] = 0.5 * lvl_SNR[k] - 65;
                else if (lvl_SNR[k] < 67) amdb[k] = 1.8 * lvl_SNR[k] - 146.9;
                else if (lvl_SNR[k] < 100) amdb[k] = 0.5 * lvl_SNR[k] - 59.8;
                else amdb[k] = -10;
                amf[k] = Math.Pow(10, amdb[k] / 10);
                Iamk[k] = Ik[k - 1] * amf[k];
            }

            ////////////////////////////////////////////////////////////////////////
            //Irtk - intensity reception treshold

            var Irtk = new double[7];

            Irtk[0] = Math.Pow(10, 46 / 10.0);
            Irtk[1] = Math.Pow(10, 27 / 10.0);
            Irtk[2] = Math.Pow(10, 12 / 10.0);
            Irtk[3] = Math.Pow(10, 6.5 / 10.0);
            Irtk[4] = Math.Pow(10, 7.5 / 10.0);
            Irtk[5] = Math.Pow(10, 8 / 10.0);
            Irtk[6] = Math.Pow(10, 12 / 10.0);

            ////////////////////////////////////////////////////////////////////////
            //mkf' - adjusted mkf computation

            var mkf_ = new double[14, 7];

            for (var m = 0; m < 14; m++)
            for (var k = 0; k < 7; k++) mkf_[m, k] = mkf[m, k] * Ik[k] / (Ik[k] + Iamk[k] + Irtk[k]);

            ////////////////////////////////////////////////////////////////////////
            //SNReff - corrected SNR computation

            var SNReff = new double[14, 7];

            for (var m = 0; m < 14; m++)
            for (var k = 0; k < 7; k++)
            {
                SNReff[m, k] = 10 * Math.Log10(mkf_[m, k] / (1 - mkf_[m, k]));
                if (SNReff[m, k] > 15) SNReff[m, k] = 15;
                else if (SNReff[m, k] < -15) SNReff[m, k] = -15;
            }

            ////////////////////////////////////////////////////////////////////////
            //TIkf - corrected SNR computation

            var TIkf = new double[14, 7];

            for (var m = 0; m < 14; m++)
            for (var k = 0; k < 7; k++)
                TIkf[m, k] = (SNReff[m, k] + 15) / 30;

            ////////////////////////////////////////////////////////////////////////
            //MTIk - Modulation transfer index
            var MTIk = new double[7];


            for (var k = 0; k < 7; k++)
            {
                MTIk[k] = 0;
                for (var m = 0; m < 14; m++)
                    MTIk[k] += TIkf[m, k];
                MTIk[k] = MTIk[k] / 14.0;
            }

            ////////////////////////////////////////////////////////////////////////
            //STI
            var STI = new double();
            var alfa = new double[7];
            var beta = new double[7];

            if (gen == Speaker.kobieta)
            {
                alfa[0] = 0;
                beta[0] = 0;
                alfa[1] = 0.117;
                beta[1] = 0.099;
                alfa[2] = 0.223;
                beta[2] = 0.066;
                alfa[3] = 0.216;
                beta[3] = 0.062;
                alfa[4] = 0.328;
                beta[4] = 0.025;
                alfa[5] = 0.25;
                beta[5] = 0.076;
                alfa[6] = 0.194;
                beta[6] = 0;
            }
            else
            {
                alfa[0] = 0.085;
                beta[0] = 0.085;
                alfa[1] = 0.127;
                beta[1] = 0.078;
                alfa[2] = 0.23;
                beta[2] = 0.065;
                alfa[3] = 0.233;
                beta[3] = 0.011;
                alfa[4] = 0.309;
                beta[4] = 0.047;
                alfa[5] = 0.224;
                beta[5] = 0.095;
                alfa[6] = 0.173;
                beta[6] = 0;
            }

            for (var k = 0; k < 7; k++)
                STI += alfa[k] * MTIk[k];
            for (var k = 0; k < 6; k++)
                STI -= beta[k] * Math.Sqrt(MTIk[k] * MTIk[k + 1]);

            CenterFreqO[] freqSTI =
            {
                CenterFreqO.f125, CenterFreqO.f250, CenterFreqO.f500, CenterFreqO.f1000,
                CenterFreqO.f2000, CenterFreqO.f4000, CenterFreqO.f8000
            };
            for (var i = 0; i < 7; i++)
                try
                {
                    parameters.Rows.Find(freqSTI[i].GetDescription())["STI"] = MTIk[i];
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Row for freq " + freqSTI[i].GetDescription() + "Hz not found");
                }

            return STI;
        }

        /// <summary>
        ///     Calculates average parameter value
        /// </summary>
        /// <param name="Fs">IR sampling rate</param>
        /// <param name="maxIdx">IR max value index</param>
        /// <param name="STI_input_array">Array of transmission indexes for STI calculation</param>
        private void AverageParameters(int Fs, int maxIdx, double[][] STI_input_array)
        {
            var row500 = parameters.Rows.Find(CenterFreqO.f500.GetDescription());
            var row1000 = parameters.Rows.Find(CenterFreqO.f1000.GetDescription());
            var row2000 = parameters.Rows.Find(CenterFreqO.f2000.GetDescription());

            var sti = STI(Fs, maxIdx, STI_input_array, nc_curve, speaker);
            var edt = ((double) row500["EDT"] + (double) row1000["EDT"]) / 2;
            var t20 = ((double) row500["T20"] + (double) row1000["T20"]) / 2;
            var t30 = ((double) row500["T30"] + (double) row1000["T30"]) / 2;

            parameters.Rows.Add(
                100,
                "Średnia",
                edt,
                t20,
                t30,
                -1,
                -1,
                -1,
                sti);
        }

        /// <summary>
        ///     Returns values of parameter with given name
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns>Parameter values</returns>
        public double[] getParameterByName(string parameterName)
        {
            var param = new double[parameters.Rows.Count - 1];
            for (var i = 0; i < parameters.Rows.Count - 1; i++)
                param[i] = (double) parameters.Rows[i][parameterName];
            return param;
        }

        public double[] getIndexes()
        {
            var param = new double[parameters.Rows.Count - 1];
            for (var i = 0; i < parameters.Rows.Count - 1; i++)
                param[i] = (int) parameters.Rows[i]["freqidx"];
            return param;
        }

        public string[] getFrequencies()
        {
            var param = new string[parameters.Rows.Count - 1];
            for (var i = 0; i < parameters.Rows.Count - 1; i++)
                param[i] = (string) parameters.Rows[i]["Frequency"];
            return param;
        }
    }
}