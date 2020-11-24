using RoomMeasureNI.Sources.Results;
using System;
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

        private void onRefreshPlots(object sender, EventArgs e)
        {
            ctrlPlotPanel1.Reset();
            if (this.IsHandleCreated) // Fixes error on window creation
                this.BeginInvoke(new MethodInvoker(RefreshPlot), null);
        }

        private void RefreshPlot()
        {
            dataGridViewResultsSets.EndEdit();
            foreach (acousticParams param in checkedListParametersToPlot.CheckedItems)
                foreach (DataGridViewRow row in dataGridViewResultsSets.Rows)
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        var result = (acousticParameters)row.DataBoundItem;

                        ctrlPlotPanel1.addSeries(result.getIndexes(), result.getParameterByName(param.ToString()), param.ToString() + " - " + result.name);
                        ctrlPlotPanel1.setThirdOctaveAxis();
                        ctrlPlotPanel1.showGrid();
                    }
        }
    }
}