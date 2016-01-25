using System.IO;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string file = @"C:\Users\funky\Documents\Visual Studio 2015\Projects\Code_Eval\TrickOrTreat.txt";
        /*
            File Format 
            Vampires: 1, Zombies: 1, Witches: 1, Houses: 1
            Vampires: 3, Zombies: 2, Witches: 1, Houses: 10

            Expected Output
            4
            36

            Trick or Treat
            3 Costumes, each get a different amount of candy.
            Each line is its own group where they split the candy evenly, the last element shows how many houeses the group visits;
            Vampire - 3 candies
            Zombie  - 4 candies
            Witch   - 5 candies
            Round down when splitting the candies evenly.
        */

        using (StreamReader reader = File.OpenText(file))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;

                // extract only the numbers from string
                MatchCollection values = Regex.Matches(line, @"\d+");
                List<int> num = new List<int>();

                // put numbers into list
                foreach (Match n in values) num.Add(int.Parse(n.ToString()));

                int vamp = num[0];
                int zomb = num[1];
                int witch = num[2];
                int homes = num[3];

                int kids = vamp + zomb + witch;
                int candy = (3*vamp + 4*zomb + 5*witch) * homes;
                double avg = candy/kids;

                Console.WriteLine(Math.Floor(avg));              
            }
        }

    }
}