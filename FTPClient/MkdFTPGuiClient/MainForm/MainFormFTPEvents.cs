using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MkdFtpClient;
using System.Threading;
using System.Drawing;
using System.Net;

namespace MkdFTPGuiClient
{
    public partial class MainForm : Form
    {
        void ftp_UploadEnded(object sender, FTPUploadEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            if (ftp.Name == "LeftServer")
            {
                UpdateDownloadUploadedActionsInfo(leftActionsInfo, e, DownloadUploadState.Ended);
                ftp.ListDirectory(FTPFile.CURRENT_DIR);
            }
            if (ftp.Name == "RightServer")
            {
                UpdateDownloadUploadedActionsInfo(rightActionsInfo, e, DownloadUploadState.Ended);
                ftp.ListDirectory(FTPFile.CURRENT_DIR);
            }
        }

        void ftp_UploadError(object sender, FTPUploadErrorEventArgs e)
        {
            if (e.Error != null)
            {
                FTPClient ftp = (FTPClient)sender;
                string serverName = ftp.Name;
                if (serverName == "LeftServer")
                    OutputText(leftOutputTextBox, e.Error.Message + "\r\n");
                if (serverName == "RightServer")
                    OutputText(rightOutputTextBox, e.Error.Message + "\r\n");
            }
        }

        void ftp_UploadProgress(object sender, FTPUploadProgressEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            if (ftp.Name == "LeftServer")
                UpdateDownloadUploadedActionsInfo(leftActionsInfo, e, DownloadUploadState.Progress);
            if (ftp.Name == "RightServer")
                UpdateDownloadUploadedActionsInfo(rightActionsInfo, e, DownloadUploadState.Progress);
        }

        void ftp_UploadFileTraverse(object sender, FTPUploadFileTraverseEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            if (ftp.Name == "LeftServer")
                UpdateDownloadUploadedActionsInfo(leftActionsInfo, e, DownloadUploadState.FileTraverse);
            if (ftp.Name == "RightServer")
                UpdateDownloadUploadedActionsInfo(rightActionsInfo, e, DownloadUploadState.FileTraverse);
        }

        void ftp_UploadStarted(object sender, FTPUploadEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            if (ftp.Name == "LeftServer")
                UpdateDownloadUploadedActionsInfo(leftActionsInfo, e, DownloadUploadState.Started);
            if (ftp.Name == "RightServer")
                UpdateDownloadUploadedActionsInfo(rightActionsInfo, e, DownloadUploadState.Started);
        }


        void ftp_DownloadError(object sender, FTPDownloadErrorEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            string serverName = ftp.Name;
            if (serverName == "LeftServer")
                OutputText(leftOutputTextBox, e.Error.Message + "\r\n");
            if (serverName == "RightServer")
                OutputText(rightOutputTextBox, e.Error.Message + "\r\n");
        }

        void ftp_DownloadEnded(object sender, FTPDownloadEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            if (ftp.Name == "LeftServer")
                UpdateDownloadUploadedActionsInfo(leftActionsInfo, e, DownloadUploadState.Ended);
            if (ftp.Name == "RightServer")
                UpdateDownloadUploadedActionsInfo(rightActionsInfo, e, DownloadUploadState.Ended);
        }

        void ftp_DownloadFileTraverse(object sender, FTPDownloadFileTraverseEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            if (ftp.Name == "LeftServer")
                UpdateDownloadUploadedActionsInfo(leftActionsInfo, e, DownloadUploadState.FileTraverse);
            if (ftp.Name == "RightServer")
                UpdateDownloadUploadedActionsInfo(rightActionsInfo, e, DownloadUploadState.FileTraverse);
        }

        void ftp_DownloadProgress(object sender, FTPDownloadProgressEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            if (ftp.Name == "LeftServer")
                UpdateDownloadUploadedActionsInfo(leftActionsInfo, e, DownloadUploadState.Progress);
            if (ftp.Name == "RightServer")
                UpdateDownloadUploadedActionsInfo(rightActionsInfo, e, DownloadUploadState.Progress);
        }

