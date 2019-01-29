using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Plots
    {
        private string[,] temp; // temperature array
        private string[,] freq; // frequency array
        private string[,] over; // overband array
        private string[,] spec; // spec limit array
        private string[] spc;

        public string[,] Temp
        {
            get
            {
                return temp;
            }

            set
            {
                temp = value;
            }
        }

        public string[,] Freq
        {
            get
            {
                return freq;
            }

            set
            {
                freq = value;
            }
        }

        public string[,] Over
        {
            get
            {
                return over;
            }

            set
            {
                over = value;
            }
        }
        public string[,] Spec
        {
            get
            {
                return spec;
            }

            set
            {
                spec = value;
            }
        }

        public string[] Spc
        {
            get
            {
                return spc;
            }

            set
            {
                spc = value;
            }
        }

        public Plots(string[,] temp, string[,] freq, string[,] over, string[,] spec, string[] spc)
        {
            this.temp = temp;
            this.freq = freq;
            this.over = over;
            this.spec = spec;
            this.spc = spc;
        } 
    }
}
