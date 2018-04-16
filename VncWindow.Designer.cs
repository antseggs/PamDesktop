namespace PamDesktop
{
    partial class VncWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VncWindow));
            this.axMsRdpClient10NotSafeForScripting1 = new AxMSTSCLib.AxMsRdpClient10NotSafeForScripting();
            this.axMsRdpClient10NotSafeForScripting2 = new AxMSTSCLib.AxMsRdpClient10NotSafeForScripting();
            this.rdp = new AxMSTSCLib.AxMsTscAxNotSafeForScripting();
            this.btnQuit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axMsRdpClient10NotSafeForScripting1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMsRdpClient10NotSafeForScripting2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).BeginInit();
            this.SuspendLayout();
            // 
            // axMsRdpClient10NotSafeForScripting1
            // 
            this.axMsRdpClient10NotSafeForScripting1.Enabled = true;
            this.axMsRdpClient10NotSafeForScripting1.Location = new System.Drawing.Point(0, 0);
            this.axMsRdpClient10NotSafeForScripting1.Name = "axMsRdpClient10NotSafeForScripting1";
            this.axMsRdpClient10NotSafeForScripting1.TabIndex = 0;
            // 
            // axMsRdpClient10NotSafeForScripting2
            // 
            this.axMsRdpClient10NotSafeForScripting2.Enabled = true;
            this.axMsRdpClient10NotSafeForScripting2.Location = new System.Drawing.Point(0, 0);
            this.axMsRdpClient10NotSafeForScripting2.Name = "axMsRdpClient10NotSafeForScripting2";
            this.axMsRdpClient10NotSafeForScripting2.TabIndex = 0;
            // 
            // rdp
            // 
            this.rdp.Enabled = true;
            this.rdp.Location = new System.Drawing.Point(-1, -3);
            this.rdp.Name = "rdp";
            this.rdp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("rdp.OcxState")));
            this.rdp.Size = new System.Drawing.Size(1097, 587);
            this.rdp.TabIndex = 0;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(992, 590);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(92, 23);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "End Session";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // VncWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 623);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.rdp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "VncWindow";
            this.Text = "VncWindow";
            this.Load += new System.EventHandler(this.VncWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axMsRdpClient10NotSafeForScripting1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMsRdpClient10NotSafeForScripting2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxMSTSCLib.AxMsRdpClient10NotSafeForScripting axMsRdpClient10NotSafeForScripting1;
        private AxMSTSCLib.AxMsRdpClient10NotSafeForScripting axMsRdpClient10NotSafeForScripting2;
        private AxMSTSCLib.AxMsTscAxNotSafeForScripting rdp;
        private System.Windows.Forms.Button btnQuit;
    }
}