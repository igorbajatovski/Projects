using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPDeleteEventArgs : FTPEventArgs
    {
        private readonly FTPFile file = null;

        public FTPFile File
        {
            get { return file; }
        }

        public FTPDeleteEventArgs(FTPFile file)
        {
            this.file = file;
        }

    }
}
