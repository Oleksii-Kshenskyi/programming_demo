using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTools
{
    public class NotMoreThanYSubsequentNumbersIdenticalRule : IRule
    {
        private int NumberOfRepetitions;

        public NotMoreThanYSubsequentNumbersIdenticalRule(int numberOfRepetitions)
        {
            NumberOfRepetitions = numberOfRepetitions;
        }

        public bool ConformsToRule(string value)
        {
            int numberOfRepetitions = 1;
            char previousDigit = 'k';

            for (int i = 0; i < value.Length; i++)
            {
                if (previousDigit == value[i])
                {
                    numberOfRepetitions++;
                }
                else
                {
                    numberOfRepetitions = 1;
                }

                if (numberOfRepetitions > NumberOfRepetitions)
                {
                    return false;
                }

                previousDigit = value[i];
            }

            return true;
            
        }
    }
}
