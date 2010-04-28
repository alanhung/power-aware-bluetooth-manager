using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PowerAwareBluetooth.Controller.AI
{
    /// <summary>
    /// learns how a user is using his device by time
    /// </summary>
    public class Learner
    {
        #region State Machine
        
        /// <summary>
        /// a single state machine
        /// </summary>
        protected class StateMachine
        {
            private States m_currentState;
            
            private const States MAX_STATE = States.ON_HARD;
            private const States MIN_STATE = States.OFF_HARD;
            
            /// <summary>
            /// represents State in the learning state machine
            /// </summary>
            public enum States
            {
                OFF_HARD = -2,
                OFF = -1,
                ON = 0,
                ON_HARD = 1
            }

            /// <summary>
            /// C'tor
            /// </summary>
            public StateMachine()
            {
                //default state is ON
                m_currentState = States.ON;
            }
            
            /// <summary>
            /// Increment the State (for example move from ON to ON_HARD)
            /// </summary>
            public void IncrementState()
            {
                if (m_currentState < MAX_STATE)
                {
                    m_currentState++;
                }
            }

            /// <summary>
            /// Decrement the state (for example move from ON_HARD to ON)
            /// </summary>
            public void DecrementState()
            {
                if (m_currentState > MIN_STATE)
                {
                    m_currentState--;
                }
            }

            /// <summary>
            /// return the current state of the state machine
            /// </summary>
            public States CurrentState
            {
                get
                {
                    return m_currentState;
                }
            }
        }
        #endregion State Machine

        public enum TimeSliceLength
        {
            ONE_MINUTE = 1,
            FIVE_MINUTE = 5,
            TEN_MINUTE = 10,
            FIFTEEN_MINUTE = 15,
            THIRTY_MINUTE = 30
        }
        
        //slices repeat after a week
        private static TimeSliceLength DEFAULT_SLICE_LENGTH = TimeSliceLength.TEN_MINUTE;
        private static int DEFAULT_MINIMUM_ON_INTERVAL = 30; // in minutes
        
        private int TIME_SLICE_LENGTH;
        private int TOTAL_TIME_SLICES_NUM;
        private int SLICES_PER_DAY;
        private int SLICES_PER_HOUR;
        private int SLICES_FOR_MINIMUM_ON_INTERVAL; //represents the minimum time inetrval the bluetooth is on

        private StateMachine[] m_timeLine; 

        public Learner(TimeSliceLength timeSliceLength)
        {
            int daysInWeek  = 7;
            int hoursInDay = 24;
            int minutesInHour = 60;

            TIME_SLICE_LENGTH = (int)timeSliceLength;
            SLICES_PER_HOUR = minutesInHour / TIME_SLICE_LENGTH;
            SLICES_PER_DAY = SLICES_PER_HOUR * hoursInDay;
            TOTAL_TIME_SLICES_NUM = SLICES_PER_DAY * daysInWeek;
            SLICES_FOR_MINIMUM_ON_INTERVAL = DEFAULT_MINIMUM_ON_INTERVAL / (TIME_SLICE_LENGTH * 2);

            m_timeLine = new StateMachine[TOTAL_TIME_SLICES_NUM];
            

        }

        public Learner() : this(DEFAULT_SLICE_LENGTH) { }

        /// <summary>
        /// Learn the given result
        /// </summary>
        /// <param name="result">true means bluetooth in use false means bluetooth is off</param>
        public void Learn(bool result)
        {
            if (result)
            {
                m_timeLine[NowToSliceNum()].IncrementState();
            }
            else
            {
                m_timeLine[NowToSliceNum()].DecrementState();
            }
        }

        /// <summary>
        /// whether to activate the bluetooth or not.
        /// this function refers to Now
        /// </summary>
        /// <returns></returns>
        public bool ToActivate()
        {
            return IsCurrentStateInOnInterval();
        }

        /// <summary>
        /// gets and sets the minimum interval the  bluetooth is on 
        /// works in minutes
        /// </summary>
        public int MinimumOnInterval
        {
            get
            {
                return SLICES_FOR_MINIMUM_ON_INTERVAL * 2 * TIME_SLICE_LENGTH;
            }
            set
            {
                SLICES_FOR_MINIMUM_ON_INTERVAL = value / (TIME_SLICE_LENGTH * 2);
            }
        }
        
        private int NowToSliceNum()
        {
            DateTime currentTime = DateTime.Now;
            int day = (int) currentTime.DayOfWeek; //sunday = 0, monday = 1, ...
            int hour = currentTime.Hour;
            int minutes = currentTime.Minute;

            return ((day) * SLICES_PER_DAY) + (hour * SLICES_PER_HOUR) + (minutes / TIME_SLICE_LENGTH);
        }

        private bool IsCurrentStateInOnInterval()
        {
            int currentSlice = NowToSliceNum();
            
            bool res = false;
            //see whether one of the slices in the interval around the current slice is on
            //TODO: TAL - see that i is not negative in for
            //TODO: remove this - debug that avoids null exception
            return res;
            for (int i = (currentSlice - SLICES_FOR_MINIMUM_ON_INTERVAL); i < (currentSlice + SLICES_FOR_MINIMUM_ON_INTERVAL); i++)
            {
                if (m_timeLine[i].CurrentState >= StateMachine.States.ON)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }



    }


}
