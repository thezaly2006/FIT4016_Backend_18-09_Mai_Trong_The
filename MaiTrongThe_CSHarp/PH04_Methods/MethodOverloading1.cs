using System;

namespace MethodOverloading1
{
    class Program
    {
        static void Print(int x)
        {
            Console.WriteLine("So nguyen: " + x);
        }

        static void Print(string text)
        {
            Console.WriteLine("Chuoi: " + text);
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        static double Add(double a, double b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            Print(10); //Goji print voi int

            Print("Xin chao TheZaly"); // Goi print voi string

            int sumInt = Add(5, 10); // Goi Add voi int
            Console.WriteLine("Tong hai so nguyen: " + sumInt);

            double sumDouble = Add(5.5, 10.3); // Goi Add voi double
            Console.WriteLine("Tong hai so thuc: " + sumDouble);
        }
        
    }
}