        void ftp_DownloadStarted(object sender, FTPDownloadEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            if (ftp.Name == "LeftServer")
                UpdateDownloadUploadedActionsInfo(leftActionsInfo, e, DownloadUploadState.Started);
            if (ftp.Name == "RightServer")
                UpdateDownloadUploadedActionsInfo(rightActionsInfo, e, DownloadUploadState.Started);
        }

        void ftp_DeleteFileFailed(object sender, FTPDeleteFileErrorEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            string serverName = ftp.Name;
            if (serverName == "LeftServer")
                OutputText(leftOutputTextBox, e.Error.Message);
            if (serverName == "RightServer")
                OutputText(rightOutputTextBox, e.Error.Message);
        }

        void ftp_DeleteFileSuccesseded(object sender, FTPDeleteFileEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            if (ftp.Name == "LeftServer")
                UpdateDeleteActionsInfo(leftActionsInfo, e, DeleteState.FileDeleted);

            if (ftp.Name == "RightServer")
                UpdateDeleteActionsInfo(rightActionsInfo, e, DeleteState.FileDeleted);
        }

        void ftp_DeleteFileTraverse(object sender, FTPDeleteFileTraverseEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            if (ftp.Name == "LeftServer")
                UpdateDeleteActionsInfo(leftActionsInfo, e, DeleteState.FileTraverse);

            if (ftp.Name == "RightServer")
                UpdateDeleteActionsInfo(rightActionsInfo, e, DeleteState.FileTraverse);
        }

        void ftp_DeleteEnded(object sender, FTPDeleteEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            if (ftp.Name == "LeftServer")
            {
                UpdateDeleteActionsInfo(leftActionsInfo, e, DeleteState.Ended);
                ftp.ListDirectory(FTPFile.CURRENT_DIR);
            }

            if (ftp.Name == "RightServer")
            {
                UpdateDeleteActionsInfo(rightActionsInfo, e, DeleteState.Ended);
                ftp.ListDirectory(FTPFile.CURRENT_DIR);
            }
        }

        void ftp_DeleteStarted(object sender, FTPDeleteEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            if (ftp.Name == "LeftServer")
                UpdateDeleteActionsInfo(leftActionsInfo, e, DeleteState.Started);

            if (ftp.Name == "RightServer")
                UpdateDeleteActionsInfo(rightActionsInfo, e, DeleteState.Started);
        }

        void ftp_MakeDirectoryFailed(object sender, FTPErrorEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            string serverName = ftp.Name;
            if (serverName == "LeftServer")
                OutputText(leftOutputTextBox, e.Error.Message + "\r\n");
            if (serverName == "RightServer")
                OutputText(rightOutputTextBox, e.Error.Message + "\r\n");
        }

        void ftp_MakeDirectorySuccesseded(object sender, FTPEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            FTPFile currDir = ftp.GetCurrentDirectory();
            if (currDir != null)
                ftp.ListDirectory(currDir);
        }

        void ftp_MakeFileFailed(object sender, FTPErrorEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            string serverName = ftp.Name;
            if (serverName == "LeftServer")
                OutputText(leftOutputTextBox, e.Error.Message + "\r\n");
            if (serverName == "RightServer")
                OutputText(rightOutputTextBox, e.Error.Message + "\r\n");
        }

        void ftp_MakeFileSuccesseded(object sender, FTPEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            FTPFile currDir = ftp.GetCurrentDirectory();
            if (currDir != null)
                ftp.ListDirectory(currDir);
        }

        void ftp_RenameFailed(object sender, FTPRenameErrorEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            string serverName = ftp.Name;
            if (serverName == "LeftServer")
                OutputText(leftOutputTextBox, e.Error.Message + "\r\n");
            if (serverName == "RightServer")
                OutputText(rightOutputTextBox, e.Error.Message + "\r\n");
        }

        void ftp_RenameSuccesseded(object sender, FTPRenameEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            FTPFile currDir = ftp.GetCurrentDirectory();
            if (currDir != null)
                ftp.ListDirectory(currDir);
        }

