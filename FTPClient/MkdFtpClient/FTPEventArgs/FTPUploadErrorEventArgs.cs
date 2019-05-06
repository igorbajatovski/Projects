using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MkdFtpClient
{
    public class FTPUploadErrorEventArgs : FTPEventArgs
    {
        private readonly FileSystemInfo file = null;

        /// <summary>
        /// The file being downloaded.
        /// </summary>
        public FileSystemInfo File
        {
            get { return file; }
        }

        private readonly Exception error = null;

        /// <summary>
        /// The error that occured during the download.
        /// </summary>
        public Exception Error
        {
            get { return error; }
        }

        public FTPUploadErrorEventArgs(FileSystemInfo file, Exception error)
        {
            this.file = file;
            this.error = error;
        }
    }
}
