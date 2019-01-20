using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plotter1
{
    public class Parser
    {
        public static string Parse(string[] lines)
        {
            Plotter.Plot(lines);

            return "Hi from parser";
        }
    }
}
