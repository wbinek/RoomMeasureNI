using System;
using System.Windows.Forms;

namespace RoomMeasureNI.GUI.subMeasurement
{
    public partial class ctrlAcceptResult : Form
    {
        public bool accepted;

        public ctrlAcceptResult()
        {
            InitializeComponent();
        }

        internal void setPlot(double[] timevector, double[] result)
        {
            ctrlPlotPanel1.setData(timevector, result);
        }

        internal void setLeq(double SPL)
        {
            textBox1.Text = SPL.ToString("0.#");
        }

        internal void setSEL(double SPL)
        {
            textBox4.Text = SPL.ToString("0.#");
        }

        internal void setIntegratedSPL(double SPL)
        {
            textBox3.Text = SPL.ToString("0.#");
        }

        internal void setMaxSPL(double MaxSPL)
        {
            textBox2.Text = MaxSPL.ToString("0.#"); ;
        }

        private void butAccept_Click(object sender, EventArgs e)
        {
            accepted = true;
            Close();
        }

        private void butDrop_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}