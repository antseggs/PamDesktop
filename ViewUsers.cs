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
    public partial class ViewUsers : Form
    {
        ProgramInfo information;
        List<UserGeneral> userList = new List<UserGeneral>();

        public ViewUsers(ProgramInfo info)
        {
            InitializeComponent();
            information = info;
        }

        private void ViewUsers_Load(object sender, EventArgs e)
        {
            try
            {
                // Load users to a list. 
                GetAccessLevel current = new GetAccessLevel();
                current.SessionKey = information.Token;
                current.Id = information.UserId;

                string json = "";
                json = JsonConvert.SerializeObject(current);
                json = "=" + json;

                string path = "";
                path = information.URL + "/api/users/getAll";

                string response = ApiConnector.SendToApi(path, json);
                userList = JsonConvert.DeserializeObject<List<UserGeneral>>(response);

                // Add these items to the GUI list
                lstUsers.DataSource = userList;
                lstUsers.DisplayMember = "Username";
                lstUsers.ValueMember = "UserId";
            }
            catch (Exception ex)
            {

            }   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UserGeneral current = userList[lstUsers.SelectedIndex];
            EditOrAddUser form = new EditOrAddUser(information, current);
            form.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Find selected User
            UserRemoveOrEdit current = new UserRemoveOrEdit();
            current.SessionKey = information.Token;
            current.UserId = userList[lstUsers.SelectedIndex].UserId;
            current.PermissionLevelId = userList[lstUsers.SelectedIndex].PermissionLevelId;
            current.FirstName = userList[lstUsers.SelectedIndex].FirstName;
            current.Surname = userList[lstUsers.SelectedIndex].Surname;
            current.JobTitle = userList[lstUsers.SelectedIndex].JobTitle;
            current.DepartmentId = userList[lstUsers.SelectedIndex].DepartmentId;
            current.Username = userList[lstUsers.SelectedIndex].Username;
            current.Password = userList[lstUsers.SelectedIndex].Password;
            current.LastLoginDate = userList[lstUsers.SelectedIndex].LastLoginDate;
            current.Note = userList[lstUsers.SelectedIndex].Note;

            if(current.UserId != information.UserId)
            {
                string json = "";
                json = JsonConvert.SerializeObject(current);
                json = "=" + json;

                string path = "";
                path = information.URL + "/api/users/delete";

                string response = ApiConnector.SendToApi(path, json);
                if (response == "\"Pass!\"")
                {
                    MessageBox.Show("User successfully removed from system!");
                    // Clean up list box.
                    lstUsers.DataSource = null;
                    lstUsers.DataSource = userList;
                    lstUsers.DisplayMember = "Username";
                    lstUsers.ValueMember = "UserId";
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            EditOrAddUser form = new EditOrAddUser(information);
            form.Show();
        }
    }
}
