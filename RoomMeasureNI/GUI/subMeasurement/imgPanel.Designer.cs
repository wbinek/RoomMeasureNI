namespace RoomMeasureNI.GUI.subMeasurement
{
    partial class imgPanel
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
            this.contextImgMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.wczytajObrazToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextImgMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextImgMenu
            // 
            this.contextImgMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wczytajObrazToolStripMenuItem});
            this.contextImgMenu.Name = "contextImgMenu";
            this.contextImgMenu.Size = new System.Drawing.Size(148, 26);
            // 
            // wczytajObrazToolStripMenuItem
            // 
            this.wczytajObrazToolStripMenuItem.Name = "wczytajObrazToolStripMenuItem";
            this.wczytajObrazToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.wczytajObrazToolStripMenuItem.Text = "Wczytaj obraz";
            this.wczytajObrazToolStripMenuItem.Click += new System.EventHandler(this.wczytajObrazToolStripMenuItem_Click);
            // 
            // imgPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextImgMenu;
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Name = "imgPanel";
            this.Size = new System.Drawing.Size(435, 361);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.imgPanel_Paint);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.imgPanel_MouseDoubleClick);
            this.contextImgMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextImgMenu;
        private System.Windows.Forms.ToolStripMenuItem wczytajObrazToolStripMenuItem;
    }
}
