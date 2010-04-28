namespace PowerAwareBluetooth.View
{
    partial class UserRulesForm
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
            System.Windows.Forms.Label rulesListLabel;
            System.Windows.Forms.PictureBox addNewRuleButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserRulesForm));
            System.Windows.Forms.PictureBox removeRuleButton;
            System.Windows.Forms.PictureBox editRuleButton;
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.m_RulesListGrid = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            rulesListLabel = new System.Windows.Forms.Label();
            addNewRuleButton = new System.Windows.Forms.PictureBox();
            removeRuleButton = new System.Windows.Forms.PictureBox();
            editRuleButton = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // rulesListLabel
            // 
            rulesListLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            rulesListLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            rulesListLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rulesListLabel.Location = new System.Drawing.Point(16, 14);
            rulesListLabel.Name = "rulesListLabel";
            rulesListLabel.Size = new System.Drawing.Size(205, 25);
            rulesListLabel.Text = "Rules List";
            rulesListLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // addNewRuleButton
            // 
            addNewRuleButton.Image = ((System.Drawing.Image)(resources.GetObject("addNewRuleButton.Image")));
            addNewRuleButton.Location = new System.Drawing.Point(159, 201);
            addNewRuleButton.Name = "addNewRuleButton";
            addNewRuleButton.Size = new System.Drawing.Size(48, 47);
            addNewRuleButton.Click += new System.EventHandler(this.addNewRuleButton_Click);
            // 
            // removeRuleButton
            // 
            removeRuleButton.Image = ((System.Drawing.Image)(resources.GetObject("removeRuleButton.Image")));
            removeRuleButton.Location = new System.Drawing.Point(95, 201);
            removeRuleButton.Name = "removeRuleButton";
            removeRuleButton.Size = new System.Drawing.Size(48, 47);
            removeRuleButton.Click += new System.EventHandler(this.removeRuleButton_Click);
            // 
            // editRuleButton
            // 
            editRuleButton.Image = ((System.Drawing.Image)(resources.GetObject("editRuleButton.Image")));
            editRuleButton.Location = new System.Drawing.Point(32, 201);
            editRuleButton.Name = "editRuleButton";
            editRuleButton.Size = new System.Drawing.Size(48, 47);
            editRuleButton.Click += new System.EventHandler(this.editRuleButton_Click);
            // 
            // m_RulesListGrid
            // 
            this.m_RulesListGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_RulesListGrid.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.m_RulesListGrid.Location = new System.Drawing.Point(16, 52);
            this.m_RulesListGrid.Name = "m_RulesListGrid";
            this.m_RulesListGrid.PreferredRowHeight = 18;
            this.m_RulesListGrid.RowHeadersVisible = false;
            this.m_RulesListGrid.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.m_RulesListGrid.Size = new System.Drawing.Size(205, 117);
            this.m_RulesListGrid.TabIndex = 0;
            this.m_RulesListGrid.TableStyles.Add(this.dataGridTableStyle1);
            this.m_RulesListGrid.CurrentCellChanged += new System.EventHandler(this.m_RulesListGrid_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.MappingName = "RuleList";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Name";
            this.dataGridTextBoxColumn1.MappingName = "Name";
            // 
            // UserRulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(editRuleButton);
            this.Controls.Add(removeRuleButton);
            this.Controls.Add(addNewRuleButton);
            this.Controls.Add(rulesListLabel);
            this.Controls.Add(this.m_RulesListGrid);
            this.Menu = this.mainMenu1;
            this.Name = "UserRulesForm";
            this.Text = "User Rules";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid m_RulesListGrid;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
    }
}