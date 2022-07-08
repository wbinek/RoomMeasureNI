using RoomMeasureNI.Sources.Project;
using System;
using System.Windows.Forms;

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
            refresh();
        }

        private void refresh()
        {
            ctrlProjekt1.Odswiez();
            ctrlPomiar1.Odswiez();
            ctrlResults1.Odswiez();
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string about_text = "RoomMeasureNI wersja 1.0.0 alpha \n\n" +
                                "Aplikacja autorstwa Wojciecha Binka\n" +
                                "Rozpowszechnianie programu bez wiedzy autora zabronione\n" +
                                "©, 2022, Wojciech Binek.";

            MessageBox.Show(about_text);
        }
    }
}