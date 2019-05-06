using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPDownloadEventArgs : FTPEventArgs
    {
        private readonly FTPFile file = null;

        public FTPFile File
        {
            get { return file; }
        }

        public FTPDownloadEventArgs(FTPFile file)
        {
            this.file = file;
        }
    }
}
