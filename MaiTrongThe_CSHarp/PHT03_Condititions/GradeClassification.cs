using System;

namespace GradeClassification
{
   class Program
    {
        static void Main(string[] args)
        {
            int score = 91;
            if (score >= 90)
            {
                Console.WriteLine("Grade: A (Xuat sac)");
            }
            else if (score >= 80)
            {
                Console.WriteLine("Grade: B (Kha)");
            }
            else if (score >= 70)
            {
                Console.WriteLine("Grade: C (Trung binh)");
            }
            else if (score >= 60)
            {
                Console.WriteLine("Grade: D (Yeu)");
            }
            else
            {
                Console.WriteLine("Grade: F (Khong dat)");
            }
        }
    }
}