using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTools
{
    public class OverallIdentialNumbersRule : IRule
    {
        private int OverallIdentical;

        public OverallIdentialNumbersRule(int overallIdentical)
        {
            OverallIdentical = overallIdentical;
        }

        public bool ConformsToRule(string value)
        {
            bool result = false;

            Dictionary<char, int> overallIdentical = new Dictionary<char, int>();
            foreach (char c in value)
            {
                if (!overallIdentical.TryGetValue(c, out int temp))
                {
                    overallIdentical[c] = 0;
                }
                overallIdentical[c]++;

                if (overallIdentical[c] <= OverallIdentical)
                {
                    result = true;
                }
                else
                {
                    return false;
                }
            }

            return result;
        }
    }
}
