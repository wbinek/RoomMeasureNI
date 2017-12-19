﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using MathNet.Numerics.IntegralTransforms;

namespace RoomMeasureNI.Sources.Dependencies
{
    public static class usefulFunctions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attribute
                = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                    as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }


        public static double[] getTimeVector(int length, int Fs)
        {
            var time = new double[length];

            for (var i = 0; i < length; i++)
                time[i] = i * (1 / (double) Fs);
            return time;
        }

        public static double[] getPowerSpectrum(double[] signal, int Fs)
        {
            var ps = new double[signal.Length];

            var ft = double2Complex(signal);
            Fourier.Forward(ft, FourierOptions.NoScaling);
            var realft = Array.ConvertAll(ft, item => Math.Pow(item.Magnitude / signal.Length, 2));
            return realft;
        }

        public static double[] getSpectrum(double[] signal, int Fs)
        {
            var ps = new double[signal.Length];

            var ft = double2Complex(signal);
            Fourier.Forward(ft, FourierOptions.NoScaling);
            var realft = Array.ConvertAll(ft, item => item.Magnitude / signal.Length);
            return realft;
        }

        public static double[] getSpectrumdB(double[] signal, int Fs)
        {
            var ps = new double[signal.Length];

            var ft = double2Complex(signal);
            Fourier.Forward(ft, FourierOptions.NoScaling);
            var realft = Array.ConvertAll(ft, item => item.Magnitude / signal.Length);
            return Array.ConvertAll(realft, smpl => 20 * Math.Log10(smpl / 2e-5));
        }

        public static double[] getFreqVector(int length, int Fs)
        {
            return Fourier.FrequencyScale(length, Fs);
            ;
        }

        public static Complex[] double2Complex(double[] data)
        {
            return Array.ConvertAll(data, item => (Complex) item);
        }

        public static double[] complexReal2Double(Complex[] data)
        {
            return Array.ConvertAll(data, item => item.Real);
        }

        public static double[] getResultdB(double[] wynik_pomiaru)
        {
            return Array.ConvertAll(wynik_pomiaru, smpl => 20 * Math.Log10(Math.Abs(smpl) / 2e-5));
        }

        public static Complex[] MatlabHilbert(double[] xr)
        {
            var x = (from sample in xr select new Complex(sample, 0)).ToArray();
            Fourier.BluesteinForward(x, FourierOptions.Default);
            var h = new double[x.Length];
            var fftLengthIsOdd = (x.Length | 1) == 1;
            if (fftLengthIsOdd)
            {
                h[0] = 1;
                for (var i = 1; i < xr.Length / 2; i++) h[i] = 2;
            }
            else
            {
                h[0] = 1;
                h[xr.Length / 2] = 1;
                for (var i = 1; i < xr.Length / 2; i++) h[i] = 2;
            }
            for (var i = 0; i < x.Length; i++) x[i] *= h[i];
            Fourier.BluesteinInverse(x, FourierOptions.Default);
            return x;
        }

        public static double[] calculateEnvelopeFunction(double[] data)
        {
            var AnaliticSignal = MatlabHilbert(data);
            var envelope = Array.ConvertAll(AnaliticSignal, x => x.Magnitude);
            return envelope;
        }

        /// <summary>
        ///     Fits a line to a collection of (x,y) points.
        /// </summary>
        /// <param name="xVals">The x-axis values.</param>
        /// <param name="yVals">The y-axis values.</param>
        /// <param name="inclusiveStart">The inclusive inclusiveStart index.</param>
        /// <param name="exclusiveEnd">The exclusive exclusiveEnd index.</param>
        /// <param name="rsquared">The r^2 value of the line.</param>
        /// <param name="yintercept">The y-intercept value of the line (i.e. y = ax + b, yintercept is b).</param>
        /// <param name="slope">The slop of the line (i.e. y = ax + b, slope is a).</param>
        public static void LinearRegression(double[] xVals, double[] yVals,
            int inclusiveStart, int exclusiveEnd,
            out double rsquared, out double yintercept,
            out double slope)
        {
            //Debug.Assert(xVals.Length == yVals.Length);
            double sumOfX = 0;
            double sumOfY = 0;
            double sumOfXSq = 0;
            double sumOfYSq = 0;
            double ssX = 0;
            double ssY = 0;
            double sumCodeviates = 0;
            double sCo = 0;
            double count = exclusiveEnd - inclusiveStart;

            for (var ctr = inclusiveStart; ctr < exclusiveEnd; ctr++)
            {
                var x = xVals[ctr];
                var y = yVals[ctr];
                sumCodeviates += x * y;
                sumOfX += x;
                sumOfY += y;
                sumOfXSq += x * x;
                sumOfYSq += y * y;
            }
            ssX = sumOfXSq - sumOfX * sumOfX / count;
            ssY = sumOfYSq - sumOfY * sumOfY / count;
            var RNumerator = count * sumCodeviates - sumOfX * sumOfY;
            var RDenom = (count * sumOfXSq - sumOfX * sumOfX)
                         * (count * sumOfYSq - sumOfY * sumOfY);
            sCo = sumCodeviates - sumOfX * sumOfY / count;

            var meanX = sumOfX / count;
            var meanY = sumOfY / count;
            var dblR = RNumerator / Math.Sqrt(RDenom);
            rsquared = dblR * dblR;
            yintercept = meanY - sCo / ssX * meanX;
            slope = sCo / ssX;
        }
    }
}