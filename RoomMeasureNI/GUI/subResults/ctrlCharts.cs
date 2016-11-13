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

        private void checkedListParametersToPlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            ctrlPlotPanel1.Reset();
            foreach (DataGridViewRow row in dataGridViewResultsSets.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    acousticParameters result = (acousticParameters)row.DataBoundItem;

                    ctrlPlotPanel1.addSeries(result.getIndexes(), result.getParameterByName("T20"), "T20");
                    ctrlPlotPanel1.setThirdOctaveAxis();
                    ctrlPlotPanel1.showGrid();
                }
            }
        }
    }
}
