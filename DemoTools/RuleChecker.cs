using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTools
{
    public class RuleChecker
    {
        private List<IRule> Rules { get; set; }
        public RuleDirection Direction { get; set; }
        public RuleChecker(RuleDirection direction)
        {
            Rules = new List<IRule>();
            Direction = direction;
        }

        public void AddRule(IRule newRule)
        {
            Rules.Add(newRule);
        }

        public bool CheckRules(string stringToCheck)
        {
            return (Direction == RuleDirection.Direct) ? CheckDirectRules(stringToCheck) : CheckReverseRules(stringToCheck);
        }

        private bool CheckDirectRules(string stringToCheck)
        {
            return Rules.All( x => x.ConformsToRule(stringToCheck));
        }

        private bool CheckReverseRules(string stringToCheck)
        {
            return Rules.All(x => !x.ConformsToRule(stringToCheck));
        }
    }
}
