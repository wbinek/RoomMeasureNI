using System;

namespace RoomMeasureNI
{
    [Serializable]
    public class MeasurementConfig
    {
        public double measLength { get; set; }
        public measurementMethods measMethod { get; set; }
        public generatorMethods genMethod { get; set; }
        public int fmin { get; set; }
        public int fmax { get; set; }
        public int averages { get; set; }

        public MeasurementConfig()
        {
            setDefault();
        }

        public void setDefault()
        {
            measLength=5;
            measMethod = measurementMethods.Rejestracja_impulsu;
            genMethod = generatorMethods.ExponentialSweep;
            fmin = 20;
            fmax = 0;
            averages = 1;
        }
    }
}
