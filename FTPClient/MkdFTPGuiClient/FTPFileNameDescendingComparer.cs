using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MkdFtpClient;

namespace MkdFTPGuiClient
{
    internal class FTPFileNameDescendingComparer : IComparer<FTPFile>, IDescending
    {
        int IComparer<FTPFile>.Compare(FTPFile x, FTPFile y)
        {
            int compare = x.Name.CompareTo(y.Name);
            if (compare == -1)
                return 1;
            if (compare == 1)
                return -1;
            return compare;
        }
    }
}
