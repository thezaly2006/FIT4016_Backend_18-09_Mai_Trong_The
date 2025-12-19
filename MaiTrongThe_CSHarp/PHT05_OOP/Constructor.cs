using System;

namespace Constructor
{
    class Product
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public double Gia { get; set; }

        public Product (string maSanPham, string tenSanPham, double gia)
        {
            MaSanPham = maSanPham;
            TenSanPham = tenSanPham;
            Gia = gia;
        }

        public void Display()
        {
            Console.WriteLine("Ma san pham: " + MaSanPham);
            Console.WriteLine("Ten san pham: " + TenSanPham);
            Console.WriteLine("Gia: " + Gia);
            Console.WriteLine("-------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product("SP001", "Laptop", 15000000);
            Product p2 = new Product("SP002", "Smartphone", 800000);

            p1.Display();
            p2.Display();

            Console.ReadLine();
        }
    }
}