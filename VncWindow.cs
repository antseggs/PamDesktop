using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSTSCLib;
using Newtonsoft.Json;

namespace PamDesktop
{
    public partial class VncWindow : Form
    {
        SshSessionDetails details = new SshSessionDetails();
        DesktopLog current = new DesktopLog();
        ProgramInfo information;

        public VncWindow(SshSessionDetails conn, ProgramInfo info)
        {
            InitializeComponent();
            details = conn;
            information = info;
        }

        private void VncWindow_Load(object sender, EventArgs e)
        {
            try
            {
                rdp.Server = details.ServerIp;
                rdp.UserName = details.Username;
                IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
                secured.ClearTextPassword = details.Password;
                rdp.Connect();
            }
            catch (Exception)
            {
                MessageBox.Show("Error connecting to server!", "Error in connecting. Please check server is switched on and has a network connection!");
            }
            
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdp.Connected.ToString() == "1")
                {
                    rdp.Disconnect();
                }
            }
            catch
            {
                MessageBox.Show("Error Disconnecting", "Error disconnecting from the seesion. Please try again!");
            }
            // Ship recording

            // Ship the Log!
            current.SessionKey = information.Token;
            current.UserId = information.UserId;
            current.LogContentLocation = ""; // FILL THIS IN...
            current.PermissionLevelId = 1;
            current.FinishTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            current.UserNote = "";
            current.ProtectedAccountId = 2;

            string json = "";
            json = JsonConvert.SerializeObject(current);
            json = "=" + json;

            string path = "";
            path = information.URL + "/api/desktopLog";

            string response = ApiConnector.SendToApi(path, json);
            this.Close();
        }
    }
}
