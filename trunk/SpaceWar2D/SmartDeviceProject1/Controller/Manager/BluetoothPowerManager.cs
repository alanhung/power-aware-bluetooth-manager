using System.Collections.Generic;
using System.Threading;
using InTheHand.Net.Bluetooth;
using PowerAwareBluetooth.Controller.AI;
using PowerAwareBluetooth.Controller.IO;
using PowerAwareBluetooth.Model;

namespace PowerAwareBluetooth.Controller.Manager
{
    // TODO: ADAM (Phone dependent) - add support to wake up the gui when the user wants to

    // TODO: adam - make the bluetoothPowerManager single instance
    public class BluetoothPowerManager
    {
        private BluetoothAdapter m_BluetoothAdapter = new BluetoothAdapter();
        private RuleList m_RuleList;
        private DecisionMaker m_DecisionMaker;
        private bool m_NeedUpdateDecisionMakerRuleList = false;
        private RadioMode m_lastMode;

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
            InitWaitMessageThread();

//            TimeInterval timeInterval1 = new TimeInterval(12, 0, 14, 0);
//            Rule fakeRule1 = new Rule(
//                "adam rule",
//                timeInterval1,
//                RuleActionEnum.TurnOn,
//                new WeekDays(SelectedDays.Everyday), true);
//            TimeInterval timeInterval2 = new TimeInterval(13, 10, 14, 20);
//            Rule fakeRule2 = new Rule(
//                "tal rule", timeInterval2, RuleActionEnum.TurnOn,
//                new WeekDays(SelectedDays.Weekend), false);
//            m_RuleList.Add(fakeRule1);
//            m_RuleList.Add(fakeRule2);
            RadioMode res = m_DecisionMaker.RadioModeDecided();
            
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
            int timeToSleepMillisec;
            while(true)
            {  
                // TODO: adam + tal: think if we need to lock for a smaller scope, do we can at all ?
                // this lock ensures that changes to the rules-list will
                // affect only after a full iteration

                // TODO: adam + tal - what happens if the user changed a rule that applies immediately,
                //      or in a way that might change sleep time (for example - from sleep 4 hours, to sleep 10 minuteS)
                lock (this)
                {
                    if (m_NeedUpdateDecisionMakerRuleList)
                    {
                        m_DecisionMaker.RulesList = m_RuleList;
                        m_NeedUpdateDecisionMakerRuleList = false;
                    }
                    if (m_lastMode != m_BluetoothAdapter.RadioMode)
                    {
                        //user changed the mode while we were sleeping
                        m_DecisionMaker.LearnUserChangedMode(m_BluetoothAdapter.RadioMode);
                    }
                    else
                    {
                        //user didn't change the mode while we were sleeping

                        // gets the decision from the DecisionMaker and handles the bluetooth device
                        m_BluetoothAdapter.RadioMode = m_DecisionMaker.RadioModeDecided();

                        //sample
                        //TODO: TAL see that sampling is done once per time slice
                        m_DecisionMaker.Sample();
                    }
                   
                    m_lastMode = m_BluetoothAdapter.RadioMode;

                    // get the next time to wake-up
                    timeToSleepMillisec = m_DecisionMaker.CalculateCurrentWaitTime();

                    // TODO: debug - remove this in the future
                    timeToSleepMillisec = 15000;
                }

                // sleep - no need to lock when sleeping
                m_DecisionMaker.Sleep(timeToSleepMillisec);
            }
        }

        private TimeLine BuildGlobalTimeLine(TimeLine timeLineFromClassifier, List<Rule>  rules)
        {
            return null;
        }

        /// <summary>
        /// initializes a thread that waits for messages from another process
        /// the messages are changes to the user-defined rules.
        /// </summary>
        private void InitWaitMessageThread()
        {
            Thread thread = new Thread(WaitMessageThreadMethod);
            thread.Name = "WaitForMessageThread";
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// a infinite loop that checks the messages-queue for new messages
        /// and blocks until a new message arrives to the queue
        /// </summary>
        private void WaitMessageThreadMethod()
        {
            WinMessageAdapter.Init();
            while(true)
            {
                // waits for a new message
                WinMessageAdapter.WaitForMessage();

                RuleList newRuleList = IO.IOManager.Load() as RuleList;
                if (newRuleList != null)
                {
                    lock(this)
                    {
                        m_RuleList = newRuleList;
                        m_NeedUpdateDecisionMakerRuleList = true;
                    }
                }
            }
        }
    }
}
