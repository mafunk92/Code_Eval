using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string file = @"C:\Users\funky\Documents\Visual Studio 2015\Projects\Code_Eval\NotSoClever.txt";
        /*
            File Format - Number after pipe indicates how many rounds
            4 3 2 1 | 1
            5 4 3 2 1 | 2

            Expected Output
            3 4 2 1
            4 3 5 2 1
        */

        using (StreamReader reader = File.OpenText(file))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;

                // Remove pipe and following space
                Regex rgx = new Regex("\\| ");
                string result = rgx.Replace(line, "");

                //Break up line into array
                string[] input = result.Split(' ');
                //Convert strings into ints
                int[] param = Array.ConvertAll(input, s => int.Parse(s));

                // fill list from array, lists are easier to work with; git rid of count number
                List<int> list = new List<int>();
                list.AddRange(param);
                list.RemoveAt(list.Count - 1);

                int turns = param[param.Length - 1];
                int count = 1;

                // only switch the given amount of times
                while (count <= turns)
                {
                    bool stop = false;
                    int i = 0;

                    // go through list until switch needs to happen
                    while (!stop)
                    {
                        if (i == (list.Count - 1))
                        {
                            stop = true;
                        }
                        else
                        {
                            if (list[i] > list[i + 1])
                            {
                                int temp = list[i + 1];
                                list[i + 1] = list[i];
                                list[i] = temp;
                                stop = true;
                            }
                            i++;
                        }
                    }

                    count++;
                }

                list.ForEach(i => Console.Write("{0} ", i)); Console.WriteLine();
            }
        }


    }
}