using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPListException : FTPException
    {
        public FTPListException() : base() { }
        public FTPListException(string message) : base(message) { }
        public FTPListException(string message, Exception innerException) : base(message, innerException) { }
    }
}
