using RoomMeasureNI.GUI.subMeasurement;

namespace RoomMeasureNI.GUI
{
    partial class ctrlMeasurement
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.butStart = new System.Windows.Forms.Button();
            this.butStop = new System.Windows.Forms.Button();
            this.butTest = new System.Windows.Forms.Button();
            this.tabUstPomiaru = new System.Windows.Forms.TabControl();
            this.tabPunktyPomiarowe = new System.Windows.Forms.TabPage();
            this.splitRysPkt = new System.Windows.Forms.SplitContainer();
            this.imgPanel1 = new RoomMeasureNI.GUI.subMeasurement.imgPanel();
            this.ctrlPunktyPom = new RoomMeasureNI.GUI.subMeasurement.ctrlPunktyPom();
            this.tabMeasurementMethod = new System.Windows.Forms.TabPage();
            this.ctrlMeasureConfig1 = new RoomMeasureNI.GUI.subMeasurement.ctrlMeasureConfig();
            this.tabUstawieniaKarty = new System.Windows.Forms.TabPage();
            this.ctrlCardConfig1 = new RoomMeasureNI.GUI.subMeasurement.ctrlCardConfig();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel.SuspendLayout();
            this.tabUstPomiaru.SuspendLayout();
            this.tabPunktyPomiarowe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRysPkt)).BeginInit();
            this.splitRysPkt.Panel1.SuspendLayout();
            this.splitRysPkt.Panel2.SuspendLayout();
            this.splitRysPkt.SuspendLayout();
            this.tabMeasurementMethod.SuspendLayout();
            this.tabUstawieniaKarty.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 759);
            this.progressBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(930, 42);
            this.progressBar.TabIndex = 1;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.Controls.Add(this.butStart, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.butStop, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.butTest, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 693);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(930, 66);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // butStart
            // 
            this.butStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butStart.Location = new System.Drawing.Point(626, 6);
            this.butStart.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(298, 54);
            this.butStart.TabIndex = 0;
            this.butStart.Text = "Start";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // butStop
            // 
            this.butStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butStop.Location = new System.Drawing.Point(316, 6);
            this.butStop.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(298, 54);
            this.butStop.TabIndex = 1;
            this.butStop.Text = "Stop";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.butStop_Click);
            // 
            // butTest
            // 
            this.butTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.butTest.Location = new System.Drawing.Point(6, 6);
            this.butTest.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.butTest.Name = "butTest";
            this.butTest.Size = new System.Drawing.Size(298, 54);
            this.butTest.TabIndex = 2;
            this.butTest.Text = "Test";
            this.butTest.UseVisualStyleBackColor = true;
            this.butTest.Click += new System.EventHandler(this.butTest_Click);
            // 
            // tabUstPomiaru
            // 
            this.tabUstPomiaru.Controls.Add(this.tabPunktyPomiarowe);
            this.tabUstPomiaru.Controls.Add(this.tabMeasurementMethod);
            this.tabUstPomiaru.Controls.Add(this.tabUstawieniaKarty);
            this.tabUstPomiaru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUstPomiaru.Location = new System.Drawing.Point(0, 0);
            this.tabUstPomiaru.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabUstPomiaru.Name = "tabUstPomiaru";
            this.tabUstPomiaru.SelectedIndex = 0;
            this.tabUstPomiaru.Size = new System.Drawing.Size(930, 693);
            this.tabUstPomiaru.TabIndex = 5;
            // 
            // tabPunktyPomiarowe
            // 
            this.tabPunktyPomiarowe.Controls.Add(this.splitRysPkt);
            this.tabPunktyPomiarowe.Location = new System.Drawing.Point(4, 33);
            this.tabPunktyPomiarowe.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPunktyPomiarowe.Name = "tabPunktyPomiarowe";
            this.tabPunktyPomiarowe.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPunktyPomiarowe.Size = new System.Drawing.Size(922, 656);
            this.tabPunktyPomiarowe.TabIndex = 0;
            this.tabPunktyPomiarowe.Text = "Punkty pomiarowe";
            this.tabPunktyPomiarowe.UseVisualStyleBackColor = true;
            // 
            // splitRysPkt
            // 
            this.splitRysPkt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRysPkt.Location = new System.Drawing.Point(6, 6);
            this.splitRysPkt.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitRysPkt.Name = "splitRysPkt";
            this.splitRysPkt.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitRysPkt.Panel1
            // 
            this.splitRysPkt.Panel1.Controls.Add(this.imgPanel1);
            // 
            // splitRysPkt.Panel2
            // 
            this.splitRysPkt.Panel2.Controls.Add(this.ctrlPunktyPom);
            this.splitRysPkt.Size = new System.Drawing.Size(910, 644);
            this.splitRysPkt.SplitterDistance = 428;
            this.splitRysPkt.SplitterWidth = 7;
            this.splitRysPkt.TabIndex = 7;
            // 
            // imgPanel1
            // 
            this.imgPanel1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.imgPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgPanel1.Location = new System.Drawing.Point(0, 0);
            this.imgPanel1.Margin = new System.Windows.Forms.Padding(11, 11, 11, 11);
            this.imgPanel1.Name = "imgPanel1";
            this.imgPanel1.Size = new System.Drawing.Size(910, 428);
            this.imgPanel1.TabIndex = 0;
            // 
            // ctrlPunktyPom
            // 
            this.ctrlPunktyPom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPunktyPom.Location = new System.Drawing.Point(0, 0);
            this.ctrlPunktyPom.Margin = new System.Windows.Forms.Padding(11, 11, 11, 11);
            this.ctrlPunktyPom.Name = "ctrlPunktyPom";
            this.ctrlPunktyPom.Size = new System.Drawing.Size(910, 209);
            this.ctrlPunktyPom.TabIndex = 6;
            // 
            // tabMeasurementMethod
            // 
            this.tabMeasurementMethod.Controls.Add(this.ctrlMeasureConfig1);
            this.tabMeasurementMethod.Location = new System.Drawing.Point(4, 33);
            this.tabMeasurementMethod.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabMeasurementMethod.Name = "tabMeasurementMethod";
            this.tabMeasurementMethod.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabMeasurementMethod.Size = new System.Drawing.Size(922, 655);
            this.tabMeasurementMethod.TabIndex = 2;
            this.tabMeasurementMethod.Text = "Metoda pomiaru";
            this.tabMeasurementMethod.UseVisualStyleBackColor = true;
            // 
            // ctrlMeasureConfig1
            // 
            this.ctrlMeasureConfig1.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlMeasureConfig1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlMeasureConfig1.Location = new System.Drawing.Point(6, 6);
            this.ctrlMeasureConfig1.Margin = new System.Windows.Forms.Padding(11, 11, 11, 11);
            this.ctrlMeasureConfig1.Name = "ctrlMeasureConfig1";
            this.ctrlMeasureConfig1.Size = new System.Drawing.Size(910, 643);
            this.ctrlMeasureConfig1.TabIndex = 0;
            // 
            // tabUstawieniaKarty
            // 
            this.tabUstawieniaKarty.Controls.Add(this.ctrlCardConfig1);
            this.tabUstawieniaKarty.Location = new System.Drawing.Point(4, 33);
            this.tabUstawieniaKarty.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabUstawieniaKarty.Name = "tabUstawieniaKarty";
            this.tabUstawieniaKarty.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabUstawieniaKarty.Size = new System.Drawing.Size(922, 655);
            this.tabUstawieniaKarty.TabIndex = 1;
            this.tabUstawieniaKarty.Text = "Ustawienia karty";
            this.tabUstawieniaKarty.UseVisualStyleBackColor = true;
            // 
            // ctrlCardConfig1
            // 
            this.ctrlCardConfig1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ctrlCardConfig1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlCardConfig1.Location = new System.Drawing.Point(6, 6);
            this.ctrlCardConfig1.Margin = new System.Windows.Forms.Padding(11, 11, 11, 11);
            this.ctrlCardConfig1.Name = "ctrlCardConfig1";
            this.ctrlCardConfig1.Size = new System.Drawing.Size(910, 643);
            this.ctrlCardConfig1.TabIndex = 0;
            // 
            // ctrlMeasurement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabUstPomiaru);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.progressBar);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ctrlMeasurement";
            this.Size = new System.Drawing.Size(930, 801);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tabUstPomiaru.ResumeLayout(false);
            this.tabPunktyPomiarowe.ResumeLayout(false);
            this.splitRysPkt.Panel1.ResumeLayout(false);
            this.splitRysPkt.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRysPkt)).EndInit();
            this.splitRysPkt.ResumeLayout(false);
            this.tabMeasurementMethod.ResumeLayout(false);
            this.tabUstawieniaKarty.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.Button butStop;
        private System.Windows.Forms.Button butTest;
        private System.Windows.Forms.TabControl tabUstPomiaru;
        private System.Windows.Forms.TabPage tabPunktyPomiarowe;
        private System.Windows.Forms.TabPage tabUstawieniaKarty;
        private ctrlPunktyPom ctrlPunktyPom;
        private System.Windows.Forms.SplitContainer splitRysPkt;
        private imgPanel imgPanel1;
        private ctrlCardConfig ctrlCardConfig1;
        private System.Windows.Forms.TabPage tabMeasurementMethod;
        private ctrlMeasureConfig ctrlMeasureConfig1;
        private System.Windows.Forms.Timer timer1;
    }
}
