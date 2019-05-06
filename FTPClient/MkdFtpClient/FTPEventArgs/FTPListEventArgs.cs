using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPListEventArgs : FTPEventArgs
    {
        private readonly FTPFile[] files = new FTPFile[0] { };

        public FTPFile[] Files
        {
            get { return files; }
        }

        private readonly FTPFile listDirectory = null;

        public FTPFile ListDirectory
        {
            get { return listDirectory; }
        }

        public FTPListEventArgs(FTPFile[] files, FTPFile listDirectory)
        {
            this.files = files;
            this.listDirectory = listDirectory;
        }
    }
}
