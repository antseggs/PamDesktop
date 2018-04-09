using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PamDesktop
{
    class ApiConnector
    {
        //This class will be used to contain the code for API connections and submissions of data to the database VIA the API
        public static string SendToApi(string path, string initalObject)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(path);
                httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(initalObject);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return result;
                }
            }
            catch (Exception ex)
            {
                initalObject = "Fail";
                return initalObject;
            }
        }

    }
}
