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
    public partial class EditOrAddServer : Form
    {
        Server current;
        ProgramInfo information;

        public EditOrAddServer(Server server, ProgramInfo info)
        {
            InitializeComponent();
            current = server;
            information = info;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    // Add new
                    ServerShip newServer = new ServerShip();
                    newServer.SessionKey = information.Token;
                    newServer.ServerId = -1;
                    newServer.ServerName = txtName.Text;
                    newServer.ServerOsId = cmbOs.SelectedIndex + 1;
                    newServer.ServerDescription = txtDescription.Text;
                    newServer.ServerIp = txtIp.Text;
                    newServer.IpStatic = chkStatic.Checked;
                    newServer.Fqdn = txtFQDN.Text;
                    newServer.ServerNote = txtNotes.Text;

                    var json = JsonConvert.SerializeObject(newServer);
                    json = "=" + json;

                    var path = information.URL + "/api/servers";

                    var response = ApiConnector.SendToApi(path, json);
                    if (response.Contains("Passed!"))
                    {
                        MessageBox.Show("Server added!");
                        newServer.ServerId = Int32.Parse(response.Substring(1, 2));
                    }
                    // Create permission for this user.
                    ServerAccessLogedIn accessToSend = new ServerAccessLogedIn();
                    accessToSend.SessionKey = information.Token;
                    accessToSend.ServerAccessId = -1;
                    accessToSend.UserId = information.UserId;
                    accessToSend.DepartmentId = 1;
                    accessToSend.ServerId = newServer.ServerId;
                    accessToSend.StartTime = null;
                    accessToSend.FinishTime = null;
                    accessToSend.StandardAccountId = null;
                    accessToSend.Allowed = true;

                    json = JsonConvert.SerializeObject(accessToSend);
                    json = "=" + json;
                    path = information.URL + "/api/serverAccessLevel";

                    response = ApiConnector.SendToApi(path, json);
                }
                else
                {
                    // Update Existing
                    ServerShip newServer = new ServerShip();
                    newServer.SessionKey = information.Token;
                    newServer.ServerId = Int32.Parse(txtId.Text);
                    newServer.ServerName = txtName.Text;
                    newServer.ServerOsId = cmbOs.SelectedIndex + 1;
                    newServer.ServerDescription = txtDescription.Text;
                    newServer.ServerIp = txtIp.Text;
                    newServer.IpStatic = chkStatic.Checked;
                    newServer.Fqdn = txtFQDN.Text;
                    newServer.ServerNote = txtNotes.Text;

                    var json = JsonConvert.SerializeObject(newServer);
                    json = "=" + json;

                    var path = information.URL + "/api/servers";

                    var response = ApiConnector.SendToApi(path, json);
                    if (response.Contains("\"Passed!\""))
                    {
                        MessageBox.Show("Server updated!");
                    }
                }
            }
            catch(Exception ex)
            {
                // Do nothing
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditOrAddServer_Load(object sender, EventArgs e)
        {
            // Load all OS's
            List<AccessType> OsList = new List<AccessType>();
            OsList.Add(new AccessType {Id = 1, Name = "Windows Server 2012" });
            OsList.Add(new AccessType { Id = 2, Name = "Windows Server 2016" });
            OsList.Add(new AccessType { Id = 3, Name = "Mac OS X Server" });
            OsList.Add(new AccessType { Id = 4, Name = "Ubuntu 16.02 LTS" });
            OsList.Add(new AccessType { Id = 5, Name = "Ubuntu 15.02" });
            OsList.Add(new AccessType { Id = 6, Name = "Red Hat" });

            cmbOs.DataSource = OsList;
            cmbOs.DisplayMember = "Name";
            cmbOs.ValueMember = "Id";
            cmbOs.Refresh();

            if (current != null)
            {
                btnSave.Text = "Update";
                txtName.Text = current.ServerName;
                cmbOs.SelectedIndex = current.ServerOsId;
                txtDescription.Text = current.ServerDescription;
                txtIp.Text = current.ServerIp;
                chkStatic.Checked = current.IpStatic;
                txtFQDN.Text = current.Fqdn;
                txtNotes.Text = current.ServerNote;
            }
            else
            {
                // New server..
                btnSave.Text = "Save";
            }
        }
    }
}
