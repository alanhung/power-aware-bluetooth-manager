using System.Drawing;
using System.Windows.Forms;
using PowerAwareBluetooth.Common;
using PowerAwareBluetooth.Model;
using PowerAwareBluetooth.Properties;

namespace PowerAwareBluetooth.View
{
    public partial class UserRulesForm : Form
    {
        public UserRulesForm()
        {
            InitializeComponent();

            InitializeColumns();
        }

        internal RuleList BindedRuleList
        {
            get
            {
                return m_RulesListGrid.DataSource as RuleList;
            }
        
            set
            {
                value.ParentControl = this;
                m_RulesListGrid.DataSource = value;
                if (value.Count > 0)
                {
                    m_RulesListGrid.Select(0);
                }
            }
        }


        private void InitializeColumns()
        {
            // add the icon column

            DataGridTableStyle dataGridTableStyle = m_RulesListGrid.TableStyles["RuleList"];

            DataGridIconColumn dataGridIconColumn = new DataGridIconColumn();
            dataGridIconColumn.ColumnIcon = Resources.success;
            dataGridIconColumn.MappingName = "Enabled";
            dataGridIconColumn.HeaderText = "Enabled";

            dataGridTableStyle.GridColumnStyles.Add(dataGridIconColumn);

            Size gridSize = m_RulesListGrid.Size;
            int totalWidth = gridSize.Width;
            const int enabledColumnWidth = 50;

            m_RulesListGrid.TableStyles["RuleList"].GridColumnStyles["Enabled"].Width = enabledColumnWidth;
            m_RulesListGrid.TableStyles["RuleList"].GridColumnStyles["Name"].Width = totalWidth - enabledColumnWidth;
        }

        private void removeRuleButton_Click(object sender, System.EventArgs e)
        {
            if (BindedRuleList != null)
            {
                int selectedRow = m_RulesListGrid.CurrentRowIndex;
                if (selectedRow >= 0 && selectedRow < BindedRuleList.Count)
                {
                    BindedRuleList.RemoveAt(selectedRow);
                }
            }
        }

        private void m_RulesListGrid_CurrentCellChanged(object sender, System.EventArgs e)
        {
            m_RulesListGrid.Select(m_RulesListGrid.CurrentCell.RowNumber);
                 
        }

        private void addNewRuleButton_Click(object sender, System.EventArgs e)
        {
            AddRuleForm addRuleForm = new AddRuleForm();
            if (addRuleForm.ShowDialog() == DialogResult.OK)
            {
                BindedRuleList.Add(addRuleForm.RuleObject);
            }
        }

        private void editRuleButton_Click(object sender, System.EventArgs e)
        {
            int selectedRow = m_RulesListGrid.CurrentRowIndex;
            if (selectedRow >= 0 && selectedRow < BindedRuleList.Count)
            {
                Rule selectedRule = BindedRuleList[selectedRow];
                AddRuleForm addRuleForm = new AddRuleForm(selectedRule);
                if (addRuleForm.ShowDialog() == DialogResult.OK)
                {
                    BindedRuleList[selectedRow] = addRuleForm.RuleObject;
                }
            }
        }

    }
}