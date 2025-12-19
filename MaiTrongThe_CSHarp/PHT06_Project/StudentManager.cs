using System;

namespace HeThongQuanLySinhVien
{
    public class StudentManager
    {
        private Student[] students =  new Student[50];
        private int count = 0;

        public bool AddStudent(string id, string name, double score)
        {
            if (count >= students.Length)
            {
                Console.WriteLine("Danh sach sinh vien da day");
                return false;
            }

            //Kiểm tra trùng ID
            if (FindStudentByID(id) != null)
            {
                Console.WriteLine("Ma sinh vien da ton tai");
                return false;
            }

            students[count] = new Student(id, name, score);
            count++;
            return true;
        }

        public bool RemoveStudent(string id)
        {
            for (int i = 0; i < count; i++)
            {
                if (students[i].StudentID == id)
                {
                    for (int j = i; j < count -1; j++)
                    {
                        students[j] = students[j + 1];
                    }

                    students[count - 1] = null;
                    count --;
                    return true;
                }
            }
            Console.WriteLine("Khong tim thay sinh vien can xoa");
            return false;
        }

        public bool UpdateScore(string id, double newScore)
        {
            if (newScore < 0 || newScore > 10)
            {
                Console.WriteLine("Diem phai trong khoang 0 den 10");
                return false;
            }

            Student sv = FindStudentByID(id);
            if (sv == null)
            {
                Console.WriteLine("Khong tim thay sinh vien");
                return false;
            }

            sv.Score = newScore;
            return true;
        }

        public double GetAverageScore()
        {
            if (count == 0) return 0;
            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += students[i].Score;
            }

            return sum/count;
        }

        public double GetMaxScore()
        {
            if (count == 0) return 0;
            double max = students[0].Score;
            for (int i = 1; i < count; i++)
            {
                if (students[i].Score > max)
                {
                    max = students[i].Score;
                }
            }
            return max;
        }

        public Student FindStudentByID(string id)
        {
            for (int i = 0; i < count; i++)
            {
                if (students[i].StudentID == id)
                {
                    return students[i];
                }
            }
            return null;
        }

        public void DisplayAllStudents()
        {
            if (count == 0)
            {
                Console.WriteLine("Khong co sinh vien trong danh sach");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                students[i].Display();
            }
        }
    }
}