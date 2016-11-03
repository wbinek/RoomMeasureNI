using System;
using System.Linq;


namespace RoomMeasureNI
{
    public enum windowType { Prostokatne, Tukey}

    [Serializable]
    public class processsingWindow
    {
        public windowType type;
        public int windowStart { get; set; }
        public int windowLength { get; set; } //in samples

        public double[] getWindow(int signalLength)
        {
            switch (type)
            {
                case windowType.Prostokatne:
                    return getRectWindow(signalLength);
                case windowType.Tukey:
                    return getTukeyWindow(signalLength);
                default:
                    return getRectWindowShort();
            }
        }

        private double[] getTukeyWindow(int signalLength)
        {
            throw new NotImplementedException();
        }

        private double[] getTukeyWindowShort()
        {
            throw new NotImplementedException();
        }


        public double[] getWindowShort()
        {
            switch (type)
            {
                case windowType.Prostokatne:
                    return getRectWindowShort();
                case windowType.Tukey:
                    return getTukeyWindowShort();
                default:
                    return getRectWindowShort();
            }
        }

        public double[] getRectWindow(int signalLength)
        {
            double[] rectWindow = new double[signalLength];
            for(int i=0;i<windowLength;i++){
                rectWindow[i + windowStart] = 1;
            }
            return rectWindow;
        }

        public double[] getRectWindowShort()
        {
            double[] rectWindow = new double[windowLength];
            for (int i = 0; i < windowLength; i++)
            {
                rectWindow[i] = 1;
            }
            return rectWindow;
        }

        public double[] getWindowedSignal(double[] signal)
        {
            double[] window = getWindowShort();
            double[] cutSignal = signal.Skip(windowStart).Take(windowLength).ToArray();

            cutSignal.Zip(window, (a, b) => a * b);
            return cutSignal;
        }
    }
}
