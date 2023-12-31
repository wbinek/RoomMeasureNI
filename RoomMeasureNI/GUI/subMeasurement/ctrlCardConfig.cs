﻿using NationalInstruments.DAQmx;
using RoomMeasureNI.Sources.Project;
using System;
using System.Windows.Forms;

namespace RoomMeasureNI.GUI.subMeasurement
{
    public partial class ctrlCardConfig : UserControl
    {
        private readonly Project proj = Project.Instance;

        public ctrlCardConfig()
        {
            InitializeComponent();
            projektBindingSource.DataSource = proj; //wiąże tabelę z plikiem projektu

            inputTerminalComboBox.DataSource = Enum.GetValues(typeof(AITerminalConfiguration));
            excitationComboBox.DataSource = Enum.GetValues(typeof(AIExcitationSource));

            Odswiez();
        }

        public void Odswiez()
        {
            projektBindingSource.ResetBindings(false);
            channelConfigBindingSource.ResetBindings(false);

            comboTimingRate.SelectedItem = proj.cardConfig.chSmplRate.ToString();
            comboSamplesToRead.SelectedItem = proj.cardConfig.chSmplToRead.ToString();
            maximumPressureNumeric.Value = (decimal)proj.cardConfig.chMaxPress;
            currentNumeric.Value = (decimal)proj.cardConfig.chIEPEVal;
            inputTerminalComboBox.SelectedItem = proj.cardConfig.terminalConfig;
            excitationComboBox.SelectedItem = proj.cardConfig.excitationSource;
            outputChannelComboBox.SelectedItem = proj.cardConfig.aoChannelSelected;
            outputMaxValNumeric.Value = proj.cardConfig.aoMax;
            outputMinValNumeric.Value = proj.cardConfig.aoMin;
        }

        //.........................EVENT HANDLERS................................................
        private void comboTimingRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            proj.cardConfig.chSmplRate = int.Parse(comboTimingRate.SelectedItem.ToString());
        }

        private void comboSamplesToRead_SelectedIndexChanged(object sender, EventArgs e)
        {
            proj.cardConfig.chSmplToRead = int.Parse(comboSamplesToRead.SelectedItem.ToString());
        }

        private void maximumPressureNumeric_ValueChanged(object sender, EventArgs e)
        {
            proj.cardConfig.chMaxPress = (double)maximumPressureNumeric.Value;
        }

        private void inputTerminalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            proj.cardConfig.terminalConfig = (AITerminalConfiguration)inputTerminalComboBox.SelectedItem;
        }

        private void excitationComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            proj.cardConfig.excitationSource = (AIExcitationSource)excitationComboBox.SelectedItem;
        }

        private void currentNumeric_ValueChanged(object sender, EventArgs e)
        {
            proj.cardConfig.chIEPEVal = (double)currentNumeric.Value;
        }

        private void outputChannelComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            proj.cardConfig.aoChannelSelected = outputChannelComboBox.SelectedItem.ToString();
        }

        private void outputMaxValNumeric_ValueChanged(object sender, EventArgs e)
        {
            proj.cardConfig.aoMax = outputMaxValNumeric.Value;
        }

        private void outputMinValNumeric_ValueChanged(object sender, EventArgs e)
        {
            proj.cardConfig.aoMin = outputMinValNumeric.Value;
        }
    }
}