using System;

namespace RoomMeasureNI
{
    public enum generatorMethods { SineWave, ExponentialSweep, };

    public static class FunctionGenerator
    {
        private static double Ln(double a)
        {
            return Math.Log(a, Math.E);
        }

        public static double[] generateSin(int length, int Fs, int f)
        {
            double[] sin = new double[length];
            double[] time = usefulFunctions.getTimeVector(length, Fs);

            for (int i = 0; i < length; i++)
            {
                sin[i] = Math.Sin(2*Math.PI*f*time[i]);
            }

            return sin;
        }

        public static double[] generateZeros(int length)
        {
            return new double[length];
        }


        public static double[] generateExpSweep(int length, int Fs, int minFreq, int maxFreq)
        {
            double[] time = usefulFunctions.getTimeVector(length, Fs);
            double[] expSweep = new double[length];

            double maxT=time[length-1];

            for(int i=0; i<length; i++)
            {
                expSweep[i] = Math.Sin(2*Math.PI*minFreq * (maxT / (Ln(maxFreq) - Ln(minFreq))) * (Math.Pow(Math.E, (Ln(maxFreq) - Ln(minFreq)) * (time[i] / maxT))-1));
            }

            return expSweep;
        }

        public static double[] generateByEnum(generatorMethods type, int length, int Fs, int F1, int optionalF2 = 0)
        {
            double[] signal = new double[length];

            switch (type)
            {
                case generatorMethods.SineWave:
                    signal = generateSin(length, Fs, F1);
                    break;
                case generatorMethods.ExponentialSweep:
                    signal = generateExpSweep(length, Fs, F1, optionalF2);
                    break;
            }
            return signal;
        }
    }
}
