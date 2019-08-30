using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTools
{
    public static class Strings
    {
        public static string UserIsDumb = "\n\nDear user, you are a bit dumb, aren't you? Try again!";
        public static string RequestNumberInput = "\n\nPlease input a number to verify ==> ";
        public static string DigitsInNumberRequestText = "\n\nHow many digits do you want in your number? ==> ";
        public static string OverallIdenticalRequestText = "\nMax number of identical digits overall? ==> ";
        public static string SubsequentIdenticalRequestText = "\nMax number of subsequent identical digits? ==> ";
        public static string NumberOfDigits = "\nYour number has {0} digits!";
        public static string NumberDisplay = "\nYour number is {0}";
        public static string UserPrompt = "==> ";
        public static string NumberIsDirect = "\n\nYour number conforms to direct rules!";
        public static string NumberIsReverse = "\n\nYour number conforms to reverse rules!";

        public static string UserMenu = "Welcome to the Vadym number generation application!\n" +
                                        "Please choose what to do:\n" +
                                        "1. Generate random numbers following direct rules.\n" +
                                        "2. Generate random numbers following reversed rules.\n" +
                                        "3. Input a number yourself and let the application verify it.\n" +
                                        "4. Exit the application.\n";
    }
}
