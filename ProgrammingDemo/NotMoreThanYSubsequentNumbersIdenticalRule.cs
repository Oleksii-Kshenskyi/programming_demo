using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingDemo
{
    class NotMoreThanYSubsequentNumbersIdenticalRule : IRule
    {
        private int NumberOfRepetitions;

        static private Dictionary<string, string> Pairs;

        static NotMoreThanYSubsequentNumbersIdenticalRule()
        {
            Pairs = new Dictionary<string, string>();
        }

        public NotMoreThanYSubsequentNumbersIdenticalRule(int numberOfRepetitions)
        {
            NumberOfRepetitions = numberOfRepetitions;
        }

        public bool ConformsToRule(string value)
        {
            throw new NotImplementedException();
        }
    }
}
