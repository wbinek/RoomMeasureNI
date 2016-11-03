using System;
using System.Data;
using System.Windows.Forms;
using RoomMeasureNI.Sources.ButterworthFilterDesign;
using System.Collections;

namespace RoomMeasureNI.GUI
{
    enum chartType { Czas, Czestotliwosc, PowerSpectrum};
    enum yAxis { Liniowa, Logarytmiczna};

    public partial class ctrlResults : UserControl
    {
        private Project proj = Project.Instance;
        private MeasurementResult currentMeasurement;
        public ctrlResults()
        {
            InitializeComponent();
            projektBindingSource.DataSource = proj;
            comboChart.DataSource = Enum.GetValues(typeof(chartType));
            comboYScale.DataSource = Enum.GetValues(typeof(yAxis));
            comboWindow.DataSource = Enum.GetValues(typeof(windowType));
            comboFilter.DataSource = Enum.GetValues(typeof(FilterBank));
            checkedListParametersToPlot.DataSource = Enum.GetValues(typeof(acousticParams));
            comboFrequency.Enabled = false;
        }

        public void Odswiez()
        {
            projektBindingSource.ResetBindings(false);
            //ctrlPlotPanel1.setData();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            currentMeasurement = (MeasurementResult)dataGridViewMesurements.Rows[e.RowIndex].DataBoundItem;
            currentMeasurement.calculateDefaultParams();
            setData(currentMeasurement);
            numericWindowStart.Value = (decimal)currentMeasurement.getWindowStart();
            numericWindowLength.Value = (decimal)currentMeasurement.getWindowLength();
            Odswiez();
        }

        public void setData(MeasurementResult pomiar)
        {
            updateChart(pomiar);
        }

        ///////////////////////////////////////Tab Ogólne/////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pomiar"></param>
        private void updateChart(MeasurementResult pomiar)
        {
            double[] data;

            if ((chartType)comboChart.SelectedItem == chartType.Czas)
                data = pomiar.getFilteredResult((FilterBank)comboFilter.SelectedItem, (Enum)comboFrequency.SelectedItem);
            else
                data = pomiar.getWindowedSignal();

            switch ((chartType) comboChart.SelectedItem)
            {
                case chartType.Czas:
                    if ((yAxis)comboYScale.SelectedItem == yAxis.Logarytmiczna)
                        ctrlPlotImpulse.setData(usefulFunctions.getTimeVector(data.Length, pomiar.Fs), usefulFunctions.getResultdB(data));
                    else
                        ctrlPlotImpulse.setData(usefulFunctions.getTimeVector(data.Length, pomiar.Fs), data);
                    if((FilterBank)comboFilter.SelectedItem==FilterBank.None) ctrlPlotImpulse.addSeries(usefulFunctions.getTimeVector(pomiar.wynik_pomiaru.Length, pomiar.Fs), pomiar.getWindow());
                    break;

                case chartType.Czestotliwosc:
                    if ((yAxis)comboYScale.SelectedItem == yAxis.Logarytmiczna)
                        ctrlPlotImpulse.setData(usefulFunctions.getFreqVector(data.Length, pomiar.Fs), usefulFunctions.getSpectrumdB(data, pomiar.Fs));
                    else
                        ctrlPlotImpulse.setData(usefulFunctions.getFreqVector(data.Length, pomiar.Fs), usefulFunctions.getSpectrum(data, pomiar.Fs));
                    ctrlPlotImpulse.setXlog(true);
                    ctrlPlotImpulse.setXlimits(20, pomiar.Fs / 2);
                    break;

                case chartType.PowerSpectrum:
                    ctrlPlotImpulse.setData(usefulFunctions.getFreqVector(data.Length, pomiar.Fs), usefulFunctions.getPowerSpectrum(data, pomiar.Fs));
                    ctrlPlotImpulse.setXlog(true);
                    ctrlPlotImpulse.setXlimits(20, pomiar.Fs / 2);
                    break;
            }   
        }

