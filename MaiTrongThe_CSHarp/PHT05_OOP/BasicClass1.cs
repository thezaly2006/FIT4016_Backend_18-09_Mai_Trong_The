using System;

namespace BasicClass1
{
    class Student
    {
        public string MaSinhVien { get; set; }
        public string HoTen { get; set; }  
        public double GPA { get; set; }
        public void Display()
        {
            Console.WriteLine("Mã Sinh Viên: " + MaSinhVien);
            Console.WriteLine("Họ Tên: " + HoTen);
            Console.WriteLine("GPA: " + GPA);
            Console.WriteLine("-------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            s1.MaSinhVien = "1871020550";
            s1.HoTen = "Mai Trong The";
            s1.GPA = 3.5;

            Student s2 = new Student();
            s2.MaSinhVien = "1871020027";
            s2.HoTen = "Pham Duy Anh";
            s2.GPA = 3.5;

            s1.Display();
            s2.Display();

            Console.ReadLine();
        }
    }
}