using System;

namespace ArrayMethods
{
    class Program
    {
        static int SumArray(int[] numbers)
        {
            int sum = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        static int FindMax(int[] numbers)
        {
            int max = numbers[0];
            for(int i = 1; i < numbers.Length; i++)
            {
                if(numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            return max;
        }

        static void Main(string[] args)
        {
            int[] scores = {85, 92, 78, 90, 88};

            int total = SumArray(scores);
            Console.WriteLine("Tong cac phan tu: " + total);

            int highest = FindMax(scores);
            Console.WriteLine("Gia tri lon nhat: " + highest);
        }
    }
}