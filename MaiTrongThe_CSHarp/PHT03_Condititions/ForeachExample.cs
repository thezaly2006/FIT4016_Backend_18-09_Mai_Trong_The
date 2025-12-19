using System;

namespace ForeachExample
{
    class Program
    {
        static void Main(string[] args)
        {
           string[] friends = { "Mai", "Binh", "Chi", "Danh"};
           foreach (string friend in friends)
           {
               Console.WriteLine(friend);
           }
        }
    }
}