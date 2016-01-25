using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        string file = @"C:\Users\funky\Documents\Visual Studio 2015\Projects\Code_Eval\Testing.txt";
        /*
            File Format 
            Heelo Codevval | Hello Codeeval
            hELLO cODEEVAL | Hello Codeeval
            Hello Codeeval | Hello Codeeval

            Expected Output
            Low
            Critical
            Done

            Testing
            Look for bugs, section before pipe is input, after is design;
            Print priorities of each line
            2 or fewer - Low
            4 or fewer - Medium
            6 or fewer - High
            6+         - Critical
            0          - Done
        */

        using (StreamReader reader = File.OpenText(file))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;

                string[] input = line.Split('|');
                // Remove spaces that were before and after pipe
                input[0] = input[0].Substring(0, input[0].Length - 2);
                input[1] = input[1].Substring(1, input[1].Length - 2);

                int bugs = 0;

                for(int i=0;i<input[0].Length;i++)
                {
                    if (!input[0][i].Equals(input[1][i])) bugs++;
                }

                if (bugs == 0) Console.WriteLine("Done");
                else if (bugs <= 2) Console.WriteLine("Low");
                else if (bugs <= 4) Console.WriteLine("Medium");
                else if (bugs <= 6) Console.WriteLine("High");
                else Console.WriteLine("Critical");

            }
        }
            
    }
}