using System;
using System.Windows.Forms;
using RoomMeasureNI.Sources.Project;

namespace RoomMeasureNI.GUI
{
    public partial class main_window : Form
    {
        private readonly Project proj = Project.Instance;

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
            ctrlProjekt1.Odswiez();
            ctrlPomiar1.Odswiez();
            ctrlResults1.Odswiez();
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            Odswiez();
        }
    }
}