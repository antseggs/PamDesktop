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
    public partial class ServerView : Form
    {
        ProgramInfo information;
        List<Server> servers = new List<Server>();
        List<StandardAccount> passwords = new List<StandardAccount>();
        List<Automation> currentAutomation = new List<Automation>();
        List<ServerAccessLevel> serverList = new List<ServerAccessLevel>();

        public ServerView(ProgramInfo info)
        {
            InitializeComponent();
            information = info;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = " Welcome back " + information.Name;

            // Load in all server Access levels for user
            GetAccessLevel current = new GetAccessLevel();
            current.SessionKey = information.Token;
            current.Id = information.UserId;

            string json = "";
            json = JsonConvert.SerializeObject(current);
            json = "=" + json;

            string path = "";
            path = information.URL + "/api/protectedAccount/getAll";

            string response = ApiConnector.SendToApi(path, json);
            serverList = JsonConvert.DeserializeObject<List<ServerAccessLevel>>(response);

            // Load in all appropriate server details
            foreach (ServerAccessLevel access in serverList)
            {
                // Call API for server info
                GetAccessLevel currServer = new GetAccessLevel();
                currServer.SessionKey = information.Token;
                currServer.Id = access.ServerId;

                json = JsonConvert.SerializeObject(currServer);
                json = "=" + json;
                path = information.URL + "/api/servers/get";

                // Add to server list
                response = ApiConnector.SendToApi(path, json);
                var objec = JsonConvert.DeserializeObject<Server>(response);
                if (objec.ServerId != 5)
                {
                    servers.Add(objec);
                }
                else
                {
                    current.Id = access.StandardAccountId;
                    json = JsonConvert.SerializeObject(current);
                    json = "=" + json;
                    path = information.URL + "/api/standardAccount/get";

                    response = ApiConnector.SendToApi(path, json);
                    var pass = JsonConvert.DeserializeObject<StandardAccount>(response);

                    passwords.Add(pass);
                }
                
            }
            // Add to the UI list
            lstServerList.DataSource = servers;
            lstServerList.DisplayMember = "ServerName";
            lstServerList.ValueMember = "ServerId";

            lstAccountsList.DataSource = passwords;
            lstAccountsList.DisplayMember = "AccountName";
            lstAccountsList.ValueMember = "StandardAccountId";

            // Load in all services details
            getAutomation(servers[0].ServerOsId);
            cmbAutomationList.DataSource = currentAutomation;
            cmbAutomationList.DisplayMember = "ScriptName";
            cmbAutomationList.ValueMember = "AutomationScriptId";
        }

        private void getAutomation(int? serverOsId)
        {
            GetAccessLevel current = new GetAccessLevel();
            current.SessionKey = information.Token;
            current.Id = serverOsId;

            string json = "";
            json = JsonConvert.SerializeObject(current);
            json = "=" + json;

            string path = "";
            path = information.URL + "/api/automation/getAll";

            string response = ApiConnector.SendToApi(path, json);
            currentAutomation = JsonConvert.DeserializeObject<List<Automation>>(response);
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

        private void lstServerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Server ser = servers[lstServerList.SelectedIndex];
                getAutomation(ser.ServerOsId);
                // Doesnt work....cmbAutomationList.Refresh();
                cmbAutomationList.DataSource = null;
                cmbAutomationList.DataSource = currentAutomation;
                cmbAutomationList.DisplayMember = "ScriptName";
                cmbAutomationList.ValueMember = "AutomationScriptId";
            }
            catch (Exception)
            {

            }
           
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnViewPassword_Click(object sender, EventArgs e)
        {
            var selectedAccount = passwords[lstServerList.SelectedIndex];
            PasswordView passwordView = new PasswordView(selectedAccount,false);
            passwordView.ShowDialog();
        }

        private void btnRunAutomation_Click(object sender, EventArgs e)
        {
            try
            {
                GetAccessLevel current = new GetAccessLevel();
                current.SessionKey = information.Token;
                current.Id = servers[lstServerList.SelectedIndex].ServerOsId;

                string json = "";
                json = JsonConvert.SerializeObject(current);
                json = "=" + json;

                string path = "";
                path = information.URL + "/api/protectedAccount/get";

                string response = ApiConnector.SendToApi(path, json);
                ProtectedAccount acc = JsonConvert.DeserializeObject<ProtectedAccount>(response);

                SshClient currentSession = new SshClient(servers[lstServerList.SelectedIndex].ServerIp, 22, acc.Username, acc.Password);
                currentSession.Connect();

                // get the automation script!
                currentSession.RunCommand(currentAutomation[cmbAutomationList.SelectedIndex].ScriptText);

                // close session 
                currentSession.Disconnect();

                // show success message box!
                MessageBox.Show("Successfully Completed Automation!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occorred Running this automation for more info: " + ex);
            }
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //Decide if the server is SSH or VNC
            if (servers[lstServerList.SelectedIndex].ServerOsId == 3 || servers[lstServerList.SelectedIndex].ServerOsId == 4 || servers[lstServerList.SelectedIndex].ServerOsId == 5 || servers[lstServerList.SelectedIndex].ServerOsId == 6)
            {
                try
                {
                    // Start SSH session
                    GetAccessLevel current = new GetAccessLevel();
                    current.SessionKey = information.Token;
                    current.Id = servers[lstServerList.SelectedIndex].ServerOsId;

                    string json = "";
                    json = JsonConvert.SerializeObject(current);
                    json = "=" + json;

                    string path = "";
                    path = information.URL + "/api/protectedAccount/get";

                    string response = ApiConnector.SendToApi(path, json);
                    ProtectedAccount acc = JsonConvert.DeserializeObject<ProtectedAccount>(response);

                    SshSessionDetails details = new SshSessionDetails
                    {
                        ServerIp = servers[lstServerList.SelectedIndex].ServerIp,
                        Port = 22,
                        Username = acc.Username,
                        Password = acc.Password
                    };

                    SshConnectionForm sshCon = new SshConnectionForm(details, information);
                    sshCon.ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error connecting to server. Check the server is on.");
                }
            }else
            {
                // Start VNC session

            }

            
        }
    }
}
