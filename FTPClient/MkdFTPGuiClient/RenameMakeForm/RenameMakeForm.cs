using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MkdFtpClient;

namespace MkdFTPGuiClient
{
    public partial class RenameMakeForm : Form
    {
        private FTPFile oldFile = null;
        private FTPFile newFile = null;

        public enum MODE { Rename, MakeDir, MakeFile }
        private MODE mode = MODE.Rename;

        public FTPFile File
        {
            get { return newFile; }
        }

        public RenameMakeForm(FTPFile file, MODE mode)
        {
            this.mode = mode;
            InitializeComponent();
            if (this.mode == MODE.Rename)
            {
                this.Text = "Преименувај";
                this.newFileNameTextBox.Text = file.Name;
            }
            else if (this.mode == MODE.MakeDir)
            {
                this.Text = "Креирај фолдер";
            }
            else if (this.mode == MODE.MakeFile)
            {
                this.Text = "Креирај датотека";
            }
            this.oldFile = file;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.newFileNameTextBox.Text = string.Empty;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.mode == MODE.Rename)
            {
                if (!this.newFileNameTextBox.Text.Equals(oldFile.Name))
                    this.newFile = 
                        new FTPFile(this.oldFile.ParentDir.AbsoluthFileName.Clone() + "/" + this.newFileNameTextBox.Text.Clone(), 
                                    this.oldFile.Type);
                return;
            }

            if (this.mode == MODE.MakeDir)
            {
                this.newFile =
                        new FTPFile(this.oldFile.AbsoluthFileName.Clone() + "/" + this.newFileNameTextBox.Text.Clone(), 
                                    FTPFileType.Directory);
                return;
            }

            if (this.mode == MODE.MakeFile)
            {
                this.newFile =
                        new FTPFile(this.oldFile.AbsoluthFileName.Clone() + "/" + this.newFileNameTextBox.Text.Clone(),
                                    FTPFileType.File);
                return;
            }
        }        
    }
}
