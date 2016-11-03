using System;
using System.Data;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace RoomMeasureNI
{
    public partial class ctrlPlotPanel : UserControl
    {
        private OxyPlot.WindowsForms.PlotView plot1;

        public ctrlPlotPanel()
        {
            InitializeComponent();
            plot1 = new OxyPlot.WindowsForms.PlotView();

            this.plot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(this.plot1);

            var myModel = new PlotModel();
            myModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
            this.plot1.Model = myModel;
        }

        public void setData(DataTable input,string x_name,string y_name)
        {
            var myModel = new PlotModel();
            LineSeries data= new LineSeries();
            data.MinimumSegmentLength = 15;
            data.StrokeThickness = 1;

            for(int i=0; i<input.Rows.Count; i++)
            {
                DataPoint XYpoint = new DataPoint((double)input.Rows[i][x_name], (double)input.Rows[i][y_name]);
                data.Points.Add(XYpoint);
            }
            myModel.Series.Add(data);

            this.plot1.Model = myModel;
        }

        public void setData(double[] X, double[] Y)
        {
            var myModel = new PlotModel { };
            LineSeries data = new LineSeries();
            DataPoint[] XYpoint = new DataPoint[X.Length];

            for (int i = 0; i < X.Length; i++)
            {
                XYpoint[i] = new DataPoint(X[i], Y[i]);
            }
            data.Points.AddRange(XYpoint);
            myModel.Series.Add(data);

            this.plot1.Model = myModel;
        }

        public void addSeries(double[] X, double[] Y)
        {
            LineSeries data = new LineSeries();
            data.LineStyle = LineStyle.Dash;
            DataPoint[] XYpoint = new DataPoint[X.Length];

            for (int i = 0; i < X.Length; i++)
            {
                XYpoint[i] = new DataPoint(X[i], Y[i]);
            }
            data.Points.AddRange(XYpoint);
            this.plot1.Model.Series.Add(data);
        }

        public void setXlog(bool clear)
        {
            LogarithmicAxis os = new LogarithmicAxis();
            os.Position = AxisPosition.Bottom;
            if(clear) plot1.Model.Axes.Clear();
            plot1.Model.Axes.Add(os);
        }

        public void setYlog(bool clear)
        {
            LogarithmicAxis os = new LogarithmicAxis();
            os.Position = AxisPosition.Left;
            if (clear) plot1.Model.Axes.Clear();
            plot1.Model.Axes.Add(os);
        }

        public void setXYlog(bool clear)
        {
            LogarithmicAxis osX = new LogarithmicAxis();
            LogarithmicAxis osY = new LogarithmicAxis();

            osX.Position = AxisPosition.Bottom;
            osY.Position = AxisPosition.Left;

            if (clear) plot1.Model.Axes.Clear();
            plot1.Model.Axes.Add(osX);
            plot1.Model.Axes.Add(osY);
        }

        public void setXlimits(int Min, int Max)
        {
            plot1.Model.Axes[0].Minimum = Min;
            plot1.Model.Axes[0].Maximum = Max;
        }

        public void setYlimits(int Min, int Max)
        {
            plot1.Model.Axes[1].Minimum = Min;
            plot1.Model.Axes[1].Maximum = Max;
        }

        public void showGrid()
        {
            plot1.Model.Axes[0].MajorGridlineStyle = LineStyle.Dash;
            plot1.Model.Axes[1].MajorGridlineStyle = LineStyle.Dash;
        }
    }
}
