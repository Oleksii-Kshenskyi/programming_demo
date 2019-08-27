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
    }
}
