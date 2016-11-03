using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using RoomMeasureNI.Sources.ButterworthFilterDesign;
using NAudio.Wave;
using System.Windows.Forms;

namespace RoomMeasureNI
{
    [Serializable]
    public class MeasurementResult
    {
        public double[] wynik_pomiaru { get; set; }
        public processsingWindow okno { get; set; }
        public List<acousticParameters> parameters { get; set; }

        public string kanal { get; set; }
        public int Fs { get; set; }
        public string nazwaPunktu { get; set; }

        public measurementMethods metoda { get; set; }
        public int fstart { get; set; }
        public int fstop { get; set; }

        public DateTime godzina_pomiaru { get; set; }
        public string nazwa { get; set; }

        public MeasurementResult()
        {
            okno = new processsingWindow();
            parameters = new List<acousticParameters>();
        }

        public void calculateDefWindow()
        {
            double preGap = 0.1;
            double windowLength = 1;
            
            double maxVal=wynik_pomiaru.Select(x => Math.Abs(x)).Max();
            int maxIdx = Array.FindIndex(wynik_pomiaru, item => Math.Abs(item) == maxVal);
            int startGap = (int)(Fs * preGap);
            
            if(startGap>maxIdx){
                startGap=maxIdx;
            }
            okno.windowStart = maxIdx - startGap;

            int windowLengthSmpl = (int)((windowLength + preGap) * Fs);
            if (windowLengthSmpl + okno.windowStart > wynik_pomiaru.Length)
            {
                windowLengthSmpl = wynik_pomiaru.Length - okno.windowStart;
            }

            okno.windowLength = windowLengthSmpl;
            okno.type = windowType.Prostokatne;
        }

        public double[] getWindowedSignal()
        {
            return okno.getWindowedSignal(wynik_pomiaru);
        }

        public double[] getWindow()
        {
            double max = wynik_pomiaru.Max();
            double[] window = okno.getWindow(wynik_pomiaru.Length);

            int i = 0;
            Array.ForEach(window, (x) => { window[i++] = x * max; });
            return window;
        }

        public void setWindowStart(double windowStart)
        {
            okno.windowStart = (int)(windowStart * Fs);
        }

        public void setWindowLength(double windowLength)
        {
            okno.windowLength = (int)(windowLength * Fs);
        }

        public double getWindowLength()
        {
            return (double)okno.windowLength / Fs;
        }

        public double getWindowStart()
        {
            return (double)okno.windowStart / Fs;
        }

        public double[] getResultdB()
        {
            return Array.ConvertAll(wynik_pomiaru, smpl => 20*Math.Log10(Math.Abs(smpl)/2e-5));
        }

        public double[] getResult()
        {
            return wynik_pomiaru;
        }

        public double[] getFilteredResult(FilterBank bank, Enum freq)
        {
            if (bank == FilterBank.None)
            {
                return getResult();
            }
            else
            {
                return Butterworth.filterResult(bank, freq, getWindowedSignal(),Fs);
            }  
        }


        public void calculateDefaultParams(bool add=false)
        {
            if (parameters.Count == 0 || add)
            {
                acousticParameters newParamSetOkt = new acousticParameters();
                acousticParameters newParamSetTr = new acousticParameters();

                newParamSetOkt.name = "Oktawy";
                newParamSetOkt.calcParams(getWindowedSignal(), FilterBank.Octave,Fs);
                parameters.Add(newParamSetOkt);

                newParamSetTr.name = "Tercje";
                newParamSetTr.calcParams(getWindowedSignal(), FilterBank.Third_octave, Fs);
                parameters.Add(newParamSetTr);
            }
        }

        public void exportResultAsWave()
        {
            //Get File Path
            string path;
            SaveFileDialog SaveDialog = new SaveFileDialog();
            SaveDialog.Filter = "wav files (*.wav)|*.wav";

            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                path = SaveDialog.FileName;
                WaveFormat format = new WaveFormat(Fs, 24, 1);
                WaveFileWriter writer = new WaveFileWriter(path, format);

                float[] responseFloat = getWindowedSignal().Select(s => (float)s/10).ToArray();
                writer.WriteSamples(responseFloat, 0, responseFloat.Length);
                writer.Close();
            }           
        }

        public static MeasurementResult[] importResultFromWave()
        {

            //Get File Path
            string path;
            OpenFileDialog OpenDialog = new OpenFileDialog();
            OpenDialog.Filter = "wav files (*.wav)|*.wav";

            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                path = OpenDialog.FileName;
                AudioFileReader reader = new AudioFileReader(path);

                MeasurementResult[] MesResults = new MeasurementResult[reader.WaveFormat.Channels];
                List<float>[] responses = new List<float>[reader.WaveFormat.Channels];

                for (int i=0; i < reader.WaveFormat.Channels; i++)
                {
                    MeasurementResult result = new MeasurementResult();
                    result.Fs = reader.WaveFormat.SampleRate;
                    result.nazwa = OpenDialog.SafeFileName + " channel " + i;
                    result.kanal = "imported";
                    result.nazwaPunktu = "imported";
                    result.fstart = 20;
                    result.fstop = result.Fs/2;

                    MesResults[i] = result;
                    responses[i] = new List<float>();


                }
              
                float [] buffer = new float[reader.WaveFormat.Channels];
                while (reader.Read(buffer, 0, reader.WaveFormat.Channels) > 0)
                {
                    for(int i=0; i< reader.WaveFormat.Channels; i++)
                    {
                        responses[i].Add(buffer[i]);
                    }
                }

                for (int i = 0; i < reader.WaveFormat.Channels; i++)
                {
                    MesResults[i].wynik_pomiaru = Array.ConvertAll(responses[i].ToArray(), x => (double)x);
                    MesResults[i].calculateDefWindow();
                }
                return MesResults;
            }else
            {
                return new MeasurementResult[0];
            }
        }
    }
}
