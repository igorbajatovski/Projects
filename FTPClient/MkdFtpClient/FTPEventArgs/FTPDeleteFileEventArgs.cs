using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPDeleteFileEventArgs : FTPEventArgs
    {
        private readonly long deletedFiles = 0;

        public long DeletedFiles
        {
            get { return deletedFiles; }
        }

        private readonly long totalFilesToDelete = 0;

        public long TotalFilesToDelete
        {
            get { return totalFilesToDelete; }
        }

        private readonly FTPFile deletedFile = null;

        public FTPFile DeletedFile
        {
            get { return deletedFile; }
        }

        private readonly FTPFile fileBeeingDeleted = null;

        public FTPFile FileBeeingDeleted
        {
            get { return fileBeeingDeleted; }
        } 


        private bool cancelDelete = false;

        public bool CancelDelete
        {
            get { return cancelDelete; }
            set { cancelDelete = value; }
        }

        public FTPDeleteFileEventArgs(long deletedFiles, long totalFilesToDelete, FTPFile deletedFile, FTPFile fileBeeingDeleted)
        {
            this.deletedFiles = deletedFiles;
            this.totalFilesToDelete = totalFilesToDelete;
            this.deletedFile = deletedFile;
            this.fileBeeingDeleted = fileBeeingDeleted;
        }
    }
}
