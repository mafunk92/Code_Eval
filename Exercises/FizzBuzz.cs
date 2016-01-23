using System.IO;
using System.Collections.Generic;
using System;

class Program
{
    static void Main(string[] args)
    {
        string file = @"C:\Users\funky\Documents\Visual Studio 2015\Projects\Code_Eval\FizzBuzz.txt";
        /*
            File Format - First number is X, Second number is Y, Third(last) number is max(count)
            3 5 10
            2 7 15

            Expected Output
            1 2 F 4 B F 7 8 F B
            1 F 3 F 5 F b F 11 F 13 FB 15

            FizzBuzz
            If number is divisible by X print F
            If number is divisible by Y print B
            If number is divisble by both X and Y print FB
            Else print number

        */
        using (StreamReader reader = File.OpenText(file))
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (null == line)
                continue;

                //Break up line into array
                string[] input = line.Split(' ');
                //Convert strings into ints
                int[] param = Array.ConvertAll(input, s => int.Parse(s));

                //Loop through 1 to Max
                for(int i=1;i <= param[2]; i++)
                {
                    if ((i % (param[0]) == 0) && (i % (param[1]) == 0)) Console.Write("FB");
                    else if (i % param[1] == 0) Console.Write("B");
                    else if (i % param[0] == 0) Console.Write("F");
                    else Console.Write(String.Format("{0}",i));

                    if (i % param[2] != 0) Console.Write(" ");
                    else Console.WriteLine();
                }

        }
    }
}