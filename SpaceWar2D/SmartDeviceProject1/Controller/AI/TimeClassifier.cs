using System.Collections.Generic;
using PowerAwareBluetooth.Model;

namespace PowerAwareBluetooth.Controller.AI
{
    /// <summary>
    /// the time classifier should save the Results and the last timeline to the HD
    /// </summary>
    public class TimeClassifier
    {
        private List<TimeSample.SampleResult> m_SampleResultList;
        
        public void AddExample(TimeSample.SampleResult sampleResult)
        {
            
        }

        public TimeLine GetTimeLine()
        {
            return null;
        }

    }
}