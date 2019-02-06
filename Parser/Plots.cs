using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Plots
    {
        public string[,] Temp { get; set; }

        public string[,] Freq { get; set; }
   
        public string[,] Over { get; set; }
    
        public string[,] Spec { get; set; }

        public string[] Spc { get; set; }
      
        public Plots(string[,] temp, string[,] freq, string[,] over, string[,] spec, string[] spc)
        {
            Temp = temp;
            Freq = freq;
            Over = over;
            Spec = spec;
            Spc = spc;
        } 
    }
}
