namespace PamDesktop
{
    partial class SshConnectionForm
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
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnFinishSession = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtConsole.ForeColor = System.Drawing.Color.Lime;
            this.txtConsole.Location = new System.Drawing.Point(0, 0);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(800, 409);
            this.txtConsole.TabIndex = 0;
            this.txtConsole.Text = "Starting Connection... \r\nConnection Started!\r\n#\r\n";
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(0, 409);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(728, 20);
            this.txtCommand.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(725, 407);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnFinishSession
            // 
            this.btnFinishSession.Location = new System.Drawing.Point(666, 435);
            this.btnFinishSession.Name = "btnFinishSession";
            this.btnFinishSession.Size = new System.Drawing.Size(134, 23);
            this.btnFinishSession.TabIndex = 3;
            this.btnFinishSession.Text = "Finish Session";
            this.btnFinishSession.UseVisualStyleBackColor = true;
            this.btnFinishSession.Click += new System.EventHandler(this.btnFinishSession_Click);
            // 
            // SshConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 456);
            this.Controls.Add(this.btnFinishSession);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.txtConsole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SshConnectionForm";
            this.Text = "SshConnection";
            this.Load += new System.EventHandler(this.SshConnection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnFinishSession;
    }
}