using System;

namespace GuessNumber1
{
    class Program
    {
        static void Main(string[] args)
        {
            int secretNumber = 50;
            int guess = 0;
            while (guess != secretNumber)
            {
                Console.Write("Nhap so ma ban doan: ");
                guess = int.Parse(Console.ReadLine());
                
                if (guess < secretNumber)
                {
                    Console.WriteLine("Qua thap moi thu lai");
                }
                else if (guess > secretNumber)
                {
                    Console.WriteLine("Qua cao moi thu lai");
                }
                else
                {
                    Console.WriteLine("Chinh xac");
                }
            }
        }
    }
}