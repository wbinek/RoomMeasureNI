using System;
using System.Windows.Forms;

namespace RoomMeasureNI
{
    public partial class ctrlAcceptResult : Form
    {
        public bool accepted = false;
        public ctrlAcceptResult()
        {
            InitializeComponent();
        }

        internal void setPlot(double[] timevector, double[] result)
        {
            ctrlPlotPanel1.setData(timevector, result);
        }

        private void butAccept_Click(object sender, EventArgs e)
        {
            accepted = true;
            this.Close();
        }

        private void butDrop_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
