using System.IO;
using System.Collections.Generic;
using System;

class Program
{
    static void Main(string[] args)
    {
        string file = @"C:\Users\funky\Documents\Visual Studio 2015\Projects\Code_Eval\LongLines.txt";
        /*
            File Format - First line indicates number of lines of output;
            2
            Hello World
            CodeEval
            Quick Fox
            A
            San Francisco

            Expected Output
            San Francisco
            Hello World

            Longest Line
            Print out Longest lines, first line represents how many outputs there should be
        */

        List<string> lines = new List<string>();

        using (StreamReader reader = File.OpenText(file))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;
                // do something with line
                lines.Add(line);
            }
        }

        // Get output amount and remove from list
        int max = Convert.ToInt32(lines[0]);
        lines.Remove(max.ToString());

        // Sort list in desc order
        lines.Sort((a,b) => b.Length.CompareTo(a.Length));
        
        // output list
         for(int i=0; i< max;i++)
        {
            Console.WriteLine(lines[i]);
        }
    }
}