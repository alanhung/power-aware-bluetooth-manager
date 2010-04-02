using System;
using System.Text;
using System.Windows.Forms;
using PowerAwareBluetooth.Model;

namespace PowerAwareBluetooth.View
{
    public partial class AddRuleForm : Form
    {
        private Rule m_RuleObject;
        //private WeekDays m_CustomWeekDays;
        private bool[] m_WaitingTimePickerValueChange = {false, false};
        private bool[] m_SelectedDayBoolArray;

        public AddRuleForm()
        {
            InitializeComponent();
            m_DaysComboBox.DataSource = WeekDays.GetSelectedDaysList();
            m_StartRuleTimePicker.Value = new DateTime(2015, 1, 1, DateTime.Now.Hour, 0, 0);
            m_EndRuleTimePicker.Value = new DateTime(2015, 1, 1, DateTime.Now.Hour, 0, 0);
            m_WaitingTimePickerValueChange[0] = m_WaitingTimePickerValueChange[1] = true;
            m_SelectedDayBoolArray = new[]
                                         {
                                             true, true, true, true,
                                             true, true, true
                                         };
        }

        public AddRuleForm(Rule ruleToEdit): this()
        {
            m_NameComboBox.Text = ruleToEdit.Name;
            m_DaysComboBox.SelectedItem = ruleToEdit.ActiveWeekDays.SelectedDaysEnum;
            m_SelectedDayBoolArray = ruleToEdit.ActiveWeekDays.SelectedDaysArray;
            m_StartRuleTimePicker.Value = new DateTime(2015, 1, 1, ruleToEdit.TimeInterval.StartHour,
                                                       ruleToEdit.TimeInterval.StartMinutes, 0);

            m_EndRuleTimePicker.Value = new DateTime(2015, 1, 1, ruleToEdit.TimeInterval.EndHour,
                                           ruleToEdit.TimeInterval.EndMinutes, 0);
            m_RadioButtonTurnOn.Checked = ruleToEdit.RuleAction == RuleActionEnum.TurnOn;
            m_ActiveCheckBox.Checked = ruleToEdit.Enabled;
       }

        internal Rule RuleObject
        {
            get
            {
                return m_RuleObject;
            }
        }

        /// <summary>
        /// saves the rule according to the data that was provided by the user
        /// the rule is saved to <see cref="m_RuleObject"/>
        /// </summary>
        private void SaveRuleObject()
        {
            if (!string.IsNullOrEmpty(this.m_NameComboBox.Text))
            {
                int startHour, startMinute, endHour, endMinute;
                GetTime(m_StartRuleTimePicker, out startHour, out startMinute);
                GetTime(m_EndRuleTimePicker, out endHour, out endMinute);
                TimeInterval timeInterval = new TimeInterval(startHour, startMinute, endHour, endMinute);
                RuleActionEnum ruleActionEnum = (m_RadioButtonTurnOn.Checked
                                                     ? RuleActionEnum.TurnOn
                                                     : RuleActionEnum.TurnOff);
                WeekDays weekDays = GetSelectedDays();
//                SelectedDays selectedDays = Enum.Parse(typeof (SelectedDays), m_DaysComboBox.Text, true);
//
//
                m_RuleObject = new Rule(
                    this.m_NameComboBox.Text,
                    timeInterval,
                    ruleActionEnum,
                    weekDays,
                    this.m_ActiveCheckBox.Checked);
            }
        }

        private WeekDays GetSelectedDays()
        {
            Object selectedDays = m_DaysComboBox.SelectedItem;
            if (selectedDays is SelectedDays)
            {
                SelectedDays selectedDaysEnum = (SelectedDays) selectedDays;
                if (selectedDaysEnum == SelectedDays.Custom)
                {
                    return new WeekDays(m_SelectedDayBoolArray);
                }
                return new WeekDays(selectedDaysEnum);
             }
            else
            {
                return null;
            }

        }

