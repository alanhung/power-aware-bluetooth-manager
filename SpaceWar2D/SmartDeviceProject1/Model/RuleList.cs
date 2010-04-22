using System;
using System.Windows.Forms;
using PowerAwareBluetooth.Common;

namespace PowerAwareBluetooth.Model
{
    class RuleList : AsyncBindingList<Rule>
    {
        public bool IsRuleExist(DateTime dateTime)
        {
            return (GetRule(dateTime) == null);
        }

        public Rule GetRule(DateTime dateTime)
        {
            //TODO: Adam - implement me
            return null;
        }

    }
}
