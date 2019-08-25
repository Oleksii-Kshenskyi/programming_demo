using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingDemo
{
    class AllCharsInstringAreDigitsRule : IRule
    {
        public bool ConformsToRule(string value)
        {
            return value.All(x => char.IsDigit(x));
        }
    }
}
