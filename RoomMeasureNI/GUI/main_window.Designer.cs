namespace RoomMeasureNI.GUI
{
    partial class main_window
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszJakoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabProjekt = new System.Windows.Forms.TabPage();
            this.ctrlProjekt1 = new RoomMeasureNI.GUI.ctrlProject();
            this.tabPomiar = new System.Windows.Forms.TabPage();
            this.ctrlPomiar1 = new RoomMeasureNI.GUI.ctrlMeasurement();
            this.tabWyniki = new System.Windows.Forms.TabPage();
            this.ctrlResults1 = new RoomMeasureNI.GUI.ctrlResults();
            this.menuStrip1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabProjekt.SuspendLayout();
            this.tabPomiar.SuspendLayout();
            this.tabWyniki.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1108, 44);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzToolStripMenuItem,
            this.zapiszToolStripMenuItem,
            this.zapiszJakoToolStripMenuItem,
            this.zamknijToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // otwórzToolStripMenuItem
            // 
            this.otwórzToolStripMenuItem.Name = "otwórzToolStripMenuItem";
            this.otwórzToolStripMenuItem.Size = new System.Drawing.Size(233, 38);
            this.otwórzToolStripMenuItem.Text = "Otwórz";
            this.otwórzToolStripMenuItem.Click += new System.EventHandler(this.otwórzToolStripMenuItem_Click);
            // 
            // zapiszToolStripMenuItem
            // 
            this.zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            this.zapiszToolStripMenuItem.Size = new System.Drawing.Size(233, 38);
            this.zapiszToolStripMenuItem.Text = "Zapisz";
            this.zapiszToolStripMenuItem.Click += new System.EventHandler(this.zapiszToolStripMenuItem_Click);
            // 
            // zapiszJakoToolStripMenuItem
            // 
            this.zapiszJakoToolStripMenuItem.Name = "zapiszJakoToolStripMenuItem";
            this.zapiszJakoToolStripMenuItem.Size = new System.Drawing.Size(233, 38);
            this.zapiszJakoToolStripMenuItem.Text = "Zapisz jako";
            this.zapiszJakoToolStripMenuItem.Click += new System.EventHandler(this.zapiszJakoToolStripMenuItem_Click);
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(233, 38);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabProjekt);
            this.tabMain.Controls.Add(this.tabPomiar);
            this.tabMain.Controls.Add(this.tabWyniki);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 44);
            this.tabMain.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1108, 1054);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 1;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabProjekt
            // 
            this.tabProjekt.Controls.Add(this.ctrlProjekt1);
            this.tabProjekt.Location = new System.Drawing.Point(8, 39);
            this.tabProjekt.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabProjekt.Name = "tabProjekt";
            this.tabProjekt.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabProjekt.Size = new System.Drawing.Size(1092, 1007);
            this.tabProjekt.TabIndex = 0;
            this.tabProjekt.Text = "Projekt";
            this.tabProjekt.UseVisualStyleBackColor = true;
            // 
            // ctrlProjekt1
            // 
            this.ctrlProjekt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlProjekt1.Location = new System.Drawing.Point(6, 6);
            this.ctrlProjekt1.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.ctrlProjekt1.Name = "ctrlProjekt1";
            this.ctrlProjekt1.Size = new System.Drawing.Size(1080, 995);
            this.ctrlProjekt1.TabIndex = 0;
            // 
            // tabPomiar
            // 
            this.tabPomiar.Controls.Add(this.ctrlPomiar1);
            this.tabPomiar.Location = new System.Drawing.Point(8, 39);
            this.tabPomiar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPomiar.Name = "tabPomiar";
            this.tabPomiar.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPomiar.Size = new System.Drawing.Size(1092, 1005);
            this.tabPomiar.TabIndex = 1;
            this.tabPomiar.Text = "Pomiar";
            this.tabPomiar.UseVisualStyleBackColor = true;
            // 
            // ctrlPomiar1
            // 
            this.ctrlPomiar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPomiar1.Location = new System.Drawing.Point(6, 6);
            this.ctrlPomiar1.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.ctrlPomiar1.Name = "ctrlPomiar1";
            this.ctrlPomiar1.Size = new System.Drawing.Size(1080, 993);
            this.ctrlPomiar1.TabIndex = 0;
            // 
            // tabWyniki
            // 
            this.tabWyniki.Controls.Add(this.ctrlResults1);
            this.tabWyniki.Location = new System.Drawing.Point(8, 39);
            this.tabWyniki.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabWyniki.Name = "tabWyniki";
            this.tabWyniki.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabWyniki.Size = new System.Drawing.Size(1092, 1007);
            this.tabWyniki.TabIndex = 2;
            this.tabWyniki.Text = "Wyniki";
            this.tabWyniki.UseVisualStyleBackColor = true;
            // 
            // ctrlResults1
            // 
            this.ctrlResults1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlResults1.Location = new System.Drawing.Point(6, 6);
            this.ctrlResults1.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.ctrlResults1.MinimumSize = new System.Drawing.Size(780, 1000);
            this.ctrlResults1.Name = "ctrlResults1";
            this.ctrlResults1.Size = new System.Drawing.Size(1080, 1000);
            this.ctrlResults1.TabIndex = 0;
            // 
            // main_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 1098);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MinimumSize = new System.Drawing.Size(1114, 1108);
            this.Name = "main_window";
            this.Text = "main_window";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabProjekt.ResumeLayout(false);
            this.tabPomiar.ResumeLayout(false);
            this.tabWyniki.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otwórzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabProjekt;
        private System.Windows.Forms.TabPage tabPomiar;
        private System.Windows.Forms.TabPage tabWyniki;
        private GUI.ctrlProject ctrlProjekt1;
        private GUI.ctrlMeasurement ctrlPomiar1;
        private System.Windows.Forms.ToolStripMenuItem zapiszJakoToolStripMenuItem;
        private GUI.ctrlResults ctrlResults1;
    }
}