using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPDeleteFileErrorEventArgs : FTPErrorEventArgs
    {
        private readonly FTPFile file = null;

        public FTPFile File
        {
            get { return file; }
        }

        public FTPDeleteFileErrorEventArgs(FTPFile file)
            : base()
        {
            this.file = file;
        }

        public FTPDeleteFileErrorEventArgs(FTPFile file, FTPException ex)
            : base(ex)
        {
            this.file = file;
        }
    }
}
