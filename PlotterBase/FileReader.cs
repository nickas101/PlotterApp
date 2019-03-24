using System;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace PlotterBase
{
    static class FileReader
    {
       public static string WorkingDirectory;

       /*
        * Try to read file from the current folder
        * returns array of read lines
        * if not successful - throw an exception
        * TODO: if not successful - a dialog window to choose another file
        */
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
