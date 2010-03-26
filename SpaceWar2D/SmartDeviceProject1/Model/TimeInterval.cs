using System;

namespace PowerAwareBluetooth.Model
{
    public class TimeInterval
    {
        public const int MIN_HOUR = 0;
        public const int MAX_HOUR = 23;
        public const int MIN_MINUTES = 0;
        public const int MAX_MINUTES = 59;

//        private const int UNDEFINED = -1;

        private int m_StartHour;
        private int m_StartMinutes;
        private int m_EndHour;
        private int m_EndMinutes;

        public TimeInterval(int startHour, int startMinutes, int endHour, int endMinutes)
        {
            if (!IsLegalHour(startHour) ||
                !IsLegalHour(endHour) ||
                !IsLegalMinutes(startMinutes) ||
                !IsLegalMinutes(endMinutes) ||
                IsStartBeforeEnd(startHour, startMinutes, endHour, endMinutes))
            {
                throw new ArgumentException("Bad time interval arguments");
            }

            m_StartHour = startHour;
            m_StartMinutes = startMinutes;
            m_EndHour = endHour;
            m_EndMinutes = endMinutes;
        }

        public int StartMinutes
        {
            get { return m_StartMinutes; }
            set { m_StartMinutes = value; }
        }

        public int StartHour
        {
            get { return m_StartHour; }
            set { m_StartHour = value; }
        }

        public int EndMinutes
        {
            get { return m_EndMinutes; }
            set { m_EndMinutes = value; }
        }

        public int EndHour
        {
            get { return m_EndHour; }
            set { m_EndHour = value; }
        }

        public static bool IsStartBeforeEnd(int startHour, int startMinutes, int endHour, int endMinutes)
        {
            return (startHour > endHour ||
                    (startHour == endHour && startMinutes > endMinutes));
        }

        public static bool IsLegalHour(int hour)
        {
            return IsInRange(hour, MIN_HOUR, MAX_HOUR);
        }

        public static bool IsLegalMinutes(int minutes)
        {
            return IsInRange(minutes, MIN_MINUTES, MAX_MINUTES);
        }

        private static bool IsInRange(int value, int min, int max)
        {
            return (value >= min && value <= max);
        }
    }
}
