using System;

namespace BreakContinue
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 20; i++)
            {
                if (i % 2 == 0)
                {
                    continue;
                }
                Console.Write(i + " ");
            }
            Console.WriteLine();

            int[] numbers = { 2, 5, 7, 1, 9, 7, 3};
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == 7)
                {
                    Console.WriteLine("Da tim thay so 7 tai vi tri: " + i);
                    break;
                }
            }
        }
    }
}