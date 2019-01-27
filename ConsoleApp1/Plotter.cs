using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ConsoleApp1
{
    public class Plotter
    {
        public static void DrowPlot(Parser.Plot plot)
        {

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

            //chart.BorderlineWidth = Chart


            chart.BackColor = Color.Gray;
            chart.BackSecondaryColor = Color.WhiteSmoke;
            chart.BackGradientStyle = GradientStyle.DiagonalRight;

            //chart.PlotArea.LineFormat.Color = XColors.DarkGray;

            chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;

            chart.ChartAreas[0].AxisX.MajorGrid.Interval = 1;

            //chart.ChartAreas[0].AxisY.Minimum = -.02;

            //chart.ChartAreas[0].AxisX.MajorGrid.LineColor.IsNamedColor.Equals.

            chart.ChartAreas[0].AxisX.Title = "Frequency over Temperature";

            Series series = new Series()
            {
                Name = "series1",
                IsVisibleInLegend = false,  // ???????
                ChartType = SeriesChartType.Spline
            };

            Series series2 = new Series()
            {
                Name = "series2",
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Line

                //BorderDashStyle = ChartDashStyle.Dash
           
            };

            Series series3 = new Series()
            {
                Name = "series3",
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Line
            };

            chart.Series.Add(series);
            chart.Series.Add(series2);
            chart.Series.Add(series3);

            //chart.Series["series1"].BorderWidth = Chart
            chart.Series["series2"].BorderDashStyle = ChartDashStyle.Dash;
            chart.Series["series3"].BorderDashStyle = ChartDashStyle.Dash;


            for (int i = 0; i < plot.Temp.GetLength(1); i++)
            {

                //DataPoint p1 = new DataPoint(0, Double.Parse(item.Kurz));
                if (plot.Over[2, i] != null)
                {
                    DataPoint p1 = new DataPoint(0, Double.Parse(plot.Over[2, i]));
                    p1.Color = System.Drawing.Color.Blue;
                    p1.BorderWidth = 2;
                    p1.AxisLabel = plot.Temp[2, i];
                    series.Points.Add(p1);
                    p1.LegendText = "Legend";
                }

                if (plot.Spec[2, i] != null)
                {
                    DataPoint p3 = new DataPoint(0, Double.Parse(plot.Spec[2, i]));
                    p3.Color = System.Drawing.Color.Red;
                    p3.AxisLabel = plot.Temp[2, i];
                    series2.Points.Add(p3);
                    p3.LegendText = "Legend";
                }

                if (plot.Spec[2, i] != null)
                {
                    DataPoint p4 = new DataPoint(0, -Double.Parse(plot.Spec[2, i]));
                    p4.Color = System.Drawing.Color.Red;
                    p4.AxisLabel = plot.Temp[2, i];
                    series3.Points.Add(p4);
                    p4.LegendText = "Legend";
                }

                DataPoint p2 = new DataPoint(0, Double.Parse("0"));
                
                p2.Color = System.Drawing.Color.LightBlue;
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

            string filename = "D:\\Chart.png";
            chart.SaveImage(filename, ChartImageFormat.Png);





        }
    }
}
