using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using Plotter1;

namespace ConsoleApp1
{
    class FileRead
    {
       public static string Read()
        {
            string pathToFile = "D:\\5524.txt";
            string[] readEveryLine = new string[5];

            readEveryLine = File.ReadAllLines(pathToFile);

            Plotter1.Parser.Parse(readEveryLine);

            //for (int i = 0; i < readEveryLine.Length; i++)
            //Console.Write(readEveryLine[i] + " | ");

            return readEveryLine[8];

            //return Plotter1.Plotter.Plot();

            //return "Hi from method";
        }
    }
}
