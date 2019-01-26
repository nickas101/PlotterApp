using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allLines = FileReader.Read();

            Parser.Plot plot = Parser.Parser.Parse(allLines);

            //Console.Write(plot.X[1, 2] + "\n");
            //Console.ReadKey();

            Plotter.DrowPlot(plot);

            //Console.WriteLine(plot.Y);
            //Console.ReadKey();
        }
    }
}
