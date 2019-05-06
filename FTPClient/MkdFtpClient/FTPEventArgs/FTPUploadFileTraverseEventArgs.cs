using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MkdFtpClient
{
    public class FTPUploadFileTraverseEventArgs : FTPEventArgs
    {
        private bool cancelUpload = false;

        /// <summary>
        /// Gets or sets whether the upload
        /// should be stoped or not.
        /// </summary>
        public bool CancelUpload
        {
            get { return cancelUpload; }
            set { this.cancelUpload = value; }
        }

        private readonly FileSystemInfo file = null;
        
        /// <summary>
        /// The uper most file that is being traversed.
        /// </summary>
        public FileSystemInfo File
        {
            get { return file; }
        }

        public FTPUploadFileTraverseEventArgs(FileSystemInfo file)
        {
            this.file = file;
        }
    }
}
