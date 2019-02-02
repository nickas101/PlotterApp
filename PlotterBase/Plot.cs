using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public Plot(string[] x, string[,] y, string[] specArray, int i, string productNumber)
        {
            this.x = x;
            this.multyY = y;
            this.specArray = specArray;
            this.i = i;
            this.productNumber = productNumber;

            PreparePlot();
            DrowPlot();
        }

        public Plot(string[] x, string[] y, string[] specArray, int i, string productNumber)
        {
            this.x = x;
            this.singleY = y;
            this.specArray = specArray;
            this.i = i;
            this.productNumber = productNumber;

            PreparePlot();
            DrowPlot();
        }

        public void PreparePlot()
        {
            string[] specArray = this.specArray;
            double specRound = Math.Round(2 * Double.Parse(this.specArray[1]), 2);
            int i = this.i;

            Chart chart = new Chart();

            chart.Size = new System.Drawing.Size(this.plotSizeX, this.plotSizeY);
            ChartArea area = new ChartArea();
            chart.ChartAreas.Add(area);

            chart.BackColor = System.Drawing.Color.White; // Was Transparent
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;

            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;

            chart.ChartAreas[0].BackColor = Color.GhostWhite;

            // strip for upper limit
            StripLine upper_lower_strip = new StripLine();
            upper_lower_strip.Interval = 0;
            //upper_lower_strip.Text = "Spec limit";
            upper_lower_strip.IntervalOffset = Double.Parse(specArray[1]);
            upper_lower_strip.StripWidth = 0.00005;
            upper_lower_strip.BorderDashStyle = ChartDashStyle.Dash;
            upper_lower_strip.BackColor = Color.FromArgb(150, Color.Red);
            chart.ChartAreas[0].AxisY.StripLines.Add(upper_lower_strip);

            // strip for lower limit
            StripLine limit_lower_strip = new StripLine();
            limit_lower_strip.Interval = 0;
            //limit_lower_strip.Text = "Spec limit";
            limit_lower_strip.IntervalOffset = -Double.Parse(specArray[1]);
            limit_lower_strip.StripWidth = 0.00005;
            limit_lower_strip.BorderDashStyle = ChartDashStyle.Dash;
            limit_lower_strip.BackColor = Color.FromArgb(150, Color.Red);
            chart.ChartAreas[0].AxisY.StripLines.Add(limit_lower_strip);

            chart.BackColor = Color.Gray;
            chart.BackSecondaryColor = Color.WhiteSmoke;
            chart.BackGradientStyle = GradientStyle.DiagonalRight;

            chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;

            //chart.ChartAreas[0].AxisX.MajorGrid.Interval = 1;

            chart.ChartAreas[0].AxisY.Minimum = -specRound;
            chart.ChartAreas[0].AxisY.Maximum = specRound;

            chart.ChartAreas[0].AxisX.Title = "Temperature, C";
            chart.ChartAreas[0].AxisY.Title = "Frequency, ppm";
            
            this.chartImage = chart;
        }

        public virtual void DrowPlot()
        {
        }
    }
}
