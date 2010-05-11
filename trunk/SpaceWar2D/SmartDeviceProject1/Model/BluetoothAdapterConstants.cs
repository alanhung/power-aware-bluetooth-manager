using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PowerAwareBluetooth.Model
{
    internal class BluetoothAdapterConstants
    {
        public class Learning
        {
            public  const int MinimumTimeAfterUserExplicitControl = 30;
            public  const PowerAwareBluetooth.Controller.AI.Learner.TimeSliceLength DEFAULT_SLICE_LENGTH 
                                        = PowerAwareBluetooth.Controller.AI.Learner.TimeSliceLength.TEN_MINUTE;
            public  const int DEFAULT_MINIMUM_ON_INTERVAL = 30; // in minutes
            public const int DEFAULT_WAITING_TIME_BETWEEN_SAMPLES = 1000 * 60 * 10; // 10 minutes
        }
    }
}
