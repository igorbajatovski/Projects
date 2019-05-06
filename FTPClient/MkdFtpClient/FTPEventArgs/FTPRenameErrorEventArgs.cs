using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPRenameErrorEventArgs : FTPErrorEventArgs
    {
        private readonly FTPFile oldFile = null;

        public FTPFile OldFile
        {
            get { return oldFile; }
        }

        private readonly FTPFile newFile = null;

        public FTPFile NewFile
        {
            get { return newFile; }
        }

        public FTPRenameErrorEventArgs(FTPException ex, FTPFile oldFile, FTPFile newFile)
            :base(ex)
        {
            this.oldFile = oldFile;
            this.newFile = newFile;
        }

        public FTPRenameErrorEventArgs(FTPException ex)
            :base(ex) {}
    }
}
