using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTools
{
    public class RandomGenerator : IGenerator
    {
        private RuleChecker IterativeRules { get; set; }
        private RuleChecker OverarchingRules { get; set; }

        public RandomGenerator(RuleChecker iterativeRules, RuleChecker overarchingRules)
        {
            IterativeRules = iterativeRules;
            OverarchingRules = overarchingRules;
        }

        public string Generate(RuleDirection direction)
        {
            return (direction == RuleDirection.Direct) ? GenerateDirectNumber() : GenerateReverseNumber();
        }

        private string GenerateDirectNumber()
        {
            string result = "";
            Random generator = new Random();
            int i = 0;
            while (!OverarchingRules.CheckRules(i.ToString()))
            {
                string digit = generator.Next(0, 10).ToString();

                if (IterativeRules.CheckRules(result + digit))
                {
                    i++;
                    result += digit;
                }
            }

            return result;
        }

        private string GenerateReverseNumber()
        {
            string result = "";
            Random generator = new Random();
            int i = 0;
            do
            {
                result = "";
                i = 0;
                while (!OverarchingRules.CheckRules(result.Length.ToString()))
                {
                    string digit = generator.Next(0, 10).ToString();
                    i++;
                    result += digit;
                }
            } while (!IterativeRules.CheckRules(result));

            return result;
        }
    }
}
