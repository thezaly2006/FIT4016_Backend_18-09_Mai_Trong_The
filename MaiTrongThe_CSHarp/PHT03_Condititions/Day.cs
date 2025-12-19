using System;

namespace Day
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = 10;
            switch (day)
            {
                case 1:
                Console.WriteLine("Thu Hai");
                break;
                case 2:
                Console.WriteLine("Thu Ba");
                break;
                case 3:
                Console.WriteLine("Thu Tu");
                break;
                case 4:
                Console.WriteLine("Thu Nam");
                break;
                case 5:
                Console.WriteLine("Thu Sau");
                break;
                case 6:
                Console.WriteLine("Thu Bay");
                break;
                case 7:
                Console.WriteLine("Chu Nhat");
                break;
                default:
                Console.WriteLine("Ngay khong hop le");
                break;
            }
        }
    }
}