using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    internal interface ICommandNotify
    {
        void OnCommandExecuted(FTPReply reply);
    }
}
