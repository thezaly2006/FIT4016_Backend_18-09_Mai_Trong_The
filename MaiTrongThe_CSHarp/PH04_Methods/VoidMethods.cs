using System;

namespace VoidMethods
{
    class Program
    {
        static void PrintBox(string text)
        {
            int length = text.Length;
            Console.WriteLine(new string('*', length + 6));
            Console.WriteLine("*   " + text + "   *");
            Console.WriteLine(new string('*', length + 6));
        }

        static void Main(string[] args)
        {
            PrintBox("Hello");
            Console.WriteLine();
            PrintBox("TheZaly so handsome");
            Console.WriteLine();
        }
    }
}