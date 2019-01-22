using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Parser
    {
        public static string Parse(string[] lines)
        {
            //Plotter.Plot(lines);
            Plot thePlot = new Plot(1,2);

            Console.WriteLine(thePlot.X);
            Console.ReadKey();

            return "Hi from parser";
        }
    }
}
