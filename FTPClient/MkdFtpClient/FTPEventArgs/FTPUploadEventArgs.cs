using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MkdFtpClient
{
    public class FTPUploadEventArgs : FTPEventArgs
    {
        private readonly FileSystemInfo file = null;

        public FileSystemInfo File
        {
            get { return file; }
        }

        public FTPUploadEventArgs(FileSystemInfo file)
        {
            this.file = file;
        }
    }
}
