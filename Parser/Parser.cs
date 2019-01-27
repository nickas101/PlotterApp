﻿using System;
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
            string[,] temp = new string[20, 50]; // temperature array
            string[,] freq = new string[20, 50]; // frequency array
            string[,] over = new string[20, 50]; // overband array
            string[,] spec = new string[20, 50]; // spec limit array

            //string[,] temp; // temperature array
            //string[,] freq; // frequency array

            //string[] xx = { "777", "888", "999", "555" };

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace("<", "");
                lines[i] = lines[i].Replace("FAIL", " ");
                lines[i] = lines[i].Replace("+", " ");
                lines[i] = lines[i].Replace("     ", " ");
                lines[i] = lines[i].Replace("    ", " ");
                lines[i] = lines[i].Replace("   ", " ");
                lines[i] = lines[i].Replace("  ", " ");
                
                lines[i] = lines[i].Trim();

                if (lines[i].Contains("POSn") == true)
                {
                    string[] words = lines[i].Split(new char[] { ' ' });
                    string[] word = words[3].Split(new char[] { ':' });
                    unit = int.Parse(word[1]);
                    row = 0;
                    //Console.Write(unit + "\n");
                }
                    

                if (lines[i].Contains("Worst") == true)
                    to_read = false;

                if (lines[i].Length > 0 && to_read == true)
                {
                    string[] digs = lines[i].Split(new char[] { ' ' });
                    temp[unit, row] = digs[0];
                    freq[unit, row] = digs[2];
                    over[unit, row] = digs[3];
                    spec[unit, row] = digs[4];


                    //Console.Write(freq[unit, row] + "\n");

                    row++;
                }

                if (lines[i].Contains("(ppm/'C)") == true)
                    to_read = true;

            }

            //Console.ReadKey();


            Plot thePlot = new Plot(temp, freq, over, spec);

            return thePlot;
        }
    }
}