        void ftp_ChangeDirectoryFailed(object sender, FTPChangeDirectoryErrorEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            string serverName = ftp.Name;
            if (serverName == "LeftServer")
                OutputText(leftOutputTextBox, e.Error.Message + "\r\n");
            if (serverName == "RightServer")
                OutputText(rightOutputTextBox, e.Error.Message + "\r\n");

            if (e.Error is FTPConnectionClosedException)
            {
                if (serverName == "LeftServer")
                {   
                    ftp.LoginSuccsseded -= this.leftLoginSuccsseded;
                    ftp.Connect(new IPEndPoint(IPAddress.Parse(leftHostTextBox.Text), Convert.ToInt16(leftPortTextBox.Text)));
                    ftp.LoginSuccsseded += this.leftLoginSuccsseded;
                    if (((FTPChangeDirectoryErrorEventArgs)e).Directory.Equals(FTPFile.BACK_DIR))
                        ftp.ChangeDirectory(this.LeftCurrentDirectory.ParentDir);
                    else
                        ftp.ChangeDirectory(((FTPChangeDirectoryErrorEventArgs)e).Directory);
                }
                if (serverName == "RightServer")
                {   
                    ftp.LoginSuccsseded -= this.rightLoginSuccsseded;
                    ftp.Connect(new IPEndPoint(IPAddress.Parse(rightHostTextBox.Text), Convert.ToInt16(rightPortTextBox.Text)));
                    ftp.LoginSuccsseded += this.rightLoginSuccsseded;
                    if (((FTPChangeDirectoryErrorEventArgs)e).Directory.Equals(FTPFile.BACK_DIR))
                        ftp.ChangeDirectory(this.RightCurrentDirectory.ParentDir);
                    else
                        ftp.ChangeDirectory(((FTPChangeDirectoryErrorEventArgs)e).Directory);
                }
            }
        }

        void ftp_ChangeDirectorySuccesseded(object sender, FTPChangeDirectoryEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            if (ftp.Name == "LeftServer")
            {
                FTPFile currDir = ftp.GetCurrentDirectory();
                if (currDir != null)
                    ftp.ListDirectory(currDir);
            }
            if (ftp.Name == "RightServer")
            {
                FTPFile currDir = ftp.GetCurrentDirectory();
                if (currDir != null)
                    ftp.ListDirectory(currDir);
            }
        }

        void ftp_CurrentDirectorySucceeded(object sender, FTPCurrentDirectoryEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            string serverName = ftp.Name;
            if (serverName == "LeftServer")
            {
                UpdateWorkingDirPath(this.leftWorkingDirLabel, e.CurrentDirectory.AbsoluthFileName);
                this.LeftCurrentDirectory = e.CurrentDirectory;
            }
            if (serverName == "RightServer")
            {
                UpdateWorkingDirPath(this.rightWorkingDirLabel, e.CurrentDirectory.AbsoluthFileName);
                this.RightCurrentDirectory = e.CurrentDirectory;
            }
        }

        void ftp_CurrentDirectoryFailed(object sender, FTPErrorEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            string serverName = ftp.Name;
            if (serverName == "LeftServer")
                OutputText(leftOutputTextBox, e.Error.Message + "\r\n");
            if (serverName == "RightServer")
                OutputText(rightOutputTextBox, e.Error.Message + "\r\n");
        }

        void ftp_ListDirectoryFailed(object sender, FTPErrorEventArgs e)
        {   
            FTPClient ftp = (FTPClient)sender;
            string serverName = ftp.Name;
            if (serverName == "LeftServer")
                OutputText(leftOutputTextBox, e.Error.Message + "\r\n");
            if (serverName == "RightServer")
                OutputText(rightOutputTextBox, e.Error.Message + "\r\n");
        }

