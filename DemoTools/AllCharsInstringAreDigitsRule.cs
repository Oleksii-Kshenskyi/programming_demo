using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTools
{
    public class AllCharsInstringAreDigitsRule : IRule
    {
        public bool ConformsToRule(string value)
        {
            return value.All(x => char.IsDigit(x));
        }
    }
}
