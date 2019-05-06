using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPRenameEventArgs : FTPEventArgs
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

        public FTPRenameEventArgs(FTPFile oldFile, FTPFile newFile)
        {
            this.oldFile = oldFile;
            this.newFile = newFile;
        }
    }
}
