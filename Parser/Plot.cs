using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Plot
    {
        private string[,] x; // temperature array
        private string[,] y; // frequency array MHz

        public string[,] X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public string[,] Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public Plot(string[,] x, string[,] y)
        {
            this.x = x;
            this.y = y;
        } 
    }
}
