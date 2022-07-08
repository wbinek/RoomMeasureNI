using RoomMeasureNI.GUI.shared;
using RoomMeasureNI.Sources.Results;

namespace RoomMeasureNI.GUI.subResults
{
    partial class ctrlCharts
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewResultsSets = new System.Windows.Forms.DataGridView();
            this.checkboxPlot = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parametersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.measurementResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkedListParametersToPlot = new System.Windows.Forms.CheckedListBox();
            this.ctrlPlotPanel1 = new RoomMeasureNI.GUI.shared.ctrlPlotPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultsSets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.measurementResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ctrlPlotPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 236F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(488, 688);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(6, 458);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(6);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dataGridViewResultsSets);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.checkedListParametersToPlot);
            this.splitContainer3.Size = new System.Drawing.Size(476, 224);
            this.splitContainer3.SplitterDistance = 238;
            this.splitContainer3.SplitterWidth = 7;
            this.splitContainer3.TabIndex = 1;
            // 
            // dataGridViewResultsSets
            // 
            this.dataGridViewResultsSets.AllowUserToAddRows = false;
            this.dataGridViewResultsSets.AllowUserToDeleteRows = false;
            this.dataGridViewResultsSets.AutoGenerateColumns = false;
            this.dataGridViewResultsSets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResultsSets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkboxPlot,
            this.nameDataGridViewTextBoxColumn});
            this.dataGridViewResultsSets.DataSource = this.parametersBindingSource;
            this.dataGridViewResultsSets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewResultsSets.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewResultsSets.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridViewResultsSets.Name = "dataGridViewResultsSets";
            this.dataGridViewResultsSets.RowHeadersVisible = false;
            this.dataGridViewResultsSets.RowHeadersWidth = 72;
            this.dataGridViewResultsSets.Size = new System.Drawing.Size(238, 224);
            this.dataGridViewResultsSets.TabIndex = 0;
            this.dataGridViewResultsSets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.onRefreshPlots);
            // 
            // checkboxPlot
            // 
            this.checkboxPlot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.checkboxPlot.HeaderText = "";
            this.checkboxPlot.MinimumWidth = 21;
            this.checkboxPlot.Name = "checkboxPlot";
            this.checkboxPlot.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.checkboxPlot.Width = 21;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 9;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // parametersBindingSource
            // 
            this.parametersBindingSource.DataMember = "parameters";
            this.parametersBindingSource.DataSource = this.measurementResultBindingSource;
            // 
            // measurementResultBindingSource
            // 
            this.measurementResultBindingSource.DataSource = typeof(RoomMeasureNI.Sources.Results.MeasurementResult);
            // 
            // checkedListParametersToPlot
            // 
            this.checkedListParametersToPlot.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListParametersToPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListParametersToPlot.FormattingEnabled = true;
            this.checkedListParametersToPlot.Items.AddRange(new object[] {
            "parameter1",
            "parameter2"});
            this.checkedListParametersToPlot.Location = new System.Drawing.Point(0, 0);
            this.checkedListParametersToPlot.Margin = new System.Windows.Forms.Padding(6);
            this.checkedListParametersToPlot.MinimumSize = new System.Drawing.Size(184, 4);
            this.checkedListParametersToPlot.Name = "checkedListParametersToPlot";
            this.checkedListParametersToPlot.Size = new System.Drawing.Size(231, 224);
            this.checkedListParametersToPlot.TabIndex = 0;
            this.checkedListParametersToPlot.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.onRefreshPlots);
            // 
            // ctrlPlotPanel1
            // 
            this.ctrlPlotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPlotPanel1.Location = new System.Drawing.Point(6, 6);
            this.ctrlPlotPanel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ctrlPlotPanel1.Name = "ctrlPlotPanel1";
            this.ctrlPlotPanel1.Size = new System.Drawing.Size(476, 440);
            this.ctrlPlotPanel1.TabIndex = 2;
            // 
            // ctrlCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ctrlCharts";
            this.Size = new System.Drawing.Size(488, 688);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultsSets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.measurementResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dataGridViewResultsSets;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkboxPlot;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource parametersBindingSource;
        private System.Windows.Forms.BindingSource measurementResultBindingSource;
        private System.Windows.Forms.CheckedListBox checkedListParametersToPlot;
        private ctrlPlotPanel ctrlPlotPanel1;
    }
}
