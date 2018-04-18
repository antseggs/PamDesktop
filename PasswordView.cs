using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PamDesktop
{
    public partial class PasswordView : Form
    {
        public PasswordView(StandardAccount acc, bool enableEdit)
        {
            InitializeComponent();
            // Load account details here
            lblName.Text = acc.AccountName;
            lblAddress.Text = acc.AccountAddress;
            lblUsername.Text = acc.Username;
            lblPassword.Text = acc.Password;
            lblNotes.Text = acc.Note;
            // Enable edit if req
            if (enableEdit)
            {
                btnEdit.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void PasswordView_Load(object sender, EventArgs e)
        {

        }
    }
}
