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

        /// <summary>
        /// searches for a rule that collides with the given rule
        /// </summary>
        /// <param name="ruleToTest">the rule that a colliding rule will collide with</param>
        /// <param name="indexToSkip">an index to skip when iterating the rules list, this parameter can be null</param>
        /// <returns>a rule that collides with the given rule if one exists, null otherwise</returns>
        public Rule GetCollidingRule(Rule ruleToTest, int? indexToSkip)
        {
            Rule collidingRule = null;
            for (int i = 0; i < this.Count; ++i)
            {
                if (indexToSkip.HasValue && indexToSkip.Value == i)
                {
                    continue;
                }
                Rule rule = this[i];
                if (rule.IsCollidesWith(ruleToTest))
                {
                    collidingRule = rule;
                    break;
                }
            }
            return collidingRule;
        }

        /// <summary>
        /// tests if a rule exists with a given name.
        /// </summary>
        /// <param name="ruleName">the name to test</param>
        /// <returns>true if such rule exists, false otherwise</returns>
        public bool ContainsByName(string ruleName)
        {
            foreach (Rule rule in this)
            {
                if (rule.Name.Equals(ruleName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
