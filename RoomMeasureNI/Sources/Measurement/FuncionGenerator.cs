﻿using System;
using System.Linq;

namespace RoomMeasureNI.Sources.Measurement
{
    public enum generatorMethods
    {
        SineWave,
        ExponentialSweep,
        Silence,
    }

    public static class FunctionGenerator
    {
        private static double Ln(double a)
        {
            return Math.Log(a, Math.E);
        }

        public static double[] generateSin(int length, int Fs, int f)
        {
            var sin = new double[length];
            var time = Tools.getTimeVector(length, Fs);

            for (var i = 0; i < length; i++)
                sin[i] = Math.Sin(2 * Math.PI * f * time[i]);

            return sin;
        }

        public static double[] generateSilence(int length)
        {
            double[] silence = new double[length];
            return silence;
        }

        public static double[] generateZeros(int length)
        {
            return new double[length];
        }


        public static double[] generateExpSweep(int length, int Fs, int minFreq, int maxFreq)
        {
            var time = Tools.getTimeVector(length, Fs);
            var expSweep = new double[length];

            var maxT = time[length - 1];

            for (var i = 0; i < length; i++)
                expSweep[i] =
                    Math.Sin(2 * Math.PI * minFreq * (maxT / (Ln(maxFreq) - Ln(minFreq))) *
                             (Math.Pow(Math.E, (Ln(maxFreq) - Ln(minFreq)) * (time[i] / maxT)) - 1));

            return expSweep;
        }

        public static double[] generateReverseSweep(int length, int Fs, int minFreq, int maxFreq, double outputScaling = 1)
        {
            double[] sweep = generateExpSweep(length, Fs, minFreq, maxFreq);
            var time = Tools.getTimeVector(length, Fs);
            var maxT = time[time.Count() - 1];
            double L = maxT / Math.Log10(2 * Math.PI * (maxFreq / minFreq));

            double[] invSweep = sweep.Reverse().Zip(time, (x, t) => x * Math.Exp(-t / L)).ToArray();

            //Energy calculation part for the filter to be energy conserving - migh be wrong!!!
            double SqEN = Tools.getSignalEnergy(invSweep) * 2 * outputScaling;
            return Array.ConvertAll(invSweep, x => (1d / (SqEN)) * x);
        }

        public static double[] repeatSignal(double[] signal, int breakLength, int repetitions)
        {
            int lengthSequence = (signal.Length + breakLength);
            double[] silence = new double[breakLength];
            double[] output = new double[lengthSequence * repetitions + (int)(0.2 * signal.Length)];
            for (int i = 0; i < repetitions; i++)
            {
                signal.CopyTo(output, i * lengthSequence);
                silence.CopyTo(output, (i * lengthSequence) + signal.Length);
            }

            signal.Take((int)(0.2 * signal.Length)).ToArray().CopyTo(output, repetitions * lengthSequence);

            return output;
        }

        public static double[] generateByEnum(generatorMethods type, int length, int Fs, int F1, int optionalF2 = 0, int breakLength = 0, int repetitions = 1)
        {
            var signal = new double[length];

            switch (type)
            {
                case generatorMethods.SineWave:
                    signal = generateSin(length, Fs, F1);
                    break;
                case generatorMethods.ExponentialSweep:
                    signal = generateExpSweep(length, Fs, F1, optionalF2);
                    break;
                case generatorMethods.Silence:
                    signal = generateSilence(length);
                    break;
            }
            return repeatSignal(signal, breakLength, repetitions);
        }
    }
}
