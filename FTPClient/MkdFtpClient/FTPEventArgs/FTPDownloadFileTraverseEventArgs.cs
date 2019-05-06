using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPDownloadFileTraverseEventArgs : FTPEventArgs
    {
        private bool cancelDownload = false;

        /// <summary>
        /// Gets or sets whether the donwload
        /// should be stoped or not.
        /// </summary>
        public bool CancelDownload
        {
            get { return cancelDownload; }
            set { this.cancelDownload = value; }
        }

        private readonly FTPFile file = null;
        
        /// <summary>
        /// The uper most file that is being traversed.
        /// </summary>
        public FTPFile File
        {
            get { return file; }
        }

        public FTPDownloadFileTraverseEventArgs(FTPFile file)
        {
            this.file = file;
        }
    }
}
