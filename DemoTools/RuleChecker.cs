using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTools
{
    public class RuleChecker
    {
        public List<IRule> Rules { get; private set; }
        public RuleChecker()
        {
            Rules = new List<IRule>();
        }

        public void AddRule(IRule newRule)
        {
            Rules.Add(newRule);
        }

        public bool CheckRules(string stringToCheck)
        {
            return Rules.All( x => x.ConformsToRule(stringToCheck));
        }
    }
}
