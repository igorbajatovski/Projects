using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MkdFtpClient;

namespace MkdFTPGuiClient
{
    class FTPFileSizeDescendingComparer : IComparer<FTPFile>, IDescending
    {   
        int IComparer<FTPFile>.Compare(FTPFile x, FTPFile y)
        {
            int xSize = 0;
            int.TryParse(x.Size, out xSize);
            int ySize = 0;
            int.TryParse(y.Size, out ySize);
            if (xSize < ySize)
                return 1;
            if (xSize > ySize)
                return -1;
            return 0;
        }
    }
}
