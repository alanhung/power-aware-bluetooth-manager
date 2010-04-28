using System;
using System.Collections.Generic;
using PowerAwareBluetooth.Settings;

namespace PowerAwareBluetooth.Model
{
    public enum SelectedDays
    {
        Everyday,
        Workdays,
        Weekend,
        Custom
    }

    public class WeekDays
    {
        private static readonly bool[] Everyday_Arr = { true, true, true, true, true, true, true };
        private static readonly bool[] Workdays_Arr = { true, true, true, true, true, false, false };
        private static readonly bool[] Weekend_Arr = { false, false, false, false, false, true, true };


        private bool[] m_SelectedDays = new bool[Constants.DAYS_IN_WEEK];

        private SelectedDays m_SelectedDaysEnum;

        private static bool IsIdentical(bool[] arrCompare, bool[] other)
        {
            if  (arrCompare.Length == other.Length)
            {
                for(int i = 0; i < arrCompare.Length; ++i)
                {
                    if (arrCompare[i] != other[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;

        }

        /// <summary>
        /// tests if the given array is equal to a previously defined array.
        /// for instance if the selected-days array is equal to the boolean array
        /// named <see cref="Everyday_Arr"/> then the method will return SelectedDays.EveryDay
        /// </summary>
        /// <param name="selectedDays">an array to check against the previously defined arrays</param>
        /// <returns>an enum value from SelectedDays if a matching was found otherwise the value
        /// SelectedDays.Custom </returns>
        public static SelectedDays GetSelectedDaysEnumByIndices(bool[] selectedDays)
        {
            if (selectedDays != null && selectedDays.Length == Constants.DAYS_IN_WEEK)
            {
                if (IsIdentical(selectedDays, Everyday_Arr))
                {
                    return SelectedDays.Everyday;
                }
                if (IsIdentical(selectedDays, Workdays_Arr))
                {
                    return SelectedDays.Workdays;
                }
                if (IsIdentical(selectedDays, Weekend_Arr))
                {
                    return SelectedDays.Weekend;
                }
            }
            return SelectedDays.Custom;
        }

        public WeekDays(bool[] selectedDays)
        {
            SelectedDaysEnum = SelectedDays.Custom;
            m_SelectedDays = selectedDays;
        }

        public WeekDays(SelectedDays selectedDays)
        {
            SelectedDaysEnum = selectedDays;
            bool[] array = null;
            switch (selectedDays)
            {
                case SelectedDays.Everyday:
                    array = Everyday_Arr;
                    break;
                case SelectedDays.Workdays:
                    array = Workdays_Arr;
                    break;
                case SelectedDays.Weekend:
                    array = Weekend_Arr;
                    break;
                case SelectedDays.Custom:
                    // non selected
                    break;
            }
            if (array != null)
            {
                for(int i = 0; i < Constants.DAYS_IN_WEEK; ++i)
                {
                    m_SelectedDays[i] = array[i];
                }

            }
           
        }

        public bool[] SelectedDaysArray
        {
            get
            {
                return m_SelectedDays;
            }
        }

        /// <summary>
        /// tests if the given day is selected
        /// </summary>
        /// <param name="dayNumber">a number between 0 (Sunday) to 6 (Saturday)</param>
        /// <returns></returns>
        public bool IsDaySelected(int dayNumber)
        {
            return m_SelectedDays[dayNumber];
        }

        /// <summary>
        /// tests if the given day is selected
        /// </summary>
        /// <param name="dayOfWeek">the day to test</param>
        /// <returns></returns>
        public bool IsDaySelected(DayOfWeek dayOfWeek)
        {
            int day = (int) dayOfWeek;
            return IsDaySelected(day);
        }

        public SelectedDays SelectedDaysEnum
        {
            get { return m_SelectedDaysEnum; }
            set { m_SelectedDaysEnum = value; }
        }

        public static List<SelectedDays> GetSelectedDaysList()
        {
            List<SelectedDays> list = new List<SelectedDays>();
            list.Add(SelectedDays.Everyday);
            list.Add(SelectedDays.Workdays);
            list.Add(SelectedDays.Weekend);
            list.Add(SelectedDays.Custom);

            return list;
        }


    }
}
