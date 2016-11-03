namespace RoomMeasureNI.GUI
{
    partial class ctrlCardConfig
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timingRateLabel = new System.Windows.Forms.Label();
            this.timingSamplesLabel = new System.Windows.Forms.Label();
            this.timingParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.comboSamplesToRead = new System.Windows.Forms.ComboBox();
            this.comboTimingRate = new System.Windows.Forms.ComboBox();
            this.channelConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projektBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chActiveDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chSensDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.channelParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.currentNumeric = new System.Windows.Forms.NumericUpDown();
            this.inputTerminalComboBox = new System.Windows.Forms.ComboBox();
            this.inputTerminalLabel = new System.Windows.Forms.Label();
            this.excitationLabel = new System.Windows.Forms.Label();
            this.excitationComboBox = new System.Windows.Forms.ComboBox();
            this.currentLabel = new System.Windows.Forms.Label();
            this.maximumPressureNumeric = new System.Windows.Forms.NumericUpDown();
            this.maximumPressureLabel = new System.Windows.Forms.Label();
            this.outputChanGroupBox = new System.Windows.Forms.GroupBox();
            this.outputChannelComboBox = new System.Windows.Forms.ComboBox();
            this.aoChannelAvalibleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.outputMinValNumeric = new System.Windows.Forms.NumericUpDown();
            this.outputMaxValLabel = new System.Windows.Forms.Label();
            this.outputMinValLabel = new System.Windows.Forms.Label();
            this.outputMaxValNumeric = new System.Windows.Forms.NumericUpDown();
            this.outputChanLabel = new System.Windows.Forms.Label();
            this.timingParametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.channelConfigBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projektBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chConfigBindingSource)).BeginInit();
            this.channelParametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumPressureNumeric)).BeginInit();
            this.outputChanGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aoChannelAvalibleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputMinValNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputMaxValNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // timingRateLabel
            // 
            this.timingRateLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.timingRateLabel.Location = new System.Drawing.Point(8, 24);
            this.timingRateLabel.Name = "timingRateLabel";
            this.timingRateLabel.Size = new System.Drawing.Size(104, 16);
            this.timingRateLabel.TabIndex = 0;
            this.timingRateLabel.Text = "Rate [Hz]:";
            // 
            // timingSamplesLabel
            // 
            this.timingSamplesLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.timingSamplesLabel.Location = new System.Drawing.Point(8, 48);
            this.timingSamplesLabel.Name = "timingSamplesLabel";
            this.timingSamplesLabel.Size = new System.Drawing.Size(104, 16);
            this.timingSamplesLabel.TabIndex = 0;
            this.timingSamplesLabel.Text = "Samples to Read:";
            // 
            // timingParametersGroupBox
            // 
            this.timingParametersGroupBox.Controls.Add(this.comboSamplesToRead);
            this.timingParametersGroupBox.Controls.Add(this.comboTimingRate);
            this.timingParametersGroupBox.Controls.Add(this.timingRateLabel);
            this.timingParametersGroupBox.Controls.Add(this.timingSamplesLabel);
            this.timingParametersGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.timingParametersGroupBox.Location = new System.Drawing.Point(190, 3);
            this.timingParametersGroupBox.Name = "timingParametersGroupBox";
            this.timingParametersGroupBox.Size = new System.Drawing.Size(240, 80);
            this.timingParametersGroupBox.TabIndex = 2;
            this.timingParametersGroupBox.TabStop = false;
            this.timingParametersGroupBox.Text = "Timing Parameters";
            // 
            // comboSamplesToRead
            // 
            this.comboSamplesToRead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSamplesToRead.FormattingEnabled = true;
            this.comboSamplesToRead.Items.AddRange(new object[] {
            "102400",
            "51200",
            "25600",
            "10240",
            "5120",
            "2560"});
            this.comboSamplesToRead.Location = new System.Drawing.Point(121, 46);
            this.comboSamplesToRead.Name = "comboSamplesToRead";
            this.comboSamplesToRead.Size = new System.Drawing.Size(112, 21);
            this.comboSamplesToRead.TabIndex = 5;
            this.comboSamplesToRead.SelectionChangeCommitted += new System.EventHandler(this.comboSamplesToRead_SelectedIndexChanged);
            // 
            // comboTimingRate
            // 
            this.comboTimingRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTimingRate.FormattingEnabled = true;
            this.comboTimingRate.Items.AddRange(new object[] {
            "102400",
            "51200",
            "25600"});
            this.comboTimingRate.Location = new System.Drawing.Point(121, 19);
            this.comboTimingRate.Name = "comboTimingRate";
            this.comboTimingRate.Size = new System.Drawing.Size(112, 21);
            this.comboTimingRate.TabIndex = 5;
            this.comboTimingRate.SelectionChangeCommitted += new System.EventHandler(this.comboTimingRate_SelectedIndexChanged);
            // 
            // channelConfigBindingSource
            // 
            this.channelConfigBindingSource.DataMember = "cardConfig";
            this.channelConfigBindingSource.DataSource = this.projektBindingSource;
            // 
            // projektBindingSource
            // 
            this.projektBindingSource.DataSource = typeof(RoomMeasureNI.Projekt);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chNameDataGridViewTextBoxColumn,
            this.chActiveDataGridViewCheckBoxColumn,
            this.chSensDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.chConfigBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(184, 368);
            this.dataGridView1.TabIndex = 3;
            // 
            // chNameDataGridViewTextBoxColumn
            // 
            this.chNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.chNameDataGridViewTextBoxColumn.DataPropertyName = "chName";
            this.chNameDataGridViewTextBoxColumn.HeaderText = "Nazwa";
            this.chNameDataGridViewTextBoxColumn.MinimumWidth = 70;
            this.chNameDataGridViewTextBoxColumn.Name = "chNameDataGridViewTextBoxColumn";
            this.chNameDataGridViewTextBoxColumn.Width = 70;
            // 
            // chActiveDataGridViewCheckBoxColumn
            // 
            this.chActiveDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.chActiveDataGridViewCheckBoxColumn.DataPropertyName = "chActive";
            this.chActiveDataGridViewCheckBoxColumn.HeaderText = "Aktywny";
            this.chActiveDataGridViewCheckBoxColumn.MinimumWidth = 40;
            this.chActiveDataGridViewCheckBoxColumn.Name = "chActiveDataGridViewCheckBoxColumn";
            this.chActiveDataGridViewCheckBoxColumn.Width = 53;
            // 
            // chSensDataGridViewTextBoxColumn
            // 
            this.chSensDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.chSensDataGridViewTextBoxColumn.DataPropertyName = "chSens";
            this.chSensDataGridViewTextBoxColumn.HeaderText = "Czułość";
            this.chSensDataGridViewTextBoxColumn.Name = "chSensDataGridViewTextBoxColumn";
            this.chSensDataGridViewTextBoxColumn.Width = 71;
            // 
            // chConfigBindingSource
            // 
            this.chConfigBindingSource.DataMember = "chConfig";
            this.chConfigBindingSource.DataSource = this.channelConfigBindingSource;
            // 
            // channelParametersGroupBox
            // 
            this.channelParametersGroupBox.Controls.Add(this.currentNumeric);
            this.channelParametersGroupBox.Controls.Add(this.inputTerminalComboBox);
            this.channelParametersGroupBox.Controls.Add(this.inputTerminalLabel);
            this.channelParametersGroupBox.Controls.Add(this.excitationLabel);
            this.channelParametersGroupBox.Controls.Add(this.excitationComboBox);
            this.channelParametersGroupBox.Controls.Add(this.currentLabel);
            this.channelParametersGroupBox.Controls.Add(this.maximumPressureNumeric);
            this.channelParametersGroupBox.Controls.Add(this.maximumPressureLabel);
            this.channelParametersGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.channelParametersGroupBox.Location = new System.Drawing.Point(190, 89);
            this.channelParametersGroupBox.Name = "channelParametersGroupBox";
            this.channelParametersGroupBox.Size = new System.Drawing.Size(240, 135);
            this.channelParametersGroupBox.TabIndex = 4;
            this.channelParametersGroupBox.TabStop = false;
            this.channelParametersGroupBox.Text = "Channel Parameters";
            // 
            // currentNumeric
            // 
            this.currentNumeric.DecimalPlaces = 3;
            this.currentNumeric.Location = new System.Drawing.Point(121, 106);
            this.currentNumeric.Name = "currentNumeric";
            this.currentNumeric.Size = new System.Drawing.Size(112, 20);
            this.currentNumeric.TabIndex = 5;
            this.currentNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            196608});
            this.currentNumeric.ValueChanged += new System.EventHandler(this.currentNumeric_ValueChanged);
            // 
            // inputTerminalComboBox
            // 
            this.inputTerminalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputTerminalComboBox.Location = new System.Drawing.Point(121, 49);
            this.inputTerminalComboBox.Name = "inputTerminalComboBox";
            this.inputTerminalComboBox.Size = new System.Drawing.Size(112, 21);
            this.inputTerminalComboBox.TabIndex = 2;
            this.inputTerminalComboBox.SelectionChangeCommitted += new System.EventHandler(this.inputTerminalComboBox_SelectedIndexChanged);
            // 
            // inputTerminalLabel
            // 
            this.inputTerminalLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.inputTerminalLabel.Location = new System.Drawing.Point(6, 52);
            this.inputTerminalLabel.Name = "inputTerminalLabel";
            this.inputTerminalLabel.Size = new System.Drawing.Size(104, 16);
            this.inputTerminalLabel.TabIndex = 0;
            this.inputTerminalLabel.Text = "Input Terminal:";
            // 
            // excitationLabel
            // 
            this.excitationLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.excitationLabel.Location = new System.Drawing.Point(6, 80);
            this.excitationLabel.Name = "excitationLabel";
            this.excitationLabel.Size = new System.Drawing.Size(104, 16);
            this.excitationLabel.TabIndex = 0;
            this.excitationLabel.Text = "IEPE Excitation:";
            // 
            // excitationComboBox
            // 
            this.excitationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.excitationComboBox.Location = new System.Drawing.Point(121, 77);
            this.excitationComboBox.Name = "excitationComboBox";
            this.excitationComboBox.Size = new System.Drawing.Size(112, 21);
            this.excitationComboBox.TabIndex = 4;
            this.excitationComboBox.SelectionChangeCommitted += new System.EventHandler(this.excitationComboBox_SelectionChangeCommitted);
            // 
            // currentLabel
            // 
            this.currentLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.currentLabel.Location = new System.Drawing.Point(6, 108);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(104, 16);
            this.currentLabel.TabIndex = 0;
            this.currentLabel.Text = "IEPE Current [A]:";
            // 
            // maximumPressureNumeric
            // 
            this.maximumPressureNumeric.DecimalPlaces = 2;
            this.maximumPressureNumeric.Location = new System.Drawing.Point(121, 23);
            this.maximumPressureNumeric.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.maximumPressureNumeric.Name = "maximumPressureNumeric";
            this.maximumPressureNumeric.Size = new System.Drawing.Size(112, 20);
            this.maximumPressureNumeric.TabIndex = 1;
            this.maximumPressureNumeric.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.maximumPressureNumeric.ValueChanged += new System.EventHandler(this.maximumPressureNumeric_ValueChanged);
            // 
            // maximumPressureLabel
            // 
            this.maximumPressureLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.maximumPressureLabel.Location = new System.Drawing.Point(6, 25);
            this.maximumPressureLabel.Name = "maximumPressureLabel";
            this.maximumPressureLabel.Size = new System.Drawing.Size(128, 16);
            this.maximumPressureLabel.TabIndex = 0;
            this.maximumPressureLabel.Text = "Maximum Pressure [db]:";
            // 
            // outputChanGroupBox
            // 
            this.outputChanGroupBox.Controls.Add(this.outputChannelComboBox);
            this.outputChanGroupBox.Controls.Add(this.outputMinValNumeric);
            this.outputChanGroupBox.Controls.Add(this.outputMaxValLabel);
            this.outputChanGroupBox.Controls.Add(this.outputMinValLabel);
            this.outputChanGroupBox.Controls.Add(this.outputMaxValNumeric);
            this.outputChanGroupBox.Controls.Add(this.outputChanLabel);
            this.outputChanGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.outputChanGroupBox.Location = new System.Drawing.Point(190, 230);
            this.outputChanGroupBox.Name = "outputChanGroupBox";
            this.outputChanGroupBox.Size = new System.Drawing.Size(240, 135);
            this.outputChanGroupBox.TabIndex = 5;
            this.outputChanGroupBox.TabStop = false;
            this.outputChanGroupBox.Text = "Channel Parameters - Output";
            // 
            // outputChannelComboBox
            // 
            this.outputChannelComboBox.DataSource = this.aoChannelAvalibleBindingSource;
            this.outputChannelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputChannelComboBox.Location = new System.Drawing.Point(121, 23);
            this.outputChannelComboBox.Name = "outputChannelComboBox";
            this.outputChannelComboBox.Size = new System.Drawing.Size(112, 21);
            this.outputChannelComboBox.TabIndex = 1;
            this.outputChannelComboBox.SelectionChangeCommitted += new System.EventHandler(this.outputChannelComboBox_SelectionChangeCommitted);
            // 
            // aoChannelAvalibleBindingSource
            // 
            this.aoChannelAvalibleBindingSource.DataMember = "aoChannelAvalible";
            this.aoChannelAvalibleBindingSource.DataSource = this.channelConfigBindingSource;
            // 
            // outputMinValNumeric
            // 
            this.outputMinValNumeric.DecimalPlaces = 2;
            this.outputMinValNumeric.Location = new System.Drawing.Point(121, 80);
            this.outputMinValNumeric.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.outputMinValNumeric.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            -2147483648});
            this.outputMinValNumeric.Name = "outputMinValNumeric";
            this.outputMinValNumeric.Size = new System.Drawing.Size(112, 20);
            this.outputMinValNumeric.TabIndex = 5;
            this.outputMinValNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.outputMinValNumeric.ValueChanged += new System.EventHandler(this.outputMinValNumeric_ValueChanged);
            // 
            // outputMaxValLabel
            // 
            this.outputMaxValLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.outputMaxValLabel.Location = new System.Drawing.Point(16, 54);
            this.outputMaxValLabel.Name = "outputMaxValLabel";
            this.outputMaxValLabel.Size = new System.Drawing.Size(96, 16);
            this.outputMaxValLabel.TabIndex = 2;
            this.outputMaxValLabel.Text = "Maximum Value:";
            // 
            // outputMinValLabel
            // 
            this.outputMinValLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.outputMinValLabel.Location = new System.Drawing.Point(16, 82);
            this.outputMinValLabel.Name = "outputMinValLabel";
            this.outputMinValLabel.Size = new System.Drawing.Size(96, 16);
            this.outputMinValLabel.TabIndex = 4;
            this.outputMinValLabel.Text = "Minimum Value:";
            // 
            // outputMaxValNumeric
            // 
            this.outputMaxValNumeric.DecimalPlaces = 2;
            this.outputMaxValNumeric.Location = new System.Drawing.Point(121, 52);
            this.outputMaxValNumeric.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.outputMaxValNumeric.Name = "outputMaxValNumeric";
            this.outputMaxValNumeric.Size = new System.Drawing.Size(112, 20);
            this.outputMaxValNumeric.TabIndex = 3;
            this.outputMaxValNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.outputMaxValNumeric.ValueChanged += new System.EventHandler(this.outputMaxValNumeric_ValueChanged);
            // 
            // outputChanLabel
            // 
            this.outputChanLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.outputChanLabel.Location = new System.Drawing.Point(16, 26);
            this.outputChanLabel.Name = "outputChanLabel";
            this.outputChanLabel.Size = new System.Drawing.Size(96, 16);
            this.outputChanLabel.TabIndex = 0;
            this.outputChanLabel.Text = "Output Channel:";
            // 
            // ctrlCardConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.outputChanGroupBox);
            this.Controls.Add(this.channelParametersGroupBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.timingParametersGroupBox);
            this.Name = "ctrlCardConfig";
            this.Size = new System.Drawing.Size(447, 368);
            this.timingParametersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.channelConfigBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projektBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chConfigBindingSource)).EndInit();
            this.channelParametersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.currentNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumPressureNumeric)).EndInit();
            this.outputChanGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aoChannelAvalibleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputMinValNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputMaxValNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label timingRateLabel;
        private System.Windows.Forms.Label timingSamplesLabel;
        private System.Windows.Forms.GroupBox timingParametersGroupBox;
        private System.Windows.Forms.BindingSource projektBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox channelParametersGroupBox;
        private System.Windows.Forms.NumericUpDown currentNumeric;
        private System.Windows.Forms.ComboBox inputTerminalComboBox;
        private System.Windows.Forms.Label inputTerminalLabel;
        private System.Windows.Forms.Label excitationLabel;
        private System.Windows.Forms.ComboBox excitationComboBox;
        private System.Windows.Forms.Label currentLabel;
        private System.Windows.Forms.NumericUpDown maximumPressureNumeric;
        private System.Windows.Forms.Label maximumPressureLabel;
        private System.Windows.Forms.ComboBox comboSamplesToRead;
        private System.Windows.Forms.ComboBox comboTimingRate;
        private System.Windows.Forms.GroupBox outputChanGroupBox;
        private System.Windows.Forms.ComboBox outputChannelComboBox;
        private System.Windows.Forms.NumericUpDown outputMinValNumeric;
        private System.Windows.Forms.Label outputMaxValLabel;
        private System.Windows.Forms.Label outputMinValLabel;
        private System.Windows.Forms.NumericUpDown outputMaxValNumeric;
        private System.Windows.Forms.Label outputChanLabel;
        private System.Windows.Forms.BindingSource channelConfigBindingSource;
        private System.Windows.Forms.BindingSource chConfigBindingSource;
        private System.Windows.Forms.BindingSource aoChannelAvalibleBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn chNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chActiveDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chSensDataGridViewTextBoxColumn;
    }
}