        private void comboChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentMeasurement != null)
            {
                updateChart(currentMeasurement);
            }
        }

        private void averageSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewMesurements.SelectedRows.Count; i++)
            {
                //dataGridView1.SelectedRows[i].DataBoundItem;
            }
                
        }

        private void numericWindowStart_ValueChanged(object sender, EventArgs e)
        {
            if (currentMeasurement != null)
            {
                currentMeasurement.setWindowStart((double)numericWindowStart.Value);
                updateChart(currentMeasurement);
            }
        }

        private void numericWindowLength_ValueChanged(object sender, EventArgs e)
        {
            if (currentMeasurement != null)
            {
                currentMeasurement.setWindowLength((double)numericWindowLength.Value);
                updateChart(currentMeasurement);
            }
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((FilterBank)comboFilter.SelectedItem)
            {
                case (FilterBank.None):
                    comboFrequency.Enabled = false;
                    break;
                case (FilterBank.Octave):
                    comboFrequency.Enabled = true;
                    comboFrequency.DataSource = Enum.GetValues(typeof(CenterFreqO));
                    break;
                case (FilterBank.Third_octave):
                    comboFrequency.Enabled = true;
                    comboFrequency.DataSource = Enum.GetValues(typeof(CenterFreqTO));
                    break;
            }
                
            if (currentMeasurement != null)
            {
                updateChart(currentMeasurement);
            }
        }

        ///////////////////////////////////////Tab tabele///////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridParamSetData.DataSource = "null";
            dataGridParamSetData.DataSource = ((acousticParameters)dataGridResults.Rows[e.RowIndex].DataBoundItem).parameters;
            dataGridParamSetData.DefaultCellStyle.Format = "N2";
            //dataGridParamSetData.Sort(dataGridParamSetData.Columns["freqidx"], ListSortDirection.Ascending);
            //dataGridParamSetData.Columns[0].DefaultCellStyle.Format  ="#";
            //dataGridParamSetData.Columns[1].DefaultCellStyle.Format = "N";
        }

        private void dataGridParamSetData_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
            {
                char[] rowSplitter = { '\r', '\n' };
                char[] columnSplitter = { '\t' };
                //get the text from clipboard
                IDataObject dataInClipboard = Clipboard.GetDataObject();
                string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);
                //split it into lines
                string[] rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);
                //get the row and column of selected cell in grid
                int r = dataGridParamSetData.SelectedCells[0].RowIndex;
                int c = dataGridParamSetData.SelectedCells[0].ColumnIndex;
                //add rows into grid to fit clipboard lines
                if (dataGridParamSetData.Rows.Count < (r + rowsInClipboard.Length))
                {
                    ((DataTable)dataGridParamSetData.DataSource).Rows.Add(r + rowsInClipboard.Length - dataGridParamSetData.Rows.Count);
                }
                // loop through the lines, split them into cells and place the values in the corresponding cell.
                for (int iRow = 0; iRow < rowsInClipboard.Length; iRow++)
                {
                    //split row into cell values
                    string[] valuesInRow = rowsInClipboard[iRow].Split(columnSplitter);
                    //cycle through cell values
                    for (int iCol = 0; iCol < valuesInRow.Length; iCol++)
                    {
                        //assign cell value, only if it within columns of the grid
                        if (dataGridParamSetData.ColumnCount - 1 >= c + iCol)
                        {
                            dataGridParamSetData.Rows[r + iRow].Cells[c + iCol].Value = valuesInRow[iCol];
                        }
                    }
                }
            }
        }


        ///////////////////////////////////////Context menu//////////////////////////////////////////////////////////////
        private void calculateDefaultParamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IList rows = dataGridViewMesurements.SelectedCells;

            foreach(var row in rows){
                ((MeasurementResult)(dataGridViewMesurements.Rows[((DataGridViewCell)row).RowIndex].DataBoundItem)).calculateDefaultParams(true);
            }
            Odswiez();
        }

        private void saveImpulseAsWavToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IList rows = dataGridViewMesurements.SelectedCells;

            foreach (var row in rows)
            {
                ((MeasurementResult)(dataGridViewMesurements.Rows[((DataGridViewCell)row).RowIndex].DataBoundItem)).exportResultAsWave();
            }
        }

        private void loadImpulseFromWavToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeasurementResult newMeasurement = new MeasurementResult();
            MeasurementResult[] Results = MeasurementResult.importResultFromWave();

            foreach(MeasurementResult result in Results)
            {
                proj.measResults.Add(result);
            }
            Odswiez();
        }
    }
}
