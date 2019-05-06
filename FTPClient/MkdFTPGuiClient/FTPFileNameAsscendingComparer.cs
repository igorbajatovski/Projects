using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MkdFtpClient;

namespace MkdFTPGuiClient
{
    internal class FTPFileNameAsscendingComparer : IComparer<FTPFile>, IAsscending
    {
        int IComparer<FTPFile>.Compare(FTPFile x, FTPFile y)
        {
            return x.Name.CompareTo(y.Name);
        }
    };
}
