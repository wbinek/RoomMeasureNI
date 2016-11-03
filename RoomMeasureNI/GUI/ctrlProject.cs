using System;
using System.Windows.Forms;

namespace RoomMeasureNI.GUI
{
    public partial class ctrlProject : UserControl
    {
        private Project proj = Project.Instance;
        public ctrlProject()
        {
            InitializeComponent();
        }


        //...............Metody........................

        //Update project.info fileds on text changed
        private void textNazwa_TextChanged(object sender, EventArgs e)
        {
            proj.info.nazwa = (sender as TextBox).Text;
        }

        private void textZleceniodawca_TextChanged(object sender, EventArgs e)
        {
            proj.info.zleceniodawca = (sender as TextBox).Text;
        }

        private void textAdres_TextChanged(object sender, EventArgs e)
        {
            proj.info.adres = (sender as TextBox).Text;
        }

        private void textOpis_TextChanged(object sender, EventArgs e)
        {
            proj.info.opis = (sender as TextBox).Text;
        }

        //Refresh - called when project changed (ex. loaded)
        public void Odswiez()
        {
            this.textNazwa.Text = proj.info.nazwa;
            this.textZleceniodawca.Text = proj.info.zleceniodawca;
            this.textAdres.Text = proj.info.adres;
            this.textOpis.Text = proj.info.opis;
        }
    }
}
