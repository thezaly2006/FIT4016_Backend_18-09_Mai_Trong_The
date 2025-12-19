using System;

namespace SumCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 1; i <= 100; i++)
            {
                sum += i;
            }
            Console.WriteLine("Tong tu 1 den 100 la: " + sum);
        }
    }
}