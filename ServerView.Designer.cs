namespace PamDesktop
{
    partial class ServerView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnAccountSettings = new System.Windows.Forms.Button();
            this.btnManageServers = new System.Windows.Forms.Button();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.btnManagePasswords = new System.Windows.Forms.Button();
            this.lstServerList = new System.Windows.Forms.ListBox();
            this.lstAccountsList = new System.Windows.Forms.ListBox();
            this.btnViewPassword = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbAutomationList = new System.Windows.Forms.ComboBox();
            this.btnRunAutomation = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnViewLogs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("OCR A Std", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Privalaged Access Management";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(12, 27);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(92, 13);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome [NAME]";
            this.lblWelcome.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 627);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Need help? Please contact your system administrator";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(79, 295);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(107, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Start Connection";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnAccountSettings
            // 
            this.btnAccountSettings.Enabled = false;
            this.btnAccountSettings.Location = new System.Drawing.Point(15, 43);
            this.btnAccountSettings.Name = "btnAccountSettings";
            this.btnAccountSettings.Size = new System.Drawing.Size(106, 23);
            this.btnAccountSettings.TabIndex = 4;
            this.btnAccountSettings.Text = "Account Settings";
            this.btnAccountSettings.UseVisualStyleBackColor = true;
            // 
            // btnManageServers
            // 
            this.btnManageServers.Enabled = false;
            this.btnManageServers.Location = new System.Drawing.Point(169, 563);
            this.btnManageServers.Name = "btnManageServers";
            this.btnManageServers.Size = new System.Drawing.Size(130, 23);
            this.btnManageServers.TabIndex = 5;
            this.btnManageServers.Text = "Manage Servers ";
            this.btnManageServers.UseVisualStyleBackColor = true;
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Enabled = false;
            this.btnManageUsers.Location = new System.Drawing.Point(14, 534);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(130, 23);
            this.btnManageUsers.TabIndex = 6;
            this.btnManageUsers.Text = "Manage Users";
            this.btnManageUsers.UseVisualStyleBackColor = true;
            // 
            // btnManagePasswords
            // 
            this.btnManagePasswords.Enabled = false;
            this.btnManagePasswords.Location = new System.Drawing.Point(14, 563);
            this.btnManagePasswords.Name = "btnManagePasswords";
            this.btnManagePasswords.Size = new System.Drawing.Size(130, 23);
            this.btnManagePasswords.TabIndex = 7;
            this.btnManagePasswords.Text = "Manage Passwords";
            this.btnManagePasswords.UseVisualStyleBackColor = true;
            // 
            // lstServerList
            // 
            this.lstServerList.FormattingEnabled = true;
            this.lstServerList.Location = new System.Drawing.Point(15, 83);
            this.lstServerList.Name = "lstServerList";
            this.lstServerList.Size = new System.Drawing.Size(284, 160);
            this.lstServerList.TabIndex = 8;
            this.lstServerList.SelectedIndexChanged += new System.EventHandler(this.lstServerList_SelectedIndexChanged);
            // 
            // lstAccountsList
            // 
            this.lstAccountsList.FormattingEnabled = true;
            this.lstAccountsList.Location = new System.Drawing.Point(15, 338);
            this.lstAccountsList.Name = "lstAccountsList";
            this.lstAccountsList.Size = new System.Drawing.Size(284, 160);
            this.lstAccountsList.TabIndex = 9;
            // 
            // btnViewPassword
            // 
            this.btnViewPassword.Location = new System.Drawing.Point(192, 504);
            this.btnViewPassword.Name = "btnViewPassword";
            this.btnViewPassword.Size = new System.Drawing.Size(107, 23);
            this.btnViewPassword.TabIndex = 10;
            this.btnViewPassword.Text = "View Password";
            this.btnViewPassword.UseVisualStyleBackColor = true;
            this.btnViewPassword.Click += new System.EventHandler(this.btnViewPassword_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "View Passwords";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Server List";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Automation (Optional)";
            // 
            // cmbAutomationList
            // 
            this.cmbAutomationList.FormattingEnabled = true;
            this.cmbAutomationList.Location = new System.Drawing.Point(15, 268);
            this.cmbAutomationList.Name = "cmbAutomationList";
            this.cmbAutomationList.Size = new System.Drawing.Size(284, 21);
            this.cmbAutomationList.TabIndex = 14;
            // 
            // btnRunAutomation
            // 
            this.btnRunAutomation.Location = new System.Drawing.Point(192, 295);
            this.btnRunAutomation.Name = "btnRunAutomation";
            this.btnRunAutomation.Size = new System.Drawing.Size(107, 23);
            this.btnRunAutomation.TabIndex = 15;
            this.btnRunAutomation.Text = "Run Automation";
            this.btnRunAutomation.UseVisualStyleBackColor = true;
            this.btnRunAutomation.Click += new System.EventHandler(this.btnRunAutomation_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(14, 601);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(286, 23);
            this.btnLogOut.TabIndex = 16;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnViewLogs
            // 
            this.btnViewLogs.Enabled = false;
            this.btnViewLogs.Location = new System.Drawing.Point(170, 534);
            this.btnViewLogs.Name = "btnViewLogs";
            this.btnViewLogs.Size = new System.Drawing.Size(130, 23);
            this.btnViewLogs.TabIndex = 17;
            this.btnViewLogs.Text = "View Logs";
            this.btnViewLogs.UseVisualStyleBackColor = true;
            // 
            // ServerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 649);
            this.Controls.Add(this.btnViewLogs);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnRunAutomation);
            this.Controls.Add(this.cmbAutomationList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnViewPassword);
            this.Controls.Add(this.lstAccountsList);
            this.Controls.Add(this.lstServerList);
            this.Controls.Add(this.btnManagePasswords);
            this.Controls.Add(this.btnManageUsers);
            this.Controls.Add(this.btnManageServers);
            this.Controls.Add(this.btnAccountSettings);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.label1);
            this.Name = "ServerView";
            this.Text = "PAM - Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnAccountSettings;
        private System.Windows.Forms.Button btnManageServers;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Button btnManagePasswords;
        private System.Windows.Forms.ListBox lstServerList;
        private System.Windows.Forms.ListBox lstAccountsList;
        private System.Windows.Forms.Button btnViewPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbAutomationList;
        private System.Windows.Forms.Button btnRunAutomation;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnViewLogs;
    }
}

