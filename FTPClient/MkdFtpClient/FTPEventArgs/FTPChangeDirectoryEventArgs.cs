using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPChangeDirectoryEventArgs : FTPEventArgs
    {
        private readonly FTPFile currentDirectory = null;

        public FTPFile CurrentDirectory
        {
            get { return currentDirectory; }
        }

        public FTPChangeDirectoryEventArgs(FTPFile currentDirectory)
        {
            this.currentDirectory = currentDirectory;
        }
    }
}
