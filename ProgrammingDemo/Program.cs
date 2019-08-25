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

            int numberOfDigits = 0;

            ConsoleKeyInfo UserInput;

            // We check input for a Digit
            do
            {
                Console.Write("How many digits do you want in your number? ==> ");
                UserInput = Console.ReadKey(); // Get user input

                if (char.IsDigit(UserInput.KeyChar))
                {
                    numberOfDigits = int.Parse(UserInput.KeyChar.ToString()); // use Parse if it's a Digit
                }
                else
                {
                    Console.WriteLine("\nDear user, you are a bit dumb, aren't you? Try again!");
                }
            } while (!char.IsDigit(UserInput.KeyChar));

            for (int i = 1; i <= numberOfDigits; i++)
            {
                var digit = generator.Next(0, 10);
                result += digit;
            }
            Console.WriteLine("\nYour " + numberOfDigits + "-digit number is " + result + "!");
            Console.ReadKey();
        }
    }
}
