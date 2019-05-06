using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MkdFtpClient;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections.Generic;

namespace MkdFTPGuiClient
{
    public partial class MainForm : Form
    {   
        private FTPClient ftpLeft = null;
        private FTPClient ftpRight = null;

        FTPEventHandler<FTPEventArgs> leftLoginSuccsseded = null;
        FTPEventHandler<FTPEventArgs> rightLoginSuccsseded = null;

        public MainForm()
        {
            InitializeComponent();

            leftFilesInfo.AutoGenerateColumns = false;
            rightFilesInfo.AutoGenerateColumns = false;

            ftpLeft = new FTPClient();
            ftpLeft.Name = "LeftServer";
            ftpLeft.CommandExecuted += new FTPEventHandler<FTPReplyEventArgs>(ftp_CommandExecuted);
            ftpLeft.ConnectSuccsseded += new FTPEventHandler<FTPEventArgs>(ftp_ConnectSuccsseded);
            ftpLeft.ConnectFailed += new FTPEventHandler<FTPErrorEventArgs>(ftp_ConnectFailed);
            ftpLeft.DisconnectSuccsseded += new FTPEventHandler<FTPEventArgs>(ftp_DisconnectSuccsseded);
            ftpLeft.DisconnectFailed += new FTPEventHandler<FTPErrorEventArgs>(ftp_DisconnectFailed);
            leftLoginSuccsseded = new FTPEventHandler<FTPEventArgs>(ftp_LoginSuccsseded);
            ftpLeft.LoginSuccsseded += leftLoginSuccsseded;
            ftpLeft.LoginFailed += new FTPEventHandler<FTPErrorEventArgs>(ftp_LoginFailed);
            ftpLeft.LogoffSuccsseded += new FTPEventHandler<FTPEventArgs>(ftp_LogoffSuccsseded);
            ftpLeft.LogoffFailed += new FTPEventHandler<FTPErrorEventArgs>(ftp_LogoffFailed);
            ftpLeft.CurrentDirectorySucceeded += new FTPEventHandler<FTPCurrentDirectoryEventArgs>(ftp_CurrentDirectorySucceeded);
            ftpLeft.CurrentDirectoryFailed += new FTPEventHandler<FTPErrorEventArgs>(ftp_CurrentDirectoryFailed);
            ftpLeft.ListDirectorySuccesseded += new FTPEventHandler<FTPListEventArgs>(ftp_ListDirectorySuccesseded);
            ftpLeft.ListDirectoryFailed += new FTPEventHandler<FTPErrorEventArgs>(ftp_ListDirectoryFailed);
            ftpLeft.ChangeDirectorySuccesseded += new FTPEventHandler<FTPChangeDirectoryEventArgs>(ftp_ChangeDirectorySuccesseded);
            ftpLeft.ChangeDirectoryFailed += new FTPEventHandler<FTPChangeDirectoryErrorEventArgs>(ftp_ChangeDirectoryFailed);
            ftpLeft.RenameSuccesseded += new FTPEventHandler<FTPRenameEventArgs>(ftp_RenameSuccesseded);
            ftpLeft.RenameFailed += new FTPEventHandler<FTPRenameErrorEventArgs>(ftp_RenameFailed);
            ftpLeft.DeleteStarted += new FTPEventHandler<FTPDeleteEventArgs>(ftp_DeleteStarted);
            ftpLeft.DeleteEnded += new FTPEventHandler<FTPDeleteEventArgs>(ftp_DeleteEnded);
            ftpLeft.DeleteFileTraverse += new FTPEventHandler<FTPDeleteFileTraverseEventArgs>(ftp_DeleteFileTraverse);
            ftpLeft.DeleteFileSuccesseded += new FTPEventHandler<FTPDeleteFileEventArgs>(ftp_DeleteFileSuccesseded);
            ftpLeft.DeleteFileFailed += new FTPEventHandler<FTPDeleteFileErrorEventArgs>(ftp_DeleteFileFailed);
            ftpLeft.DownloadStarted += new FTPEventHandler<FTPDownloadEventArgs>(ftp_DownloadStarted);
            ftpLeft.DownloadProgress += new FTPEventHandler<FTPDownloadProgressEventArgs>(ftp_DownloadProgress);
            ftpLeft.DownloadFileTraverse += new FTPEventHandler<FTPDownloadFileTraverseEventArgs>(ftp_DownloadFileTraverse);
            ftpLeft.DownloadEnded += new FTPEventHandler<FTPDownloadEventArgs>(ftp_DownloadEnded);
            ftpLeft.DownloadError += new FTPEventHandler<FTPDownloadErrorEventArgs>(ftp_DownloadError);
            ftpLeft.UploadStarted += new FTPEventHandler<FTPUploadEventArgs>(ftp_UploadStarted);
            ftpLeft.UploadFileTraverse += new FTPEventHandler<FTPUploadFileTraverseEventArgs>(ftp_UploadFileTraverse);
            ftpLeft.UploadProgress += new FTPEventHandler<FTPUploadProgressEventArgs>(ftp_UploadProgress);
            ftpLeft.UploadError += new FTPEventHandler<FTPUploadErrorEventArgs>(ftp_UploadError);
            ftpLeft.UploadEnded += new FTPEventHandler<FTPUploadEventArgs>(ftp_UploadEnded);
            ftpLeft.MakeDirectorySuccesseded += ftp_MakeDirectorySuccesseded;
            ftpLeft.MakeDirectoryFailed += ftp_MakeDirectoryFailed;
            ftpLeft.MakeFileSuccesseded += ftp_MakeFileSuccesseded;
            ftpLeft.MakeFileFailed += ftp_MakeFileFailed;

            ftpRight = new FTPClient();
            ftpRight.Name = "RightServer";
            ftpRight.CommandExecuted += new FTPEventHandler<FTPReplyEventArgs>(ftp_CommandExecuted);
            ftpRight.ConnectSuccsseded += new FTPEventHandler<FTPEventArgs>(ftp_ConnectSuccsseded);
            ftpRight.ConnectFailed += new FTPEventHandler<FTPErrorEventArgs>(ftp_ConnectFailed);
            ftpRight.DisconnectSuccsseded += new FTPEventHandler<FTPEventArgs>(ftp_DisconnectSuccsseded);
            ftpRight.DisconnectFailed += new FTPEventHandler<FTPErrorEventArgs>(ftp_DisconnectFailed);
            rightLoginSuccsseded = new FTPEventHandler<FTPEventArgs>(ftp_LoginSuccsseded);
            ftpRight.LoginSuccsseded += rightLoginSuccsseded;
            ftpRight.LoginFailed += new FTPEventHandler<FTPErrorEventArgs>(ftp_LoginFailed);
            ftpRight.CurrentDirectorySucceeded += new FTPEventHandler<FTPCurrentDirectoryEventArgs>(ftp_CurrentDirectorySucceeded);
            ftpRight.CurrentDirectoryFailed += new FTPEventHandler<FTPErrorEventArgs>(ftp_CurrentDirectoryFailed);
            ftpRight.LogoffSuccsseded += new FTPEventHandler<FTPEventArgs>(ftp_LogoffSuccsseded);
            ftpRight.LogoffFailed += new FTPEventHandler<FTPErrorEventArgs>(ftp_LogoffFailed);
            ftpRight.ListDirectorySuccesseded += new FTPEventHandler<FTPListEventArgs>(ftp_ListDirectorySuccesseded);
            ftpRight.ListDirectoryFailed += new FTPEventHandler<FTPErrorEventArgs>(ftp_ListDirectoryFailed);
            ftpRight.ChangeDirectorySuccesseded += new FTPEventHandler<FTPChangeDirectoryEventArgs>(ftp_ChangeDirectorySuccesseded);
            ftpRight.ChangeDirectoryFailed += new FTPEventHandler<FTPChangeDirectoryErrorEventArgs>(ftp_ChangeDirectoryFailed);
            ftpRight.RenameSuccesseded += new FTPEventHandler<FTPRenameEventArgs>(ftp_RenameSuccesseded);
            ftpRight.RenameFailed += new FTPEventHandler<FTPRenameErrorEventArgs>(ftp_RenameFailed);
            ftpRight.DeleteStarted += new FTPEventHandler<FTPDeleteEventArgs>(ftp_DeleteStarted);
            ftpRight.DeleteEnded += new FTPEventHandler<FTPDeleteEventArgs>(ftp_DeleteEnded);
            ftpRight.DeleteFileTraverse += new FTPEventHandler<FTPDeleteFileTraverseEventArgs>(ftp_DeleteFileTraverse);
            ftpRight.DeleteFileSuccesseded += new FTPEventHandler<FTPDeleteFileEventArgs>(ftp_DeleteFileSuccesseded);
            ftpRight.DeleteFileFailed += new FTPEventHandler<FTPDeleteFileErrorEventArgs>(ftp_DeleteFileFailed);
            ftpRight.DownloadStarted += new FTPEventHandler<FTPDownloadEventArgs>(ftp_DownloadStarted);
            ftpRight.DownloadProgress += new FTPEventHandler<FTPDownloadProgressEventArgs>(ftp_DownloadProgress);
            ftpRight.DownloadFileTraverse += new FTPEventHandler<FTPDownloadFileTraverseEventArgs>(ftp_DownloadFileTraverse);
            ftpRight.DownloadEnded += new FTPEventHandler<FTPDownloadEventArgs>(ftp_DownloadEnded);
            ftpRight.DownloadError += new FTPEventHandler<FTPDownloadErrorEventArgs>(ftp_DownloadError);
            ftpRight.UploadStarted += new FTPEventHandler<FTPUploadEventArgs>(ftp_UploadStarted);
            ftpRight.UploadFileTraverse += new FTPEventHandler<FTPUploadFileTraverseEventArgs>(ftp_UploadFileTraverse);
            ftpRight.UploadProgress += new FTPEventHandler<FTPUploadProgressEventArgs>(ftp_UploadProgress);
            ftpRight.UploadError += new FTPEventHandler<FTPUploadErrorEventArgs>(ftp_UploadError);
            ftpRight.UploadEnded += new FTPEventHandler<FTPUploadEventArgs>(ftp_UploadEnded);
            ftpRight.MakeFileSuccesseded += ftp_MakeFileSuccesseded;
            ftpRight.MakeFileFailed += ftp_MakeFileFailed;
        }
    }
}
