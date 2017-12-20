using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using MathNet.Numerics.IntegralTransforms;
using RoomMeasureNI.GUI.subMeasurement;
using RoomMeasureNI.Sources.Dependencies;
using RoomMeasureNI.Sources.Results;

namespace RoomMeasureNI.Sources.Measurement
{
    public class MeasurementExecutioner
    {
        private readonly Project.Project proj = Project.Project.Instance;
        private readonly CardConfig cardConfig;
        private readonly MeasurementConfig measConfig;
        private readonly aiaoDriver recorder;
        private readonly object thisLock = new object();
        private double[] output = new double[0];

        public MeasurementExecutioner()
        {
            recorder = new aiaoDriver();
            recorder.MeasurementFinished += OnMeasurementFinished;
            cardConfig = proj.cardConfig;
            measConfig = proj.measConfig;
        }

        private void OnMeasurementFinished(object sender, EventArgs args)
        {
            List<double[]> dane = recorder.getDataAsList();
            List<string> channelNames = recorder.getChannelNames();

            recorder.Dispose();

            switch (measConfig.measMethod)
            {
                case MeasurementMethods.SweepSine:
                    postprocess(dane, channelNames);
                    break;
                case MeasurementMethods.ImpulseRecording:
                    showAcceptanceWindow(dane, channelNames);
                    break;
            }
        }

        public void startMeasurement()
        {
            preprocess();
            generateOutput();
            recorder.startMeasurement(output, output.Length, cardConfig);
        }

        public void stopMeasurement()
        {
            recorder.stopMeasurement(true);
        }

        public void generateOutput()
        {
            switch (measConfig.measMethod)
            {
                case MeasurementMethods.Calibrate:
                    output = FunctionGenerator.generateByEnum(measConfig.genMethod,
                                            (int)(cardConfig.chSmplRate * measConfig.measLength), cardConfig.chSmplRate,
                                            measConfig.fmin, measConfig.fmax, (int)measConfig.breakLength * cardConfig.chSmplRate, measConfig.averages + 1);
                    break;
                case MeasurementMethods.SweepSine:
                    output = FunctionGenerator.generateByEnum(measConfig.genMethod,
                        (int)(cardConfig.chSmplRate * measConfig.measLength), cardConfig.chSmplRate,
                        measConfig.fmin, measConfig.fmax, (int)measConfig.breakLength * cardConfig.chSmplRate, measConfig.averages + 1);
                    break;
                case MeasurementMethods.ImpulseRecording:
                    output = FunctionGenerator.generateByEnum(generatorMethods.Silence,
                        (int)(cardConfig.chSmplRate * measConfig.measLength), cardConfig.chSmplRate,
                        measConfig.fmin, measConfig.fmax, (int)measConfig.breakLength * cardConfig.chSmplRate, measConfig.averages + 1);
                    break;
            }

            var i = 0;
            Array.ForEach(output, x => { output[i++] = x * (double)cardConfig.aoMax; });
        }

        private void postprocess(List<double[]> dane, List<string> channelNames)
        {
            List<double[]> impulseResponses = new List<double[]>();
            foreach (double[] response in dane) {
                impulseResponses.Add(calculateImpulseResp(response));
            }

            showAcceptanceWindow(impulseResponses, channelNames);
        }

        private void showAcceptanceWindow(List<double[]> impulseResponses, List<string> channelNames)
        {
            for(int i=0;i<impulseResponses.Count();i++)
            {
                double[] result = impulseResponses[i];
                string channelName = channelNames[i];

                var length = result.Count();
                var Fs = proj.cardConfig.chSmplRate;

                var timevector = usefulFunctions.getTimeVector(length, Fs);

                var okno = new ctrlAcceptResult();
                okno.setPlot(timevector, result);
                okno.ShowDialog();

                if (okno.accepted)
                {
                    var pomiar = new MeasurementResult();
                    pomiar.wynik_pomiaru = result;
                    pomiar.godzina_pomiaru = DateTime.Now;
                    pomiar.nazwaPunktu = proj.punktyPomiarowe.getNameFromChannel(channelName);
                    pomiar.kanal = channelName;
                    pomiar.Fs = Fs;
                    pomiar.metoda = measConfig.measMethod;
                    pomiar.nazwa = pomiar.nazwaPunktu + " " + pomiar.godzina_pomiaru.ToShortDateString() + " " +
                                   pomiar.godzina_pomiaru.ToShortTimeString();
                    pomiar.fstart = proj.measConfig.fmin;
                    pomiar.fstop = proj.measConfig.fmax;
                    pomiar.calculateDefWindow();

                    proj.measResults.Add(pomiar);
                }
            }
        }

        private double[] calculateImpulseResp(double[] inputData)
        {
            // Initialize variables
            int length = (int)(cardConfig.chSmplRate * (measConfig.breakLength/*));//*/ + measConfig.measLength));
            double[] response = new double[length];

            //Calculate impulse repsponses
            if (measConfig.measMethod == MeasurementMethods.SweepSine)
            {
                mtCalculateResponse(measConfig.averages, inputData, response, measConfig.processMethod);
            }

            //Return response
            return response;
        }

        private void preprocess()
        {
            if (measConfig.fmax == 0) measConfig.fmax = cardConfig.chSmplRate / 2;
        }

        internal double getLength()
        {
            return (proj.measConfig.measLength + measConfig.breakLength) * proj.measConfig.averages;
        }

        protected void mtCalculateResponse(int averages, double[] input, double[] target, PostProcessMethods processing)
        {
            /// Use for testing
            //input = output;

            //if (processing == PostProcessMethods.FilterInput)
            //{
            //    //Filter input signal
            //    input = Butterworth.filterResult(measConfig.fmax, measConfig.fmin, input, cardConfig.chSmplRate, 12);
            //}

            // Impulse response calculation using linear convolution
            int length = (int)(cardConfig.chSmplRate * (measConfig.breakLength/*));//*/ + measConfig.measLength));
            double[] invsweep = FunctionGenerator.generateReverseSweep((int)(cardConfig.chSmplRate * measConfig.measLength), cardConfig.chSmplRate, measConfig.fmin, measConfig.fmax, (double)cardConfig.aoMax);
            double[] result = Tools.fastConvolution(input, invsweep);

            var responseList = result.Split(length);

            foreach (var oneMeasurement in responseList.Skip(1).Take(responseList.Count() - 2))
            {
                double[] data = oneMeasurement.ToArray();
                lock (thisLock)
                {
                    for (var i = 0; i < data.Length; i++)
                        target[i] += data[i] / averages;
                }
            }
        }
    }
}