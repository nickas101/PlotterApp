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
            DrowPlot();
        }

        public override void DrowPlot()
        {
            string[] x = this.x;
            string[] y = this.singleY;
           
            Chart chart = this.chartImage;

            chart.Titles.Add(productNumber + "  Unit#" + i.ToString());
            chart.Titles[0].Font = new Font("Arial", 14, FontStyle.Bold);

            Series series = new Series()
            {
                Name = "Unit#" + i.ToString(),
                IsVisibleInLegend = true,
                //IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Spline
            };

            chart.Series.Add(series);
            
            for (int i = 0; i < x.Length; i++)
            {
                if (y[i] != null)
                {
                    DataPoint point = new DataPoint(0, Double.Parse(y[i]));
                    point.Color = System.Drawing.Color.Blue;
                    point.BorderWidth = 2;
                    point.AxisLabel = x[i];
                    series.Points.Add(point);
                    point.Color = System.Drawing.Color.Blue;
                }
            }

            this.chartImage = chart;
        }
    }
}
