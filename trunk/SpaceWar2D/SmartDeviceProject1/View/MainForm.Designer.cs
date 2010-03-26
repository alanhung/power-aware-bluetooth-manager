namespace PowerAwareBluetooth.View
{
    partial class MainForm
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.m_RulesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_RulesButton
            // 
            this.m_RulesButton.Location = new System.Drawing.Point(63, 50);
            this.m_RulesButton.Name = "m_RulesButton";
            this.m_RulesButton.Size = new System.Drawing.Size(102, 47);
            this.m_RulesButton.TabIndex = 0;
            this.m_RulesButton.Text = "Define Rules";
            this.m_RulesButton.Click += new System.EventHandler(this.m_RulesButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.m_RulesButton);
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.Text = "Bluetooth Power Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_RulesButton;


    }
}