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

    public class ProgramInfo
    {
        public string Token { get; set; }
        public string URL { get; set; }
        public int Port { get; set; }
    }

    public class LoggedInType
    {
        // This class will be inherited by all datatypes (nearly all) that require a log in prior to making the request.
        public string SessionKey { get; set; }
    }

    public class Authentication
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserGeneral
    {
        public int UserId { get; set; }
        public int PermissionLevelId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string JobTitle { get; set; }
        public int DepartmentId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string Note { get; set; }
    }

    public class UserReturn : LoggedInType
    {
        //Used to add the token
    }
}