﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
﻿using System.Threading;
using PowerAwareBluetooth.Model;
using InTheHand.Net.Bluetooth;

namespace PowerAwareBluetooth.Controller.AI
{
    public class DecisionMaker
    {
        private Learner m_learner;
        private BluetoothAdapter m_bluetoothAdapter;
        private RuleList m_rules;

        public DecisionMaker()
        {
            m_learner = new Learner();
            m_bluetoothAdapter = new BluetoothAdapter();
            m_rules = new RuleList(); //TODO: implement RuleList (including binding to gui)

            //register to events 
            m_bluetoothAdapter.BluetoothRadioModeChanged += new BluetoothRadioModeChangedHandler(HandleBluetoothRadioModeChanged);
            //TODO: register to cell phone events
        }

        public bool ToActivate()
        {
            if(IsNowInRulesScope)
            {
                //TODO: implement
                return false;
            }
            else
            {
                return m_learner.ToActivate();
            }
        }

        private void HandleBluetoothRadioModeChanged()
        {
            //if radio mode changed to discoverable then learn - "user uses his bluetooth"
            if (m_bluetoothAdapter.RadioMode == RadioMode.Discoverable)
            {
                m_learner.Learn(true);
            }
            else //radio mode is either off or connectable. learn - "user doesn't uses his bluetooth"
            {
                m_learner.Learn(false);
            }
        }

        //returns true if in the current time is in the rules scope and therefore the bluetooth
        //needs to be activated according to the rules
        private bool IsNowInRulesScope
        {
            //TODO: implement
            return false;
        }

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