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
        private bool[] m_SelectedDays = new bool[Constants.DAYS_IN_WEEK];

        private SelectedDays m_SelectedDaysEnum;

        public WeekDays(SelectedDays selectedDays)
        {
            SelectedDaysEnum = selectedDays;
            int[] indices = null;
            switch (selectedDays)
            {
                case SelectedDays.Everyday:
                    indices = new int[] {0, 1, 2, 3, 4, 5, 6};
                    break;
                case SelectedDays.Workdays:
                    indices = new int[] {0, 1, 2, 3, 4};
                    break;
                case SelectedDays.Weekend:
                    indices = new int[] {5, 6};
                    break;
                case SelectedDays.Custom:
                    // non selected
                    break;
            }
            if (indices != null)
            {
                for(int i = 0; i < indices.Length; ++i)
                {
                    m_SelectedDays[indices[i]] = true;
                }

            }
           
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
