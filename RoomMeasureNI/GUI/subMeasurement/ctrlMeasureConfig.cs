using RoomMeasureNI.Sources.Measurement;
using RoomMeasureNI.Sources.Project;
using System;
using System.Windows.Forms;

namespace RoomMeasureNI.GUI.subMeasurement
{
    public partial class ctrlMeasureConfig : UserControl
    {
        private readonly Project proj = Project.Instance;

        public ctrlMeasureConfig()
        {
            InitializeComponent();
            comboGenerator.DataSource = Enum.GetValues(typeof(generatorMethods));
            comboMeasMethod.DataSource = Enum.GetValues(typeof(MeasurementMethods));
            refresh();
        }

        public void refresh()
        {
            comboMeasLength.SelectedItem = proj.measConfig.measLength.ToString();
            comboMeasMethod.SelectedIndex = (int)proj.measConfig.measMethod;
            comboAverages.SelectedItem = proj.measConfig.averages.ToString();
            comboFmin.SelectedItem = proj.measConfig.fmin.ToString();
            comboBreakLength.SelectedItem = proj.measConfig.breakLength.ToString();
            if (proj.measConfig.fmax == 0) comboFmax.SelectedItem = "Fs/2";
            else comboFmax.SelectedItem = proj.measConfig.fmax.ToString();
            comboGenerator.SelectedIndex = (int)proj.measConfig.genMethod;
            if ((MeasurementMethods)comboMeasMethod.SelectedItem == MeasurementMethods.ImpulseRecording
                || (MeasurementMethods)comboMeasMethod.SelectedItem == MeasurementMethods.Calibrate) groupMethod.Enabled = false;
            else groupMethod.Enabled = true;
        }

        private void comboMeasLength_SelectionChangeCommitted(object sender, EventArgs e)
        {
            proj.measConfig.measLength = double.Parse(comboMeasLength.SelectedItem.ToString());
        }

        private void comboMeasMethod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            proj.measConfig.measMethod = (MeasurementMethods)comboMeasMethod.SelectedIndex;

            if ((MeasurementMethods)comboMeasMethod.SelectedItem == MeasurementMethods.ImpulseRecording || (MeasurementMethods)comboMeasMethod.SelectedItem == MeasurementMethods.Calibrate)
            {
                groupMethod.Enabled = false;
                comboAverages.SelectedIndex = 0;
                proj.measConfig.averages = int.Parse(comboAverages.SelectedItem.ToString());
            }
            else
            {
                groupMethod.Enabled = true;
                comboAverages.SelectedIndex = 4;
                proj.measConfig.averages = int.Parse(comboAverages.SelectedItem.ToString());
            }
        }

        private void comboAverages_SelectionChangeCommitted(object sender, EventArgs e)
        {
            proj.measConfig.averages = int.Parse(comboAverages.SelectedItem.ToString());
        }

        private void comboFmin_SelectionChangeCommitted(object sender, EventArgs e)
        {
            proj.measConfig.fmin = int.Parse(comboFmin.SelectedItem.ToString());
        }

        private void comboFmax_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboFmax.SelectedItem.ToString() == "Fs/2")
                proj.measConfig.fmax = 0;
            else
                proj.measConfig.fmax = int.Parse(comboFmax.SelectedItem.ToString());
        }

        private void comboBreakLength_SelectionChangeCommitted(object sender, EventArgs e)
        {
            proj.measConfig.breakLength = int.Parse(comboBreakLength.SelectedItem.ToString());
        }
    }
}