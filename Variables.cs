using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slakking
{
    internal class Variables
    {
        internal static string ResponderAgent = "SlackBot";
        internal static string urlWithAccessToken = "SlackWebhookWithAccessToken";
    }

    internal class CommandHolder
    { 
        internal static List<Commands> CommandList { get; set; }
    }

    internal class Commands
    {
        internal string Command1 = "Command1";
        internal string Command2 = "Command2";
        internal string Command3 = "Command3";
        internal string Command4 = "Command4";
    }

    internal class Functions
    {
        internal static List<string> getFiles() 
        {
            List<string> fileList = new List<string>();

            return fileList;
        }

        internal static List<string> getFolders()
        {
            List<string> folderList = new List<string>();

            return folderList;
        }

        internal static string getUuid()
        {
            string uuid = null;

            return uuid;
        }

        internal static string getSysName()
        {
            string systemName = null;

            return systemName;
        }
    }
}
