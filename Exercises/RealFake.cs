using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string file = @"C:\Users\funky\Documents\Visual Studio 2015\Projects\Code_Eval\RealFake.txt";
        /*
            File Format 
            9999 9999 9999 9999
            9999 9999 9999 9993

            Expected Output
            Fake
            Real

            Real Fake
            Sum up all, if index%2 == 0, sum up the double
            If sum%10 == 0, print Real, else Fake
        */

        using (StreamReader reader = File.OpenText(file))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;

                // Remove spaces
                Regex rgx = new Regex("\\ ");
                string result = rgx.Replace(line, "");

                //Break up line into list
                List<int> nums = new List<int>();
                foreach (char  ch in result)
                {
                    nums.Add(int.Parse(ch.ToString()));
                }

                int sum = 0;

                for(int i=0;i<nums.Count;i++)
                {
                    if (i % 2 == 0) sum += nums[i] * 2;
                    else sum += nums[i];
                }

                if (sum % 10 == 0) Console.WriteLine("Real");
                else Console.WriteLine("Fake");
            }
        }


    }
}