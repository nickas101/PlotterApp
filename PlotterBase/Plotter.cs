using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace PlotterBase
{
    public static class Plotter
    {
        public static void PreparePlots(Parser.Plots plots)
        {
            const string OUTPUTPATH = "D:\\Plots";
            var outputDirectory = new DirectoryInfo(@OUTPUTPATH);
            outputDirectory.Create();

            string[] xm = new string[20];
            string[,] ym = new string[20, 50];
            string[] specm = new string[20];

            for (var i = 1; i < plots.Temp.GetLength(0); i++)
            {
                string[] x = new string[20];
                string[] y = new string[20];
                string[] spec = new string[20];
                bool notEmpty = false;

                for (var j = 0; j < plots.Temp.GetLength(1); j++)
                {
                    if (plots.Temp[i, j] == null) continue;
                    x[j] = plots.Temp[i, j];
                    xm[j] = plots.Temp[i, j];
                    y[j] = plots.Over[i, j];
                    ym[i,j] = plots.Over[i, j];
                    spec[j] = plots.Spec[i, j];
                    specm[j] = plots.Spec[i, j];

                    notEmpty = true;
                }

                if (notEmpty != true) continue;
                string unit = i.ToString();

                var singlePlot = new SinglePlot(x, y, spec, i, plots.Spc[i]);

                string filename = OUTPUTPATH + "/Unit#" + unit + ".png";
                singlePlot.ChartImage.SaveImage(filename, ChartImageFormat.Png);
            }

            var multiPlot = new MultiPlot(xm, ym, specm, plots.Spc[1]);

            string filenameMulti = OUTPUTPATH + "/AllUnits.png";
            multiPlot.ChartImage.SaveImage(filenameMulti, ChartImageFormat.Png);
        }
    }
}
