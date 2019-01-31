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
    class MultyPlot
    {






        private string[] x;
        private string[,] y;
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

        public MultyPlot(string[] x, string[,] y, string[] spec, int i, string spc)
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
            string[,] y = this.y;
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

            chart.Titles.Add(spc + "  All Units");
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

            chart.ChartAreas[0].AxisX.Title = "Temperature, C";
            chart.ChartAreas[0].AxisY.Title = "Frequency, ppm";

            Legend legend1 = new Legend("Legend1");
            legend1.Font = new Font("Arial", 10);
            //LegendItem legendItem1 = new LegendItem("Under Performance", Color.Red, "");
            //legendItem1.BorderColor = Color.Red;

            chart.Legends.Add(legend1);

            //legend1.CustomItems.Add(legendItem1);

            for (int j = 1; j < y.GetLength(0); j++)
            {
                //string[] colors = {"Yellow", "YellowGreen", "Pink", "LightCyan", "SeaGreen", "Violet",
                //    "Pink", "RoyalBlue", "Salmon", "Goldenrod" };

                if (y[j, 1] != null)
                {

                    Series series = new Series()
                    {
                        Name = "Unit#" + j.ToString(),
                        IsVisibleInLegend = true,  // ???????
                        ChartType = SeriesChartType.Spline
                    };

                    chart.Series.Add(series);

                    for (int i = 0; i < x.Length; i++)
                    {
                        if (y[j, i] != null)
                        {
                            DataPoint p1 = new DataPoint(0, Double.Parse(y[j, i]));
                            p1.Color = Color.Blue;
                            p1.BorderWidth = 2;
                            p1.AxisLabel = x[i];
                            //p1.LegendText = "Unit#1";
                            series.Points.Add(p1);

                            //p1.LegendText = "Legend";

                            switch (j)
                            {
                                case 1:
                                    p1.Color = Color.Yellow;
                                    break;
                                case 2:
                                    p1.Color = Color.YellowGreen;
                                    break;
                                case 3:
                                    p1.Color = Color.Pink;
                                    break;
                                case 4:
                                    p1.Color = Color.LightCyan;
                                    break;
                                case 5:
                                    p1.Color = Color.SeaGreen;
                                    break;
                                case 6:
                                    p1.Color = Color.Violet;
                                    break;
                                case 7:
                                    p1.Color = Color.Pink;
                                    break;
                                case 8:
                                    p1.Color = Color.RoyalBlue;
                                    break;
                                case 9:
                                    p1.Color = Color.Salmon;
                                    break;
                                default:
                                    p1.Color = Color.Blue;
                                    break;
                            }

                        }

                        //DataPoint p2 = new DataPoint(0, Double.Parse("0"));

                        //p2.Color = Color.colors[j];


                    }
                }

                //LegendItem legendItem1 = new LegendItem("Under Performance", Color.Red, "");
                //legendItem1.BorderColor = Color.Red;
                //legend1.CustomItems.Add(legendItem1);

                
            }

            this.chart = chart;
        }
    }
}
