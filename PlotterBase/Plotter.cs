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
    public class Plotter
    {
        public static void PreparePlots(Parser.Plots plots)
        {
            DirectoryInfo d = new DirectoryInfo(@"D:\Plots");
            d.Create();

            string[] xm = new string[20];
            string[,] ym = new string[20, 50];
            string[] specm = new string[20];
            //bool notEmptym = false;

            for (int i = 1; i < plots.Temp.GetLength(0); i++)
            {
                string[] x = new string[20];
                string[] y = new string[20];
                string[] spec = new string[20];
                bool notEmpty = false;

                for (int j = 0; j < plots.Temp.GetLength(1); j++)
                {
                    if (plots.Temp[i, j] != null)
                    {
                        x[j] = plots.Temp[i, j];
                        xm[j] = plots.Temp[i, j];
                        y[j] = plots.Over[i, j];
                        ym[i,j] = plots.Over[i, j];
                        spec[j] = plots.Spec[i, j];
                        specm[j] = plots.Spec[i, j];

                        notEmpty = true;
                    } 
                }
 
                if (notEmpty == true)
                {
                    string unit = i.ToString();

                    SinglePlot singlePlot = new SinglePlot(x, y, spec, i, plots.Spc[i]);

                    string filename = "D:\\Plots/Unit#" + unit + ".png";
                    singlePlot.ChartImage.SaveImage(filename, ChartImageFormat.Png);
                }
            }

            MultyPlot multyPlot = new MultyPlot(xm, ym, specm, 1, plots.Spc[1]);

            string filenameMulty = "D:\\Plots/AllUnits.png";
            multyPlot.ChartImage.SaveImage(filenameMulty, ChartImageFormat.Png);
        }
    }
}