        void ftp_ListDirectorySuccesseded(object sender, FTPListEventArgs e)
        {
            if (((FTPClient)sender).Name == "LeftServer")
            {
                List<FTPFile> files = new List<FTPFile>(e.Files);
                if (!e.ListDirectory.Equals(FTPFile.ROOT))
                    files.Insert(0, FTPFile.BACK_DIR);
                FillDataGrid(leftFilesInfo, files);
            }
            if (((FTPClient)sender).Name == "RightServer")
            {
                List<FTPFile> files = new List<FTPFile>(e.Files);
                if (!e.ListDirectory.Equals(FTPFile.ROOT))
                    files.Insert(0, FTPFile.BACK_DIR);
                FillDataGrid(rightFilesInfo, files);
            }
        }

        void ftp_LogoffFailed(object sender, FTPErrorEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            string serverName = ftp.Name;
            if (serverName == "LeftServer")
                OutputText(leftOutputTextBox, e.Error.Message + "\r\n");
            if (serverName == "RightServer")
                OutputText(rightOutputTextBox, e.Error.Message + "\r\n");
        }

        void ftp_LogoffSuccsseded(object sender, FTPEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            string serverName = ftp.Name;
            if (serverName == "LeftServer")
                OutputText(leftOutputTextBox, "Logoff successfull\r\n");
            if (serverName == "RightServer")
                OutputText(rightOutputTextBox, "Logoff successfull\r\n");
            ftp.Disconnect();
        }

        void ftp_LoginFailed(object sender, FTPErrorEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            string serverName = ftp.Name;
            if (serverName == "LeftServer")
                OutputText(leftOutputTextBox, e.Error.Message + "\r\n");
            if (serverName == "RightServer")
                OutputText(rightOutputTextBox, e.Error.Message + "\r\n");
            ftp.Disconnect();
        }

        void ftp_LoginSuccsseded(object sender, FTPEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            string serverName = ftp.Name;
            if (serverName == "LeftServer")
            {
                FTPFile currDir = ftp.GetCurrentDirectory();
                if (currDir != null)
                    ftp.ListDirectory(currDir);
            }
            if (serverName == "RightServer")
            {
                FTPFile currDir = ftp.GetCurrentDirectory();
                if (currDir != null)
                    ftp.ListDirectory(currDir);
            }
        }

        void ftp_DisconnectFailed(object sender, FTPErrorEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            string serverName = ftp.Name;
            if (serverName == "LeftServer")
                OutputText(leftOutputTextBox, e.Error.Message + "\r\n");
            if (serverName == "RightServer")
                OutputText(rightOutputTextBox, e.Error.Message + "\r\n");
        }

        void ftp_DisconnectSuccsseded(object sender, FTPEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            string serverName = ftp.Name;
            if (serverName == "LeftServer")
                OutputText(leftOutputTextBox, "Successfully disconnected from the server\r\n");
            if (serverName == "RightServer")
                OutputText(rightOutputTextBox, "Successfully disconnected from the server\r\n");
        }

        void ftp_ConnectFailed(object sender, FTPErrorEventArgs e)
        {   
            FTPClient ftp = (FTPClient)sender;
            string serverName = ftp.Name;
            if (serverName == "LeftServer")
                OutputText(leftOutputTextBox, e.Error.Message + "\r\n");
            if (serverName == "RightServer")
                OutputText(rightOutputTextBox, e.Error.Message + "\r\n");
        }

        void ftp_ConnectSuccsseded(object sender, FTPEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            string serverName = ftp.Name;
            if (serverName == "LeftServer")
                ftp.Login(leftUsernameTextBox.Text, leftPasswordTextBox.Text);
            if (serverName == "RightServer")
                ftp.Login(rightUsernameTextBox.Text, rightPasswordTextBox.Text);
        }

        void ftp_CommandExecuted(object sender, FTPReplyEventArgs e)
        {
            FTPClient ftp = (FTPClient)sender;
            string serverName = ftp.Name;
            if (serverName == "LeftServer")
                OutputText(leftOutputTextBox, (e.Command != "" ? e.Command + ": " : string.Empty ) + e.Reply);
            if (serverName == "RightServer")
                OutputText(rightOutputTextBox, (e.Command != "" ? e.Command + ": " : string.Empty) + e.Reply);
        }
    }
}
