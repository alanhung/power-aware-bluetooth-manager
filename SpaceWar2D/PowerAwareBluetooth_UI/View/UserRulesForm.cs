﻿using System;
using System.Drawing;
using System.Windows.Forms;
using PowerAwareBluetooth.Model;
using PowerAwareBluetooth_UI.Common;

namespace PowerAwareBluetooth.View
{
    public partial class UserRulesForm : Form
    {
        public UserRulesForm()
        {
            InitializeComponent();

            InitializeColumns();

            LoadRuleListFromFile();
        }

        /// <summary>
        /// initialize the binded-rule list from the saved file.
        /// if the file can not be loaded - a new list is created
        /// </summary>
        private void LoadRuleListFromFile()
        {
            RuleList ruleList = Controller.IO.IOManager.Load() as RuleList;
            if (ruleList == null)
            {
                ruleList = new RuleList();
            }
            BindedRuleList = ruleList;
        }

        /// <summary>
        /// gets or sets the list that is bounded to the grid-view
        /// </summary>
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
            dataGridIconColumn.Center = true;
            dataGridIconColumn.ColumnIcon = PowerAwareBluetooth_UI.Properties.Resources.success;
            dataGridIconColumn.MappingName = "Enabled";
            dataGridIconColumn.HeaderText = "Enabled";

            dataGridTableStyle.GridColumnStyles.Add(dataGridIconColumn);

            Size gridSize = m_RulesListGrid.Size;
            int totalWidth = gridSize.Width;
            const int gap = 5;
            const int enabledColumnWidth = 70;
            int nameColumnWidth = totalWidth - enabledColumnWidth - gap;
            m_RulesListGrid.TableStyles["RuleList"].GridColumnStyles["Enabled"].Width = enabledColumnWidth;
            m_RulesListGrid.TableStyles["RuleList"].GridColumnStyles["Name"].Width = nameColumnWidth;
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
            addRuleForm.RulesList = BindedRuleList;
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
                addRuleForm.RulesList = BindedRuleList;
                if (addRuleForm.ShowDialog() == DialogResult.OK)
                {
                    BindedRuleList[selectedRow] = addRuleForm.RuleObject;
                }
            }
        }

        /// <summary>
        /// an handler to handle the closing of the form.
        /// closing the form will result in two actions:
        /// 1) the changes to the list will be saved to the local file
        /// 2) if the bluetooth manager is running then it will be informed
        ///  that changes were made to the file
        /// </summary>
        /// <param name="sender">the sender of the event, this is actually the form itself</param>
        /// <param name="e">the event-arguments</param>
        private void UserRulesForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveListToFile();
            NotifyBluetoothProcess();
        }

        /// <summary>
        /// notifies the blue-tooth process that a new rules list
        /// is ready.
        /// </summary>
        private void NotifyBluetoothProcess()
        {
            WinMessageAdapter.NotifyListChanged(BindedRuleList);
        }

        /// <summary>
        /// saves the list to a local file
        /// </summary>
        private void SaveListToFile()
        {
            RuleList list = BindedRuleList;
            if (list != null)
            {
                Controller.IO.IOManager.Save(list);
            }
        }
    }
}