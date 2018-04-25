using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Video.FFMPEG;
using MSTSCLib;
using Newtonsoft.Json;
using Renci.SshNet;

namespace PamDesktop
{
    public partial class VncWindow : Form
    {
        SshSessionDetails details = new SshSessionDetails();
        DesktopLog current = new DesktopLog();
        ProgramInfo information;
        Timer timer1 = new Timer();
        VideoFileWriter vf;
        String timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");

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

                // Start the recording
                timer1.Interval = 20;
                timer1.Tick += Timer1_Tick;
                vf = new VideoFileWriter();
                vf.Open(Path.GetTempPath() + timeStamp + ".avi", Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, 25, VideoCodec.MPEG4, 1000000);
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server!", "Error in connecting. Please check server is switched on and has a network connection!");
                this.Close();
            }
            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                var bp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                var gr = Graphics.FromImage(bp);
                gr.CopyFromScreen(0, 0, 0, 0, bp.Size);
                vf.WriteVideoFrame(bp);
            }
            catch (Exception ex)
            {
                // catch exceptions
            }
           
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdp.Connected.ToString() == "1")
                {
                    rdp.Disconnect();
                    timer1.Stop();
                    vf.Close();
                    // Move recording to blob storage
                    var location = new System.IO.DirectoryInfo(Path.GetTempPath() + timeStamp + ".avi");
                    FileInfo f = new FileInfo(location.ToString());
                    string uploadfile = f.FullName;
                    var client = new SftpClient("92.233.50.207", 22, "root", "toor");
                    client.Connect();
                        client.ChangeDirectory("/Recordings");
                        var fileStream = new FileStream(uploadfile, FileMode.Open);
                        client.BufferSize = 4 * 1024;
                        client.UploadFile(fileStream, f.Name, null);
                    client.Disconnect();
                    client.Dispose();

                    //using (var scp = new ScpClient("92.233.50.207", "root", "toor"))
                    //{
                    //    scp.Connect();
                    //    var location = new System.IO.DirectoryInfo(Path.GetTempPath() + timeStamp + ".avi");
                    //    scp.Upload(location, "/recordings " + timeStamp + ".avi");
                    //}

                    //ScpClient currentScp = new ScpClient("92.233.50.207", "administrator", "test");
                    //currentScp.Connect();
                    //var location = new System.IO.DirectoryInfo(Path.GetTempPath() + timeStamp + ".avi");
                    //currentScp.Upload(location, "/recordings " + timeStamp + ".avi");
                    //currentScp.Disconnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Disconnecting", "Error disconnecting from the seesion. Please try again!");
                this.Close();
            }
            // Ship recording

            // Ship the Log!
            current.SessionKey = information.Token;
            current.UserId = information.UserId;
            current.LogContentLocation = timeStamp + ".avi";
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
