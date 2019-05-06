using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPDownloadErrorEventArgs : FTPEventArgs
    {
        private readonly FTPFile file = null;

        /// <summary>
        /// The file being downloaded.
        /// </summary>
        public FTPFile File
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

        public FTPDownloadErrorEventArgs(FTPFile file, Exception error)
        {
            this.file = file;
            this.error = error;
        }
    }
}
