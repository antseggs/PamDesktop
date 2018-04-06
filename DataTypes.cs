using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamDesktop
{
    class DataTypes
    {
        // This class will hold the datatypes for the program. 
    }

    public class LoggedInType
    {
        // This class will be inherited by all datatypes (nearly all) that require a log in prior to making the request.
        public string Token { get; set; }
    }

    public class Authentication
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }


}
