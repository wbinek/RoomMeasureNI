using System;
using System.Windows.Forms;

namespace RoomMeasureNI
{
    public partial class main_window : Form
    {
        private Projekt proj = Projekt.Instance;
        public main_window()
        {
            InitializeComponent();
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proj.saveAs();
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proj.save();
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proj.loadFile();
            Odswiez();
        }
        private void Odswiez()
        {
            this.ctrlProjekt1.Odswiez();
            this.ctrlPomiar1.Odswiez();
            this.ctrlResults1.Odswiez();
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            Odswiez();
        }
    }
}
