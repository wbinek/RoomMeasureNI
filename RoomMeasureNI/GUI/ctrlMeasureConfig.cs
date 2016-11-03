using System;
using System.Windows.Forms;

namespace RoomMeasureNI.GUI
{
    public partial class ctrlMeasureConfig : UserControl
    {
        Projekt proj = Projekt.Instance;

        public ctrlMeasureConfig()
        {
            InitializeComponent();
            comboGenerator.DataSource = Enum.GetValues(typeof(generatorMethods));
            refresh();
        }

        public void refresh()
        {
            comboMeasLength.SelectedItem = proj.measConfig.measLength.ToString();
            comboMeasMethod.SelectedIndex = (int)proj.measConfig.measMethod;
            comboAverages.SelectedItem = proj.measConfig.averages.ToString();
            comboFmin.SelectedItem = proj.measConfig.fmin.ToString();
            if (proj.measConfig.fmax == 0) { comboFmax.SelectedItem = "Fs/2"; } else { comboFmax.SelectedItem = proj.measConfig.fmax.ToString(); }
            comboGenerator.SelectedIndex = (int)proj.measConfig.genMethod;
            if (comboMeasMethod.SelectedIndex == 0) { groupMethod.Enabled = false; } else { groupMethod.Enabled = true; }
        }

        private void comboMeasLength_SelectionChangeCommitted(object sender, EventArgs e)
        {
            proj.measConfig.measLength = double.Parse(comboMeasLength.SelectedItem.ToString());
        }

        private void comboMeasMethod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            proj.measConfig.measMethod = (measurementMethods)comboMeasMethod.SelectedIndex;

            if (comboMeasMethod.SelectedIndex == 0)
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
            {
                proj.measConfig.fmax = 0;
            }
            else
            {
                proj.measConfig.fmax = int.Parse(comboFmax.SelectedItem.ToString());
            }
        }

    }
}
