using Newtonsoft.Json;
using Renci.SshNet;
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
    public partial class SshConnectionForm : Form
    {
        SshSessionDetails details = new SshSessionDetails();
        SshClient currentSession;
        ProgramInfo information;
        SshLog current = new SshLog();

        public SshConnectionForm(SshSessionDetails sessionDetail, ProgramInfo info)
        {
            InitializeComponent();
            // Load in the object passed to the 
            details = sessionDetail;
            information = info;
        }

        private void btnFinishSession_Click(object sender, EventArgs e)
        {

            // Ship Log... 
            current.SessionKey = information.Token;
            current.UserId = information.UserId;
            current.LogContent = txtConsole.Text;
            current.PermissionLevelId = 1;
            current.FinishTime = DateTime.Now.AddHours(12).ToString("yyy-MM-dd HH:mm:ss.fff");
            current.UserNote = "";
            current.ProtectedAccountId = 2;

            string json = "";
            json = JsonConvert.SerializeObject(current);
            json = "=" + json;

            string path = "";
            path = information.URL + "/api/sshLog";

            string response = ApiConnector.SendToApi(path, json);
            // Close session.
            currentSession.Disconnect();
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var result = currentSession.RunCommand(txtCommand.Text);
            txtConsole.AppendText("\r\n" + result.Result.Replace("        ","\r\n") + result.Error);
        }

        private void SshConnection_Load(object sender, EventArgs e)
        {
            try
            {
                // On load start session
                currentSession = new SshClient(details.ServerIp, details.Port, details.Username, details.Password);
                currentSession.Connect();
            }
            catch
            {
                MessageBox.Show("Error in connecting with the server. Ensure the server is turned on!");
            }
        }
    }
}
