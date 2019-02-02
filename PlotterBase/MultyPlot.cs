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
    class MultyPlot : Plot
    {
        public MultyPlot(string[] x, string[,] y, string[] specArray, int i, string productNumber) :
                    base(x, y, specArray, i, productNumber)
        {
            this.x = x;
            this.multyY = y;
            this.specArray = specArray;
            this.i = i;
            this.productNumber = productNumber;

            PreparePlot();
            DrowPlot();
        }

        public override void DrowPlot()
        {
            string[] x = this.x;
            string[,] y = this.multyY;
           
            Chart chart = this.chartImage;

            chart.Titles.Add(this.productNumber + "  All Units");
            chart.Titles[0].Font = new Font("Arial", 14, FontStyle.Bold);

            Legend legend = new Legend("Legend1");
            legend.Font = new Font("Arial", 10);
            //LegendItem legendItem1 = new LegendItem("Under Performance", Color.Red, "");
            //legendItem1.BorderColor = Color.Red;

            chart.Legends.Add(legend);
            //legend.CustomItems.Add(legendItem1);

            for (int j = 1; j < y.GetLength(0); j++)
            {    
                if (y[j, 1] != null)
                {
                    Series series = new Series()
                    {
                        Name = "Unit#" + j.ToString(),
                        IsVisibleInLegend = true,
                        ChartType = SeriesChartType.Spline
                    };

                    chart.Series.Add(series);

                    for (int i = 0; i < x.Length; i++)
                    {
                        if (y[j, i] != null)
                        {
                            DataPoint point = new DataPoint(0, Double.Parse(y[j, i]));
                            point.Color = Color.Blue;
                            point.BorderWidth = 2;
                            point.AxisLabel = x[i];
                            series.Points.Add(point);

                            switch (j)
                            {
                                case 1:
                                    point.Color = Color.Yellow;
                                    break;
                                case 2:
                                    point.Color = Color.YellowGreen;
                                    break;
                                case 3:
                                    point.Color = Color.Pink;
                                    break;
                                case 4:
                                    point.Color = Color.LightCyan;
                                    break;
                                case 5:
                                    point.Color = Color.SeaGreen;
                                    break;
                                case 6:
                                    point.Color = Color.Violet;
                                    break;
                                case 7:
                                    point.Color = Color.Pink;
                                    break;
                                case 8:
                                    point.Color = Color.RoyalBlue;
                                    break;
                                case 9:
                                    point.Color = Color.Salmon;
                                    break;
                                default:
                                    point.Color = Color.Blue;
                                    break;
                            }
                        }
                    }
                }
            }

            this.chartImage = chart;
        }
    }
}
