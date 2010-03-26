﻿using System;
using System.Windows.Forms;
using PowerAwareBluetooth.Controller.Manager;

namespace PowerAwareBluetooth.View
{
    public partial class MainForm : Form
    {
        private BluetoothPowerManager m_BluetoothPowerManager;

        public MainForm()
        {
            InitializeComponent();
            InitializeBluetoothPowerManager();
        }

        private void InitializeBluetoothPowerManager()
        {
            m_BluetoothPowerManager = new BluetoothPowerManager();

        }

        private void m_RulesButton_Click(object sender, EventArgs e)
        {
            UserRulesForm userRulesForm = new UserRulesForm();
            userRulesForm.BindedRuleList = m_BluetoothPowerManager.RulesList;

            userRulesForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_RulesButton_Click(sender, e);
        }
    }
}