using Newtonsoft.Json;
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
    public partial class ServerManager : Form
    {
        List<Server> servers;
        ProgramInfo information;

        public ServerManager(List<Server> serversLst, ProgramInfo info)
        {
            InitializeComponent();
            servers = serversLst;
            information = info;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Find selected User
            GetAccessLevel current = new GetAccessLevel();
            current.SessionKey = information.Token;
            current.Id = servers[lstServers.SelectedIndex].ServerId;

            if (true)
            {
                string json = "";
                json = JsonConvert.SerializeObject(current);
                json = "=" + json;

                string path = "";
                path = information.URL + "/api/servers/delete";

                string response = ApiConnector.SendToApi(path, json);
                if (response == "\"Pass!\"")
                {
                    MessageBox.Show("User successfully removed from system!");
                    // Clean up list box.
                    lstServers.DataSource = null;
                    lstServers.DataSource = servers;
                    lstServers.DisplayMember = "serverName";
                    lstServers.ValueMember = "serverId";
                }
                else
                {
                    MessageBox.Show("Something went wrong, please try again!");
                }
            }
            else
            {
                MessageBox.Show("You cant delete yourself!");
            }
        }

        private void ServerManager_Load(object sender, EventArgs e)
        {
                // Add these items to the GUI list
                lstServers.DataSource = servers;
                lstServers.DisplayMember = "serverName";
                lstServers.ValueMember = "serverId";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            EditOrAddServer form = new EditOrAddServer(null, information);
            form.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditOrAddServer form = new EditOrAddServer(servers[lstServers.SelectedIndex], information);
            form.Show();
        }
    }
}
