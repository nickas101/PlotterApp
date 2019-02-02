using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
//using Plotter1;

namespace PlotterBase
{
    class FileReader
    {
       public static string[] Read()
        {
            string[] readEveryLine = {};
            string pathToFile = "";

            try
            {
                string folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

                Regex regex = new Regex("[0-9]{4}" + ".txt", RegexOptions.IgnoreCase);

                var files = Directory.GetFiles(folder).Where(f => regex.IsMatch(f));

                pathToFile = files.First();

                readEveryLine = File.ReadAllLines(pathToFile);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.Write("------\nPress any key to continue . .");
                Console.ReadKey(true);
            }

            return readEveryLine;
        }
    }
}
