using System;
using System.Drawing;
using System.Windows.Forms;
using RoomMeasureNI.Sources.Measurement;
using RoomMeasureNI.Sources.Project;

namespace RoomMeasureNI.GUI.subMeasurement
{
    [Serializable]
    public partial class imgPanel : UserControl
    {
        private readonly Project proj = Project.Instance;
        private ctrlMeasurement parent;
        private double ratio;

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
            var ratioX = (double) maxWidth / image.Width;
            var ratioY = (double) maxHeight / image.Height;
            ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int) (image.Width * ratio);
            var newHeight = (int) (image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        private void wczytajObrazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "jpeg|*.jpeg|bitmap|*.bmp|jpg|*.jpg|png|*.png";
            openFileDialog1.Title = "Load an image file";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
                proj.drawingSchema = Image.FromFile(openFileDialog1.FileName, true);
            Refresh();
        }

        private void imgPanel_Paint(object sender, PaintEventArgs e)
        {
            if (proj.drawingSchema != null)
            {
                e.Graphics.DrawImage(ScaleImage(proj.drawingSchema, Width, Height), new Point(0, 0));

                var pedzel_green = new Pen(Color.Green);
                pedzel_green.Width = 2;
                var pedzel_red = new Pen(Color.Red);
                pedzel_red.Width = 2;

                foreach (var pkt in proj.punktyPomiarowe.listaPunktow)
                    if (pkt.Aktywny)
                        e.Graphics.DrawEllipse(pedzel_green, (int) (pkt.X * ratio - 5), (int) (pkt.Y * ratio - 5), 10,
                            10);
                    else
                        e.Graphics.DrawEllipse(pedzel_red, (int) (pkt.X * ratio - 5), (int) (pkt.Y * ratio - 5), 10, 10);
            }
        }

        private void imgPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (proj.drawingSchema != null)
            {
                var me = e;
                var coordinates = me.Location;

                coordinates.X = (int) (coordinates.X / ratio);
                coordinates.Y = (int) (coordinates.Y / ratio);

                var ppom = new MeasurementPoint();
                ppom.X = coordinates.X;
                ppom.Y = coordinates.Y;
                ppom.Nazwa = "Punkt " + coordinates.X + coordinates.Y;
                ppom.Aktywny = false;
                try
                {
                    ppom.Kanal = proj.cardConfig.chConfig[0].chName;
                }
                catch (ArgumentOutOfRangeException)
                {
                }


                proj.punktyPomiarowe.listaPunktow.Add(ppom);
                parent.Odswiez();
            }
        }
    }
}