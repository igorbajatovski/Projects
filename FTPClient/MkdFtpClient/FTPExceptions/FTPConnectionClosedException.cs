using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPConnectionClosedException : FTPException
    {
        public FTPConnectionClosedException() : base() { }
        public FTPConnectionClosedException(string message) : base(message) { }
        public FTPConnectionClosedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
