using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
// using this.PamDesktop.ApiConnector;

namespace PamDesktop
{
    public partial class LoginForm : Form
    {
        public ProgramInfo information;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // This on opening should load in the settings from file and add them to the settings page. This will also be passed to each form
            // to keep settings consistant.
            // Json Formatted. (File stored with exe as pam.settings)

            try
            {
                // Load file
                var fileInformation = JsonConvert.DeserializeObject<ProgramInfo>(System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "pam.settings")));
                // Send info to the form.
                information = fileInformation;
                // Load these into the settings box
                txtPort.Text = information.Port.ToString();
                txtServerAddress.Text = information.URL;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Settings File seems to be missing! Please click the settings tab and re-enter! Details: " + ex);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // unused ignore
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Login to the system send the request. Get back token and if successful then load the next form. Else show login invalid.
                Authentication authString = new Authentication();
                authString.Username = txtUsername.Text;
                authString.Password = txtPassword.Text;

                //SALT AND HASH! // Do this! /// Dont ignore it! //********************************
                HashAlgorithm algo = new SHA256Managed();
                Byte[] plainTextWithSalt = new byte[authString.Password.Length + 8];
                

                string json = "";
                json = JsonConvert.SerializeObject(authString);
                json = "=" + json;

                string path = "";
                path = information.URL + "/api/authentication";

                string response = ApiConnector.SendToApi(path, json);
                response = response.Substring(1,response.Length-2);

                if(response == "Fail")
                {
                    throw new AuthenticationException("Incorrect Username or Password");
                }

                //add the responce to the information tile
                LoggedInType token = new LoggedInType();
                token.SessionKey = response;
                information.Token = response;
                // Get self!
                UserGeneral yourself = new UserGeneral();

                path = information.URL + "/api/users/getSelf";
                json = JsonConvert.SerializeObject(token);
                json = "=" + json;

                response = ApiConnector.SendToApi(path, json);
                //response = response.Substring(1, response.Length - 2);
                //response.Replace(@"\", "");

                yourself.Equals(JsonConvert.DeserializeObject<UserGeneral>(response));

                // Open next form and pass information!
                ServerView serverView = new ServerView();
                serverView.ShowDialog();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Catch all exceptions 
                MessageBox.Show("Login error, Please try again! " + ex);
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            // Clear the settings file and enter data back in 
            // Json formatted!
            information.URL = txtServerAddress.Text;
            information.Port = int.Parse(txtPort.Text);

            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "pam.settings"), JsonConvert.SerializeObject(information));
        }
    }
}
