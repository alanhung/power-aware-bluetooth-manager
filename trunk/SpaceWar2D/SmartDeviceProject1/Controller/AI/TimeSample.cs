using System;

namespace PowerAwareBluetooth.Controller.AI
{
    public class TimeSample
    {
        public enum SampleResult
        {
            CONNECTED,
            NOT_CONNECTED
        }

        private DateTime m_SampleTime;
        private SampleResult m_SampleResult;
        
    }
}