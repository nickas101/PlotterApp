using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace PlotterBase
{
    class Plot
    {
        protected string[] x;
        protected string[] singleY;
        protected string[,] multyY;
        protected string[] specArray;
        protected string productNumber;
        protected int i;
        protected int plotSizeX = 1000;
        protected int plotSizeY = 500;

        protected Chart chartImage;

        public Chart ChartImage
        {
            get
            {
                return chartImage;
            }

            set
            {
                chartImage = value;
            }
        }

        public Plot(string[] x, string[,] y, string[] specArray, string productNumber)
        {
            this.x = x;
            this.multyY = y;
            this.specArray = specArray;
            this.productNumber = productNumber;

            PreparePlot();
            DrawPlot();
        }

        public Plot(string[] x, string[] y, string[] specArray, int i, string productNumber)
        {
            this.x = x;
            this.singleY = y;
            this.specArray = specArray;
            this.i = i;
            this.productNumber = productNumber;

            PreparePlot();
            DrawPlot();
        }

        protected void PreparePlot()
        {
            string[] specArray = this.specArray;
            double specRound = Math.Round(2 * Double.Parse(this.specArray[1]), 2);

            var chart = new Chart
            {
                Size = new System.Drawing.Size(this.plotSizeX, this.plotSizeY),
                BackColor = Color.Gray,
                BackSecondaryColor = Color.WhiteSmoke,
                BackGradientStyle = GradientStyle.DiagonalRight,
                BorderSkin = {SkinStyle = BorderSkinStyle.Emboss}
            };
           
            var area = new ChartArea();
            chart.ChartAreas.Add(area);
    
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;

            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;

            chart.ChartAreas[0].BackColor = Color.GhostWhite;

            // strip for upper limit
            var limitUpperStrip = new StripLine
            {
                Interval = 0,
                IntervalOffset = double.Parse(specArray[1]),
                StripWidth = 0.00005,
                BorderDashStyle = ChartDashStyle.Dash,
                BackColor = Color.FromArgb(150, Color.Red),
                //Text = "Spec limit"
            };

            chart.ChartAreas[0].AxisY.StripLines.Add(limitUpperStrip);

            // strip for lower limit
            var limitLowerStrip = new StripLine
            {
                Interval = 0,
                IntervalOffset = -double.Parse(specArray[1]),
                StripWidth = 0.00005,
                BorderDashStyle = ChartDashStyle.Dash,
                BackColor = Color.FromArgb(150, Color.Red),
                //Text = "Spec limit"
            };
            
            chart.ChartAreas[0].AxisY.StripLines.Add(limitLowerStrip);

            //chart.ChartAreas[0].AxisX.MajorGrid.Interval = 1;

            chart.ChartAreas[0].AxisY.Minimum = -specRound;
            chart.ChartAreas[0].AxisY.Maximum = specRound;

            chart.ChartAreas[0].AxisX.Title = "Temperature, C";
            chart.ChartAreas[0].AxisY.Title = "Frequency, ppm";
            
            this.chartImage = chart;
        }

        protected virtual void DrawPlot()
        {
        }
    }
}
