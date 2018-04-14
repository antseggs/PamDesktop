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
        public string Name { get; set; }
        public int UserId { get; set; }
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

    public class GetAccessLevel : LoggedInType
    {
        public int? Id { get; set; }
    }

    public class ServerAccessLevel
    {
        public int? ServerAccessId { get; set; }
        public int? UserId { get; set; }
        public int? DepartmentId { get; set; }
        public int? ServerId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public int? StandardAccountId { get; set; }
        public bool? Allowed { get; set; }
    }

    public class Server
    {
        public int ServerId { get; set; }
        public int ServerOsId { get; set; }
        public string ServerName { get; set; }
        public string ServerDescription { get; set; }
        public string ServerIp { get; set; }
        public string Fqdn { get; set; }
        public string ServerNote { get; set; }
        public bool IpStatic { get; set; }
    }

    public class StandardAccount
    {
        public int StandardAccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? AccountGroupId { get; set; }
        public string Note { get; set; }
    }

    public class Automation
    {
        public string ScriptName { get; set; }
        public int? ServerOsId { get; set; }
        public string ScriptText { get; set; }
        public int? ServerAccessLevelId { get; set; }
        public DateTime LastUpdate { get; set; }
        public int AutomationScriptId { get; set; }
    }

    public class ProtectedAccount
    {
        public int ProtectedAccountId { get; set; }
        public string AccountName { get; set; }
        public int ServerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AccountGroupId { get; set; }
        public string Note { get; set; }
    }

    public class SshSessionDetails
    {
        public string ServerIp { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class SshLog : LoggedInType
    {
        public int UserId { get; set; }
        public string LogContent { get; set; }
        public int PermissionLevelId { get; set; }
        public string FinishTime { get; set; }
        public string UserNote { get; set; }
        public int ProtectedAccountId { get; set; }
    }

    public class DesktopLog : LoggedInType
    {
        public int UserId { get; set; }
        public string LogContentLocation { get; set; }
        public int PermissionLevelId { get; set; }
        public string FinishTime { get; set; }
        public string UserNote { get; set; }
        public int ProtectedAccountId { get; set; }
    }
}