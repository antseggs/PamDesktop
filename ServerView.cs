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
    public partial class ServerView : Form
    {
        ProgramInfo information;

        public ServerView(ProgramInfo info)
        {
            InitializeComponent();
            information = info;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = " Welcome back " + information.Name;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Mistakenly made - ignore
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //Mistakenly made - ignore
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            //Mistakenly made - ignore
        }
    }
}
