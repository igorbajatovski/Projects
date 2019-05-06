using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPCommandException :FTPException
    {
        public FTPCommandException() : base() { }
        public FTPCommandException(string message) : base(message) { }
        public FTPCommandException(string message, Exception innerException) : base(message, innerException) { }
    }
}
