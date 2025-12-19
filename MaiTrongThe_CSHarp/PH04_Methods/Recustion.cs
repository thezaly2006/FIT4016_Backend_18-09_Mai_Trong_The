using System;


namespace Recurtion
{
    class Program
    {
        static long Factorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        static void Main(string[] args)
        {
            long results5 = Factorial(5);
            Console.WriteLine("5! = " + results5);

            long results10 = Factorial(10);
            Console.WriteLine("10! = " + results10);
        }
    }
}
