using System;

namespace HeThongQuanLySinhVien
{
    public class Student
    {
        public string StudentID { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }   
        //Constructor
        public Student(string id, string name, double score)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Student ID khong duoc rong");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Ten sinh vien khong duoc rong");
            }
            if (score < 0 || score > 10)
            {
                throw new ArgumentException("Diem phai trong khoang 0 den 10");
            }

            StudentID = id;
            Name = name;
            Score = score;
        }

        public void Display()
        {
            Console.WriteLine($"Ma sinh vien: {StudentID} | Ten: {Name} | Diem: {Score}");


        }
    }
}