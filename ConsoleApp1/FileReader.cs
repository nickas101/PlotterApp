using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
//using Plotter1;

namespace ConsoleApp1
{
    class FileReader
    {
       public static string[] Read()
        {
            string[] readEveryLine = {};
            string pathToFile;

            try
            {
                string folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                pathToFile = File.ReadAllText(folder + "\\5524.txt");
                Console.WriteLine(pathToFile);
                readEveryLine = File.ReadAllLines(pathToFile);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.Write("------\nPress any key to continue . .");
                Console.ReadKey(true);
            }

            //Console.Write("------\nPress any key to continue . .");
            //Console.ReadKey(true);

            //string pathToFile = "D:\\5524.txt";
            //readEveryLine = File.ReadAllLines(pathToFile);

            return readEveryLine;
        }
    }
}
