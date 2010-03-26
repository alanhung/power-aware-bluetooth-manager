namespace PowerAwareBluetooth.View
{
    partial class AddRuleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label mainLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label daysLabel;
            System.Windows.Forms.Button selectDaysButton;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Button okButton;
            System.Windows.Forms.Button resetButton;
            System.Windows.Forms.Button cancelButton;
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.m_NameComboBox = new System.Windows.Forms.ComboBox();
            this.m_DaysComboBox = new System.Windows.Forms.ComboBox();
            this.m_StartRuleTimePicker = new System.Windows.Forms.DateTimePicker();
            this.m_EndRuleTimePicker = new System.Windows.Forms.DateTimePicker();
            this.m_RadioButtonTurnOn = new System.Windows.Forms.RadioButton();
            this.m_RadioButtonTurnOff = new System.Windows.Forms.RadioButton();
            this.m_ActiveCheckBox = new System.Windows.Forms.CheckBox();
            mainLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            daysLabel = new System.Windows.Forms.Label();
            selectDaysButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            okButton = new System.Windows.Forms.Button();
            resetButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainLabel
            // 
            mainLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            mainLabel.Location = new System.Drawing.Point(23, 18);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new System.Drawing.Size(185, 20);
            mainLabel.Text = "Rule Properties";
            mainLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nameLabel
            // 
            nameLabel.Location = new System.Drawing.Point(10, 53);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(58, 22);
            nameLabel.Text = "Name:";
            nameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // daysLabel
            // 
            daysLabel.Location = new System.Drawing.Point(23, 81);
            daysLabel.Name = "daysLabel";
            daysLabel.Size = new System.Drawing.Size(44, 22);
            daysLabel.Text = "Days:";
            daysLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // selectDaysButton
            // 
            selectDaysButton.Location = new System.Drawing.Point(170, 81);
            selectDaysButton.Name = "selectDaysButton";
            selectDaysButton.Size = new System.Drawing.Size(52, 22);
            selectDaysButton.TabIndex = 6;
            selectDaysButton.Text = "custom";
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(10, 109);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(59, 22);
            label1.Text = "Start:";
            label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(10, 137);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(59, 22);
            label2.Text = "End:";
            label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(9, 170);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(59, 22);
            label3.Text = "Turn:";
            label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // okButton
            // 
            okButton.Location = new System.Drawing.Point(170, 222);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(52, 25);
            okButton.TabIndex = 21;
            okButton.Text = "Ok";
            okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // resetButton
            // 
            resetButton.Location = new System.Drawing.Point(54, 222);
            resetButton.Name = "resetButton";
            resetButton.Size = new System.Drawing.Size(52, 25);
            resetButton.TabIndex = 28;
            resetButton.Text = "Reset";
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Location = new System.Drawing.Point(112, 222);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(52, 25);
            cancelButton.TabIndex = 29;
            cancelButton.Text = "Cancel";
            // 
            // m_NameComboBox
            // 
            this.m_NameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_NameComboBox.Location = new System.Drawing.Point(73, 53);
            this.m_NameComboBox.Name = "m_NameComboBox";
            this.m_NameComboBox.Size = new System.Drawing.Size(91, 22);
            this.m_NameComboBox.TabIndex = 2;
            this.m_NameComboBox.Text = "My Rule";
            // 
            // m_DaysComboBox
            // 
            this.m_DaysComboBox.DisplayMember = "0";
            this.m_DaysComboBox.Items.Add("Everyday");
            this.m_DaysComboBox.Items.Add("Workdays");
            this.m_DaysComboBox.Items.Add("Weekend");
            this.m_DaysComboBox.Items.Add("Custom");
            this.m_DaysComboBox.Location = new System.Drawing.Point(73, 81);
            this.m_DaysComboBox.Name = "m_DaysComboBox";
            this.m_DaysComboBox.Size = new System.Drawing.Size(91, 22);
            this.m_DaysComboBox.TabIndex = 7;
            // 
            // m_StartRuleTimePicker
            // 
            this.m_StartRuleTimePicker.CustomFormat = "HH:mm";
            this.m_StartRuleTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_StartRuleTimePicker.Location = new System.Drawing.Point(75, 109);
            this.m_StartRuleTimePicker.Name = "m_StartRuleTimePicker";
            this.m_StartRuleTimePicker.ShowUpDown = true;
            this.m_StartRuleTimePicker.Size = new System.Drawing.Size(90, 22);
            this.m_StartRuleTimePicker.TabIndex = 10;
            // 
            // m_EndRuleTimePicker
            // 
            this.m_EndRuleTimePicker.CustomFormat = "HH:mm";
            this.m_EndRuleTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_EndRuleTimePicker.Location = new System.Drawing.Point(75, 137);
            this.m_EndRuleTimePicker.Name = "m_EndRuleTimePicker";
            this.m_EndRuleTimePicker.ShowUpDown = true;
            this.m_EndRuleTimePicker.Size = new System.Drawing.Size(90, 22);
            this.m_EndRuleTimePicker.TabIndex = 13;
            // 
            // m_RadioButtonTurnOn
            // 
            this.m_RadioButtonTurnOn.Checked = true;
            this.m_RadioButtonTurnOn.Location = new System.Drawing.Point(75, 170);
            this.m_RadioButtonTurnOn.Name = "m_RadioButtonTurnOn";
            this.m_RadioButtonTurnOn.Size = new System.Drawing.Size(40, 20);
            this.m_RadioButtonTurnOn.TabIndex = 18;
            this.m_RadioButtonTurnOn.Text = "On";
            // 
            // m_RadioButtonTurnOff
            // 
            this.m_RadioButtonTurnOff.Location = new System.Drawing.Point(121, 170);
            this.m_RadioButtonTurnOff.Name = "m_RadioButtonTurnOff";
            this.m_RadioButtonTurnOff.Size = new System.Drawing.Size(44, 20);
            this.m_RadioButtonTurnOff.TabIndex = 19;
            this.m_RadioButtonTurnOff.TabStop = false;
            this.m_RadioButtonTurnOff.Text = "Off";
            // 
            // m_ActiveCheckBox
            // 
            this.m_ActiveCheckBox.Checked = true;
            this.m_ActiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_ActiveCheckBox.Location = new System.Drawing.Point(73, 196);
            this.m_ActiveCheckBox.Name = "m_ActiveCheckBox";
            this.m_ActiveCheckBox.Size = new System.Drawing.Size(91, 20);
            this.m_ActiveCheckBox.TabIndex = 20;
            this.m_ActiveCheckBox.Text = "Active";
            // 
            // AddRuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(cancelButton);
            this.Controls.Add(resetButton);
            this.Controls.Add(okButton);
            this.Controls.Add(this.m_ActiveCheckBox);
            this.Controls.Add(this.m_RadioButtonTurnOff);
            this.Controls.Add(this.m_RadioButtonTurnOn);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(this.m_EndRuleTimePicker);
            this.Controls.Add(this.m_StartRuleTimePicker);
            this.Controls.Add(label1);
            this.Controls.Add(this.m_DaysComboBox);
            this.Controls.Add(selectDaysButton);
            this.Controls.Add(daysLabel);
            this.Controls.Add(this.m_NameComboBox);
            this.Controls.Add(nameLabel);
            this.Controls.Add(mainLabel);
            this.Menu = this.mainMenu1;
            this.Name = "AddRuleForm";
            this.Text = "Add new rule";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox m_NameComboBox;
        private System.Windows.Forms.ComboBox m_DaysComboBox;
        private System.Windows.Forms.DateTimePicker m_StartRuleTimePicker;
        private System.Windows.Forms.DateTimePicker m_EndRuleTimePicker;
        private System.Windows.Forms.RadioButton m_RadioButtonTurnOn;
        private System.Windows.Forms.RadioButton m_RadioButtonTurnOff;
        private System.Windows.Forms.CheckBox m_ActiveCheckBox;
    }
}