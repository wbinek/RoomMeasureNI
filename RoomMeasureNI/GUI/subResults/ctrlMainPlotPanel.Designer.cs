using RoomMeasureNI.GUI.shared;

namespace RoomMeasureNI.GUI.subResults
{
    partial class ctrlMainPlotPanel
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupWindowSettings = new System.Windows.Forms.GroupBox();
            this.numericWindowLength = new System.Windows.Forms.NumericUpDown();
            this.numericWindowStart = new System.Windows.Forms.NumericUpDown();
            this.labWindowLength = new System.Windows.Forms.Label();
            this.labWindowStart = new System.Windows.Forms.Label();
            this.labWindow = new System.Windows.Forms.Label();
            this.comboWindow = new System.Windows.Forms.ComboBox();
            this.groupChartSettings = new System.Windows.Forms.GroupBox();
            this.labChartType = new System.Windows.Forms.Label();
            this.labFrequency = new System.Windows.Forms.Label();
            this.labFilter = new System.Windows.Forms.Label();
            this.comboFrequency = new System.Windows.Forms.ComboBox();
            this.labScaleY = new System.Windows.Forms.Label();
            this.comboFilter = new System.Windows.Forms.ComboBox();
            this.comboChart = new System.Windows.Forms.ComboBox();
            this.comboYScale = new System.Windows.Forms.ComboBox();
            this.ctrlPlotImpulse = new ctrlPlotPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupWindowSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWindowLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWindowStart)).BeginInit();
            this.groupChartSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(6);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ctrlPlotImpulse);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer2.Panel2.Controls.Add(this.groupWindowSettings);
            this.splitContainer2.Panel2.Controls.Add(this.groupChartSettings);
            this.splitContainer2.Panel2MinSize = 200;
            this.splitContainer2.Size = new System.Drawing.Size(603, 970);
            this.splitContainer2.SplitterDistance = 573;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 1;
            // 
            // groupWindowSettings
            // 
            this.groupWindowSettings.Controls.Add(this.numericWindowLength);
            this.groupWindowSettings.Controls.Add(this.numericWindowStart);
            this.groupWindowSettings.Controls.Add(this.labWindowLength);
            this.groupWindowSettings.Controls.Add(this.labWindowStart);
            this.groupWindowSettings.Controls.Add(this.labWindow);
            this.groupWindowSettings.Controls.Add(this.comboWindow);
            this.groupWindowSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupWindowSettings.Location = new System.Drawing.Point(0, 16);
            this.groupWindowSettings.Margin = new System.Windows.Forms.Padding(6);
            this.groupWindowSettings.Name = "groupWindowSettings";
            this.groupWindowSettings.Padding = new System.Windows.Forms.Padding(6);
            this.groupWindowSettings.Size = new System.Drawing.Size(603, 169);
            this.groupWindowSettings.TabIndex = 3;
            this.groupWindowSettings.TabStop = false;
            this.groupWindowSettings.Text = "Ustawienia okna";
            // 
            // numericWindowLength
            // 
            this.numericWindowLength.DecimalPlaces = 1;
            this.numericWindowLength.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericWindowLength.Location = new System.Drawing.Point(242, 127);
            this.numericWindowLength.Margin = new System.Windows.Forms.Padding(6);
            this.numericWindowLength.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericWindowLength.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericWindowLength.Name = "numericWindowLength";
            this.numericWindowLength.Size = new System.Drawing.Size(240, 31);
            this.numericWindowLength.TabIndex = 2;
            this.numericWindowLength.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericWindowLength.ValueChanged += new System.EventHandler(this.numericWindowLength_ValueChanged);
            // 
            // numericWindowStart
            // 
            this.numericWindowStart.DecimalPlaces = 1;
            this.numericWindowStart.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericWindowStart.Location = new System.Drawing.Point(242, 77);
            this.numericWindowStart.Margin = new System.Windows.Forms.Padding(6);
            this.numericWindowStart.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericWindowStart.Name = "numericWindowStart";
            this.numericWindowStart.Size = new System.Drawing.Size(240, 31);
            this.numericWindowStart.TabIndex = 2;
            this.numericWindowStart.ValueChanged += new System.EventHandler(this.numericWindowStart_ValueChanged);
            // 
            // labWindowLength
            // 
            this.labWindowLength.AutoSize = true;
            this.labWindowLength.Location = new System.Drawing.Point(12, 131);
            this.labWindowLength.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labWindowLength.Name = "labWindowLength";
            this.labWindowLength.Size = new System.Drawing.Size(127, 25);
            this.labWindowLength.TabIndex = 1;
            this.labWindowLength.Text = "Długość (s):";
            // 
            // labWindowStart
            // 
            this.labWindowStart.AutoSize = true;
            this.labWindowStart.Location = new System.Drawing.Point(12, 81);
            this.labWindowStart.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labWindowStart.Name = "labWindowStart";
            this.labWindowStart.Size = new System.Drawing.Size(138, 25);
            this.labWindowStart.TabIndex = 1;
            this.labWindowStart.Text = "Początek (s):";
            // 
            // labWindow
            // 
            this.labWindow.AutoSize = true;
            this.labWindow.Location = new System.Drawing.Point(12, 31);
            this.labWindow.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labWindow.Name = "labWindow";
            this.labWindow.Size = new System.Drawing.Size(107, 25);
            this.labWindow.TabIndex = 1;
            this.labWindow.Text = "Typ okna:";
            // 
            // comboWindow
            // 
            this.comboWindow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWindow.FormattingEnabled = true;
            this.comboWindow.Location = new System.Drawing.Point(242, 25);
            this.comboWindow.Margin = new System.Windows.Forms.Padding(6);
            this.comboWindow.Name = "comboWindow";
            this.comboWindow.Size = new System.Drawing.Size(238, 33);
            this.comboWindow.TabIndex = 0;
            // 
            // groupChartSettings
            // 
            this.groupChartSettings.Controls.Add(this.labChartType);
            this.groupChartSettings.Controls.Add(this.labFrequency);
            this.groupChartSettings.Controls.Add(this.labFilter);
            this.groupChartSettings.Controls.Add(this.comboFrequency);
            this.groupChartSettings.Controls.Add(this.labScaleY);
            this.groupChartSettings.Controls.Add(this.comboFilter);
            this.groupChartSettings.Controls.Add(this.comboChart);
            this.groupChartSettings.Controls.Add(this.comboYScale);
            this.groupChartSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupChartSettings.Location = new System.Drawing.Point(0, 185);
            this.groupChartSettings.Margin = new System.Windows.Forms.Padding(6);
            this.groupChartSettings.Name = "groupChartSettings";
            this.groupChartSettings.Padding = new System.Windows.Forms.Padding(6);
            this.groupChartSettings.Size = new System.Drawing.Size(603, 204);
            this.groupChartSettings.TabIndex = 2;
            this.groupChartSettings.TabStop = false;
            this.groupChartSettings.Text = "Ustawienia wykresu";
            // 
            // labChartType
            // 
            this.labChartType.AutoSize = true;
            this.labChartType.Location = new System.Drawing.Point(12, 31);
            this.labChartType.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labChartType.Name = "labChartType";
            this.labChartType.Size = new System.Drawing.Size(139, 25);
            this.labChartType.TabIndex = 1;
            this.labChartType.Text = "Typ wykresu:";
            // 
            // labFrequency
            // 
            this.labFrequency.AutoSize = true;
            this.labFrequency.Location = new System.Drawing.Point(12, 160);
            this.labFrequency.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labFrequency.Name = "labFrequency";
            this.labFrequency.Size = new System.Drawing.Size(150, 25);
            this.labFrequency.TabIndex = 1;
            this.labFrequency.Text = "Częstotliwość:";
            // 
            // labFilter
            // 
            this.labFilter.AutoSize = true;
            this.labFilter.Location = new System.Drawing.Point(12, 117);
            this.labFilter.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labFilter.Name = "labFilter";
            this.labFilter.Size = new System.Drawing.Size(54, 25);
            this.labFilter.TabIndex = 1;
            this.labFilter.Text = "Filtr:";
            // 
            // comboFrequency
            // 
            this.comboFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFrequency.FormattingEnabled = true;
            this.comboFrequency.Location = new System.Drawing.Point(242, 154);
            this.comboFrequency.Margin = new System.Windows.Forms.Padding(6);
            this.comboFrequency.Name = "comboFrequency";
            this.comboFrequency.Size = new System.Drawing.Size(238, 33);
            this.comboFrequency.TabIndex = 0;
            this.comboFrequency.SelectedIndexChanged += new System.EventHandler(this.onUpdateChart);
            // 
            // labScaleY
            // 
            this.labScaleY.AutoSize = true;
            this.labScaleY.Location = new System.Drawing.Point(12, 73);
            this.labScaleY.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labScaleY.Name = "labScaleY";
            this.labScaleY.Size = new System.Drawing.Size(93, 25);
            this.labScaleY.TabIndex = 1;
            this.labScaleY.Text = "Skala Y:";
            // 
            // comboFilter
            // 
            this.comboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilter.FormattingEnabled = true;
            this.comboFilter.Location = new System.Drawing.Point(242, 112);
            this.comboFilter.Margin = new System.Windows.Forms.Padding(6);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(238, 33);
            this.comboFilter.TabIndex = 0;
            this.comboFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilter_SelectedIndexChanged);
            // 
            // comboChart
            // 
            this.comboChart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboChart.FormattingEnabled = true;
            this.comboChart.Location = new System.Drawing.Point(242, 25);
            this.comboChart.Margin = new System.Windows.Forms.Padding(6);
            this.comboChart.Name = "comboChart";
            this.comboChart.Size = new System.Drawing.Size(238, 33);
            this.comboChart.TabIndex = 0;
            this.comboChart.SelectedIndexChanged += new System.EventHandler(this.onUpdateChart);
            // 
            // comboYScale
            // 
            this.comboYScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboYScale.FormattingEnabled = true;
            this.comboYScale.Location = new System.Drawing.Point(242, 67);
            this.comboYScale.Margin = new System.Windows.Forms.Padding(6);
            this.comboYScale.Name = "comboYScale";
            this.comboYScale.Size = new System.Drawing.Size(238, 33);
            this.comboYScale.TabIndex = 0;
            this.comboYScale.SelectedIndexChanged += new System.EventHandler(this.onUpdateChart);
            // 
            // ctrlPlotImpulse
            // 
            this.ctrlPlotImpulse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlPlotImpulse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlPlotImpulse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPlotImpulse.Location = new System.Drawing.Point(0, 0);
            this.ctrlPlotImpulse.Margin = new System.Windows.Forms.Padding(12);
            this.ctrlPlotImpulse.Name = "ctrlPlotImpulse";
            this.ctrlPlotImpulse.Size = new System.Drawing.Size(603, 573);
            this.ctrlPlotImpulse.TabIndex = 0;
            // 
            // ctrlMainPlotPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Name = "ctrlMainPlotPanel";
            this.Size = new System.Drawing.Size(603, 970);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupWindowSettings.ResumeLayout(false);
            this.groupWindowSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWindowLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWindowStart)).EndInit();
            this.groupChartSettings.ResumeLayout(false);
            this.groupChartSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private ctrlPlotPanel ctrlPlotImpulse;
        private System.Windows.Forms.GroupBox groupWindowSettings;
        private System.Windows.Forms.NumericUpDown numericWindowLength;
        private System.Windows.Forms.NumericUpDown numericWindowStart;
        private System.Windows.Forms.Label labWindowLength;
        private System.Windows.Forms.Label labWindowStart;
        private System.Windows.Forms.Label labWindow;
        private System.Windows.Forms.ComboBox comboWindow;
        private System.Windows.Forms.GroupBox groupChartSettings;
        private System.Windows.Forms.Label labChartType;
        private System.Windows.Forms.Label labFrequency;
        private System.Windows.Forms.Label labFilter;
        private System.Windows.Forms.ComboBox comboFrequency;
        private System.Windows.Forms.Label labScaleY;
        private System.Windows.Forms.ComboBox comboFilter;
        private System.Windows.Forms.ComboBox comboChart;
        private System.Windows.Forms.ComboBox comboYScale;
    }
}
