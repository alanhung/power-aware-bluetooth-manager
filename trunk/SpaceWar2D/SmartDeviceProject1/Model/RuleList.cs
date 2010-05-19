using System;
using System.Collections.Generic;
using PowerAwareBluetooth.Common;

namespace PowerAwareBluetooth.Model
{
    /// <summary>
    /// a list of user-defined rules. rules can be entered using the window form
    /// <see cref="AddRuleForm"/>.
    /// </summary>
    public class RuleList : List<Rule>
    {
        /// <summary>
        /// converts the list to an <see cref="AsyncBindingList"/> that can be used
        /// with ui objects.
        /// </summary>
        /// <returns></returns>
        public AsyncBindingList<Rule> ToAsyncBindingList()
        {
            AsyncBindingList<Rule> retList = new AsyncBindingList<Rule>();
            foreach (Rule rule in this)
            {
                retList.Add(rule);
            }
            return retList;
        }

        /// <summary>
        /// tests if a rule exists for the specified time
        /// </summary>
        /// <param name="dateTime">the time that will be used to search for the rule</param>
        /// <returns>true if a rule was found, false otherwise</returns>
        public bool IsRuleExist(DateTime dateTime)
        {
            return (GetRule(dateTime) == null);
        }

        /// <summary>
        /// searched for a rule that corresponds to the given date-time object
        /// </summary>
        /// <param name="dateTime">the time that will be used to search for the rule</param>
        /// <returns>a rule that matched the given time, or null if non were found</returns>
        public Rule GetRule(DateTime dateTime)
        {
            Rule matchingRule = null;
            foreach (Rule rule in this)
            {
                if (rule.IsRelevant(dateTime))
                {
                    matchingRule = rule;
                    break;
                }
            }
            return matchingRule;
        }

        public Rule GetCollidingRule(Rule ruleToTest)
        {
            Rule collidingRule = null;
            foreach (Rule rule in this)
            {
                if (rule.IsCollidesWith(ruleToTest))
                {
                    collidingRule = rule;
                    break;
                }
            }
            return collidingRule;
        }
    }
}
