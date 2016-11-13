namespace RoomMeasureNI.GUI
{
    partial class ctrlMeasureConfig
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
            this.comboMeasLength = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboMeasMethod = new System.Windows.Forms.ComboBox();
            this.groupMethod = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboFmax = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboFmin = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboGenerator = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboAverages = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupMethod.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboMeasLength
            // 
            this.comboMeasLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMeasLength.FormattingEnabled = true;
            this.comboMeasLength.Items.AddRange(new object[] {
            "1",
            "1,5",
            "2",
            "2,5",
            "3",
            "5",
            "10",
            "15",
            "30"});
            this.comboMeasLength.Location = new System.Drawing.Point(624, 37);
            this.comboMeasLength.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboMeasLength.Name = "comboMeasLength";
            this.comboMeasLength.Size = new System.Drawing.Size(218, 33);
            this.comboMeasLength.TabIndex = 1;
            this.comboMeasLength.SelectionChangeCommitted += new System.EventHandler(this.comboMeasLength_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboMeasLength);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboMeasMethod);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(874, 96);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ustawienia ogólne";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(898, -387);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Metoda pomiaru:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Długość pomiaru:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Metoda pomiaru:";
            // 
            // comboMeasMethod
            // 
            this.comboMeasMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMeasMethod.FormattingEnabled = true;
            this.comboMeasMethod.Items.AddRange(new object[] {
            "Rejestracja impulsu",
            "Sweep sine"});
            this.comboMeasMethod.Location = new System.Drawing.Point(196, 37);
            this.comboMeasMethod.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboMeasMethod.Name = "comboMeasMethod";
            this.comboMeasMethod.Size = new System.Drawing.Size(218, 33);
            this.comboMeasMethod.TabIndex = 0;
            this.comboMeasMethod.SelectionChangeCommitted += new System.EventHandler(this.comboMeasMethod_SelectionChangeCommitted);
            // 
            // groupMethod
            // 
            this.groupMethod.Controls.Add(this.label6);
            this.groupMethod.Controls.Add(this.comboFmax);
            this.groupMethod.Controls.Add(this.label5);
            this.groupMethod.Controls.Add(this.comboFmin);
            this.groupMethod.Controls.Add(this.label7);
            this.groupMethod.Controls.Add(this.comboGenerator);
            this.groupMethod.Controls.Add(this.label4);
            this.groupMethod.Controls.Add(this.comboAverages);
            this.groupMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupMethod.Enabled = false;
            this.groupMethod.Location = new System.Drawing.Point(0, 96);
            this.groupMethod.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupMethod.Name = "groupMethod";
            this.groupMethod.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupMethod.Size = new System.Drawing.Size(874, 610);
            this.groupMethod.TabIndex = 3;
            this.groupMethod.TabStop = false;
            this.groupMethod.Text = "Ustawienia metody";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(542, 137);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Fmax:";
            // 
            // comboFmax
            // 
            this.comboFmax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFmax.FormattingEnabled = true;
            this.comboFmax.Items.AddRange(new object[] {
            "Fs/2",
            "51200",
            "25600",
            "16000",
            "8000"});
            this.comboFmax.Location = new System.Drawing.Point(624, 131);
            this.comboFmax.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboFmax.Name = "comboFmax";
            this.comboFmax.Size = new System.Drawing.Size(218, 33);
            this.comboFmax.TabIndex = 0;
            this.comboFmax.SelectionChangeCommitted += new System.EventHandler(this.comboFmax_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 137);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "Fmin:";
            // 
            // comboFmin
            // 
            this.comboFmin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFmin.FormattingEnabled = true;
            this.comboFmin.Items.AddRange(new object[] {
            "10",
            "20",
            "40",
            "80"});
            this.comboFmin.Location = new System.Drawing.Point(196, 131);
            this.comboFmin.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboFmin.Name = "comboFmin";
            this.comboFmin.Size = new System.Drawing.Size(218, 33);
            this.comboFmin.TabIndex = 0;
            this.comboFmin.SelectionChangeCommitted += new System.EventHandler(this.comboFmin_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(96, 215);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 25);
            this.label7.TabIndex = 1;
            this.label7.Text = "Sygnał:";
            // 
            // comboGenerator
            // 
            this.comboGenerator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGenerator.FormattingEnabled = true;
            this.comboGenerator.Items.AddRange(new object[] {
            "Sweep wykładniczy"});
            this.comboGenerator.Location = new System.Drawing.Point(196, 210);
            this.comboGenerator.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboGenerator.Name = "comboGenerator";
            this.comboGenerator.Size = new System.Drawing.Size(218, 33);
            this.comboGenerator.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ilość uśrednień:";
            // 
            // comboAverages
            // 
            this.comboAverages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAverages.FormattingEnabled = true;
            this.comboAverages.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboAverages.Location = new System.Drawing.Point(196, 56);
            this.comboAverages.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboAverages.Name = "comboAverages";
            this.comboAverages.Size = new System.Drawing.Size(218, 33);
            this.comboAverages.TabIndex = 0;
            this.comboAverages.SelectionChangeCommitted += new System.EventHandler(this.comboAverages_SelectionChangeCommitted);
            // 
            // ctrlMeasureConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupMethod);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ctrlMeasureConfig";
            this.Size = new System.Drawing.Size(874, 706);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupMethod.ResumeLayout(false);
            this.groupMethod.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboMeasLength;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboMeasMethod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupMethod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboFmax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboFmin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboAverages;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboGenerator;
    }
}
