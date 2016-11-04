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
        ctrlResults parent;

        public ctrlMainPlotPanel()
        {
            InitializeComponent();
            comboChart.DataSource = Enum.GetValues(typeof(chartType));
            comboYScale.DataSource = Enum.GetValues(typeof(yAxis));
            comboWindow.DataSource = Enum.GetValues(typeof(windowType));
            comboFilter.DataSource = Enum.GetValues(typeof(FilterBank));
            comboFrequency.Enabled = false;
        }

        public void setParent(ctrlResults _parent)
        {
            parent = _parent;
        }

        public void setWindowParams()
        {
            numericWindowStart.Value = (decimal)parent.getCurrentMeadurement().getWindowStart();
            numericWindowLength.Value = (decimal)parent.getCurrentMeadurement().getWindowLength();
        }

        ///////////////////////////////////////Tab Ogólne/////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pomiar"></param>
        public void updateChart()
        {
            if (parent == null)
                return;

            if (parent.getCurrentMeadurement() == null)
                return;

            MeasurementResult pomiar = parent.getCurrentMeadurement();

            double[] data;

            if ((chartType)comboChart.SelectedItem == chartType.Czas)
                data = pomiar.getFilteredResult((FilterBank)comboFilter.SelectedItem, (Enum)comboFrequency.SelectedItem);
            else
                data = pomiar.getWindowedSignal();

            switch ((chartType)comboChart.SelectedItem)
            {
                case chartType.Czas:
                    if ((yAxis)comboYScale.SelectedItem == yAxis.Logarytmiczna)
                        ctrlPlotImpulse.setData(usefulFunctions.getTimeVector(data.Length, pomiar.Fs), usefulFunctions.getResultdB(data));
                    else
                        ctrlPlotImpulse.setData(usefulFunctions.getTimeVector(data.Length, pomiar.Fs), data);
                    if ((FilterBank)comboFilter.SelectedItem == FilterBank.None) ctrlPlotImpulse.addSeries(usefulFunctions.getTimeVector(pomiar.wynik_pomiaru.Length, pomiar.Fs), pomiar.getWindow());
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

        private void onUpdateChart(object sender, EventArgs e)
        {
            updateChart();
        }

        private void numericWindowStart_ValueChanged(object sender, EventArgs e)
        {
            if (parent.getCurrentMeadurement() != null)
            {
                parent.getCurrentMeadurement().setWindowStart((double)numericWindowStart.Value);
                updateChart();
            }
        }

        private void numericWindowLength_ValueChanged(object sender, EventArgs e)
        {
            if (parent.getCurrentMeadurement() != null)
            {
                parent.getCurrentMeadurement().setWindowLength((double)numericWindowLength.Value);
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
