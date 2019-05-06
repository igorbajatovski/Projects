using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPChangeDirectoryErrorEventArgs : FTPErrorEventArgs
    {
        private readonly FTPFile dir = null;

        public FTPFile Directory
        {
            get
            {
                return dir;
            }
        }

        public FTPChangeDirectoryErrorEventArgs(FTPException ex)
            : base(ex) {}

        public FTPChangeDirectoryErrorEventArgs(FTPException ex, FTPFile dir)
            :base(ex)
        {
            this.dir = dir;
        }
    }
}
