using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using PowerAwareBluetooth.Model;
using InTheHand.Net.Bluetooth;

namespace PowerAwareBluetooth.Controller.AI
{
    internal class DecisionMaker
    {
        #region Members

        private Learner m_learner;
        private BluetoothAdapter m_bluetoothAdapter;
        private BatteryAdapter m_BatteryAdapter = new BatteryAdapter();
        private RuleList m_rules;
        
        private bool m_enableLearning = true;
        private DateTime m_waitAfterUserControl = DateTime.MinValue;
        private int m_waitTimeBetweenSamples = BluetoothAdapterConstants.Learning.DEFAULT_WAITING_TIME_BETWEEN_SAMPLES;

        #endregion Members

        public DecisionMaker(BluetoothAdapter bluetoothAdapter, RuleList ruleList)
        {
            m_learner = new Learner();
            m_bluetoothAdapter = bluetoothAdapter;
            m_rules = ruleList;

            //register to events 
            m_bluetoothAdapter.BluetoothRadioModeChanged += HandleBluetoothRadioModeChanged;
            //TODO: TAL register to cell phone events
        }

        /// <summary>
        /// return the decision maker decision (what radio mode should the bluetooth be in)
        /// </summary>
        /// <returns></returns>
        public RadioMode RadioModeDecided()
        {
            //TODO TAL: consider battery power - done!
            
            RadioMode res;
            if (DateTime.Now < m_waitAfterUserControl)
            {
                res = m_bluetoothAdapter.RadioMode;
            }
            else
            {
                //check if user defined rule for the current time
                Rule rule = m_rules.GetRule(DateTime.Now);

                if (rule != null)
                {
                    if(rule.RuleAction == RuleActionEnum.TurnOn)
                    {
                        res = RadioMode.Discoverable;
                    }
                    else
                    {
                        res = RadioMode.PowerOff;
                    }
                    
                }
                else
                {
                    //no rule - go according to learner and battery power
                    bool learnerDecision = m_learner.ToActivate();
                    res = RadioMode.PowerOff;
                    if (m_learner.ToActivate())
                    {
                        //listen to learner only if battery is not low or battery is charging
                        if (!m_BatteryAdapter.BatteryLow || m_BatteryAdapter.BatteryCharching)
                        {
                            res = RadioMode.Discoverable;
                        }
                    }
                }

            }
            
            return res;
        }

        /// <summary>
        /// sample for other bluetooth and learn the result
        /// </summary>
        public void Sample()
        {
            //TODO TAL: consider battery power - should this be here or in the decision making? - done!
            bool result = m_bluetoothAdapter.SampleForOtherBluetooth();
            m_learner.Learn(result);
        }

        /// <summary>
        /// enable or disable the learning mechanism
        /// one should set this flag to false if he's about to activate the bluetooth
        /// and remember to turn back on after bluetooth is activated
        /// </summary>
        public bool EnableLearning
        {
            get
            {
                return m_enableLearning;
            }
            set
            {
                m_enableLearning = value;
            }
        }

        /// <summary>
        /// called when the radio mode was changed
        /// </summary>
        private void HandleBluetoothRadioModeChanged()
        {
            //TODO: TAL improve this rotten logic - ignore the times when radio mode is changed
            //because of the manager operation - done

            // if we need to wake up the manager: WakeUp()

            //TODO: Tal - decision maker should remember that user de-activated the bluetooth and 
            //not turn it on next time the manager wakes up - done
            if (m_enableLearning)
            {
                //if radio mode changed to discoverable then learn - "user uses his bluetooth"
                if (m_bluetoothAdapter.RadioMode == RadioMode.Discoverable)
                {
                    m_learner.Learn(true);
                    //don't touch bluetooth for next Constant minutes
                    m_waitAfterUserControl = DateTime.Now.AddMinutes(BluetoothAdapterConstants.Learning.MinimumTimeAfterUserExplicitControl);
                }
                else //radio mode is either off or connectable. learn - "user doesn't uses his bluetooth"
                {
                    m_learner.Learn(false);
                    //don't touch bluetooth for next Constant minutes
                    m_waitAfterUserControl = DateTime.Now.AddMinutes(BluetoothAdapterConstants.Learning.MinimumTimeAfterUserExplicitControl);
                    
                }
            }
            
        }

//        //returns true if in the current time is in the rules scope and therefore the bluetooth
//        //needs to be activated according to the rules
//        private bool IsNowInRulesScope()
//        {
//            m_rules.           
//        }

        #region Threads
        private AutoResetEvent m_RuleInterruptAutoResetEvent = new AutoResetEvent(false);

        // reset    --> state = not signaled --> threads will block
        // set      --> state = signaled     --> releases waiting threads

        /// <summary>
        /// calculates the number of milliseconds that the manager
        /// should wait until asking for the next action
        /// </summary>
        /// <returns>the number of milliseconds to sleep</returns>
        public int CalculateCurrentWaitTime()
        {
            // TODO: TAL support different time sampling
            //return 1000;
            return m_waitTimeBetweenSamples;
        }

        /// <summary>
        /// waits for a <see cref="m_RuleInterruptAutoResetEvent"/> to occur. 
        /// </summary>
        /// <param name="timeout">the timeout in milliseconds to wait for the
        /// event</param>
        public void Sleep(int timeout)
        {
            m_RuleInterruptAutoResetEvent.WaitOne(timeout, false);
        }

        /// <summary>
        /// wakes up threads that are waiting on <see cref="m_RuleInterruptAutoResetEvent"/>
        /// </summary>
        private void WakeUp()
        {
            m_RuleInterruptAutoResetEvent.Set();
        }

        #endregion Threads

  
    }
}