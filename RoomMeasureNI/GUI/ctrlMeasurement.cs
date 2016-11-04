using System;
using System.Windows.Forms;

namespace RoomMeasureNI.GUI
{
    public partial class ctrlMeasurement : UserControl
    {
        private MeasurementExecutioner measExec;
        
        public ctrlMeasurement()
        {
            InitializeComponent();
            imgPanel1.setParent(this);
            ctrlPunktyPom.setParent(this);
            measExec = new MeasurementExecutioner();
            timer1.Tick += new System.EventHandler(timer1_Tick);


        }
        public void Odswiez(){
            this.ctrlPunktyPom.Odswiez();
            this.imgPanel1.Refresh();
            this.ctrlCardConfig1.Odswiez();
            this.ctrlMeasureConfig1.refresh();
        }



        private void butStart_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            Form1_Load(measExec.getLength());
            measExec.startMeasurement();
        }

        private void butStop_Click(object sender, EventArgs e)
        {
            measExec.stopMeasurement();
        }

        private void Form1_Load(double time)
        {
            progressBar.Maximum = (int)(time * 10);
            timer1.Interval = 100;//0.1 second
            timer1.Start();        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //do whatever you want
            if (progressBar.Value == progressBar.Maximum)
                timer1.Stop();
            else
                progressBar.Value += 1;
        }
    }
}
