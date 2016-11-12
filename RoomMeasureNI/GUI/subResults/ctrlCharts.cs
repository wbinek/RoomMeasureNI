using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomMeasureNI.GUI.subResults
{
    public partial class ctrlCharts : UserControl
    {
        public ctrlCharts()
        {
            InitializeComponent();
            checkedListParametersToPlot.DataSource = Enum.GetValues(typeof(acousticParams));
        }

        public void refresh()
        {
            measurementResultBindingSource.ResetBindings(false);
        }

        public void setResult(MeasurementResult currentMeasurement)
        {
            measurementResultBindingSource.DataSource = currentMeasurement;
        }

    }
}
