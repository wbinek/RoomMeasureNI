using System;
using System.Collections.Generic;

namespace RoomMeasureNI
{
    [Serializable]
    public class MeasurementPoint
    {
        private string _nazwa;
        private double _X;
        private double _Y;
        private string _kanal;
        private bool _aktywny;

        public string Nazwa { get { return _nazwa; } set { _nazwa = value; } }
        public double X { get { return _X; } set { _X = value; } }
        public double Y { get { return _Y; } set { _Y = value; } }
        public string Kanal { get { return _kanal; } set { _kanal = value; } }
        public bool Aktywny { get { return _aktywny; } set { _aktywny = value; } }
    }

    [Serializable]
    public class PunktyPomiarowe
    {
        public List<MeasurementPoint> listaPunktow {get; set;}

        public PunktyPomiarowe()
        {
            listaPunktow = new List<MeasurementPoint>();
        }

        public int getNumActive()
        {
            int count = 0;
            foreach (MeasurementPoint punkt in listaPunktow)
            {
                if (punkt.Aktywny)
                    count++;
            }
            return count;
        }

        public string getNameFromChannel(string channel)
        {
            foreach (MeasurementPoint punkt in listaPunktow)
            {
                if (punkt.Aktywny && punkt.Kanal == channel)
                    return punkt.Nazwa;
            }
            return "not found";
        }

        public void disableIfChannelActive(int changed)
        {
            for (int i=0;i<listaPunktow.Count;i++)
            {
                if (listaPunktow[i].Aktywny && listaPunktow[i].Kanal == listaPunktow[changed].Kanal && i != changed)
                    listaPunktow[i].Aktywny = false;
            }
        }
    }
}
