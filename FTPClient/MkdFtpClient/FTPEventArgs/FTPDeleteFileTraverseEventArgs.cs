using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPDeleteFileTraverseEventArgs : FTPEventArgs
    {
        private bool cancelDelete = false;

        public bool CancelDelete
        {
            get { return cancelDelete; }
            set { this.cancelDelete = value; }
        }

        private readonly FTPFile fileBeeingDeleted = null;

        public FTPFile FileBeeingDeleted
        {
            get { return fileBeeingDeleted; }
        } 

        public FTPDeleteFileTraverseEventArgs(FTPFile fileBeeingDeleted) 
        {
            this.fileBeeingDeleted = fileBeeingDeleted;
        }
    }
}
