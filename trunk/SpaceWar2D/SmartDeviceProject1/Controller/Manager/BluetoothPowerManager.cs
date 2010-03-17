using System.Collections.Generic;
using PowerAwareBluetooth.Controller.AI;
using PowerAwareBluetooth.Model;

namespace PowerAwareBluetooth.Controller.Manager
{
    class BluetoothPowerManager
    {
        private TimeClassifier m_TimeClassifier;
        private BluetoothAdapter m_BluetoothAdapter;
        private List<Rule> m_Rules;

        /// <summary>
        /// manages the blue-tooth according to the <see cref="TimeLine"/>
        /// </summary>
        public void Start()
        {
            // gets the time line from the classifier

            // manages the power according to the timeline

            // needs to register to blue tooth events

        }

        private TimeLine BuildGlobalTimeLine(TimeLine timeLineFromClassifier, List<Rule>)
        {
            return null;
        }
    }
}
