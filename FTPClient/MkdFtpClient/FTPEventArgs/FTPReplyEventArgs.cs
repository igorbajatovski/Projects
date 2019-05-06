using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPReplyEventArgs : FTPEventArgs
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

        private readonly FTPException error = null;

        public FTPException Error
        {
            get { return error; }
        }

        public FTPReplyEventArgs(FTPReply reply, FTPException error)
            :this(reply)
        {
            this.error = error;
        }

        public FTPReplyEventArgs(FTPReply reply)
        {
            if (reply != null)
            {
                this.command = reply.Command;
                this.arguments = reply.Arguments;
                this.reply = reply.Reply;
                this.ftpCode = reply.FtpCode;
            }
        }
    }
}
