using System.Collections.Generic;
using InTheHand.Net.Bluetooth;
using PowerAwareBluetooth.Controller.AI;
using PowerAwareBluetooth.Controller.IO;
using PowerAwareBluetooth.Model;

namespace PowerAwareBluetooth.Controller.Manager
{
    // TODO: ADAM (Phone dependent) - add support to wake up the gui when the user wants to
    class BluetoothPowerManager
    {
        private BluetoothAdapter m_BluetoothAdapter = new BluetoothAdapter();
        private RuleList m_RuleList;
        private DecisionMaker m_DecisionMaker;

        public RuleList RulesList
        {
            get { return m_RuleList; }
        }

        /// <summary>
        /// creates the bluetooth power manager
        /// 1. initializes the adapter
        /// 2. initializes the decision maker
        /// </summary>
        public BluetoothPowerManager()
        {
            // load rule list from the sim-card/hard disk
            m_RuleList = LoadRuleList();
            m_DecisionMaker = new DecisionMaker(m_BluetoothAdapter, m_RuleList);
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
            bool res = m_DecisionMaker.IsNeedActive();
            
        }

        private RuleList LoadRuleList()
        {
            RuleList retList = IOManager.Load() as RuleList;
            if (retList == null)
            {
                retList = new RuleList();
            }
            return retList;
        }

        /// <summary>
        /// manages the blue-tooth according to the <see cref="TimeLine"/>
        /// </summary>
        public void Start()
        {
            while(true)
            {
                // gets the decision from the DecisionMaker and handles the bluetooth device
                if (m_DecisionMaker.IsNeedActive())
                {
                    m_BluetoothAdapter.RadioMode = RadioMode.Discoverable;
                }
                else
                {
                    m_BluetoothAdapter.RadioMode = RadioMode.PowerOff;
                }

                //sample
                // m_DecisionMaker.Sample();

                // get the next time to wake-up
                int timeToSleepMillisec = m_DecisionMaker.CalculateCurrentWaitTime();

                // sleep
                m_DecisionMaker.Sleep(timeToSleepMillisec);
            }
        }

        private TimeLine BuildGlobalTimeLine(TimeLine timeLineFromClassifier, List<Rule>  rules)
        {
            return null;
        }
    }
}
