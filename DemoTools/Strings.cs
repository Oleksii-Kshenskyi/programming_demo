﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTools
{
    public static class Strings
    {
        public static string UserIsDumb = "\nDear user, you are a bit dumb, aren't you? Try again!";
        public static string DigitsInNumberRequestText = "How many digits do you want in your number? ==> ";
        public static string OverallIdenticalRequestText = "\nMax number of identical digits overall? ==> ";
        public static string SubsequentIdenticalRequestText = "\nMax number of subsequent identical digits? ==> ";
        public static string NumberDisplay = "\nYour {0}-digit number is {1}!";
        public static string CorrectString = "Your string is correct!";
        public static string IncorrectString = "Your string is incorrect!";
        public static string UserPrompt = "==> ";
        public static string NotImplemented = "\nNot Implemented Yet!";

        public static string UserMenu = "Welcome to the Vadym number generation application!\n" +
                                        "Please choose what to do:\n" +
                                        "1. Generate random numbers following direct rules.\n" +
                                        "2. Generate random numbers following reversed rules.\n" +
                                        "3. Input a number yourself and let the application verify it.\n" +
                                        "4. Exit the application.\n";
    }
}