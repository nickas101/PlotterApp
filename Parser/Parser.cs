using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Parser
    {
        public static Plot Parse(string[] lines)
        {
            bool to_read = false;
            int unit = 0;
            int row = 0;
            string[,] temp = new string[50,100]; // temperature array

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace("<", "");
                lines[i] = lines[i].Replace("    ", " ");
                lines[i] = lines[i].Replace("   ", " ");
                lines[i] = lines[i].Replace("  ", " ");
                lines[i] = lines[i].Replace("FAIL", " ");
                lines[i] = lines[i].Replace("+", " ");
                lines[i] = lines[i].Trim();

                if (lines[i].Contains("POSn") == true)
                {
                    string[] words = lines[i].Split(new char[] { ' ' });
                    string[] word = words[3].Split(new char[] { ':' });
                    unit = int.Parse(word[1]);
                    row = 0;
                    Console.Write(unit + "\n");
                }
                    

                if (lines[i].Contains("Worst") == true)
                    to_read = false;

                if (lines[i].Length > 0 && to_read == true)
                {
                    string[] digs = lines[i].Split(new char[] { ' ' });
                    temp[unit,row] = digs[0]; 


                    Console.Write(temp[unit,row] + "\n");

                    row++;
                }

                if (lines[i].Contains("(ppm/'C)") == true)
                    to_read = true;


            }

            Console.ReadKey();

            Plot thePlot = new Plot(1,2);

            return thePlot;
        }
    }
}
