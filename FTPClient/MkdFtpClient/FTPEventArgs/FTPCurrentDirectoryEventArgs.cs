using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPCurrentDirectoryEventArgs : FTPEventArgs
    {
        private readonly FTPFile currentDirectory = null;

        public FTPFile CurrentDirectory
        {
            get { return currentDirectory; }
        }

        public FTPCurrentDirectoryEventArgs(FTPFile currentDirectory)
        {
            this.currentDirectory = currentDirectory;
        }
    }
}
