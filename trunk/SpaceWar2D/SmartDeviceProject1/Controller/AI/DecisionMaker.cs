using System.Threading;

namespace PowerAwareBluetooth.Controller.AI
{
    public class DecisionMaker
    {
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


    }
}
