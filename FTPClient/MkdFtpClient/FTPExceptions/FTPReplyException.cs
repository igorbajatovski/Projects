using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPReplyException : FTPException
    {
        public FTPReplyException() : base() { }
        public FTPReplyException(string message) : base(message) { }
        public FTPReplyException(string message, Exception innerException) : base(message, innerException) { }
    }
}
