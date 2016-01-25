using System;

class Program
{
    static void Main(string[] args)
    {
        // sum first 1000 primes;
        int max = 1000;

        // 2 is first prime, going to start with that
        int count = 1;
        int dx = 2;
        int sum = 0;

        while(count<=max)
        {
            bool isPrime = true;
            for(int i=2;i <= Math.Floor(Math.Sqrt(dx));i++ )
            {
                if (dx % i == 0 && dx != i) isPrime = false;
            }

            if (isPrime)
            {
                sum += dx;
                count++;
            }
            dx++;
        }

        Console.WriteLine(sum);     
    }
}