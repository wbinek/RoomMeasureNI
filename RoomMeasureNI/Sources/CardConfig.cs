using NationalInstruments.DAQmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RoomMeasureNI
{
    [Serializable]
    public class ChannelConfig
    {
        public string chName { get; set; }
        public bool chActive { get; set; }
        public double chSens { get; set; }

        public ChannelConfig(string name, bool active, double sens)
        {
            chName = name;
            chActive = active;
            chSens = sens;
        }
    }

    [Serializable]
    public class CardConfig
    {
        public List<ChannelConfig> chConfig { get; set; }

        public int chSmplRate { get; set; }
        public int chSmplToRead { get; set; }
        public double chMaxPress { get; set; }
        public AITerminalConfiguration terminalConfig { get; set; }
        public AIExcitationSource excitationSource { get; set; }
        public double chIEPEVal { get; set; }

        public List<string> aoChannelAvalible { get; set; }
        public string aoChannelSellected { get; set; }
        public decimal aoMax { get; set; }
        public decimal aoMin { get; set; }

        public double sigLength { get; set; }

        public CardConfig()
        {
            chConfig=new List<ChannelConfig>();
            aoChannelAvalible = new List<string>();

            string[] chName = new string[0];

            try
            {
                chName = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External);
                aoChannelAvalible = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AO, PhysicalChannelAccess.External).ToList();
            }
            catch (DaqException)
            {
                MessageBox.Show("DAQmx driver not running");
            }

            foreach (string input in chName)
            {
                ChannelConfig channel = new ChannelConfig(input, false, 50);
                chConfig.Add(channel);
            }

            try
            {
                chConfig[0].chActive = true;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No input channel detected");
            }

            try
            {
                aoChannelSellected = aoChannelAvalible[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No output channel detected");
            }
                
           loadDefault();
        }

        public void loadDefault()
        {
            chSmplRate = 51200;
            chSmplToRead =5120;
            chMaxPress = 120;
            terminalConfig = AITerminalConfiguration.Pseudodifferential;
            excitationSource = AIExcitationSource.Internal;
            chIEPEVal = 0.002;
            aoMax = 1;
            aoMin = -1;
        }

        public string[] getActiveChannels()
        {
            List<string> result = new List<string>();
            foreach (ChannelConfig channel in chConfig)
            {
                if (channel.chActive)
                {
                    result.Add(channel.chName);
                }
            }
            return result.ToArray();
        }

        public int getNumActiveChannels()
        {
            int numActive = 0;
            foreach (ChannelConfig channel in chConfig)
            {
                if (channel.chActive)
                {
                    numActive++;
                }
            }
            return numActive;
        }
    }
}
