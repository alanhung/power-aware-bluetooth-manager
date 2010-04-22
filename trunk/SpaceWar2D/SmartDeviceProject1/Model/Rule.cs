using PowerAwareBluetooth.Settings;

namespace PowerAwareBluetooth.Model
{
    // TODO: adam - add rules collision
    public class Rule
    {
        /// <summary>
        /// the name of the rule
        /// </summary>
        private string m_Name;

        /// <summary>
        /// a boolean array that indicates for which days the rule applies
        /// </summary>
        private WeekDays m_ActiveWeekDays;


        /// <summary>
        /// the period of time in the day the rule is relevant
        /// </summary>
        private TimeInterval m_TimeInterval;

        /// <summary>
        /// the action that will be made when the rule is activated
        /// </summary>
        private RuleActionEnum m_RuleAction;

        /// <summary>
        /// indicates if the rule is active
        /// </summary>
        private bool m_Enabled;

        public Rule(
            string name,
            TimeInterval timeInterval,
            RuleActionEnum ruleAction,
            WeekDays activeDays,
            bool enabled)
        {
            m_Name = name;
            m_TimeInterval = timeInterval;
            m_RuleAction = ruleAction;
            m_Enabled = enabled;
            m_ActiveWeekDays = activeDays;
        }

        /// <summary>
        /// the name of the rule
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        /// <summary>
        /// the period of time in the day the rule is relevant
        /// </summary>
        public TimeInterval TimeInterval
        {
            get { return m_TimeInterval; }
            set { m_TimeInterval = value; }
        }

        /// <summary>
        /// a boolean array that indicates for which days the rule applies
        /// </summary>
        public WeekDays ActiveWeekDays
        {
            get { return m_ActiveWeekDays; }
            set { m_ActiveWeekDays = value; }
        }

        /// <summary>
        /// the action that will be made when the rule is activated
        /// </summary>
        public RuleActionEnum RuleAction
        {
            get { return m_RuleAction; }
            set { m_RuleAction = value; }
        }

        /// <summary>
        /// indicates if the rule is active
        /// </summary>
        public bool Enabled
        {
            get { return m_Enabled; }
            set { m_Enabled = value; }
        }
    }
}
