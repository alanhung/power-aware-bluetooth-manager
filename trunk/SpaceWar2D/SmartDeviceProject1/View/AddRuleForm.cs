using System;
using System.Text;
using System.Windows.Forms;
using PowerAwareBluetooth.Model;

namespace PowerAwareBluetooth.View
{
    public partial class AddRuleForm : Form
    {
        private Rule m_RuleObject;
        private WeekDays m_CustomWeekDays;


        public AddRuleForm()
        {
            InitializeComponent();
            m_DaysComboBox.DataSource = WeekDays.GetSelectedDaysList();
        }

        public AddRuleForm(Rule ruleToEdit): this()
        {
            m_NameComboBox.Text = ruleToEdit.Name;
            m_DaysComboBox.SelectedItem = ruleToEdit.ActiveWeekDays.SelectedDaysEnum;
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
                return new WeekDays(selectedDaysEnum);
            }
            else
            {
                return m_DaysComboBox.SelectedItem as WeekDays;
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
                    errorString.AppendLine(GetErrorString(++errorNumber, "No days were selected"));
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
    }
}