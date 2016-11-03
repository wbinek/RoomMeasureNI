using MathNet.Numerics.IntegralTransforms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace RoomMeasureNI
{
    public class MeasurementExecutioner
    {
        private Project proj = Project.Instance;
        private aiaoDriver recorder;

        private List<DataTable> dane = new List<DataTable>();
        private double[] output = new double[0];
        private int count;
        private Object thisLock = new Object();

        public MeasurementExecutioner()
        {
            recorder = new aiaoDriver();
            recorder.MeasurementFinished += this.OnMeasurementFinished;
        }

        private void OnMeasurementFinished(object sender, EventArgs args)
        {
            dane.Add(recorder.getDataTable());
            if (count < proj.measConfig.averages)
            {
                recorder.startMeasurement(output, proj.measConfig.measLength, proj.cardConfig);
            }
            else
            {
                postprocess();
            }
            count++;

        }

        public void startMeasurement()
        {
            count = 1;
            preprocess();
            generateOutput();
            recorder.startMeasurement(output, proj.measConfig.measLength, proj.cardConfig);
        }

        public void stopMeasurement(){
            recorder.stopMeasurement();
        }

        public void generateOutput()
        {
            switch (proj.measConfig.measMethod)
            {
                case measurementMethods.Rejestracja_impulsu:
                    output = FunctionGenerator.generateZeros((int)(proj.cardConfig.chSmplRate * proj.measConfig.measLength));
                    break;
                case measurementMethods.Sweep_sine:
                    output = FunctionGenerator.generateByEnum(proj.measConfig.genMethod, (int)(proj.cardConfig.chSmplRate * proj.measConfig.measLength), proj.cardConfig.chSmplRate, proj.measConfig.fmin, proj.measConfig.fmax);
                    break;
            }

            int i = 0;
            Array.ForEach(output, (x) => { output[i++] = x * (double)proj.cardConfig.aoMax; });
        }

        private void postprocess()
        {
            DataTable wynik = calculateImpulseResp();
            showAcceptanceWindow(wynik);
        }

        private void showAcceptanceWindow(DataTable wynik)
        {
            foreach (DataColumn datacolumn in wynik.Columns)
            {
                int length = datacolumn.Table.Rows.Count;
                int Fs = proj.cardConfig.chSmplRate;

                double[] timevector = usefulFunctions.getTimeVector(length, Fs);
                double[] result = new double[length];

                for (int i = 0; i < length; i++)
                {
                    result[i] = (double)wynik.Rows[i][datacolumn.ColumnName];
                }


                ctrlAcceptResult okno = new ctrlAcceptResult();
                okno.setPlot(timevector, result);
                okno.ShowDialog();

                if (okno.accepted)
                {
                    MeasurementResult pomiar = new MeasurementResult();
                    pomiar.wynik_pomiaru = result;
                    pomiar.godzina_pomiaru = DateTime.Now;
                    pomiar.nazwaPunktu = proj.punktyPomiarowe.getNameFromChannel(datacolumn.ColumnName);
                    pomiar.kanal = datacolumn.ColumnName;
                    pomiar.Fs = Fs;
                    pomiar.metoda = proj.measConfig.measMethod;
                    pomiar.nazwa = pomiar.nazwaPunktu + " " + pomiar.godzina_pomiaru.ToShortDateString() + " " + pomiar.godzina_pomiaru.ToShortTimeString();
                    pomiar.fstart = proj.measConfig.fmin;
                    pomiar.fstop = proj.measConfig.fmax;
                    pomiar.calculateDefWindow();

                    proj.measResults.Add(pomiar);
                }
            }
        }

        private DataTable calculateImpulseResp()
        {
            DataTable wynik = dane[0].Copy();

            if (proj.measConfig.measMethod == measurementMethods.Sweep_sine)
            {
                Complex[] outputFFT = usefulFunctions.double2Complex(output);
                Fourier.Forward(outputFFT,FourierOptions.Matlab);

                //zero all elements in finall result table
                foreach (DataColumn datacolumn in wynik.Columns)
                {
                    for (int i = 0; i < datacolumn.Table.Rows.Count; i++)
                    {
                        wynik.Rows[i][datacolumn.ColumnName] = 0;
                    }
                }

                var tasks = new List<Task>();

                //calculate all impulse responses
                foreach (DataTable table in dane)
                {
                    for (int i=0; i<table.Columns.Count;i++)
                    {
                        int index = i;
                        tasks.Add(Task.Factory.StartNew(() => mtCalculateResponse(index, table, wynik, outputFFT)));
                    }
                }
                Task.WaitAll(tasks.ToArray());

            }

            return wynik;
        }

        private void preprocess()
        {
            dane.Clear();
            if (proj.measConfig.fmax == 0) { proj.measConfig.fmax = proj.cardConfig.chSmplRate / 2; }
        }

        internal double getLength()
        {
            return proj.measConfig.measLength * proj.measConfig.averages;
        }

        private void mtCalculateResponse(int column, DataTable table, DataTable wynik, Complex[] outputFFT)
        {

            double[] result = table.Rows.Cast<DataRow>().Select(row => (double)row[column]).ToArray();

            Complex[] resultFFT = usefulFunctions.double2Complex(result);
            Fourier.Forward(resultFFT, FourierOptions.Matlab);

            resultFFT = resultFFT.Zip(outputFFT, (x, y) => x / y).ToArray();

            Fourier.Inverse(resultFFT, FourierOptions.Matlab);
            result = usefulFunctions.complexReal2Double(resultFFT);

            lock (thisLock)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    wynik.Rows[i][column] = (double)wynik.Rows[i][column] + result[i] / dane.Count;
                }
            }
        }


    }
}
