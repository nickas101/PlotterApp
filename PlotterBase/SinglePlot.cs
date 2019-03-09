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
    class SinglePlot : Plot
    {
        public SinglePlot(string[] x, string[] y, string[] specArray, int i, string productNumber) : 
            base(x, y, specArray, i, productNumber) 
        {
            this.x = x;
            this.singleY = y;
            this.specArray = specArray;
            this.i = i;
            this.productNumber = productNumber;

            PreparePlot();
            DrawPlot();
        }

        public sealed override void DrawPlot()
        {
            string[] x = this.x;
            string[] y = this.singleY;
           
            Chart chart = this.chartImage;

            chart.Titles.Add(productNumber + "  Unit#" + i.ToString());
            chart.Titles[0].Font = new Font("Arial", 14, FontStyle.Bold);

            var series = new Series()
            {
                Name = "Unit#" + i.ToString(),
                IsVisibleInLegend = true,
                //IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Spline
            };

            chart.Series.Add(series);
            
            for (var row = 0; row < x.Length; row++)
            {
                if (y[row] == null) continue;
                var point = new DataPoint(double.Parse(x[row]), double.Parse(y[row]))
                {
                    Color = Color.Blue,
                    BorderWidth = 2,
                    //AxisLabel = x[row]
                };
                series.Points.Add(point);
            }

            this.chartImage = chart;
        }
    }
}
