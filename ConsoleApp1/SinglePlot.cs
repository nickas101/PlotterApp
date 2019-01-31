using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ConsoleApp1
{
    class SinglePlot
    {
        private string[] x;
        private string[] y;
        private string[] spec;
        private string spc;
        private int i;

        private Chart chart;

        public Chart Chrt
        {
            get
            {
                return chart;
            }

            set
            {
                chart = value;
            }
        }

        public SinglePlot(string[] x, string[] y, string[] spec, int i, string spc)
        {
            this.x = x;
            this.y = y;
            this.spec = spec;
            this.i = i;
            this.spc = spc;

            DrowSinglePlot();
        }

        public void DrowSinglePlot()
        {

            string[] x = this.x;
            string[] y = this.y;
            string[] spec = this.spec;

            Chart chart = new Chart();

            chart.Size = new System.Drawing.Size(1000, 500);
            ChartArea area = new ChartArea();
            chart.ChartAreas.Add(area);

            chart.BackColor = System.Drawing.Color.White; // Was Transparent
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;

            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;

            chart.ChartAreas[0].BackColor = Color.GhostWhite;

            chart.Titles.Add(spc + "  Unit#" + i.ToString());
            chart.Titles[0].Font = new Font("Arial", 14, FontStyle.Bold);


            // strip for upper limit
            StripLine upper_lower_strip = new StripLine();
            upper_lower_strip.Interval = 0;
            //upper_lower_strip.Text = "Spec limit";
            upper_lower_strip.IntervalOffset = Double.Parse(spec[1]);
            upper_lower_strip.StripWidth = 0.00005;
            upper_lower_strip.BorderDashStyle = ChartDashStyle.Dash;
            upper_lower_strip.BackColor = Color.FromArgb(150, Color.Red);
            chart.ChartAreas[0].AxisY.StripLines.Add(upper_lower_strip);

            // strip for lower limit
            StripLine limit_lower_strip = new StripLine();
            limit_lower_strip.Interval = 0;
            //limit_lower_strip.Text = "Spec limit";
            limit_lower_strip.IntervalOffset = -Double.Parse(spec[1]);
            limit_lower_strip.StripWidth = 0.00005;
            limit_lower_strip.BorderDashStyle = ChartDashStyle.Dash;
            limit_lower_strip.BackColor = Color.FromArgb(150, Color.Red);
            chart.ChartAreas[0].AxisY.StripLines.Add(limit_lower_strip);



            chart.BackColor = Color.Gray;
            chart.BackSecondaryColor = Color.WhiteSmoke;
            chart.BackGradientStyle = GradientStyle.DiagonalRight;

            //chart.PlotArea.LineFormat.Color = XColors.DarkGray;

            chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;

            //chart.ChartAreas[0].AxisX.MajorGrid.Interval = 1;

            chart.ChartAreas[0].AxisY.Minimum = -.01;
            chart.ChartAreas[0].AxisY.Maximum = .01;

            //chart.ChartAreas[0].AxisX.MajorGrid.LineColor.IsNamedColor.Equals.

            chart.ChartAreas[0].AxisX.Title = "Temperature, C";
            chart.ChartAreas[0].AxisY.Title = "Frequency, ppm";

            //Legend legend = new Legend()
            //{
            //    Name = "Legend1",
            //};

            //Legend legend1 = new Legend("Legend1");
            //LegendItem legendItem1 = new LegendItem("Under Performance", Color.Red, "");
            //legendItem1.BorderColor = Color.Red;

            //chart.Legends.Add(legend1);

            //chart.Legends["Legend1"].Docking = Docking.Bottom;

            //chart.Legends.Add

            //chart.LegendTitle = "Title";

            Series series = new Series()
            {
                Name = "series1",
                IsVisibleInLegend = true,  // ???????
                //IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Spline
            };

            Series series2 = new Series()
            {
                Name = "series2",
                IsVisibleInLegend = true,
                //IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Line

                //BorderDashStyle = ChartDashStyle.Dash

            };

            Series series3 = new Series()
            {
                Name = "series3",
                IsVisibleInLegend = true,
                //IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Line
            };

            chart.Series.Add(series);
            //chart.Series.Add(series2);
            //chart.Series.Add(series3);

            //chart.Series["series1"].BorderWidth = Chart
            //chart.Series["series2"].BorderDashStyle = ChartDashStyle.Dash;
            //chart.Series["series3"].BorderDashStyle = ChartDashStyle.Dash;

            //chart.Series[0].Name = "Подача";

            //series.LegendTitle = "Title";

            for (int i = 0; i < x.Length; i++)
            {

                if (y[i] != null)
                {
                    DataPoint p1 = new DataPoint(0, Double.Parse(y[i]));
                    p1.Color = System.Drawing.Color.Blue;
                    p1.BorderWidth = 2;
                    p1.AxisLabel = x[i];
                    //series.Points[2].LegendText = "Unit#1";
                    series.Points.Add(p1);
                    //p1.LegendText = "Legend";
                    p1.Color = System.Drawing.Color.Blue;
                    p1.LegendText = "Unit#1";

                    //this.chart.DisplayLegend = true;
                    //this.chart1.LegendTitle = "Title";
                    //p1.LegendText[0] = new Font("Arial", 14, FontStyle.Bold);
                }

                //if (spec[i] != null)
                //{
                //    DataPoint p3 = new DataPoint(0, Double.Parse(spec[i]));
                //    p3.Color = System.Drawing.Color.Red;
                //    p3.AxisLabel = x[i];
                //    series2.Points.Add(p3);
                //    p3.LegendText = "Legend";

                //    DataPoint p4 = new DataPoint(0, -Double.Parse(spec[i]));
                //    p4.Color = System.Drawing.Color.Red;
                //    p4.AxisLabel = x[i];
                //    series3.Points.Add(p4);
                //    p4.LegendText = "Legend";
                //}



                //DataPoint p2 = new DataPoint(0, Double.Parse("0"));

                //p2.Color = System.Drawing.Color.LightBlue;
                //p1.AxisLabel = item.Kod;
                //p1.LegendText = item.Kod;
                // p1.Label = item.Kurz;

                //p1.AxisLabel = "Axis";


                //p1.Label = "Label";


                //series2.Points.Add(p2);


                //Console.Write(plot.Y[2, i] + "\n");
                //Console.ReadKey();

            }

            //Console.Write(plot.X[0, i].Length + "\n");
            //Console.ReadKey();


            //int i = 0;

            //foreach (string item in plot.X[0,i])
            //{
            //     //DataPoint p1 = new DataPoint(0, Double.Parse(item.Kurz));
            //     DataPoint p1 = new DataPoint(0, Double.Parse(item));
            //    DataPoint p2 = new DataPoint(0, Double.Parse("0"));
            //    p1.Color = System.Drawing.Color.Blue;
            //    p2.Color = System.Drawing.Color.LightBlue;
            //    //p1.AxisLabel = item.Kod;
            //    //p1.LegendText = item.Kod;
            //    // p1.Label = item.Kurz;

            //    //p1.AxisLabel = "Axis";
            //    p1.AxisLabel = item;
            //    p1.LegendText = "Legend";
            //     //p1.Label = "Label";

            //    series.Points.Add(p1);
            //    series2.Points.Add(p2);

            //}

            //DirectoryInfo d = new DirectoryInfo(@"D:\Plots");
            //d.Create();

            //string filename = "D:\\Plots/Chart.png";
            //chart.SaveImage(filename, ChartImageFormat.Png);

            this.chart = chart;

        }
    }
}
