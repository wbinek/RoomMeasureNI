using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoomMeasureNI.Sources.ButterworthFilterDesign;

namespace RoomMeasureNI.GUI
{
    public partial class ctrlMainPlotPanel : UserControl
    {
        MeasurementResult result; 

        public ctrlMainPlotPanel()
        {
            InitializeComponent();
            comboChart.DataSource = Enum.GetValues(typeof(chartType));
            comboYScale.DataSource = Enum.GetValues(typeof(yAxis));
            comboWindow.DataSource = Enum.GetValues(typeof(windowType));
            comboFilter.DataSource = Enum.GetValues(typeof(FilterBank));
            comboFrequency.Enabled = false;
        }

        public void setResult(MeasurementResult _result)
        {
            result = _result;
        }

        public void setWindowParams()
        {
            numericWindowStart.Value = (decimal)result.getWindowStart();
            numericWindowLength.Value = (decimal)result.getWindowLength();
        }

        ///////////////////////////////////////Tab Ogólne/////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        public void updateChart()
        {
            if (result == null)
                return;

            double[] data;

            if ((chartType)comboChart.SelectedItem == chartType.Czas)
                data = result.getFilteredResult((FilterBank)comboFilter.SelectedItem, (Enum)comboFrequency.SelectedItem);
            else
                data = result.getWindowedSignal();

            switch ((chartType)comboChart.SelectedItem)
            {
                case chartType.Czas:
                    if ((yAxis)comboYScale.SelectedItem == yAxis.Logarytmiczna)
                    {
                        data = usefulFunctions.getResultdB(data);
                        ctrlPlotImpulse.setData(usefulFunctions.getTimeVector(data.Length, result.Fs), data);
                        ctrlPlotImpulse.setYlimits((int) data.Max()-70,(int) data.Max()+5);
                    }
                    else
                        ctrlPlotImpulse.setData(usefulFunctions.getTimeVector(data.Length, result.Fs), data);
                    if ((FilterBank)comboFilter.SelectedItem == FilterBank.None) ctrlPlotImpulse.addSeries(usefulFunctions.getTimeVector(result.wynik_pomiaru.Length, result.Fs), result.getWindow(data.Max()),null,OxyPlot.LineStyle.Dash);
                    break;

                case chartType.Czestotliwosc:
                    if ((yAxis)comboYScale.SelectedItem == yAxis.Logarytmiczna)
                    {
                        data = usefulFunctions.getSpectrumdB(data, result.Fs);
                        ctrlPlotImpulse.setData(usefulFunctions.getFreqVector(data.Length, result.Fs), data);
                        ctrlPlotImpulse.setYlimits((int)data.Max() - 70, (int)data.Max()+5);
                    }
                    else
                        ctrlPlotImpulse.setData(usefulFunctions.getFreqVector(data.Length, result.Fs), usefulFunctions.getSpectrum(data, result.Fs));
                    ctrlPlotImpulse.setXlog(true);
                    ctrlPlotImpulse.setXlimits(20, result.Fs / 2);
                    break;

                case chartType.PowerSpectrum:
                    ctrlPlotImpulse.setData(usefulFunctions.getFreqVector(data.Length, result.Fs), usefulFunctions.getPowerSpectrum(data, result.Fs));
                    ctrlPlotImpulse.setXlog(true);
                    ctrlPlotImpulse.setXlimits(20, result.Fs / 2);
                    break;
            }
        }

        private void onUpdateChart(object sender, EventArgs e)
        {
            updateChart();
        }

        private void numericWindowStart_ValueChanged(object sender, EventArgs e)
        {
            if (result != null)
            {
                result.setWindowStart((double)numericWindowStart.Value);
                updateChart();
            }
        }

        private void numericWindowLength_ValueChanged(object sender, EventArgs e)
        {
            if (result != null)
            {
                result.setWindowLength((double)numericWindowLength.Value);
                updateChart();
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

            updateChart();
        }
    }
}
