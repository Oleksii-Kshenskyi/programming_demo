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

            int subsequentIdenticalNumber = 0;

            do
            {
                Console.Write("\nMax number of subsequent identical digits? ==> ");
                UserInput = Console.ReadKey(); // Get user input

                if (char.IsDigit(UserInput.KeyChar))
                {
                    subsequentIdenticalNumber = int.Parse(UserInput.KeyChar.ToString()); // use Parse if it's a Digit
                }
                else
                {
                    Console.WriteLine("\nDear user, you are a bit dumb, aren't you? Try again!");
                }
            } while (!char.IsDigit(UserInput.KeyChar));

            Dictionary<int, int> subsequentIdentical = new Dictionary<int, int>();
            for (int i = 1; i <= numberOfDigits; i++)
            {
                bool ok = false;
                while (!ok)
                {
                    var digit = generator.Next(0, 10);
                    int temp = 0;
                    if (!subsequentIdentical.TryGetValue(digit, out temp))
                    {
                        subsequentIdentical[digit] = 0;
                    }
                    subsequentIdentical[digit]++;

                    if (subsequentIdentical[digit] <= subsequentIdenticalNumber)
                    {
                        result += digit;
                        ok = true;
                    }
                }
            }

            Console.WriteLine("\nYour " + numberOfDigits + "-digit number is " + result + "!");
            Console.WriteLine("\n" + (new AllCharsInstringAreDigitsRule().ConformsToRule(result) ? "Your string is correct!" : "Your string is incorrect!"));
            Console.ReadKey();
        }
    }
}
