using System;
using System.Drawing;
using System.Windows.Forms;

namespace RoomMeasureNI.GUI
{
    [Serializable]
    public partial class imgPanel : UserControl
    {
        Project proj = Project.Instance;
        ctrlMeasurement parent;
        double ratio;

        public imgPanel()
        {
            InitializeComponent();
        }

        public void setParent(ctrlMeasurement _parent)
        {
            parent = _parent;
        }


        public Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

        private void wczytajObrazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "jpeg|*.jpeg|bitmap|*.bmp|jpg|*.jpg|png|*.png";
            openFileDialog1.Title = "Load an image file";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                proj.rysPlan = Image.FromFile(openFileDialog1.FileName, true);
            }
            this.Refresh();
        }

        private void imgPanel_Paint(object sender, PaintEventArgs e)
        {
            if (proj.rysPlan != null)
            {
                e.Graphics.DrawImage(ScaleImage(proj.rysPlan, this.Width, this.Height), new Point(0, 0));

                Pen pedzel_green=new Pen(Color.Green);
                pedzel_green.Width = 2;
                Pen pedzel_red = new Pen(Color.Red);
                pedzel_red.Width = 2;

                foreach (MeasurementPoint pkt in proj.punktyPomiarowe.listaPunktow)
                {
                    if (pkt.Aktywny)
                    {
                        e.Graphics.DrawEllipse(pedzel_green, (int)(pkt.X * ratio - 5), (int)(pkt.Y * ratio - 5), 10, 10);
                    }
                    else
                    {
                        e.Graphics.DrawEllipse(pedzel_red, (int)(pkt.X * ratio - 5), (int)(pkt.Y * ratio - 5), 10, 10);
                    }
                }
            }
        }

        private void imgPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (proj.rysPlan != null)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                Point coordinates = me.Location;

                coordinates.X = (int)(coordinates.X / ratio);
                coordinates.Y = (int)(coordinates.Y / ratio);

                MeasurementPoint ppom = new MeasurementPoint();
                ppom.X = coordinates.X;
                ppom.Y = coordinates.Y;
                ppom.Nazwa = "Punkt " + coordinates.X.ToString() + coordinates.Y.ToString() ;
                ppom.Aktywny = false;
                try { ppom.Kanal = proj.cardConfig.chConfig[0].chName; }
                catch (ArgumentOutOfRangeException) { }
                

                proj.punktyPomiarowe.listaPunktow.Add(ppom);
                parent.Odswiez();
            }
        }
    }
}
