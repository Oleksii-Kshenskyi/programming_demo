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
        public static int blah { get; set; }


        static void Main(string[] args)
        {
            StartMainMenu();
            //TestRules();
            Console.ReadKey();
        }

        static void TestRules()
        {
            RuleChecker rules = new RuleChecker();
            rules.AddRule(new NotMoreThanYSubsequentNumbersIdenticalRule(3));

            Console.WriteLine(rules.CheckRules("43332583383338338333") ? "Rules OK!" : "Rules broken :(");
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
            string result = "";

            int numberOfDigits = Utilities.RequestInputFromUser(Strings.DigitsInNumberRequestText);

            int overallIdenticalNumber = Utilities.RequestInputFromUser(Strings.OverallIdenticalRequestText);

            int subsequentIdenticalNumber = Utilities.RequestInputFromUser(Strings.SubsequentIdenticalRequestText);

            RuleChecker checker = new RuleChecker();
            checker.AddRule(new OverallIdentialNumbersRule(overallIdenticalNumber));
            checker.AddRule(new NotMoreThanYSubsequentNumbersIdenticalRule(subsequentIdenticalNumber));

            Console.WriteLine(string.Format(Strings.NumberDisplay, numberOfDigits, GenerateNumberAccordingToRules(checker, numberOfDigits)));
            Console.WriteLine("\n" + (new AllCharsInstringAreDigitsRule().ConformsToRule(result) ? Strings.CorrectString : Strings.IncorrectString));
            Console.ReadKey();
        }

        public static string GenerateNumberAccordingToRules(RuleChecker rulesToCheck, int numberOfDigits)
        {
            string result = "";
            Random generator = new Random();
            int i = 0;
            while (i < numberOfDigits)
            {
                string digit = generator.Next(0,10).ToString();

                if (rulesToCheck.CheckRules(result + digit))
                {
                    i++;
                    result += digit;
                }
            }

            return result;
        }
    }
}
