using System;
using System.Collections.Generic;
using DemoTools;
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
                Console.WriteLine(Strings.UserMenu);
                Console.Write(Strings.UserPrompt);

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
                            Console.WriteLine(Strings.NotImplemented);
                            break;
                        case "3":
                            Console.WriteLine(Strings.NotImplemented);
                            break;
                        case "4":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine(Strings.UserIsDumb);
                            break;
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine(Strings.UserIsDumb);
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
                Console.Write(Strings.DigitsInNumberRequestText);
                UserInput = Console.ReadKey(); // Get user input

                if (char.IsDigit(UserInput.KeyChar))
                {
                    numberOfDigits = int.Parse(UserInput.KeyChar.ToString()); // use Parse if it's a Digit
                }
                else
                {
                    Console.WriteLine(Strings.UserIsDumb);
                }
            } while (!char.IsDigit(UserInput.KeyChar));

            int overallIdenticalNumber = 0;

            do
            {
                Console.Write(Strings.OverallIdenticalRequestText);
                UserInput = Console.ReadKey(); // Get user input

                if (char.IsDigit(UserInput.KeyChar))
                {
                    overallIdenticalNumber = int.Parse(UserInput.KeyChar.ToString()); // use Parse if it's a Digit
                }
                else
                {
                    Console.WriteLine(Strings.UserIsDumb);
                }
            } while (!char.IsDigit(UserInput.KeyChar));

            int subsequentIdenticalNumber = -1;
            do
            {
                Console.Write(Strings.SubsequentIdenticalRequestText);
                UserInput = Console.ReadKey(); // Get user input

                if (char.IsDigit(UserInput.KeyChar))
                {
                    subsequentIdenticalNumber = int.Parse(UserInput.KeyChar.ToString()); // use Parse if it's a Digit
                }
                else
                {
                    Console.WriteLine(Strings.UserIsDumb);
                }
            } while (!char.IsDigit(UserInput.KeyChar));

            Dictionary<int, int> overallIdentical = new Dictionary<int, int>();
            int previousDigit = -1;
            int numberOfRepetitions = 1;
            for (int i = 1; i <= numberOfDigits; i++)
            {
                bool ok1 = false;
                bool ok2 = true;
                while (!ok1 || !ok2)
                {
                    var digit = generator.Next(0, 10);
                    int temp = 0;
                    if (!overallIdentical.TryGetValue(digit, out temp))
                    {
                        overallIdentical[digit] = 0;
                    }
                    overallIdentical[digit]++;

                    if (previousDigit == digit)
                    {
                        numberOfRepetitions++;
                    }
                    else
                    {
                        numberOfRepetitions = 1;
                    }

                    if (overallIdentical[digit] <= overallIdenticalNumber)
                    {
                        ok1 = true;
                    }

                    if (numberOfRepetitions > subsequentIdenticalNumber)
                    {
                        ok2 = false;
                    }
                    else if (numberOfRepetitions <= subsequentIdenticalNumber)
                    {
                        ok2 = true;
                    }

                    if (ok1 && ok2)
                    {
                        result += digit;
                        previousDigit = digit;
                    }
                }
            }

            Console.WriteLine(string.Format(Strings.NumberDisplay, numberOfDigits, result));
            Console.WriteLine("\n" + (new AllCharsInstringAreDigitsRule().ConformsToRule(result) ? Strings.CorrectString : Strings.IncorrectString));
            Console.ReadKey();
        }
    }
}
