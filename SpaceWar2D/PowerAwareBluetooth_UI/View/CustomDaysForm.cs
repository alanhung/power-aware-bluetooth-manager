using System.Windows.Forms;
using PowerAwareBluetooth.Settings;

namespace PowerAwareBluetooth_UI.View
{
    public partial class CustomDaysForm : Form
    {
        private CheckBox[] m_Days;
        private bool[] m_SelectedDays;

        /// <summary>
        /// a dialog for selecting specific days for a specific rule
        /// </summary>
        public CustomDaysForm()
        {
            InitializeComponent();

            m_Days = 
                new[]
                    {
                        m_Sunday,
                        m_Monday,
                        m_Tuesday,
                        m_Wednesday,
                        m_Thursday,
                        m_Friday,
                        m_Saturday
                    };

        }

        /// <summary>
        /// gets the days that the user selected for the rule
        /// </summary>
        public bool[] SelectedDays
        {
            get
            {
                return m_SelectedDays;
            }
            set
            {
                if (value != null)
                {
                    for (int i = 0; i < Constants.DAYS_IN_WEEK; ++i)
                    {
                        m_Days[i].Checked = value[i];
                    }
                }
                m_SelectedDays = value;
            }
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            bool[] selectedDaysBoolArray = new bool[Constants.DAYS_IN_WEEK];
            for (int i = 0; i < Constants.DAYS_IN_WEEK; ++i)
            {
                selectedDaysBoolArray[i] = m_Days[i].Checked;
            }
            m_SelectedDays = selectedDaysBoolArray;
      
        }
    }
}