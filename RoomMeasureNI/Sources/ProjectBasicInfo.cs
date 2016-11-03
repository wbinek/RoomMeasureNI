using System;

namespace RoomMeasureNI
{
    [Serializable]
    public class ProjectBasicInfo
    {
        public string nazwa { get; set; }
        public string zleceniodawca { get; set; }
        public string adres { get; set; }
        public string opis { get; set; }
    }
}
