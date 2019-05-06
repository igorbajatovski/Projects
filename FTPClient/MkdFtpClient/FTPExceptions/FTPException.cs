using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPException : Exception
    {
        public FTPException() : base() { }
        public FTPException(string message) : base(message) { }
        public FTPException(string message, Exception innerException) : base(message, innerException) { }
    }
}
