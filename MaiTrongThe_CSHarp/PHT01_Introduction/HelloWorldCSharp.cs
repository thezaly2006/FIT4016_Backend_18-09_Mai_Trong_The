using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Chao mung đen voi C#");

        string ten =  "Nguyen Van A";
        int tuoi = 20;
        double diem = 8.5;
        Console.WriteLine("Ten: " + ten);
        Console.WriteLine("Tuoi: " + tuoi);
        Console.WriteLine("Điem: " + diem);
        
        Console.WriteLine($"Thong tin: {ten}, Tuoi: {tuoi}, Điem: {diem}");
    }
}