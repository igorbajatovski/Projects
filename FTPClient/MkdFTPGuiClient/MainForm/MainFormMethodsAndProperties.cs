using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MkdFtpClient;

namespace MkdFTPGuiClient
{
    public partial class MainForm : Form
    {
        private FTPFile leftCurrentDirectory = FTPFile.ROOT;
        private FTPFile rightCurrentDirectory = FTPFile.ROOT;

        private FTPFile LeftCurrentDirectory
        {
            set
            {
                lock (this.leftCurrentDirectory)
                    this.leftCurrentDirectory = value;
            }

            get
            {
                lock (this.leftCurrentDirectory)
                    return this.leftCurrentDirectory;
            }
        }

        private FTPFile RightCurrentDirectory
        {
            set
            {
                lock (this.rightCurrentDirectory)
                    this.rightCurrentDirectory = value;
            }

            get
            {
                lock (this.rightCurrentDirectory)
                    return this.rightCurrentDirectory;
            }
        }

    }
}
