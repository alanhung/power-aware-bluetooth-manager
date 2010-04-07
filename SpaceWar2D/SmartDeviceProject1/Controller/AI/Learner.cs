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
            TWENTY_MINUTE = 20            
        }
        
        //slices repeat after a week
        private static TimeSliceLength DEFAULT_SLICE_LENGTH = TimeSliceLength.TEN_MINUTE;
        private int TIME_SLICE_LENGTH;
        private int TOTAL_TIME_SLICES_NUM;
        private int SLICES_PER_DAY;
        private int SLICES_PER_HOUR;

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
                m_timeLine[NowToInt()].IncrementState();
            }
            else
            {
                m_timeLine[NowToInt()].DecrementState();
            }
        }
        
        private int NowToInt()
        {
            DateTime currentTime = DateTime.Now;
            int day = (int) currentTime.DayOfWeek; //sunday = 0, monday = 1, ...
            int hour = currentTime.Hour;
            int minutes = currentTime.Minute;

            return ((day) * SLICES_PER_DAY) + (hour * SLICES_PER_HOUR) + (minutes / TIME_SLICE_LENGTH);
        }

        

    }


}
