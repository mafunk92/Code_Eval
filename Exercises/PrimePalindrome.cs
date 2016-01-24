using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // find largest prime number under 1000, that is also a palindrome
        int max = 1000;
        bool stop = false;

        while(!stop)
        {
            max--;
            bool prime = true;

            // check if prime
            for(int i = 2; i < Math.Floor(Math.Sqrt(max)); i++)
            {
                if (max % i == 0) prime = false;
            }

            if(prime)
            {
                string pal = max.ToString();

                // check if palindrome
                if (pal.SequenceEqual(pal.Reverse()))
                {
                    stop = true;
                    Console.WriteLine(max);
                }          
            }
        }
    }
}