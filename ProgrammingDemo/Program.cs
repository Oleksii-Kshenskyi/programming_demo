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
            Console.ReadKey();
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

                if (UserInput.KeyChar == '4')
                {
                    Environment.Exit(0);
                }

                if (char.IsDigit(UserInput.KeyChar) && int.TryParse(UserInput.KeyChar.ToString(), out temp))
                {
                    choice = temp.ToString();
                    int numberOfDigits = 0;
                    string numberToVerify = "";
                    if (choice != "3")
                    {
                        numberOfDigits = Utilities.RequestInputFromUser(Strings.DigitsInNumberRequestText);
                    }
                    else
                    {
                        numberToVerify = Utilities.RequestNumberInputFromUser(Strings.RequestNumberInput);
                    }

                    int overallIdenticalNumber = Utilities.RequestInputFromUser(Strings.OverallIdenticalRequestText);
                    int subsequentIdenticalNumber = Utilities.RequestInputFromUser(Strings.SubsequentIdenticalRequestText);
                    if (!UserInputConformsToRules((choice != "3") ? numberOfDigits : numberToVerify.Length, overallIdenticalNumber, subsequentIdenticalNumber))
                    {
                        Console.WriteLine(Strings.UserIsDumb);
                        Console.ReadKey();
                        continue;
                    }
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine();
                            PerformCalculations(RuleDirection.Direct, numberOfDigits, overallIdenticalNumber, subsequentIdenticalNumber);
                            break;
                        case "2":
                            Console.WriteLine();
                            PerformCalculations(RuleDirection.Reverse, numberOfDigits, overallIdenticalNumber, subsequentIdenticalNumber);
                            break;
                        case "3":
                            PerformNumberCheck(overallIdenticalNumber, subsequentIdenticalNumber, numberToVerify);
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
    

        static void PerformCalculations(RuleDirection direction, int numberOfDigits, int overallIdenticalNumber, int subsequentIdenticalNumber)
        {
            RuleChecker overarchingChecker = CreateOverarchingRules(numberOfDigits);
            RuleChecker iterativeChecker = CreateIterativeRules(direction, overallIdenticalNumber, subsequentIdenticalNumber);
            
            Console.WriteLine(string.Format(Strings.NumberDisplay, new RandomGenerator(iterativeChecker, overarchingChecker).Generate(direction)));
            Console.ReadKey();
        }

        static void PerformNumberCheck(int overallIdenticalNumber, int subsequentIdenticalNumber, string numberToVerify)
        {
            RuleChecker iterativeChecker = CreateIterativeRules(RuleDirection.Direct, overallIdenticalNumber, subsequentIdenticalNumber);

            processNumberCheck(iterativeChecker, numberToVerify);
        }

        static void processNumberCheck(RuleChecker iterativeRules, string numberToVerify)
        {
            if (iterativeRules.CheckRules(numberToVerify))
            {
                Console.WriteLine(Strings.NumberIsDirect);
            }
            else
            {
                Console.WriteLine(Strings.NumberIsReverse);
            }
        }

        public static RuleChecker CreateIterativeRules(RuleDirection direction, int overallIdenticalNumber, int subsequentIdenticalNumber)
        {
            RuleChecker checker = new RuleChecker(direction);

            checker.AddRule(new OverallIdenticalNumbersRule(overallIdenticalNumber));
            checker.AddRule(new NotMoreThanYSubsequentNumbersIdenticalRule(subsequentIdenticalNumber));

            return checker;
        }

        public static RuleChecker CreateOverarchingRules(int numberOfDigits)
        {
            RuleChecker checker = new RuleChecker(RuleDirection.Direct);
            checker.AddRule(new OverallDigitsRule(numberOfDigits));

            return checker;
        }

        public static bool UserInputConformsToRules(int first, int second, int third)
        {
            return (first >= second) && (second >= third);
        }
    }
}
