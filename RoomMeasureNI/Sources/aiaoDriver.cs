using NationalInstruments;
using NationalInstruments.DAQmx;
using System;
using System.Data;
//using System.Threading.Tasks;
using System.Windows.Forms;


namespace RoomMeasureNI
{
    class aiaoDriver
    {
        private Task inputTask;
        private Task outputTask;
        private AnalogMultiChannelReader soundReader;
        private AnalogSingleChannelWriter writer;

        private AsyncCallback soundCallback;
        private DataTable dataTable;
        private DataColumn[] dataColumn;
        private NationalInstruments.DAQmx.Task runningTask;

        private Project proj = Project.Instance;

        private double no_cycles;
        private int no_samples;

        private int cycle;
        private int sampleCount=0;
        public event EventHandler MeasurementFinished;

        public aiaoDriver()
        {
            dataTable=new DataTable();
        }

        public void startMeasurement(double[] output, double measLength, CardConfig cardConfig)
        {
            if (runningTask == null)
            {
                no_samples = (int)(measLength * cardConfig.chSmplRate);
                no_cycles = (double)no_samples / cardConfig.chSmplToRead;

                if (no_cycles % 1 != 0 && no_cycles!=0)
                {
                    MessageBox.Show("Measurement time and sampling settings doesnt match");

                }
                else
                {
                    try
                    {
                        // Create a new task
                        inputTask = new Task("inputTask");
                        outputTask = new Task("outputTask");

                        // Configure the Terminal Configuration and Excitation Source with enums
                        //AITerminalConfiguration terminal = proj.cardConfig.terminalConfig;
                        //AIExcitationSource exctSource = proj.cardConfig.excitationSource;

                        // Create the channel

                        foreach (ChannelConfig channel in cardConfig.chConfig)
                        {
                            if (channel.chActive)
                            {
                                inputTask.AIChannels.CreateMicrophoneChannel(channel.chName, "soundChannel" + channel.chName.Replace('/', '_'),
                                    channel.chSens, cardConfig.chMaxPress,
                                    cardConfig.terminalConfig, cardConfig.excitationSource, cardConfig.chIEPEVal, AISoundPressureUnits.Pascals);
                            }
                        }

                        outputTask.AOChannels.CreateVoltageChannel(cardConfig.aoChannelSellected,
                        "",
                        (double) proj.cardConfig.aoMin,
                        (double) proj.cardConfig.aoMax,
                        AOVoltageUnits.Volts);


                        // Configure the timing parameters
                        inputTask.Timing.ConfigureSampleClock("", cardConfig.chSmplRate,
                            SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples);

                        outputTask.Timing.ConfigureSampleClock("", cardConfig.chSmplRate,
                            SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples);

                        // Verify the Task
                        inputTask.Control(TaskAction.Verify);
                        outputTask.Control(TaskAction.Verify);

                        // Set up the start trigger
                        string deviceName = inputTask.AIChannels[0].PhysicalName.Split('/')[0];
                        string terminalNameBase = "/" + GetDeviceName(deviceName) + "/";
                        outputTask.Triggers.StartTrigger.ConfigureDigitalEdgeTrigger(terminalNameBase + "ai/StartTrigger",
                            DigitalEdgeStartTriggerEdge.Rising);

                        // Initialize the data table
                        InitializeDataTable(inputTask.AIChannels, ref dataTable);

                        //Write data to output

                        writer = new AnalogSingleChannelWriter(outputTask.Stream);
                        writer.WriteMultiSample(false, output);

                        // Start running the task
                        StartTask();

                        outputTask.Start();
                        inputTask.Start();

                        // Create the analog input sound reader
                        soundReader = new AnalogMultiChannelReader(inputTask.Stream);
                        soundCallback = new AsyncCallback(SoundCallback);

                        // Use SynchronizeCallbacks to specify that the object 
                        // marshals callbacks across threads appropriately.
                        soundReader.SynchronizeCallbacks = true;
                        soundReader.BeginReadWaveform(cardConfig.chSmplToRead,
                            soundCallback, inputTask);

                        cycle = 1;
                        sampleCount = 0;

                    }
                    catch (DaqException exception)
                    {
                        // Display Errors
                        MessageBox.Show(exception.Message);
                        StopTask();
                    }
                }
            }
        }

        private void SoundCallback(IAsyncResult ar)
        {
            try
            {
                if (runningTask != null && runningTask == ar.AsyncState)
                {
                    // Read the available data from the channels
                    AnalogWaveform<double>[] data = soundReader.EndReadWaveform(ar);

                    // Plot your data here
                    dataToDataTable(data, ref dataTable);


                    if (cycle != no_cycles)
                    {
                        // Set up a new callback
                        soundReader.BeginMemoryOptimizedReadWaveform(proj.cardConfig.chSmplToRead,
                            soundCallback, inputTask, data);
                        cycle++;
                    }
                    else
                    {
                        StopTask();
                    }
                }
            }
            catch (DaqException exception)
            {
                // Display Errors
                MessageBox.Show(exception.Message);
                StopTask();
            }
        }

        private void dataToDataTable(AnalogWaveform<double>[] sourceArray, ref DataTable dataTable)
        {
            // Iterate over channels
            int currentLineIndex = 0;
            foreach (AnalogWaveform<double> waveform in sourceArray)
            {
                for (int sample = 0; sample < waveform.Samples.Count; ++sample)
                {
                    dataTable.Rows[sample + sampleCount][currentLineIndex] = waveform.Samples[sample].Value;
                }
                currentLineIndex++;
            }
            sampleCount += sourceArray[0].SampleCount;
        }

        public void InitializeDataTable(AIChannelCollection channelCollection, ref DataTable data)
        {
            int numOfChannels = channelCollection.Count;
            data.Rows.Clear();
            data.Columns.Clear();
            dataColumn = new DataColumn[numOfChannels];
            int numOfRows = no_samples;      //dlugosc sygnalu

            for (int currentChannelIndex = 0; currentChannelIndex < numOfChannels; currentChannelIndex++)
            {
                dataColumn[currentChannelIndex] = new DataColumn();
                dataColumn[currentChannelIndex].DataType = typeof(double);
                dataColumn[currentChannelIndex].ColumnName = channelCollection[currentChannelIndex].PhysicalName;
            }

            data.Columns.AddRange(dataColumn);

            for (int currentDataIndex = 0; currentDataIndex < numOfRows; currentDataIndex++)
            {
                object[] rowArr = new object[numOfChannels];
                data.Rows.Add(rowArr);
            }
        }

        public void stopMeasurement()
        {
            if (runningTask != null)
            {
                // Dispose of the task
                runningTask = null;
                StopTask();
            }
        }

        private void StartTask()
        {
            runningTask = inputTask;
        }

        private void StopTask()
        {
            runningTask = null;
            inputTask.Dispose();
            outputTask.Dispose();

            if (this.MeasurementFinished != null)
                this.MeasurementFinished(this, EventArgs.Empty);
        }

        public DataTable getDataTable()
        {
            return dataTable;
        }

        public static string GetDeviceName(string deviceName)
        {
            Device device = DaqSystem.Local.LoadDevice(deviceName);
            if (device.BusType != DeviceBusType.CompactDaq)
                return deviceName;
            else
                return device.CompactDaqChassisDeviceName;
        }

    }
}
