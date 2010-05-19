namespace PowerAwareBluetooth.View
{
    partial class CustomDaysForm
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
            System.Windows.Forms.Button okButton;
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.m_Sunday = new System.Windows.Forms.CheckBox();
            this.m_Monday = new System.Windows.Forms.CheckBox();
            this.m_Tuesday = new System.Windows.Forms.CheckBox();
            this.m_Wednesday = new System.Windows.Forms.CheckBox();
            this.m_Thursday = new System.Windows.Forms.CheckBox();
            this.m_Friday = new System.Windows.Forms.CheckBox();
            this.m_Saturday = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            okButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            okButton.Location = new System.Drawing.Point(151, 227);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(72, 26);
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // m_Sunday
            // 
            this.m_Sunday.Location = new System.Drawing.Point(16, 35);
            this.m_Sunday.Name = "m_Sunday";
            this.m_Sunday.Size = new System.Drawing.Size(100, 20);
            this.m_Sunday.TabIndex = 0;
            this.m_Sunday.Text = "Sunday";
            // 
            // m_Monday
            // 
            this.m_Monday.Location = new System.Drawing.Point(16, 61);
            this.m_Monday.Name = "m_Monday";
            this.m_Monday.Size = new System.Drawing.Size(100, 20);
            this.m_Monday.TabIndex = 1;
            this.m_Monday.Text = "Monday";
            // 
            // m_Tuesday
            // 
            this.m_Tuesday.Location = new System.Drawing.Point(16, 87);
            this.m_Tuesday.Name = "m_Tuesday";
            this.m_Tuesday.Size = new System.Drawing.Size(100, 20);
            this.m_Tuesday.TabIndex = 2;
            this.m_Tuesday.Text = "Tuesday";
            // 
            // m_Wednesday
            // 
            this.m_Wednesday.Location = new System.Drawing.Point(16, 113);
            this.m_Wednesday.Name = "m_Wednesday";
            this.m_Wednesday.Size = new System.Drawing.Size(100, 20);
            this.m_Wednesday.TabIndex = 3;
            this.m_Wednesday.Text = "Wednesday";
            // 
            // m_Thursday
            // 
            this.m_Thursday.Location = new System.Drawing.Point(16, 139);
            this.m_Thursday.Name = "m_Thursday";
            this.m_Thursday.Size = new System.Drawing.Size(100, 20);
            this.m_Thursday.TabIndex = 4;
            this.m_Thursday.Text = "Thursday";
            // 
            // m_Friday
            // 
            this.m_Friday.Location = new System.Drawing.Point(16, 165);
            this.m_Friday.Name = "m_Friday";
            this.m_Friday.Size = new System.Drawing.Size(100, 20);
            this.m_Friday.TabIndex = 5;
            this.m_Friday.Text = "Friday";
            // 
            // m_Saturday
            // 
            this.m_Saturday.Location = new System.Drawing.Point(16, 191);
            this.m_Saturday.Name = "m_Saturday";
            this.m_Saturday.Size = new System.Drawing.Size(100, 20);
            this.m_Saturday.TabIndex = 6;
            this.m_Saturday.Text = "Saturday";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_Saturday);
            this.panel1.Controls.Add(this.m_Friday);
            this.panel1.Controls.Add(this.m_Thursday);
            this.panel1.Controls.Add(this.m_Wednesday);
            this.panel1.Controls.Add(this.m_Tuesday);
            this.panel1.Controls.Add(this.m_Monday);
            this.panel1.Controls.Add(this.m_Sunday);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 218);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 23);
            this.label1.Text = "Select Days";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CustomDaysForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(okButton);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "CustomDaysForm";
            this.Text = "Custom days";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox m_Sunday;
        private System.Windows.Forms.CheckBox m_Monday;
        private System.Windows.Forms.CheckBox m_Tuesday;
        private System.Windows.Forms.CheckBox m_Wednesday;
        private System.Windows.Forms.CheckBox m_Thursday;
        private System.Windows.Forms.CheckBox m_Friday;
        private System.Windows.Forms.CheckBox m_Saturday;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;

    }
}