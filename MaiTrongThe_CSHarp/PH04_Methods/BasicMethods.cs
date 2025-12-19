using System;

namespace BasicMethods
{
    class Program
    {
        static int Add(int a, int b)
        {
            return a + b;
        }

        static double Multiply(double x, double y)
        {
            return x * y;
        }

        static void Main(string[] args)
        {
            int sum = Add(5, 10);
            double product = Multiply(4.5, 2.0);

            Console.WriteLine("Tong: " + sum);
            Console.WriteLine("Tich: " + product);
        }
    }
}