        private void GetTime(DateTimePicker dateTimePicker, out int hour, out int minute)
        {
            DateTime dateTime = dateTimePicker.Value;
            hour = dateTime.Hour;
            minute = dateTime.Minute;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (VerifyValues())
            {
                SaveRuleObject();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private string GetErrorString(int number, string error)
        {
            return string.Format("{0}) {1}", number, error);
        }

        /// <summary>
        /// verifies that the user entered correct values for the rule.
        /// a message box will appear with information regarding errors the user
        /// made during the creation of the rule.
        /// </summary>
        /// <returns>true if all the values for the rule are OK, false otherwise</returns>
        private bool VerifyValues()
        {
            StringBuilder errorString = new StringBuilder(256);
            int errorNumber = 0;
            if (string.IsNullOrEmpty(m_NameComboBox.Text))
            {
                errorString.AppendLine(GetErrorString(++errorNumber, "No name was provided"));
            }
            Object selectedDays = m_DaysComboBox.SelectedItem;
            if (selectedDays is SelectedDays)
            {
                SelectedDays selectedDaysEnum = (SelectedDays) selectedDays;
                if (selectedDaysEnum == SelectedDays.Custom)
                {
                    bool error = false;
                    if (m_SelectedDayBoolArray == null)
                    {
                        error = true;
                    }
                    else
                    {
                        bool dayFound = false;
                        foreach (bool dayBoolArray in m_SelectedDayBoolArray)
                        {
                            if (dayBoolArray)
                            {
                                dayFound = true;
                                break;
                            }
                        }
                        error = !dayFound;
                    }
                    if (error)
                    {
                        errorString.AppendLine(GetErrorString(++errorNumber, "No days were selected"));
                    }
                }

            }
            int startHour, startMinute, endHour, endMinute;
            GetTime(m_StartRuleTimePicker, out startHour, out startMinute);
            GetTime(m_EndRuleTimePicker, out endHour, out endMinute);
            if (TimeInterval.IsStartBeforeEnd(startHour, startMinute, endHour, endMinute))
            {
                errorString.AppendLine(GetErrorString(++errorNumber, "the start time is after the end time"));
            }
            if (errorNumber == 0)
            {
                return true;
            }
            else
            {
                string message = "The following error(s) were found:\n" + errorString;
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                return false;
            }

        }

        private void TimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dateTimePicker = sender as DateTimePicker;
            if (dateTimePicker != null)
            {
                int arrValue = (dateTimePicker == m_StartRuleTimePicker ? 0 : 1);
                if (m_WaitingTimePickerValueChange[arrValue])
                {
                    DateTime dateTimePickerValue = dateTimePicker.Value;
                    DateTime newValue;
                    int minuteFirstDigit = dateTimePickerValue.Minute % 10;
                    bool isIncreasingMinValue = (minuteFirstDigit > 0 && minuteFirstDigit < 5); // user clicked on increase
                    newValue = isIncreasingMinValue
                                   ?
                                       GetDateTimeValue(dateTimePickerValue, 10 - minuteFirstDigit)
                                   :
                                       GetDateTimeValue(dateTimePickerValue, -minuteFirstDigit);
                    m_WaitingTimePickerValueChange[arrValue] = false;
                    dateTimePicker.Value = newValue;
                    m_WaitingTimePickerValueChange[arrValue] = true;
                }
            }
        }

        private DateTime GetDateTimeValue(DateTime dateTime, int minutesChange)
        {
            int newMinute;
            int newEnteredValue = dateTime.Minute + minutesChange;
            if (newEnteredValue >= 60)
            {
                newMinute = 0;
            }
            else if (newEnteredValue < 0)
            {
                newMinute = 50;
            }
            else
            {
                newMinute = newEnteredValue;
            }
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                dateTime.Hour, newMinute, dateTime.Second);
        }

        private void selectDaysButton_Click(object sender, EventArgs e)
        {
            CustomDaysForm customDaysForm = new CustomDaysForm();
            if (m_SelectedDayBoolArray != null)
            {
                customDaysForm.SelectedDays = m_SelectedDayBoolArray;
            }
            if (customDaysForm.ShowDialog() == DialogResult.OK)
            {
                m_SelectedDayBoolArray = customDaysForm.SelectedDays;
                m_DaysComboBox.SelectedItem = WeekDays.GetSelectedDaysEnumByIndices(m_SelectedDayBoolArray);
            }
        }

    }
}