using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MkdFtpClient
{
    public class FTPUploadProgressEventArgs : FTPEventArgs
    {
        private readonly long uploadedBytes = 0;

        public long UploadedBytes
        {
            get { return uploadedBytes; }
        }

        private readonly long totalToUploadedBytes = 0;

        public long TotalToUploadedBytes
        {
            get { return totalToUploadedBytes; }
        }

        private readonly int bytesPerSecond = 0;

        public int BytesPerSecond
        {
            get { return bytesPerSecond; }
        }

        private readonly FileSystemInfo file = null;

        /// <summary>
        /// The current file being downloaded.
        /// </summary>
        public FileSystemInfo File
        {
            get { return file; }
        }

        private bool cancelUpload = false;

        /// <summary>
        /// Gets or sets whether the donwload
        /// should be stoped or not.
        /// </summary>
        public bool CancelUpload
        {
            get { return cancelUpload; }
            set { cancelUpload = value; }
        }

        public FTPUploadProgressEventArgs(FileSystemInfo file, long downloadedBytes, long totalToUploadedBytes, int bytesPerSecond)
        {
            this.file = file;
            this.uploadedBytes = downloadedBytes;
            this.totalToUploadedBytes = totalToUploadedBytes;
            this.bytesPerSecond = bytesPerSecond;
        }
    }
}
