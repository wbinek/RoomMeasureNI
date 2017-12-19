using System;

namespace RoomMeasureNI.Sources.Project
{
    [Serializable]
    public class ProjectBasicInfo
    {
        public string projectName { get; set; }
        public string projectClient { get; set; }
        public string projectAdress { get; set; }
        public string projectDescription { get; set; }
    }
}