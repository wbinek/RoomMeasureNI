using RoomMeasureNI.GUI.shared;

namespace RoomMeasureNI.GUI.subMeasurement
{
    partial class ctrlAcceptResult
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.butAccept = new System.Windows.Forms.Button();
            this.butDrop = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ctrlPlotPanel1 = new ctrlPlotPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butAccept
            // 
            this.butAccept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butAccept.Location = new System.Drawing.Point(211, 359);
            this.butAccept.Name = "butAccept";
            this.butAccept.Size = new System.Drawing.Size(203, 41);
            this.butAccept.TabIndex = 0;
            this.butAccept.Text = "Accept";
            this.butAccept.UseVisualStyleBackColor = true;
            this.butAccept.Click += new System.EventHandler(this.butAccept_Click);
            // 
            // butDrop
            // 
            this.butDrop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butDrop.Location = new System.Drawing.Point(3, 359);
            this.butDrop.Name = "butDrop";
            this.butDrop.Size = new System.Drawing.Size(202, 41);
            this.butDrop.TabIndex = 1;
            this.butDrop.Text = "Drop";
            this.butDrop.UseVisualStyleBackColor = true;
            this.butDrop.Click += new System.EventHandler(this.butDrop_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.butDrop, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.butAccept, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ctrlPlotPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(417, 403);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ctrlPlotPanel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ctrlPlotPanel1, 2);
            this.ctrlPlotPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPlotPanel1.Location = new System.Drawing.Point(3, 3);
            this.ctrlPlotPanel1.Name = "ctrlPlotPanel1";
            this.ctrlPlotPanel1.Size = new System.Drawing.Size(411, 172);
            this.ctrlPlotPanel1.TabIndex = 2;
            // 
            // ctrlAcceptResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 403);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ctrlAcceptResult";
            this.Text = "ctrlAcceptResult";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butAccept;
        private System.Windows.Forms.Button butDrop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ctrlPlotPanel ctrlPlotPanel1;


    }
}