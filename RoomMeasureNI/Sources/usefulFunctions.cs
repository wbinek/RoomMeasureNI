using System;

using MathNet.Numerics.IntegralTransforms;
using System.Numerics;
using System.Reflection;
using System.ComponentModel;

namespace RoomMeasureNI
{
    public static class usefulFunctions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DescriptionAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                        as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }


        public static double[] getTimeVector(int length, int Fs)
        {
            double[] time = new double[length];

            for (int i = 0; i < length; i++)
            {
                time[i] = i * (1 / (double)Fs);
            }
            return time;
        }

        public static double[] getPowerSpectrum(double[] signal, int Fs)
        {
            double[] ps = new double[signal.Length];

            Complex[] ft = double2Complex(signal);
            Fourier.Forward(ft, FourierOptions.NoScaling);
            double[] realft = Array.ConvertAll(ft, item => Math.Pow(item.Magnitude/signal.Length,2));
            return realft;
        }

        public static double[] getSpectrum(double[] signal, int Fs)
        {
            double[] ps = new double[signal.Length];

            Complex[] ft = double2Complex(signal);
            Fourier.Forward(ft, FourierOptions.NoScaling);
            double[] realft = Array.ConvertAll(ft, item => item.Magnitude / signal.Length);
            return realft;
        }

        public static double[] getSpectrumdB(double[] signal, int Fs)
        {
            double[] ps = new double[signal.Length];

            Complex[] ft = double2Complex(signal);
            Fourier.Forward(ft, FourierOptions.NoScaling);
            double[] realft = Array.ConvertAll(ft, item => item.Magnitude / signal.Length);
            return Array.ConvertAll(realft, smpl => 20 * Math.Log10(smpl / 2e-5));
        }

        public static double[] getFreqVector(int length, int Fs)
        {
            return Fourier.FrequencyScale(length, Fs); ;
        }

        public static Complex[] double2Complex(double[] data)
        {
            return Array.ConvertAll(data, item => (Complex)item);
        }

        public static double[] complexReal2Double(Complex[] data)
        {
            return Array.ConvertAll(data, item => (double) item.Real);
        }

        public static double[] getResultdB(double[] wynik_pomiaru)
        {
            return Array.ConvertAll(wynik_pomiaru, smpl => 20 * Math.Log10(Math.Abs(smpl) / 2e-5));
        }

        /// <summary>
        /// Fits a line to a collection of (x,y) points.
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

            for (int ctr = inclusiveStart; ctr < exclusiveEnd; ctr++)
            {
                double x = xVals[ctr];
                double y = yVals[ctr];
                sumCodeviates += x * y;
                sumOfX += x;
                sumOfY += y;
                sumOfXSq += x * x;
                sumOfYSq += y * y;
            }
            ssX = sumOfXSq - ((sumOfX * sumOfX) / count);
            ssY = sumOfYSq - ((sumOfY * sumOfY) / count);
            double RNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
            double RDenom = (count * sumOfXSq - (sumOfX * sumOfX))
             * (count * sumOfYSq - (sumOfY * sumOfY));
            sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

            double meanX = sumOfX / count;
            double meanY = sumOfY / count;
            double dblR = RNumerator / Math.Sqrt(RDenom);
            rsquared = dblR * dblR;
            yintercept = meanY - ((sCo / ssX) * meanX);
            slope = sCo / ssX;
        }
    }
}
