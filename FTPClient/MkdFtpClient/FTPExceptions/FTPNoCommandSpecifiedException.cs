using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPNoCommandSpecifiedException : FTPException
    {
        public FTPNoCommandSpecifiedException() : base() { }
        public FTPNoCommandSpecifiedException(string message) : base(message) { }
        public FTPNoCommandSpecifiedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
