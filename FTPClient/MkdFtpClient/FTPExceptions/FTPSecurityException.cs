using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPSecurityException : FTPException
    {
        public FTPSecurityException() : base() { }
        public FTPSecurityException(string message) : base(message) { }
        public FTPSecurityException(string message, Exception innerException) : base(message, innerException) { }
    }
}
