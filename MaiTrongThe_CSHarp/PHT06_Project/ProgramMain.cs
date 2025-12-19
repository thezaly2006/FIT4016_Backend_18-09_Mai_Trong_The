using System;

namespace HeThognQuanLySinhVien
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Xoa sinh vien");
                Console.WriteLine("3. Cap nhat diem");
                Console.WriteLine("4. In danh sach");
                Console.WriteLine("5. Tinh diem trung binh");
                Console.WriteLine("6. Tim diem cao nhat");
                Console.WriteLine("7. Tim sinh vien theo ID");
                Console.WriteLine("0. Thoát");
                Console.WriteLine("==========================");
                Console.Write("Chon chuc nang: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Nhap ma sinh vien: ");
                            string id = Console.ReadLine();

                            Console.Write("Nhap ten sinh vien: ");
                            string name = Console.ReadLine();

                            Console.Write("Nhap diem sinh vien: ");
                            double score = double.Parse(Console.ReadLine());

                            manager.AddStudent(id, name, score);
                            Console.WriteLine("Them sinh vien thanh cong");
                            break;
                        case 2:
                            Console.Write("Nhap ma sinh vien can xoa: ");
                            string removeId = Console.ReadLine();

                            manager.RemoveStudent(removeId);
                            break;
                        case 3:
                            Console.Write("Nhap ma sinh vien can cap nhat diem: ");
                            string updateId = Console.ReadLine();

                            Console.Write("Nhap diem moi: ");
                            double newScore = double.Parse(Console.ReadLine());

                            manager.UpdateScore(updateId, newScore);
                            Console.WriteLine("Cap nhat diem thanh cong");
                            break;
                        case 4:
                            manager.DisplayAllStudents();
                            break;
                        case 5:
                            double avg = manager.GetAverageScore();
                            Console.WriteLine($"Điem trung binh: {avg:F2}");
                            break;
                        case 6:
                            double max = manager.GetMaxScore();
                            Console.WriteLine($"Điem cao nhat: {max}");
                            break;
                        case 7:
                            Console.Write("Nhap ma sinh vien can tim: ");
                            string findId = Console.ReadLine();

                            Student sv = manager.FindStudentByID(findId);
                            if (sv != null)
                            {
                                sv.Display();
                            }
                            else
                            {
                                Console.WriteLine("Khong tim thay sinh vien");
                            }
                            break;
                        case 0:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Lua chon khong hop le");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Vui long nhap dung dinh dang");
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}");
                }
            }
        }
    }
}