using RoomMeasureNI.Sources.Project;
using RoomMeasureNI.Sources.Results;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace RoomMeasureNI.GUI
{
    internal enum chartType
    {
        Czas,
        Czestotliwosc,
        PowerSpectrum
    }

    internal enum yAxis
    {
        Liniowa,
        Logarytmiczna
    }

    public partial class ctrlResults : UserControl
    {
        private readonly Project proj = Project.Instance;
        private MeasurementResult currentMeasurement;

        private int lastClickedMeasurementIdx = 0;

        public ctrlResults()
        {
            InitializeComponent();
            projektBindingSource.DataSource = proj;
        }

        public void Odswiez()
        {
            projektBindingSource.ResetBindings(false);
            measResultsBindingSource.ResetBindings(false);
            ctrlCharts1.refresh();
            ctrlMainPlotPanel1.updateChart();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            currentMeasurement = (MeasurementResult)dataGridViewMesurements.Rows[e.RowIndex].DataBoundItem;
            currentMeasurement.calculateDefaultParams();
            //measResultsBindingSource.DataSource = currentMeasurement;
            ctrlCharts1.setResult(currentMeasurement);
            ctrlMainPlotPanel1.setResult(currentMeasurement);
            ctrlMainPlotPanel1.setWindowParams();

            Odswiez();

            // Run after refresh to prevent overwriting the data by the binding refresh
            if (lastClickedMeasurementIdx <= dataGridResults.RowCount)
            {
                dataGridResults.Rows[dataGridResults.SelectedRows[0].Index].Selected = false;
                dataGridResults.Rows[lastClickedMeasurementIdx].Selected = true;
                dataGridResults.Refresh();
                dataGridParamSetData.DataSource =
                       ((acousticParameters)dataGridResults.Rows[lastClickedMeasurementIdx].DataBoundItem).parameters;
            }
            else
            {
                dataGridParamSetData.DataSource =
                    ((acousticParameters)dataGridResults.Rows[0].DataBoundItem).parameters;

            }

        }

        ///////////////////////////////////////Tab tabele///////////////////////////////////////////////////////////////

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridParamSetData.DataSource = "null";
            dataGridParamSetData.DataSource =
                ((acousticParameters)dataGridResults.Rows[e.RowIndex].DataBoundItem).parameters;
            dataGridParamSetData.DefaultCellStyle.Format = "N2";
            lastClickedMeasurementIdx = e.RowIndex;
            //dataGridParamSetData.Sort(dataGridParamSetData.Columns["freqidx"], ListSortDirection.Ascending);
            //dataGridParamSetData.Columns[0].DefaultCellStyle.Format  ="#";
            //dataGridParamSetData.Columns[1].DefaultCellStyle.Format = "N";
        }

        private void dataGridParamSetData_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.Insert || e.Control && e.KeyCode == Keys.V)
            {
                char[] rowSplitter = { '\r', '\n' };
                char[] columnSplitter = { '\t' };
                //get the text from clipboard
                var dataInClipboard = Clipboard.GetDataObject();
                var stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);
                //split it into lines
                var rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);
                //get the row and column of selected cell in grid
                var r = dataGridParamSetData.SelectedCells[0].RowIndex;
                var c = dataGridParamSetData.SelectedCells[0].ColumnIndex;
                //add rows into grid to fit clipboard lines
                if (dataGridParamSetData.Rows.Count < r + rowsInClipboard.Length)
                    ((DataTable)dataGridParamSetData.DataSource).Rows.Add(r + rowsInClipboard.Length -
                                                                           dataGridParamSetData.Rows.Count);
                // loop through the lines, split them into cells and place the values in the corresponding cell.
                for (var iRow = 0; iRow < rowsInClipboard.Length; iRow++)
                {
                    //split row into cell values
                    var valuesInRow = rowsInClipboard[iRow].Split(columnSplitter);
                    //cycle through cell values
                    for (var iCol = 0; iCol < valuesInRow.Length; iCol++)
                        if (dataGridParamSetData.ColumnCount - 1 >= c + iCol)
                            dataGridParamSetData.Rows[r + iRow].Cells[c + iCol].Value = valuesInRow[iCol];
                }
            }
        }

        ///////////////////////////////////////Context menu//////////////////////////////////////////////////////////////
        private void calculateDefaultParamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IList rows = dataGridViewMesurements.SelectedCells;

            foreach (var row in rows)
                ((MeasurementResult)dataGridViewMesurements.Rows[((DataGridViewCell)row).RowIndex].DataBoundItem)
                    .calculateDefaultParams(true);
            Odswiez();
        }

        private void saveImpulseAsWavToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IList rows = dataGridViewMesurements.SelectedCells;

            foreach (var row in rows)
                ((MeasurementResult)dataGridViewMesurements.Rows[((DataGridViewCell)row).RowIndex].DataBoundItem)
                    .exportResultAsWave();
        }

        private void loadImpulseFromWavToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newMeasurement = new MeasurementResult();
            var Results = MeasurementResult.importResultFromWave();

            foreach (var result in Results)
                proj.measResults.Add(result);
            Odswiez();
        }

        private void averageSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < dataGridViewMesurements.SelectedRows.Count; i++)
            {
                //dataGridView1.SelectedRows[i].DataBoundItem;
            }
            throw new NotImplementedException();
        }

        ////////////////////////////////////// OTHER Methods ////////////////////////////////////////
        public MeasurementResult getCurrentMeasurement()
        {
            return currentMeasurement;
        }

        private void saveImpulseAs44100WavToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IList rows = dataGridViewMesurements.SelectedCells;

            foreach (DataGridViewCell row in rows)
                ((MeasurementResult)dataGridViewMesurements.Rows[row.RowIndex].DataBoundItem)
                    .exportResultAsWave44100();
        }

        private void confirmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IList rows = dataGridViewMesurements.SelectedCells;

            foreach (DataGridViewCell row in rows)
            {
                dataGridViewMesurements.Rows.Remove(row.OwningRow);
            }   
        }

        private void dataGridResults_SelectionChanged(object sender, EventArgs e)
        {
            //dataGridParamSetData.DataSource = "null";
            //if (dataGridResults.SelectedRows == null) return;
            //if (dataGridResults.SelectedRows.Count == 0) return;
            //dataGridParamSetData.DataSource =
            //    ((acousticParameters)dataGridResults.SelectedRows[0].DataBoundItem).parameters;
            //dataGridParamSetData.DefaultCellStyle.Format = "N2";
            //dataGridParamSetData.Sort(dataGridParamSetData.Columns["freqidx"], ListSortDirection.Ascending);
            //dataGridParamSetData.Columns[0].DefaultCellStyle.Format  ="#";
            //dataGridParamSetData.Columns[1].DefaultCellStyle.Format = "N";
            return;
        }

        private void editOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                e.Handled = true;
                dataGridViewMesurements.BeginEdit(true);
            }
        }
    }
}