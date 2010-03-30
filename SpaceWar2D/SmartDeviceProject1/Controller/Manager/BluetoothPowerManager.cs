using System;
using System.Collections.Generic;
using PowerAwareBluetooth.Controller.AI;
using PowerAwareBluetooth.Model;

namespace PowerAwareBluetooth.Controller.Manager
{
    class BluetoothPowerManager
    {
        private TimeClassifier m_TimeClassifier;
        private BluetoothAdapter m_BluetoothAdapter;
        private RuleList m_RuleList;

        public RuleList RulesList
        {
            get { return m_RuleList; }
        }

        public BluetoothPowerManager()
        {
            //initialize adapter
            m_BluetoothAdapter = new BluetoothAdapter();
            
            // load rule list from the sim-card/hard disk
            m_RuleList = new RuleList();
            TimeInterval timeInterval1 = new TimeInterval(3, 0, 4, 0);
            Rule fakeRule1 = new Rule(
                "adam rule",
                timeInterval1,
                RuleActionEnum.TurnOff,
                new WeekDays(SelectedDays.Everyday), true);
            TimeInterval timeInterval2 = new TimeInterval(13, 10, 14, 20);
            Rule fakeRule2 = new Rule(
                "tal rule", timeInterval2, RuleActionEnum.TurnOn,
                new WeekDays(SelectedDays.Weekend), false);
            m_RuleList.Add(fakeRule1);
            m_RuleList.Add(fakeRule2);
            
        }

        /// <summary>
        /// manages the blue-tooth according to the <see cref="TimeLine"/>
        /// </summary>
        public void Start()
        {
            // gets the time line from the classifier

            // manages the power according to the timeline

            // needs to register to blue tooth events

        }

        private TimeLine BuildGlobalTimeLine(TimeLine timeLineFromClassifier, List<Rule>  rules)
        {
            return null;
        }
    }
}
