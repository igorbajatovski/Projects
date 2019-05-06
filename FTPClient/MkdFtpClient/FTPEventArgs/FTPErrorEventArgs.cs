using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPErrorEventArgs : FTPEventArgs
    {
        private readonly FTPException error = null;

        public FTPException Error
        {
            get { return error; }
        }

        protected FTPErrorEventArgs() { }
        
        public FTPErrorEventArgs(FTPException error)
        {
            this.error = error;
        }
    }
}
