namespace PamDesktop
{
    partial class EditOrAddUser
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
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.cmbAccessLevel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDepartments = new System.Windows.Forms.ComboBox();
            this.btnEditDepartments = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID";
            // 
            // txtUserId
            // 
            this.txtUserId.Enabled = false;
            this.txtUserId.Location = new System.Drawing.Point(89, 9);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(45, 20);
            this.txtUserId.TabIndex = 1;
            this.txtUserId.Text = "NEW";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(89, 35);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(161, 20);
            this.txtFirstName.TabIndex = 2;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(89, 61);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(161, 20);
            this.txtSurname.TabIndex = 3;
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.Location = new System.Drawing.Point(89, 87);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Size = new System.Drawing.Size(161, 20);
            this.txtJobTitle.TabIndex = 4;
            // 
            // cmbAccessLevel
            // 
            this.cmbAccessLevel.FormattingEnabled = true;
            this.cmbAccessLevel.Location = new System.Drawing.Point(89, 113);
            this.cmbAccessLevel.Name = "cmbAccessLevel";
            this.cmbAccessLevel.Size = new System.Drawing.Size(161, 21);
            this.cmbAccessLevel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "First Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Surname";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Job Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Access Level";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Department";
            // 
            // cmbDepartments
            // 
            this.cmbDepartments.FormattingEnabled = true;
            this.cmbDepartments.Location = new System.Drawing.Point(89, 140);
            this.cmbDepartments.Name = "cmbDepartments";
            this.cmbDepartments.Size = new System.Drawing.Size(161, 21);
            this.cmbDepartments.TabIndex = 11;
            // 
            // btnEditDepartments
            // 
            this.btnEditDepartments.Enabled = false;
            this.btnEditDepartments.Location = new System.Drawing.Point(89, 167);
            this.btnEditDepartments.Name = "btnEditDepartments";
            this.btnEditDepartments.Size = new System.Drawing.Size(161, 23);
            this.btnEditDepartments.TabIndex = 12;
            this.btnEditDepartments.Text = "Edit Departments";
            this.btnEditDepartments.UseVisualStyleBackColor = true;
            this.btnEditDepartments.Click += new System.EventHandler(this.btnEditDepartments_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Username";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 252);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Notes";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(89, 196);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(161, 20);
            this.txtUsername.TabIndex = 16;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(89, 249);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(161, 66);
            this.txtNotes.TabIndex = 19;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(15, 321);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(175, 321);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Change";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(89, 223);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(161, 20);
            this.txtPassword.TabIndex = 17;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Visible = false;
            // 
            // btnPassword
            // 
            this.btnPassword.Location = new System.Drawing.Point(89, 221);
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.Size = new System.Drawing.Size(161, 23);
            this.btnPassword.TabIndex = 22;
            this.btnPassword.Text = "Reset Password";
            this.btnPassword.UseVisualStyleBackColor = true;
            this.btnPassword.Visible = false;
            // 
            // EditOrAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 354);
            this.Controls.Add(this.btnPassword);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnEditDepartments);
            this.Controls.Add(this.cmbDepartments);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbAccessLevel);
            this.Controls.Add(this.txtJobTitle);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.label1);
            this.Name = "EditOrAddUser";
            this.Text = "EditOrAddUser";
            this.Load += new System.EventHandler(this.EditOrAddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtJobTitle;
        private System.Windows.Forms.ComboBox cmbAccessLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDepartments;
        private System.Windows.Forms.Button btnEditDepartments;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnPassword;
    }
}