using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RoomMeasureNI
{
    [Serializable]
    public sealed class Projekt
    {
        private static Projekt m_oInstance = null;
        private static readonly object m_oPadLock = new object();

        public ObservableCollection<MeasurementResult> measResults { get; set; }
        public PunktyPomiarowe punktyPomiarowe {get;set;}
        public MeasurementConfig measConfig { get; set; }
        public ProjectBasicInfo info=new ProjectBasicInfo();
        public Image rysPlan;
        public CardConfig cardConfig { get; set; }

        private string path;

        //Konstruktor domyślny
        private Projekt()
        {
            punktyPomiarowe = new PunktyPomiarowe();
            measResults = new ObservableCollection<MeasurementResult>();
            cardConfig = new CardConfig();
            measConfig = new MeasurementConfig();
        }
        
        //Signleton
        public static Projekt Instance
        {
            get
            {
                lock (m_oPadLock)
                {
                    if (m_oInstance == null)
                    {
                        m_oInstance = new Projekt();
                    }
                    return m_oInstance;
                }
            }
        }

        //..........Metody klasy.................
        //Pokaż okno zapsiu
        private void showSaveDialog(){
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "RoomMeasureNI Project File|*.rmp";
            saveFileDialog1.Title = "Save a project file";
            saveFileDialog1.ShowDialog();
            path=saveFileDialog1.FileName;
        }
        
        //Pokaż okno wczytywania
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

        //Przypisz wczytane dane do projektu
        private void assign(Projekt proj)
        {
            this.path = proj.path;
            this.measResults = proj.measResults;
            this.punktyPomiarowe = proj.punktyPomiarowe;
            this.info = proj.info;
            this.rysPlan = proj.rysPlan;
            //this.cardConfig = proj.cardConfig; /dont load to prevent issues when different/no card connected;s
            this.measConfig = proj.measConfig;
        }

        //Zapisz jako
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

        //Zapisz plik
        public void saveFile()
        {
            bool append = false;
            using (Stream stream = File.Open(path, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, this);
            }
        }

        //Wczytaj plik projektu
        public void loadFile()
        {
            Projekt proj = Projekt.Instance;
            bool load=showLoadDialog();
            if (load)
            {
                using (Stream stream = File.Open(path, FileMode.Open))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    proj = (Projekt)binaryFormatter.Deserialize(stream);
                    assign(proj);
                    return;
                }
            }
        }
    }
}
