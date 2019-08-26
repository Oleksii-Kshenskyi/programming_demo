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
            StartMainMenu();
        }

        static void StartMainMenu()
        {
            string choice = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Vadym number generation application!");
                Console.WriteLine("Please choose what to do:");
                Console.WriteLine("1. Generate random numbers following direct rules.");
                Console.WriteLine("2. Generate random numbers following reversed rules.");
                Console.WriteLine("3. Input a number yourself and let the application verify it.");
                Console.WriteLine("4. Exit the application.");
                Console.Write("==> ");

                ConsoleKeyInfo UserInput;
                UserInput = Console.ReadKey(); // Get user input
                int temp = 0;

                if (char.IsDigit(UserInput.KeyChar) && int.TryParse(UserInput.KeyChar.ToString(), out temp))
                {
                    choice = temp.ToString();

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine();
                            PerformCalculations();
                            break;
                        case "2":
                            Console.WriteLine("\nNot Implemented Yet!");
                            break;
                        case "3":
                            Console.WriteLine("\nNot Implemented Yet!");
                            break;
                        case "4":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("\nDear user, you are a bit dumb, aren't you? Try again!");
                            break;
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\nDear user, you are a bit dumb, aren't you? Try again!");
                    Console.ReadKey();
                }
            } while (choice != "4");
        }
    

        static void PerformCalculations()
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
