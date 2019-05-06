using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPDownloadProgressEventArgs : FTPEventArgs
    {
        private readonly long downloadedBytes = 0;

        public long DownloadedBytes
        {
            get { return downloadedBytes; }
        }

        private readonly long totalToDownloadBytes = 0;

        public long TotalToDownloadBytes
        {
            get { return totalToDownloadBytes; }
        }

        private readonly int bytesPerSecond = 0;

        public int BytesPerSecond
        {
            get { return bytesPerSecond; }
        } 

        private readonly FTPFile file = null;

        /// <summary>
        /// The current file being downloaded.
        /// </summary>
        public FTPFile File
        {
            get { return file; }
        }

        private bool cancelDownload = false;

        /// <summary>
        /// Gets or sets whether the donwload
        /// should be stoped or not.
        /// </summary>
        public bool CancelDownload
        {
            get { return cancelDownload; }
            set { cancelDownload = value; }
        }

        public FTPDownloadProgressEventArgs(FTPFile file, long downloadedBytes, long totalToDownloadBytes, int bytesPerSecond)
        {
            this.file = file;
            this.downloadedBytes = downloadedBytes;
            this.totalToDownloadBytes = totalToDownloadBytes;
            this.bytesPerSecond = bytesPerSecond;
        }
    }
}
