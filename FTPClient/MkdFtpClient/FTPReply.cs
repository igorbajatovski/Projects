using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{   
    public class FTPReply
    {
        private readonly string command = string.Empty;

        public string Command
        {
            get { return command; }
        }

        private readonly string[] arguments = new string[0];

        public string[] Arguments
        {
            get { return arguments; }
        }

        private readonly string reply = string.Empty;

        public string Reply
        {
            get { return reply; }
        }

        private readonly string ftpCode = string.Empty;

        public string FtpCode
        {
            get { return ftpCode; }
        }

        public FTPReply(string reply, string ftpCode)
        {
            this.reply = reply;
            this.ftpCode = ftpCode;
        }

        public FTPReply(string command, string[] arguments, string reply, string ftpCode)
        {
            this.command = command;
            this.arguments = arguments;
            this.reply = reply;
            this.ftpCode = ftpCode;
        }
    }
}
