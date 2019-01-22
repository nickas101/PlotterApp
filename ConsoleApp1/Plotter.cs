using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Plotter
    {
        public static void DrowPlot(Parser.Plot plot)
        {
            Console.WriteLine(plot.Y);

            Console.ReadKey();
        }
    }
}
