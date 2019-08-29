using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTools
{
    public class OverallDigitsRule : IRule
    {
        private int OverallDigits = -1;

        public OverallDigitsRule(int overallDigits)
        {
            OverallDigits = overallDigits;
        }

        public bool ConformsToRule(string value)
        {
            return value == OverallDigits.ToString();
        }
    }
}
