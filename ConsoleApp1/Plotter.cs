using System;
using System.Collections.Generic;
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
            //Console.WriteLine(plot.Y);

            //Console.ReadKey();

            string[] items = { "-3","-1","1", "2", "3", "4", "5", "6" };

            Chart chart = new Chart();

            chart.Size = new System.Drawing.Size(1000, 500);
            ChartArea area = new ChartArea();
            chart.ChartAreas.Add(area);

            chart.BackColor = System.Drawing.Color.White; // Was Transparent
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            chart.ChartAreas[0].AxisX.Title = "Frequency over Temperature";

            Series series = new Series()
            {
                Name = "series2",
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Line
            };

            Series series2 = new Series()
            {
                Name = "series3",
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Line
            };

            chart.Series.Add(series);
            //chart.Series.Add(series2);

            for (int i = 0; i < plot.X.GetLength(1); i++)
            {

                //DataPoint p1 = new DataPoint(0, Double.Parse(item.Kurz));
                if (plot.Y[2, i] != null)
                {
                    DataPoint p1 = new DataPoint(0, Double.Parse(plot.Y[2, i]));
                    p1.Color = System.Drawing.Color.Blue;
                    p1.AxisLabel = plot.X[2, i];
                    series.Points.Add(p1);
                    p1.LegendText = "Legend";
                }

                DataPoint p2 = new DataPoint(0, Double.Parse("0"));
                
                p2.Color = System.Drawing.Color.LightBlue;
                //p1.AxisLabel = item.Kod;
                //p1.LegendText = item.Kod;
                // p1.Label = item.Kurz;

                //p1.AxisLabel = "Axis";
                
                
                //p1.Label = "Label";

                
                series2.Points.Add(p2);


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
