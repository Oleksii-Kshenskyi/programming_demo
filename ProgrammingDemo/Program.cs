using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Random generator = new Random();
            string result = "";
            for (int i = 1; i <= 8; i++)
            {
                var digit = generator.Next(0, 10);
                result += digit;
            }
            Console.WriteLine("Your 8-digit number is " + result + "!");
            Console.ReadKey();
        }
    }
}
