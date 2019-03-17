using System;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PlotterBase
{
    static class FileReader
    {
       public static string WorkingDirectory;

       public static string[] ReadFile()
       {
            string[] readLines = {};

            try
            {
                string folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

                var regex = new Regex("[0-9]{4}" + ".txt", RegexOptions.IgnoreCase);

                var files = Directory.GetFiles(folder).Where(f => regex.IsMatch(f));

                string pathToFile = files.First();

                readLines = File.ReadAllLines(pathToFile);

                WorkingDirectory = folder;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.Write("------\nPress any key to continue . .");
                Console.ReadKey(true);
            }

            return readLines;
        }
    }
}
