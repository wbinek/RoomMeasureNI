using RoomMeasureNI.Sources.Results;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace RoomMeasureNI.GUI.subResults
{
    public partial class ctrlCharts : UserControl
    {
        private List<int> lastSelectedResults;

        public ctrlCharts()
        {
            InitializeComponent();
            lastSelectedResults = new List<int>();
            checkedListParametersToPlot.DataSource = Enum.GetValues(typeof(AcousticParams)); //throws exception, dont know why
        }

        public void refresh()
        {
            //measurementResultBindingSource.ResetBindings(false);
            RefreshPlot();
        }

        //public List<int> getSelectedMeasurement()
        //{
        //  return dataGridViewResultsSets.SelectedRows;
        //}

        public void setResult(MeasurementResult currentMeasurement)
        {
            ClearPlot();
            measurementResultBindingSource.DataSource = currentMeasurement;

            // Restore last selection state
            if (dataGridViewResultsSets.RowCount >= lastSelectedResults.Count())
            {
                foreach (var selRow in lastSelectedResults)
                    dataGridViewResultsSets.Rows[selRow].Cells[0].Value = true;
            }
            else
            {
                dataGridViewResultsSets.Rows[0].Cells[0].Value = true;
                lastSelectedResults.Append(0);
            }
        }

        private void onRefreshPlots(object sender, EventArgs e)
        {
            ctrlPlotPanel1.Reset();
            dataGridViewResultsSets.EndEdit();
            lastSelectedResults = (from DataGridViewRow row in dataGridViewResultsSets.Rows where Convert.ToBoolean(row.Cells[0].Value) select row.Index).ToList();
            if (this.IsHandleCreated) // Fixes error on window creation
                this.BeginInvoke(new MethodInvoker(RefreshPlot), null);
            //this.RefreshPlot();
        }

        private void RefreshPlot()
        {
            foreach (AcousticParams param in checkedListParametersToPlot.CheckedItems)
                foreach (DataGridViewRow row in dataGridViewResultsSets.Rows)
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        var result = (acousticParameters)row.DataBoundItem;

                        ctrlPlotPanel1.addSeries(result.getIndexes(), result.getParameterByName(param.ToString()), param.ToString() + " - " + result.name);
                        ctrlPlotPanel1.setThirdOctaveAxis();
                        ctrlPlotPanel1.showGrid();
                    }
        }

        private void ClearPlot()
        {
            ctrlPlotPanel1.Reset();
        }
    }
}