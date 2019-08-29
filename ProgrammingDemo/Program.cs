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
            RuleChecker rules = new RuleChecker(RuleDirection.Direct);
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
                            PerformCalculations(RuleDirection.Direct);
                            break;
                        case "2":
                            Console.WriteLine();
                            PerformCalculations(RuleDirection.Reverse);
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
    

        static void PerformCalculations(RuleDirection direction)
        {
            string result = "";

            RuleChecker overarchingChecker = CreateOverarchingRules();
            RuleChecker iterativeChecker = CreateIterativeRules(direction);
            
            Console.WriteLine(string.Format(Strings.NumberDisplay, new RandomGenerator(iterativeChecker, overarchingChecker).Generate()));
            Console.WriteLine("\n" + (new AllCharsInstringAreDigitsRule().ConformsToRule(result) ? Strings.CorrectString : Strings.IncorrectString));
            Console.ReadKey();
        }

        public static RuleChecker CreateIterativeRules(RuleDirection direction)
        {
            int overallIdenticalNumber = Utilities.RequestInputFromUser(Strings.OverallIdenticalRequestText);

            int subsequentIdenticalNumber = Utilities.RequestInputFromUser(Strings.SubsequentIdenticalRequestText);

            RuleChecker checker = new RuleChecker(direction);

            checker.AddRule(new OverallIdenticalNumbersRule(overallIdenticalNumber));
            checker.AddRule(new NotMoreThanYSubsequentNumbersIdenticalRule(subsequentIdenticalNumber));

            return checker;
        }

        public static RuleChecker CreateOverarchingRules()
        {
            int numberOfDigits = Utilities.RequestInputFromUser(Strings.DigitsInNumberRequestText);

            RuleChecker checker = new RuleChecker(RuleDirection.Direct);
            checker.AddRule(new OverallDigitsRule(numberOfDigits));

            return checker;
        }
    }
}
