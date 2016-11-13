using System;
using System.Data;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using RoomMeasureNI.Sources.ButterworthFilterDesign;

namespace RoomMeasureNI
{
    public partial class ctrlPlotPanel : UserControl
    {
        private OxyPlot.WindowsForms.PlotView plot1;
        
        /// <summary>
        /// Default constructor for ctrlPlotPanel 
        /// </summary>
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

        /// <summary>
        /// Sets data to plot
        /// </summary>
        /// <param name="input">Input dataTable</param>
        /// <param name="x_name">x parameter column name</param>
        /// <param name="y_name">y parameter column name</param>
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

        /// <summary>
        /// Sets data to plot from two arrays
        /// </summary>
        /// <param name="X">Array of x values</param>
        /// <param name="Y">Array of y values</param>
        public void setData(double[] X, double[] Y, string label = null)
        {
            var myModel = new PlotModel { };
            LineSeries data = new LineSeries();
            DataPoint[] XYpoint = new DataPoint[X.Length];

            for (int i = 0; i < X.Length; i++)
            {
                XYpoint[i] = new DataPoint(X[i], Y[i]);
            }
            data.Points.AddRange(XYpoint);
            data.Title = label;
            myModel.Series.Add(data);

            LinearAxis osX = new LinearAxis();
            LinearAxis osY = new LinearAxis();

            osX.Position = AxisPosition.Bottom;
            osY.Position = AxisPosition.Left;

            myModel.Axes.Clear();
            myModel.Axes.Add(osX);
            myModel.Axes.Add(osY);

            this.plot1.Model = myModel;
        }

        /// <summary>
        /// Adds series to existing plot
        /// </summary>
        /// <param name="X">Array of X values to add</param>
        /// <param name="Y">Array of Y values to add</param>
        public void addSeries(double[] X, double[] Y, string label=null, LineStyle style = LineStyle.Automatic)
        {
            LineSeries data = new LineSeries();          
            DataPoint[] XYpoint = new DataPoint[X.Length];

            for (int i = 0; i < X.Length; i++)
            {
                XYpoint[i] = new DataPoint(X[i], Y[i]);
            }
            data.Points.AddRange(XYpoint);
            data.LineStyle = style;
            data.Title = label;
            
            this.plot1.Model.Series.Add(data);
        }

        /// <summary>
        /// Sets X axis to log scale.
        /// </summary>
        /// <param name="clear">If true removes old axis</param>
        public void setXlog(bool clear)
        {
            LogarithmicAxis os = new LogarithmicAxis();
            os.Position = AxisPosition.Bottom;
            if(clear) plot1.Model.Axes.Clear();
            plot1.Model.Axes.Add(os);
        }

        /// <summary>
        /// Sets Y axis to log scale
        /// </summary>
        /// <param name="clear">If true removes old axis</param>
        public void setYlog(bool clear)
        {
            LogarithmicAxis os = new LogarithmicAxis();
            os.Position = AxisPosition.Left;
            if (clear) plot1.Model.Axes.Clear();
            plot1.Model.Axes.Add(os);
        }

        /// <summary>
        /// Sets X and Y axes to log scale.
        /// </summary>
        /// <param name="clear">If true removes old axes</param>
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

        /// <summary>
        /// Sets X axis limits.
        /// </summary>
        /// <param name="Min">Min axis value</param>
        /// <param name="Max">Max axis value</param>
        public void setXlimits(int Min, int Max)
        {
            plot1.Model.Axes[0].Minimum = Min;
            plot1.Model.Axes[0].Maximum = Max;
        }

        /// <summary>
        /// Sets Y axis limits.
        /// </summary>
        /// <param name="Min">Min axis value</param>
        /// <param name="Max">Max axis value</param>
        public void setYlimits(int Min, int Max)
        {
            plot1.Model.Axes[1].Minimum = Min;
            plot1.Model.Axes[1].Maximum = Max;
        }

        /// <summary>
        /// Adds grid to plot.
        /// </summary>
        public void showGrid()
        {
            plot1.Model.Axes[0].MajorGridlineStyle = LineStyle.Dash;
            plot1.Model.Axes[1].MajorGridlineStyle = LineStyle.Dash;
        }

        public void addCustomLabelAxis(string[] labels)
        {
            CategoryAxis categoryAxis = new CategoryAxis();
            LinearAxis osY = new LinearAxis();

            categoryAxis.Position = AxisPosition.Bottom;
            categoryAxis.Angle = -90;
            osY.Position = AxisPosition.Left;

            foreach (string s in labels)
            {
                categoryAxis.ActualLabels.Add(s);
            }

            plot1.Model.Axes.Clear();
            plot1.Model.Axes.Add(categoryAxis);
            plot1.Model.Axes.Add(osY);
        }

        public void setThirdOctaveAxis()
        {
            int i = 0;
            string[] labels = new string[Enum.GetNames(typeof(CenterFreqTO)).Length];
            foreach (CenterFreqTO freq in Enum.GetValues(typeof(CenterFreqTO)))
            {
                labels[i++] = freq.GetDescription();
            }

            addCustomLabelAxis(labels);
        }

        public void Reset()
        {
            var myModel = new PlotModel { };
            plot1.Model = myModel;
        }
    }
}
