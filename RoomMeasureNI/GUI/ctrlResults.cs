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
        private Projekt proj = Projekt.Instance;
        private MeasurementResult currentMeasurement;
        public ctrlResults()
        {
            InitializeComponent();
            projektBindingSource.DataSource = proj;
            comboChart.DataSource = Enum.GetValues(typeof(chartType));
            comboYScale.DataSource = Enum.GetValues(typeof(yAxis));
            comboOkno.DataSource = Enum.GetValues(typeof(windowType));
            comboBoxFilter.DataSource = Enum.GetValues(typeof(FilterBank));
            checkedListBox1.DataSource = Enum.GetValues(typeof(acousticParams));
            comboBoxFrequency.Enabled = false;
        }

        public void Odswiez()
        {
            projektBindingSource.ResetBindings(false);
            //ctrlPlotPanel1.setData();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            currentMeasurement = (MeasurementResult)dataGridView1.Rows[e.RowIndex].DataBoundItem;
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
                data = pomiar.getFilteredResult((FilterBank)comboBoxFilter.SelectedItem, (Enum)comboBoxFrequency.SelectedItem);
            else
                data = pomiar.getWindowedSignal();

            switch ((chartType) comboChart.SelectedItem)
            {
                case chartType.Czas:
                    if ((yAxis)comboYScale.SelectedItem == yAxis.Logarytmiczna)
                        ctrlPlotPanel1.setData(usefulFunctions.getTimeVector(data.Length, pomiar.Fs), usefulFunctions.getResultdB(data));
                    else
                        ctrlPlotPanel1.setData(usefulFunctions.getTimeVector(data.Length, pomiar.Fs), data);
                    if((FilterBank)comboBoxFilter.SelectedItem==FilterBank.None) ctrlPlotPanel1.addSeries(usefulFunctions.getTimeVector(pomiar.wynik_pomiaru.Length, pomiar.Fs), pomiar.getWindow());
                    break;

                case chartType.Czestotliwosc:
                    if ((yAxis)comboYScale.SelectedItem == yAxis.Logarytmiczna)
                        ctrlPlotPanel1.setData(usefulFunctions.getFreqVector(data.Length, pomiar.Fs), usefulFunctions.getSpectrumdB(data, pomiar.Fs));
                    else
                        ctrlPlotPanel1.setData(usefulFunctions.getFreqVector(data.Length, pomiar.Fs), usefulFunctions.getSpectrum(data, pomiar.Fs));
                    ctrlPlotPanel1.setXlog(true);
                    ctrlPlotPanel1.setXlimits(20, pomiar.Fs / 2);
                    break;

                case chartType.PowerSpectrum:
                    ctrlPlotPanel1.setData(usefulFunctions.getFreqVector(data.Length, pomiar.Fs), usefulFunctions.getPowerSpectrum(data, pomiar.Fs));
                    ctrlPlotPanel1.setXlog(true);
                    ctrlPlotPanel1.setXlimits(20, pomiar.Fs / 2);
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
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
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
            switch ((FilterBank)comboBoxFilter.SelectedItem)
            {
                case (FilterBank.None):
                    comboBoxFrequency.Enabled = false;
                    break;
                case (FilterBank.Octave):
                    comboBoxFrequency.Enabled = true;
                    comboBoxFrequency.DataSource = Enum.GetValues(typeof(CenterFreqO));
                    break;
                case (FilterBank.Third_octave):
                    comboBoxFrequency.Enabled = true;
                    comboBoxFrequency.DataSource = Enum.GetValues(typeof(CenterFreqTO));
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
            dataGridParamSetData.DataSource = ((acousticParameters)dataGridParamSetName.Rows[e.RowIndex].DataBoundItem).parameters;
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
            IList rows = dataGridView1.SelectedCells;

            foreach(var row in rows){
                ((MeasurementResult)(dataGridView1.Rows[((DataGridViewCell)row).RowIndex].DataBoundItem)).calculateDefaultParams(true);
            }
            Odswiez();
        }

        private void saveImpulseAsWavToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IList rows = dataGridView1.SelectedCells;

            foreach (var row in rows)
            {
                ((MeasurementResult)(dataGridView1.Rows[((DataGridViewCell)row).RowIndex].DataBoundItem)).exportResultAsWave();
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
