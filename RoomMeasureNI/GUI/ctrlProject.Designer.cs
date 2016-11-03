namespace RoomMeasureNI.GUI
{
    partial class ctrlProject
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
            this.tableProjektInfo = new System.Windows.Forms.TableLayoutPanel();
            this.textAdres = new System.Windows.Forms.TextBox();
            this.textZleceniodawca = new System.Windows.Forms.TextBox();
            this.lblNazwa = new System.Windows.Forms.Label();
            this.textNazwa = new System.Windows.Forms.TextBox();
            this.lblZleceniodawca = new System.Windows.Forms.Label();
            this.lblAdres = new System.Windows.Forms.Label();
            this.lblOpis = new System.Windows.Forms.Label();
            this.textOpis = new System.Windows.Forms.TextBox();
            this.tableProjektInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableProjektInfo
            // 
            this.tableProjektInfo.AutoSize = true;
            this.tableProjektInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableProjektInfo.ColumnCount = 2;
            this.tableProjektInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableProjektInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableProjektInfo.Controls.Add(this.textAdres, 0, 4);
            this.tableProjektInfo.Controls.Add(this.textZleceniodawca, 1, 1);
            this.tableProjektInfo.Controls.Add(this.lblNazwa, 0, 0);
            this.tableProjektInfo.Controls.Add(this.textNazwa, 1, 0);
            this.tableProjektInfo.Controls.Add(this.lblZleceniodawca, 0, 1);
            this.tableProjektInfo.Controls.Add(this.lblAdres, 0, 4);
            this.tableProjektInfo.Controls.Add(this.lblOpis, 0, 5);
            this.tableProjektInfo.Controls.Add(this.textOpis, 1, 5);
            this.tableProjektInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableProjektInfo.Location = new System.Drawing.Point(0, 0);
            this.tableProjektInfo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tableProjektInfo.Name = "tableProjektInfo";
            this.tableProjektInfo.RowCount = 6;
            this.tableProjektInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableProjektInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableProjektInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableProjektInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableProjektInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableProjektInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableProjektInfo.Size = new System.Drawing.Size(702, 635);
            this.tableProjektInfo.TabIndex = 0;
            // 
            // textAdres
            // 
            this.textAdres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textAdres.Location = new System.Drawing.Point(174, 92);
            this.textAdres.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textAdres.Name = "textAdres";
            this.textAdres.Size = new System.Drawing.Size(522, 31);
            this.textAdres.TabIndex = 3;
            this.textAdres.TextChanged += new System.EventHandler(this.textAdres_TextChanged);
            // 
            // textZleceniodawca
            // 
            this.textZleceniodawca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textZleceniodawca.Location = new System.Drawing.Point(174, 49);
            this.textZleceniodawca.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textZleceniodawca.Name = "textZleceniodawca";
            this.textZleceniodawca.Size = new System.Drawing.Size(522, 31);
            this.textZleceniodawca.TabIndex = 2;
            this.textZleceniodawca.TextChanged += new System.EventHandler(this.textZleceniodawca_TextChanged);
            // 
            // lblNazwa
            // 
            this.lblNazwa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNazwa.AutoSize = true;
            this.lblNazwa.Location = new System.Drawing.Point(45, 9);
            this.lblNazwa.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNazwa.Name = "lblNazwa";
            this.lblNazwa.Size = new System.Drawing.Size(77, 25);
            this.lblNazwa.TabIndex = 0;
            this.lblNazwa.Text = "Nazwa";
            // 
            // textNazwa
            // 
            this.textNazwa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textNazwa.Location = new System.Drawing.Point(174, 6);
            this.textNazwa.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textNazwa.Name = "textNazwa";
            this.textNazwa.Size = new System.Drawing.Size(522, 31);
            this.textNazwa.TabIndex = 1;
            this.textNazwa.TextChanged += new System.EventHandler(this.textNazwa_TextChanged);
            // 
            // lblZleceniodawca
            // 
            this.lblZleceniodawca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblZleceniodawca.AutoSize = true;
            this.lblZleceniodawca.Location = new System.Drawing.Point(6, 52);
            this.lblZleceniodawca.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblZleceniodawca.Name = "lblZleceniodawca";
            this.lblZleceniodawca.Size = new System.Drawing.Size(156, 25);
            this.lblZleceniodawca.TabIndex = 0;
            this.lblZleceniodawca.Text = "Zleceniodawca";
            // 
            // lblAdres
            // 
            this.lblAdres.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAdres.AutoSize = true;
            this.lblAdres.Location = new System.Drawing.Point(50, 98);
            this.lblAdres.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAdres.Name = "lblAdres";
            this.lblAdres.Size = new System.Drawing.Size(68, 25);
            this.lblAdres.TabIndex = 0;
            this.lblAdres.Text = "Adres";
            // 
            // lblOpis
            // 
            this.lblOpis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOpis.AutoSize = true;
            this.lblOpis.Location = new System.Drawing.Point(56, 373);
            this.lblOpis.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblOpis.Name = "lblOpis";
            this.lblOpis.Size = new System.Drawing.Size(56, 25);
            this.lblOpis.TabIndex = 0;
            this.lblOpis.Text = "Opis";
            // 
            // textOpis
            // 
            this.textOpis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textOpis.Location = new System.Drawing.Point(174, 142);
            this.textOpis.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textOpis.Multiline = true;
            this.textOpis.Name = "textOpis";
            this.textOpis.Size = new System.Drawing.Size(522, 487);
            this.textOpis.TabIndex = 4;
            this.textOpis.TextChanged += new System.EventHandler(this.textOpis_TextChanged);
            // 
            // ctrlProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableProjektInfo);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ctrlProject";
            this.Size = new System.Drawing.Size(702, 635);
            this.tableProjektInfo.ResumeLayout(false);
            this.tableProjektInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableProjektInfo;
        private System.Windows.Forms.TextBox textAdres;
        private System.Windows.Forms.TextBox textZleceniodawca;
        private System.Windows.Forms.Label lblNazwa;
        private System.Windows.Forms.Label lblZleceniodawca;
        private System.Windows.Forms.Label lblAdres;
        private System.Windows.Forms.Label lblOpis;
        private System.Windows.Forms.TextBox textNazwa;
        private System.Windows.Forms.TextBox textOpis;
    }
}
