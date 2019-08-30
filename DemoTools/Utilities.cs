using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTools
{
    public static class Utilities
    {
        public static int RequestInputFromUser(string userPrompt)
        {
            int output = 0;

            ConsoleKeyInfo UserInput;

            // We check input for a Digit
            do
            {
                Console.Write(userPrompt);
                UserInput = Console.ReadKey(); // Get user input

                if (char.IsDigit(UserInput.KeyChar))
                {
                    output = int.Parse(UserInput.KeyChar.ToString()); // use Parse if it's a Digit
                }
                else
                {
                    Console.WriteLine(Strings.UserIsDumb);
                }
            } while (!char.IsDigit(UserInput.KeyChar));

            return output;
        }

        public static string RequestNumberInputFromUser(string userPrompt)
        {
            string UserInput;
            bool conformsToRules = false;

            // We check input for a Digit
            do
            {
                Console.Write(userPrompt);
                UserInput = Console.ReadLine(); // Get user input
                conformsToRules = UserInput.All(x => char.IsDigit(x));

                if (!conformsToRules)
                {
                    Console.WriteLine(Strings.UserIsDumb);
                }
            } while (!conformsToRules);

            return UserInput;
        }
    }
}
