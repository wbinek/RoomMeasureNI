using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NAudio.Wave;
using RoomMeasureNI.Sources.Dependencies;
using RoomMeasureNI.Sources.Dependencies.ButterworthFilterDesign;
using RoomMeasureNI.Sources.Measurement;

namespace RoomMeasureNI.Sources.Results
{
    [Serializable]
    public class MeasurementResult
    {
        public MeasurementResult()
        {
            okno = new processsingWindow();
            parameters = new List<acousticParameters>();
        }

        public double[] wynik_pomiaru { get; set; }
        public processsingWindow okno { get; set; }
        public List<acousticParameters> parameters { get; set; }

        public string kanal { get; set; }
        public int Fs { get; set; }
        public string nazwaPunktu { get; set; }

        public MeasurementMethods metoda { get; set; }
        public int fstart { get; set; }
        public int fstop { get; set; }

        public DateTime godzina_pomiaru { get; set; }
        public string nazwa { get; set; }

        public void calculateDefWindow()
        {
            var preGap = 0.1;
            double windowLength = 1;

            var maxVal = wynik_pomiaru.Select(x => Math.Abs(x)).Max();
            var maxIdx = Array.FindIndex(wynik_pomiaru, item => Math.Abs(item) == maxVal);
            var startGap = (int) (Fs * preGap);

            if (startGap > maxIdx) startGap = maxIdx;
            okno.windowStart = maxIdx - startGap;

            var windowLengthSmpl = (int) ((windowLength + preGap) * Fs);
            if (windowLengthSmpl + okno.windowStart > wynik_pomiaru.Length)
                windowLengthSmpl = wynik_pomiaru.Length - okno.windowStart;

            okno.windowLength = windowLengthSmpl;
            okno.type = windowType.Prostokatne;
        }

        public double[] getWindowedSignal()
        {
            return okno.getWindowedSignal(wynik_pomiaru);
        }

        public double[] getWindow(double scale = 1)
        {
            //double max = wynik_pomiaru.Max();
            var window = okno.getWindow(wynik_pomiaru.Length);

            var i = 0;
            Array.ForEach(window, x => { window[i++] = x * scale; });
            return window;
        }

        public void setWindowStart(double windowStart)
        {
            okno.windowStart = (int) (windowStart * Fs);
        }

        public void setWindowLength(double windowLength)
        {
            okno.windowLength = (int) (windowLength * Fs);
        }

        public double getWindowLength()
        {
            return (double) okno.windowLength / Fs;
        }

        public double getWindowStart()
        {
            return (double) okno.windowStart / Fs;
        }

        public double[] getResultdB()
        {
            return Array.ConvertAll(wynik_pomiaru, smpl => 20 * Math.Log10(Math.Abs(smpl) / 2e-5));
        }

        public double[] getResult()
        {
            return wynik_pomiaru;
        }

        public double[] getFilteredResult(FilterBank bank, Enum freq)
        {
            if (bank == FilterBank.None)
                return getResult();
            return Butterworth.filterResult(bank, freq, getWindowedSignal(), Fs);
        }

        public void calculateDefaultParams(bool add = false)
        {
            if (parameters.Count == 0 || add)
            {
                var newParamSetOkt = new acousticParameters();
                var newParamSetTr = new acousticParameters();

                newParamSetOkt.name = "Oktawy - " + DateTime.Now.ToString("HH:mm:ss");
                newParamSetOkt.calcParams(getWindowedSignal(), FilterBank.Octave, Fs);
                parameters.Add(newParamSetOkt);

                newParamSetTr.name = "Tercje - " + DateTime.Now.ToString("HH:mm:ss");
                newParamSetTr.calcParams(getWindowedSignal(), FilterBank.Third_octave, Fs);
                parameters.Add(newParamSetTr);
            }
        }

        public void exportResultAsWave()
        {
            //Get File Path
            string path;
            var SaveDialog = new SaveFileDialog();
            SaveDialog.Filter = "wav files (*.wav)|*.wav";

            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                path = SaveDialog.FileName;
                var format = new WaveFormat(Fs, 24, 1);
                var writer = new WaveFileWriter(path, format);

                var responseFloat = wynik_pomiaru.Select(s => (float) s / 10).ToArray();
                writer.WriteSamples(responseFloat, 0, responseFloat.Length);
                writer.Close();
            }
        }

        public static MeasurementResult[] importResultFromWave()
        {
            //Get File Path
            string path;
            var OpenDialog = new OpenFileDialog();
            OpenDialog.Filter = "wav files (*.wav)|*.wav";

            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                path = OpenDialog.FileName;
                var reader = new AudioFileReader(path);

                var MesResults = new MeasurementResult[reader.WaveFormat.Channels];
                var responses = new List<float>[reader.WaveFormat.Channels];

                for (var i = 0; i < reader.WaveFormat.Channels; i++)
                {
                    var result = new MeasurementResult();
                    result.Fs = reader.WaveFormat.SampleRate;
                    result.nazwa = OpenDialog.SafeFileName + " channel " + i;
                    result.kanal = "imported";
                    result.nazwaPunktu = "imported";
                    result.fstart = 20;
                    result.fstop = result.Fs / 2;

                    MesResults[i] = result;
                    responses[i] = new List<float>();
                }

                var buffer = new float[reader.WaveFormat.Channels];
                while (reader.Read(buffer, 0, reader.WaveFormat.Channels) > 0)
                    for (var i = 0; i < reader.WaveFormat.Channels; i++)
                        responses[i].Add(buffer[i]);

                for (var i = 0; i < reader.WaveFormat.Channels; i++)
                {
                    MesResults[i].wynik_pomiaru = Array.ConvertAll(responses[i].ToArray(), x => (double) x);
                    MesResults[i].calculateDefWindow();
                }
                return MesResults;
            }
            return new MeasurementResult[0];
        }
    }
}