using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PamDesktop
{
    public partial class EditOrAddUser : Form
    {
        ProgramInfo information;
        UserGeneral current;

        public EditOrAddUser(ProgramInfo info, UserGeneral sentUser)
        {
            InitializeComponent();
            information = info;
            current = sentUser;
        }

        public EditOrAddUser(ProgramInfo info)
        {
            InitializeComponent();
            information = info;
            current = null;
        }

        private void EditOrAddUser_Load(object sender, EventArgs e)
        {
            //Load all Access Levels
            List<AccessType> accessLevelList = new List<AccessType>();
            accessLevelList.Add(new AccessType { Id = 1, Name = "Root" });
            accessLevelList.Add(new AccessType { Id = 2, Name = "Admin" });
            accessLevelList.Add(new AccessType { Id = 3, Name = "High" });
            accessLevelList.Add(new AccessType { Id = 4, Name = "Medium" });
            accessLevelList.Add(new AccessType { Id = 5, Name = "Low" });
            accessLevelList.Add(new AccessType { Id = 6, Name = "Script Only High" });
            accessLevelList.Add(new AccessType { Id = 7, Name = "Script Only Medium" });
            accessLevelList.Add(new AccessType { Id = 8, Name = "Script Only Low" });

            //Load all departments
            List<AccessType> deparmentList = new List<AccessType>();
            deparmentList.Add(new AccessType { Id = 1, Name = "Management" });
            deparmentList.Add(new AccessType { Id = 2, Name = "Admin" });
            deparmentList.Add(new AccessType { Id = 3, Name = "IT" });
            deparmentList.Add(new AccessType { Id = 4, Name = "Marketing" });
            deparmentList.Add(new AccessType { Id = 5, Name = "Help Desk" });

            cmbAccessLevel.DataSource = deparmentList;
            cmbAccessLevel.DisplayMember = "Name";
            cmbAccessLevel.ValueMember = "Id";
            cmbAccessLevel.Refresh();

            cmbDepartments.DataSource = accessLevelList;
            cmbDepartments.DisplayMember = "Name";
            cmbDepartments.ValueMember = "Id";
            cmbDepartments.Refresh();

            // Load items from given user
            if (current != null)
            {
                // Exisiting user edit ... Set up the form!
                btnSave.Text = "Update";
                btnPassword.Visible = true;

                txtUserId.Text = current.UserId.ToString();
                txtFirstName.Text = current.FirstName;
                txtSurname.Text = current.Surname;
                txtJobTitle.Text = current.JobTitle;
                cmbAccessLevel.SelectedIndex = current.PermissionLevelId - 1;
                cmbDepartments.SelectedIndex = current.DepartmentId - 1;
                txtUsername.Text = current.Username;
                txtUsername.Enabled = false;
                txtNotes.Text = current.Note;
            }
            else
            {
                // New user! set up the form
                btnSave.Text = "Save";
                txtPassword.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    // Add new user
                    UserRemoveOrEdit newUser = new UserRemoveOrEdit();
                    newUser.UserId = -1;
                    newUser.SessionKey = information.Token;
                    newUser.PermissionLevelId = cmbAccessLevel.SelectedIndex + 1;
                    newUser.FirstName = txtFirstName.Text;
                    newUser.Surname = txtSurname.Text;
                    newUser.JobTitle = txtJobTitle.Text;
                    newUser.DepartmentId = cmbDepartments.SelectedIndex + 1;
                    newUser.Username = txtUsername.Text;

                    //SALT AND HASH! // Do this! /// Dont ignore it! //********************************
                    HashAlgorithm algo = new SHA256Managed();
                    var hash = algo.ComputeHash(Encoding.ASCII.GetBytes("quis" + txtPassword.Text + "quam"));
                    string hexHash = "";
                    for (int i = 0; i < hash.Length; i++)
                    {
                        hexHash = hexHash + hash[i].ToString();
                    }
                    newUser.Password = hexHash;

                    newUser.LastLoginDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss.fff");
                    newUser.Note = txtNotes.Text;

                    // Send off to the API
                    var json = JsonConvert.SerializeObject(newUser);
                    json = "=" + json;

                    var path = information.URL + "/api/users";

                    var response = ApiConnector.SendToApi(path, json);

                    if (response.Contains("\"Passed!\""))
                    {
                        MessageBox.Show("User added!");
                        newUser.UserId = Int32.Parse(response.Substring(0, 2));
                    }

                    GetAccessLevel sendlvl = new GetAccessLevel();
                    sendlvl.SessionKey = information.Token;
                    sendlvl.Id = 1;

                    json = JsonConvert.SerializeObject(sendlvl);
                    json = "=" + json;

                    path = "";
                    path = information.URL + "/api/protectedAccount/getAll";

                    response = ApiConnector.SendToApi(path, json);
                    var serverList = JsonConvert.DeserializeObject<List<ServerAccessLevel>>(response);
                    ServerAccessLevel accessToSend = new ServerAccessLevel();

                    // Add the user permissions bassed on access Level Selected
                    if (cmbAccessLevel.SelectedIndex < 4)
                    {
                        // For all servers
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
                                accessToSend.UserId = newUser.UserId;
                                accessToSend.DepartmentId = cmbDepartments.SelectedIndex;
                                accessToSend.ServerId = objec.ServerId;
                                accessToSend.StartTime = null;
                                accessToSend.FinishTime = null;
                                accessToSend.StandardAccountId = access.StandardAccountId;
                                accessToSend.Allowed = true;
                            }

                            json = JsonConvert.SerializeObject(accessToSend);
                            json = "=" + json;
                            path = information.URL + "/api/serverAccessLevel";

                            response = ApiConnector.SendToApi(path, json);
                        }
                    }
                    else if (cmbAccessLevel.SelectedIndex < 5)
                    {
                        // For only linux servers
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
                            if (objec.ServerId != 5  && objec.ServerOsId != 1 && objec.ServerOsId != 2)
                            {
                                //Create the access level
                                accessToSend.UserId = newUser.UserId;
                                accessToSend.DepartmentId = current.DepartmentId;
                                accessToSend.ServerId = objec.ServerId;
                                accessToSend.StartTime = null;
                                accessToSend.FinishTime = null;
                                accessToSend.StandardAccountId = access.StandardAccountId;
                                accessToSend.Allowed = true;

                                json = JsonConvert.SerializeObject(accessToSend);
                                json = "=" + json;
                                path = information.URL + "/api/serverAccessLevel";

                                response = ApiConnector.SendToApi(path, json);
                            }
                        }
                    }
                    else
                    {
                        // Add permissions for scripts only!
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
                            if (objec.ServerId == 5)
                            {
                                //Create the access level
                                accessToSend.UserId = newUser.UserId;
                                accessToSend.DepartmentId = current.DepartmentId;
                                accessToSend.ServerId = objec.ServerId;
                                accessToSend.StartTime = null;
                                accessToSend.FinishTime = null;
                                accessToSend.StandardAccountId = access.StandardAccountId;
                                accessToSend.Allowed = true;

                                json = JsonConvert.SerializeObject(accessToSend);
                                json = "=" + json;
                                path = information.URL + "/api/serverAccessLevel";

                                response = ApiConnector.SendToApi(path, json);
                            }
                        }
                    }
                }
                else
                {
                    // Update User
                    UserRemoveOrEdit newUser = new UserRemoveOrEdit();
                    newUser.UserId = Int32.Parse(txtUserId.Text);
                    newUser.SessionKey = information.Token;
                    newUser.PermissionLevelId = cmbAccessLevel.SelectedIndex + 1;
                    newUser.FirstName = txtFirstName.Text;
                    newUser.Surname = txtSurname.Text;
                    newUser.JobTitle = txtJobTitle.Text;
                    newUser.DepartmentId = cmbDepartments.SelectedIndex + 1;
                    newUser.Password = current.Password;
                    newUser.Username = current.Username;
                    newUser.LastLoginDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss.fff");
                    newUser.Note = txtNotes.Text;

                    // Send off to the API
                    var json = JsonConvert.SerializeObject(newUser);
                    json = "=" + json;

                    var path = information.URL + "/api/users";

                    var response = ApiConnector.SendToApi(path, json);

                    if (response == "\"Passed!\"")
                    {
                        MessageBox.Show("User Updated!");
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditDepartments_Click(object sender, EventArgs e)
        {
            // this will be enabled later.
        }
    }
}
