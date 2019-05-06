using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPReplyMessageException : FTPException
    {
        public FTPReplyMessageException() : base() { }
        public FTPReplyMessageException(string message) : base(message) { }
        public FTPReplyMessageException(string message, Exception innerException) : base(message, innerException) { }
    }
}
