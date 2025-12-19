using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Chuong trinh Xep loai Sinh viên ===\n");

        string hoVaTen = "Mai Trong The"; 
        double diem = 9.5; 
        Console.WriteLine($"Ho ten: {hoVaTen}");
        Console.WriteLine($"Điem: {diem}\n");

        string xepLoai;
        if (diem >= 8.5)
        {
            xepLoai = "Gioi";
        }
        else if (diem >= 7.0)
        {
            xepLoai = "Kha";
        }
        else if (diem >= 5.5)
        {
            xepLoai = "Trung binh";
        }
        else
        {
            xepLoai = "Yeu";
        }

        Console.WriteLine($"Xep loai ca nhan: {xepLoai}");

        string[] tenSV = { "Nguyen Van A", "Tran Thi B", "Le Van C" };
        double[] diemSV = { 8.5, 7.2, 5.8 };

        Console.WriteLine("\n=== Bang Điem ===");
        for (int i = 0; i < tenSV.Length; i++)
        {
            double diemHienTai = diemSV[i];
            string xepLoaiBangDiem;

            if (diemHienTai >= 8.5)
            {
                xepLoaiBangDiem = "Gioi";
            }
            else if (diemHienTai >= 7.0)
            {
                xepLoaiBangDiem = "Kha";
            }
            else if (diemHienTai >= 5.5)
            {
                xepLoaiBangDiem = "Trung binh";
            }
            else
            {
                xepLoaiBangDiem = "Yeu";
            }
            Console.WriteLine($"{tenSV[i]} - Điem: {diemHienTai} - Xep loai: {xepLoaiBangDiem}");
        }

        double tongDiem = 0;
        int j = 0;

        while (j < diemSV.Length)
        {
            tongDiem += diemSV[j];
            j++;
        }

        Console.WriteLine($"\nTong điem: {tongDiem}");
        Console.WriteLine($"Điem trung binh: {tongDiem / diemSV.Length:F2}");
    }
}