using RoomMeasureNI.Sources.Project;
using System;
using System.Windows.Forms;

namespace RoomMeasureNI.GUI
{
    public partial class ctrlProject : UserControl
    {
        private readonly Project proj = Project.Instance;

        public ctrlProject()
        {
            InitializeComponent();
        }

        //...............Metody........................

        //Update project.info fileds on text changed
        private void textNazwa_TextChanged(object sender, EventArgs e)
        {
            proj.info.projectName = (sender as TextBox).Text;
        }

        private void textZleceniodawca_TextChanged(object sender, EventArgs e)
        {
            proj.info.projectClient = (sender as TextBox).Text;
        }

        private void textAdres_TextChanged(object sender, EventArgs e)
        {
            proj.info.projectAdress = (sender as TextBox).Text;
        }

        private void textOpis_TextChanged(object sender, EventArgs e)
        {
            proj.info.projectDescription = (sender as TextBox).Text;
        }

        //Refresh - called when project changed (ex. loaded)
        public void Odswiez()
        {
            textNazwa.Text = proj.info.projectName;
            textZleceniodawca.Text = proj.info.projectClient;
            textAdres.Text = proj.info.projectAdress;
            textOpis.Text = proj.info.projectDescription;
        }
    }
}