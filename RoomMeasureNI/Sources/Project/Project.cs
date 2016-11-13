using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace RoomMeasureNI
{
    [Serializable]
    public sealed class Project
    {
        private static Project m_oInstance = null;
        private static readonly object m_oPadLock = new object();

        public ObservableCollection<MeasurementResult> measResults { get; set; }    //Collection of measurement results
        public PunktyPomiarowe punktyPomiarowe {get;set;}                           //Class containing measurement points
        public MeasurementConfig measConfig { get; set; }                           //Measurement configuration
        public ProjectBasicInfo info=new ProjectBasicInfo();                        //Basic project information
        public Image drawingSchema;                                                 //Container for schematic image of the room
        public CardConfig cardConfig { get; set; }                                  //Measurement card configuration

        private string path;

        /// <summary>
        /// Default constructor
        /// </summary>
        private Project()
        {
            punktyPomiarowe = new PunktyPomiarowe();
            measResults = new ObservableCollection<MeasurementResult>();
            cardConfig = new CardConfig();
            measConfig = new MeasurementConfig();
        }
        
        /// <summary>
        /// Singleton
        /// </summary>
        public static Project Instance
        {
            get
            {
                lock (m_oPadLock)
                {
                    if (m_oInstance == null)
                    {
                        m_oInstance = new Project();
                    }
                    return m_oInstance;
                }
            }
        }

        //..........Clas methods.................
        /// <summary>
        /// Shows project save dialog
        /// </summary>
        private void showSaveDialog(){
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "RoomMeasureNI Project File|*.rmp";
            saveFileDialog1.Title = "Save a project file";
            saveFileDialog1.ShowDialog();
            path=saveFileDialog1.FileName;
        }
        
        /// <summary>
        /// Shows load dialog
        /// </summary>
        /// <returns>Returns true if file was opened</returns>
        private bool showLoadDialog()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "RoomMeasureNI Project File|*.rmp";
            openFileDialog1.Title = "Load a project file";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                path = openFileDialog1.FileName;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Assign loaded data to current project
        /// </summary>
        /// <param name="proj"></param>
        private void assign(Project proj)
        {
            this.path = proj.path;
            this.measResults = proj.measResults;
            this.punktyPomiarowe = proj.punktyPomiarowe;
            this.info = proj.info;
            this.drawingSchema = proj.drawingSchema;
            //this.cardConfig = proj.cardConfig; /dont load to prevent issues when different/no card connected;s
            this.measConfig = proj.measConfig;
        }

        /// <summary>
        /// Save project as
        /// </summary>
        public void saveAs()
        {
            showSaveDialog();
            saveFile();
            
        }

        public void save()
        {
            if (path == null)
            {
                showSaveDialog();
            }
            saveFile();
        }

        /// <summary>
        /// Save project file
        /// </summary>
        public void saveFile()
        {
            bool append = false;
            using (Stream stream = File.Open(path, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, this);
            }
        }

       /// <summary>
       /// Load project file
       /// </summary>
        public void loadFile()
        {
            Project proj = Project.Instance;
            bool load=showLoadDialog();
            if (load)
            {
                using (Stream stream = File.Open(path, FileMode.Open))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    proj = (Project)binaryFormatter.Deserialize(stream);
                    assign(proj);
                    return;
                }
            }
        }
    }
}
