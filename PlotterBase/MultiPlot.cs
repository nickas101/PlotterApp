using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace PlotterBase
{
    class MultiPlot : Plot
    {
        public MultiPlot(string[] x, string[,] y, string[] specArray, string productNumber) :
                    base(x, y, specArray, productNumber)
        {
            this.x = x;
            this.multyY = y;
            this.specArray = specArray;
            this.productNumber = productNumber;

            PreparePlot();
            DrawPlot();
        }

        protected sealed override void DrawPlot()
        {
            string[] x = this.x;
            string[,] y = this.multyY;
           
            Chart chart = this.chartImage;

            chart.Titles.Add(this.productNumber + "  All Units");
            chart.Titles[0].Font = new Font("Arial", 14, FontStyle.Bold);

            var legend = new Legend("Legend1") {Font = new Font("Arial", 10)};
            //LegendItem legendItem1 = new LegendItem("Under Performance", Color.Red, "");
            //legendItem1.BorderColor = Color.Red;

            chart.Legends.Add(legend);
            //legend.CustomItems.Add(legendItem1);

            for (var unitNumber = 1; unitNumber < y.GetLength(0); unitNumber++)
            {
                if (y[unitNumber, 1] == null) continue;
                var series = new Series()
                {
                    Name = "Unit#" + unitNumber.ToString(),
                    IsVisibleInLegend = true,
                    ChartType = SeriesChartType.Spline
                };

                chart.Series.Add(series);

                for (var row = 0; row < x.Length; row++)
                {
                    if (y[unitNumber, row] == null) continue;
                    var point = new DataPoint(Double.Parse(x[row]), Double.Parse(y[unitNumber, row]))
                    {
                        Color = Color.Blue, BorderWidth = 2
                        //AxisLabel = x[i];
                    };
                    series.Points.Add(point);

                    switch (unitNumber)
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

            this.chartImage = chart;
        }
    }
}
