namespace RoomMeasureNI.GUI
{
    partial class ctrlResults
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewMesurements = new System.Windows.Forms.DataGridView();
            this.contextMenuResults = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.calculateDefaultParamsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImpulseAsWavToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImpulseFromWavToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.confirmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMeasurementResults = new System.Windows.Forms.TabControl();
            this.tabOgolne = new System.Windows.Forms.TabPage();
            this.tabResultsCharts = new System.Windows.Forms.TabPage();
            this.tabResultsTables = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.dataGridParamSetData = new System.Windows.Forms.DataGridView();
            this.dataGridResults = new System.Windows.Forms.DataGridView();
            this.parametersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.measResultsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.oknoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parametersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kanalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nazwaPunktuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metodaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fstartDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fstopDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.godzinapomiaruDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nazwaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctrlMainPlotPanel1 = new RoomMeasureNI.GUI.ctrlMainPlotPanel();
            this.ctrlCharts1 = new RoomMeasureNI.GUI.subResults.ctrlCharts();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projektBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMesurements)).BeginInit();
            this.contextMenuResults.SuspendLayout();
            this.tabMeasurementResults.SuspendLayout();
            this.tabOgolne.SuspendLayout();
            this.tabResultsCharts.SuspendLayout();
            this.tabResultsTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridParamSetData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.measResultsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projektBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewMesurements);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabMeasurementResults);
            this.splitContainer1.Panel2MinSize = 150;
            this.splitContainer1.Size = new System.Drawing.Size(900, 1000);
            this.splitContainer1.SplitterDistance = 296;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridViewMesurements
            // 
            this.dataGridViewMesurements.AllowUserToAddRows = false;
            this.dataGridViewMesurements.AutoGenerateColumns = false;
            this.dataGridViewMesurements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMesurements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.dataGridViewMesurements.ContextMenuStrip = this.contextMenuResults;
            this.dataGridViewMesurements.DataSource = this.measResultsBindingSource;
            this.dataGridViewMesurements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMesurements.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMesurements.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridViewMesurements.Name = "dataGridViewMesurements";
            this.dataGridViewMesurements.ReadOnly = true;
            this.dataGridViewMesurements.RowHeadersVisible = false;
            this.dataGridViewMesurements.Size = new System.Drawing.Size(296, 1000);
            this.dataGridViewMesurements.TabIndex = 0;
            this.dataGridViewMesurements.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // contextMenuResults
            // 
            this.contextMenuResults.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculateDefaultParamsToolStripMenuItem,
            this.averageSelectedToolStripMenuItem,
            this.saveImpulseAsWavToolStripMenuItem,
            this.loadImpulseFromWavToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuResults.Name = "contextMenuStrip1";
            this.contextMenuResults.Size = new System.Drawing.Size(379, 194);
            // 
            // calculateDefaultParamsToolStripMenuItem
            // 
            this.calculateDefaultParamsToolStripMenuItem.Name = "calculateDefaultParamsToolStripMenuItem";
            this.calculateDefaultParamsToolStripMenuItem.Size = new System.Drawing.Size(378, 38);
            this.calculateDefaultParamsToolStripMenuItem.Text = "Calculate default params";
            this.calculateDefaultParamsToolStripMenuItem.Click += new System.EventHandler(this.calculateDefaultParamsToolStripMenuItem_Click);
            // 
            // averageSelectedToolStripMenuItem
            // 
            this.averageSelectedToolStripMenuItem.Name = "averageSelectedToolStripMenuItem";
            this.averageSelectedToolStripMenuItem.Size = new System.Drawing.Size(378, 38);
            this.averageSelectedToolStripMenuItem.Text = "Average selected";
            this.averageSelectedToolStripMenuItem.Click += new System.EventHandler(this.averageSelectedToolStripMenuItem_Click);
            // 
            // saveImpulseAsWavToolStripMenuItem
            // 
            this.saveImpulseAsWavToolStripMenuItem.Name = "saveImpulseAsWavToolStripMenuItem";
            this.saveImpulseAsWavToolStripMenuItem.Size = new System.Drawing.Size(378, 38);
            this.saveImpulseAsWavToolStripMenuItem.Text = "Save impulse as wav";
            this.saveImpulseAsWavToolStripMenuItem.Click += new System.EventHandler(this.saveImpulseAsWavToolStripMenuItem_Click);
            // 
            // loadImpulseFromWavToolStripMenuItem
            // 
            this.loadImpulseFromWavToolStripMenuItem.Name = "loadImpulseFromWavToolStripMenuItem";
            this.loadImpulseFromWavToolStripMenuItem.Size = new System.Drawing.Size(378, 38);
            this.loadImpulseFromWavToolStripMenuItem.Text = "Load impulse from wav";
            this.loadImpulseFromWavToolStripMenuItem.Click += new System.EventHandler(this.loadImpulseFromWavToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmToolStripMenuItem});
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(378, 38);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // confirmToolStripMenuItem
            // 
            this.confirmToolStripMenuItem.Name = "confirmToolStripMenuItem";
            this.confirmToolStripMenuItem.Size = new System.Drawing.Size(201, 38);
            this.confirmToolStripMenuItem.Text = "Confirm";
            // 
            // tabMeasurementResults
            // 
            this.tabMeasurementResults.Controls.Add(this.tabOgolne);
            this.tabMeasurementResults.Controls.Add(this.tabResultsCharts);
            this.tabMeasurementResults.Controls.Add(this.tabResultsTables);
            this.tabMeasurementResults.Controls.Add(this.tabInfo);
            this.tabMeasurementResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMeasurementResults.Location = new System.Drawing.Point(0, 0);
            this.tabMeasurementResults.Margin = new System.Windows.Forms.Padding(6);
            this.tabMeasurementResults.Name = "tabMeasurementResults";
            this.tabMeasurementResults.SelectedIndex = 0;
            this.tabMeasurementResults.Size = new System.Drawing.Size(596, 1000);
            this.tabMeasurementResults.TabIndex = 0;
            // 
            // tabOgolne
            // 
            this.tabOgolne.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabOgolne.Controls.Add(this.ctrlMainPlotPanel1);
            this.tabOgolne.Location = new System.Drawing.Point(8, 39);
            this.tabOgolne.Margin = new System.Windows.Forms.Padding(6);
            this.tabOgolne.Name = "tabOgolne";
            this.tabOgolne.Padding = new System.Windows.Forms.Padding(6);
            this.tabOgolne.Size = new System.Drawing.Size(580, 953);
            this.tabOgolne.TabIndex = 0;
            this.tabOgolne.Text = "Ogólne";
            // 
            // tabResultsCharts
            // 
            this.tabResultsCharts.Controls.Add(this.ctrlCharts1);
            this.tabResultsCharts.Location = new System.Drawing.Point(8, 39);
            this.tabResultsCharts.Margin = new System.Windows.Forms.Padding(6);
            this.tabResultsCharts.Name = "tabResultsCharts";
            this.tabResultsCharts.Padding = new System.Windows.Forms.Padding(6);
            this.tabResultsCharts.Size = new System.Drawing.Size(580, 953);
            this.tabResultsCharts.TabIndex = 1;
            this.tabResultsCharts.Text = "Wykresy";
            this.tabResultsCharts.UseVisualStyleBackColor = true;
            // 
            // tabResultsTables
            // 
            this.tabResultsTables.Controls.Add(this.splitContainer4);
            this.tabResultsTables.Location = new System.Drawing.Point(8, 39);
            this.tabResultsTables.Margin = new System.Windows.Forms.Padding(6);
            this.tabResultsTables.Name = "tabResultsTables";
            this.tabResultsTables.Size = new System.Drawing.Size(580, 953);
            this.tabResultsTables.TabIndex = 2;
            this.tabResultsTables.Text = "Tabele";
            this.tabResultsTables.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(6);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.dataGridParamSetData);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dataGridResults);
            this.splitContainer4.Size = new System.Drawing.Size(580, 953);
            this.splitContainer4.SplitterDistance = 673;
            this.splitContainer4.SplitterWidth = 8;
            this.splitContainer4.TabIndex = 0;
            // 
            // dataGridParamSetData
            // 
            this.dataGridParamSetData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridParamSetData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridParamSetData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridParamSetData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridParamSetData.Location = new System.Drawing.Point(0, 0);
            this.dataGridParamSetData.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridParamSetData.Name = "dataGridParamSetData";
            this.dataGridParamSetData.RowHeadersVisible = false;
            this.dataGridParamSetData.Size = new System.Drawing.Size(580, 673);
            this.dataGridParamSetData.TabIndex = 0;
            this.dataGridParamSetData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridParamSetData_KeyUp);
            // 
            // dataGridResults
            // 
            this.dataGridResults.AutoGenerateColumns = false;
            this.dataGridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dataGridResults.DataSource = this.parametersBindingSource;
            this.dataGridResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridResults.Location = new System.Drawing.Point(0, 0);
            this.dataGridResults.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridResults.MinimumSize = new System.Drawing.Size(0, 100);
            this.dataGridResults.Name = "dataGridResults";
            this.dataGridResults.RowHeadersVisible = false;
            this.dataGridResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridResults.Size = new System.Drawing.Size(580, 272);
            this.dataGridResults.TabIndex = 1;
            this.dataGridResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // parametersBindingSource
            // 
            this.parametersBindingSource.DataMember = "parameters";
            this.parametersBindingSource.DataSource = this.measResultsBindingSource;
            // 
            // measResultsBindingSource
            // 
            this.measResultsBindingSource.DataMember = "measResults";
            this.measResultsBindingSource.DataSource = this.projektBindingSource;
            // 
            // tabInfo
            // 
            this.tabInfo.Location = new System.Drawing.Point(8, 39);
            this.tabInfo.Margin = new System.Windows.Forms.Padding(6);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(6);
            this.tabInfo.Size = new System.Drawing.Size(580, 953);
            this.tabInfo.TabIndex = 3;
            this.tabInfo.Text = "Informacje";
            this.tabInfo.UseVisualStyleBackColor = true;
            // 
            // oknoDataGridViewTextBoxColumn
            // 
            this.oknoDataGridViewTextBoxColumn.DataPropertyName = "okno";
            this.oknoDataGridViewTextBoxColumn.HeaderText = "okno";
            this.oknoDataGridViewTextBoxColumn.Name = "oknoDataGridViewTextBoxColumn";
            // 
            // parametersDataGridViewTextBoxColumn
            // 
            this.parametersDataGridViewTextBoxColumn.DataPropertyName = "parameters";
            this.parametersDataGridViewTextBoxColumn.HeaderText = "parameters";
            this.parametersDataGridViewTextBoxColumn.Name = "parametersDataGridViewTextBoxColumn";
            // 
            // kanalDataGridViewTextBoxColumn
            // 
            this.kanalDataGridViewTextBoxColumn.DataPropertyName = "kanal";
            this.kanalDataGridViewTextBoxColumn.HeaderText = "kanal";
            this.kanalDataGridViewTextBoxColumn.Name = "kanalDataGridViewTextBoxColumn";
            // 
            // fsDataGridViewTextBoxColumn
            // 
            this.fsDataGridViewTextBoxColumn.DataPropertyName = "Fs";
            this.fsDataGridViewTextBoxColumn.HeaderText = "Fs";
            this.fsDataGridViewTextBoxColumn.Name = "fsDataGridViewTextBoxColumn";
            // 
            // nazwaPunktuDataGridViewTextBoxColumn
            // 
            this.nazwaPunktuDataGridViewTextBoxColumn.DataPropertyName = "nazwaPunktu";
            this.nazwaPunktuDataGridViewTextBoxColumn.HeaderText = "nazwaPunktu";
            this.nazwaPunktuDataGridViewTextBoxColumn.Name = "nazwaPunktuDataGridViewTextBoxColumn";
            // 
            // metodaDataGridViewTextBoxColumn
            // 
            this.metodaDataGridViewTextBoxColumn.DataPropertyName = "metoda";
            this.metodaDataGridViewTextBoxColumn.HeaderText = "metoda";
            this.metodaDataGridViewTextBoxColumn.Name = "metodaDataGridViewTextBoxColumn";
            // 
            // fstartDataGridViewTextBoxColumn
            // 
            this.fstartDataGridViewTextBoxColumn.DataPropertyName = "fstart";
            this.fstartDataGridViewTextBoxColumn.HeaderText = "fstart";
            this.fstartDataGridViewTextBoxColumn.Name = "fstartDataGridViewTextBoxColumn";
            // 
            // fstopDataGridViewTextBoxColumn
            // 
            this.fstopDataGridViewTextBoxColumn.DataPropertyName = "fstop";
            this.fstopDataGridViewTextBoxColumn.HeaderText = "fstop";
            this.fstopDataGridViewTextBoxColumn.Name = "fstopDataGridViewTextBoxColumn";
            // 
            // godzinapomiaruDataGridViewTextBoxColumn
            // 
            this.godzinapomiaruDataGridViewTextBoxColumn.DataPropertyName = "godzina_pomiaru";
            this.godzinapomiaruDataGridViewTextBoxColumn.HeaderText = "godzina_pomiaru";
            this.godzinapomiaruDataGridViewTextBoxColumn.Name = "godzinapomiaruDataGridViewTextBoxColumn";
            // 
            // nazwaDataGridViewTextBoxColumn1
            // 
            this.nazwaDataGridViewTextBoxColumn1.DataPropertyName = "nazwa";
            this.nazwaDataGridViewTextBoxColumn1.HeaderText = "nazwa";
            this.nazwaDataGridViewTextBoxColumn1.Name = "nazwaDataGridViewTextBoxColumn1";
            // 
            // ctrlMainPlotPanel1
            // 
            this.ctrlMainPlotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlMainPlotPanel1.Location = new System.Drawing.Point(6, 6);
            this.ctrlMainPlotPanel1.Name = "ctrlMainPlotPanel1";
            this.ctrlMainPlotPanel1.Size = new System.Drawing.Size(568, 941);
            this.ctrlMainPlotPanel1.TabIndex = 0;
            // 
            // ctrlCharts1
            // 
            this.ctrlCharts1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlCharts1.Location = new System.Drawing.Point(6, 6);
            this.ctrlCharts1.Name = "ctrlCharts1";
            this.ctrlCharts1.Size = new System.Drawing.Size(568, 941);
            this.ctrlCharts1.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Nazwa zestawu wyników";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // projektBindingSource
            // 
            this.projektBindingSource.DataSource = typeof(RoomMeasureNI.Project);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "nazwa";
            this.dataGridViewTextBoxColumn2.HeaderText = "nazwa";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // ctrlResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(780, 1000);
            this.Name = "ctrlResults";
            this.Size = new System.Drawing.Size(900, 1000);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMesurements)).EndInit();
            this.contextMenuResults.ResumeLayout(false);
            this.tabMeasurementResults.ResumeLayout(false);
            this.tabOgolne.ResumeLayout(false);
            this.tabResultsCharts.ResumeLayout(false);
            this.tabResultsTables.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridParamSetData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.measResultsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projektBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabMeasurementResults;
        private System.Windows.Forms.TabPage tabOgolne;
        private System.Windows.Forms.TabPage tabResultsCharts;
        private System.Windows.Forms.DataGridView dataGridViewMesurements;
        private System.Windows.Forms.BindingSource projektBindingSource;
        private System.Windows.Forms.TabPage tabResultsTables;
        private System.Windows.Forms.ContextMenuStrip contextMenuResults;
        private System.Windows.Forms.ToolStripMenuItem saveImpulseAsWavToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averageSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem confirmToolStripMenuItem;
        private System.Windows.Forms.TabPage tabInfo;
        private ctrlPlotPanel ctrlPlotAcousticParams;
        private System.Windows.Forms.DataGridViewTextBoxColumn oknoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parametersDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kanalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazwaPunktuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn metodaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fstartDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fstopDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn godzinapomiaruDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazwaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource measResultsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn oknoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn kanalDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fsDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazwaPunktuDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn metodaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fstartDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fstopDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn godzinapomiaruDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazwaDataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingSource parametersBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView dataGridResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dataGridParamSetData;
        private System.Windows.Forms.ToolStripMenuItem calculateDefaultParamsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImpulseFromWavToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazwaDataGridViewTextBoxColumn;
        private ctrlMainPlotPanel ctrlMainPlotPanel1;
        private subResults.ctrlCharts ctrlCharts1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
