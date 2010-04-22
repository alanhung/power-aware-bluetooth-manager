﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
﻿using System.Threading;
using PowerAwareBluetooth.Model;
using InTheHand.Net.Bluetooth;

namespace PowerAwareBluetooth.Controller.AI
{
    internal class DecisionMaker
    {
        private Learner m_learner;
        private BluetoothAdapter m_bluetoothAdapter;
        private BatteryAdapter m_BatteryAdapter = new BatteryAdapter();
        private RuleList m_rules;

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
        /// checks if the blue-tooth device should be activated
        /// </summary>
        /// <returns></returns>
        public bool IsNeedActive()
        {
            //TODO TAL: consider battery power
            Rule rule = m_rules.GetRule(DateTime.Now);
            bool res; 
            if (rule != null)
            {
                res = rule.RuleAction == RuleActionEnum.TurnOn;
            }
            else
            {
                res =  m_learner.ToActivate();
            }
            return res;
        }

        public void Sample()
        {
            //TODO TAL: consider battery power
            bool result = m_bluetoothAdapter.SampleForOtherBluetooth();
            m_learner.Learn(result);
        }

        /// <summary>
        /// called when the radio mode was changed
        /// </summary>
        private void HandleBluetoothRadioModeChanged()
        {
            //TODO: TAL improve this rotten logic - ignore the times when radio mode is changed
            //because of the manager operation

            // if we need to wake up the manager: WakeUp()

            //if radio mode changed to discoverable then learn - "user uses his bluetooth"
            if (m_bluetoothAdapter.RadioMode == RadioMode.Discoverable)
            {
                m_learner.Learn(true);
                //TODO: Tal - decision maker should remember that user activated the bluetooth and 
                //not shut it down next time the manager wakes up
            }
            else //radio mode is either off or connectable. learn - "user doesn't uses his bluetooth"
            {
                m_learner.Learn(false);
                //TODO: Tal - decision maker should remember that user de-activated the bluetooth and 
                //not turn it on next time the manager wakes up
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
            // TODO: TAL implement me
            return 100;
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