using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class FTPEventArgs : EventArgs 
    {
        public static new FTPEventArgs Empty = new FTPEventArgs();
    }
}
