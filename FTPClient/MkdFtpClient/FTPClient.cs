using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace MkdFtpClient
{
    public delegate void FTPEventHandler<T>(object sender, T e) where T : FTPEventArgs;

    public enum ConnectionMode { Active, Passive }

    public class FTPClient
    {
        private FTPConnection ftpConnection = null;
        private string commandsSupported = string.Empty;
        private object _lock = new object();

        private string Username
        {
            get; set;
        }

        private string Password
        {
            get; set;
        }

        private string Account
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public FTPFile GetCurrentDirectory()
        {
            FTPFile currentDirectory = null;
            try
            {
                FTPReply reply = null;
                lock (_lock)
                {
                    reply = FTPCommands.PWD(ftpConnection);
                    currentDirectory = FTPCommands.getCurrentDirectory(reply.Reply);
                }
                if (reply.FtpCode == "257")
                    OnCurrentDirectorySucceeded(this, new FTPCurrentDirectoryEventArgs(currentDirectory));
                else
                    OnCurrentDirectoryFailed(this, 
                        new FTPErrorEventArgs(
                            new FTPException("Retrieving of current directory failed")));
            }
            catch (FTPException ex)
            {
                OnCurrentDirectoryFailed(this, new FTPErrorEventArgs(ex));
            }

            return currentDirectory;
        }

        private int activePort = 10000;
        public int ActivePort
        {
            get 
            {
                lock (_lock)
                    return activePort;
            }
            set 
            {
                lock (_lock)
                {
                    if (activePort < 10000 || activePort > 65536)
                        activePort = 10000;
                    else
                        activePort = value;
                }
            }
        }

        private int expectedDownloadSpeed = 1024 * 1024; // 1 MB per second
        public void setDownloadSpeed(int downloadSpeedBytes)
        {
            this.expectedDownloadSpeed = downloadSpeedBytes;
        }

        public int getDownloadSpeed()
        {
            return expectedDownloadSpeed;
        }

        private ConnectionMode connectionMode = ConnectionMode.Passive;
        public ConnectionMode ConnectionMode
        {
            get { return connectionMode; }
            set { connectionMode = value; }
        }


        public event FTPEventHandler<FTPReplyEventArgs> CommandExecuted = null;

        private void OnCommandExecuted(object sender, FTPReplyEventArgs e)
        {
            if (CommandExecuted != null)
                CommandExecuted(this, e);
        }

        public event FTPEventHandler<FTPEventArgs> ConnectSuccsseded = null;

        protected void OnConnectSuccsseded(object sender, FTPEventArgs e)
        {
            if (ConnectSuccsseded != null)
                ConnectSuccsseded(sender, e);
        }

        public event FTPEventHandler<FTPErrorEventArgs> ConnectFailed = null;

        protected void OnConnectFailed(object sender, FTPErrorEventArgs e)
        {
            if (ConnectFailed != null)
                ConnectFailed(sender, e);
        }

        public event FTPEventHandler<FTPEventArgs> DisconnectSuccsseded = null;

        protected void OnDisconnectSuccsseded(object sender, FTPEventArgs e)
        {
            if (DisconnectSuccsseded != null)
                DisconnectSuccsseded(sender, e);
        }

        public event FTPEventHandler<FTPErrorEventArgs> DisconnectFailed = null;

        protected void OnDisconnectFailed(object sender, FTPErrorEventArgs e)
        {
            if (DisconnectFailed != null)
                DisconnectFailed(sender, e);
        }

        public event FTPEventHandler<FTPEventArgs> LoginSuccsseded = null;

        protected void OnLoginSuccsseded(object sender, FTPEventArgs e)
        {
            if (LoginSuccsseded != null)
                LoginSuccsseded(sender, e);
        }

        public event FTPEventHandler<FTPErrorEventArgs> LoginFailed = null;

        protected void OnLoginFailed(object sender, FTPErrorEventArgs e)
        {
            if (LoginFailed != null)
                LoginFailed(sender, e);
        }

        public event FTPEventHandler<FTPEventArgs> LogoffSuccsseded = null;

        protected void OnLogoffSuccsseded(object sender, FTPEventArgs e)
        {
            if (LogoffSuccsseded != null)
                LogoffSuccsseded(sender, e);
        }

        public event FTPEventHandler<FTPErrorEventArgs> LogoffFailed = null;

        protected void OnLogoffFailed(object sender, FTPErrorEventArgs e)
        {
            if (LogoffFailed != null)
                LogoffFailed(sender, e);
        }

        public event FTPEventHandler<FTPListEventArgs> ListDirectorySuccesseded = null;

        protected void OnListDirectorySuccesseded(object sender, FTPListEventArgs e)
        {
            if (ListDirectorySuccesseded != null)
                ListDirectorySuccesseded(sender, e);
        }

        public event FTPEventHandler<FTPErrorEventArgs> ListDirectoryFailed = null;

        protected void OnListDirectoryFailed(object sender, FTPErrorEventArgs e)
        {
            if (ListDirectoryFailed != null)
                ListDirectoryFailed(sender, e);
        }

        public event FTPEventHandler<FTPChangeDirectoryEventArgs> ChangeDirectorySuccesseded = null;

        protected void OnChangeDirectorySuccesseded(object sender, FTPChangeDirectoryEventArgs e)
        {
            if (ChangeDirectorySuccesseded != null)
                ChangeDirectorySuccesseded(sender, e);
        }

        public event FTPEventHandler<FTPChangeDirectoryErrorEventArgs> ChangeDirectoryFailed = null;

        protected void OnChangeDirectoryFailed(object sender, FTPChangeDirectoryErrorEventArgs e)
        {
            if (ChangeDirectoryFailed != null)
                ChangeDirectoryFailed(sender, e);
        }

        public event FTPEventHandler<FTPEventArgs> UpOneDirectorySuccesseded = null;

        protected void OnUpOneDirectorySuccesseded(object sender, FTPEventArgs e)
        {
            if (UpOneDirectorySuccesseded != null)
                UpOneDirectorySuccesseded(sender, e);
        }

        public event FTPEventHandler<FTPErrorEventArgs> UpOneDirectoryFailed = null;

        protected void OnUpOneDirectoryFailed(object sender, FTPErrorEventArgs e)
        {
            if (UpOneDirectoryFailed != null)
                UpOneDirectoryFailed(sender, e);
        }

        public event FTPEventHandler<FTPRenameEventArgs> RenameSuccesseded = null;

        protected void OnRenameSuccesseded(object sender, FTPRenameEventArgs e)
        {
            if (RenameSuccesseded != null)
                RenameSuccesseded(sender, e);
        }

        public event FTPEventHandler<FTPRenameErrorEventArgs> RenameFailed = null;

        protected void OnRenameFailed(object sender, FTPRenameErrorEventArgs e)
        {
            if (RenameFailed != null)
                RenameFailed(sender, e);
        }

        public event FTPEventHandler<FTPEventArgs> MakeDirectorySuccesseded = null;

        protected void OnMakeDirectorySuccesseded(object sender, FTPEventArgs e)
        {
            if (MakeDirectorySuccesseded != null)
                MakeDirectorySuccesseded(sender, e);
        }

        public event FTPEventHandler<FTPErrorEventArgs> MakeDirectoryFailed = null;

        protected void OnMakeDirectoryFailed(object sender, FTPErrorEventArgs e)
        {
            if (MakeDirectoryFailed != null)
                MakeDirectoryFailed(sender, e);
        }

        public event FTPEventHandler<FTPEventArgs> MakeFileSuccesseded = null;

        protected void OnMakeFileSuccesseded(object sender, FTPEventArgs e)
        {
            if (MakeFileSuccesseded != null)
                MakeFileSuccesseded(sender, e);
        }

        public event FTPEventHandler<FTPErrorEventArgs> MakeFileFailed = null;

        protected void OnMakeFileFailed(object sender, FTPErrorEventArgs e)
        {
            if (MakeFileFailed != null)
                MakeFileFailed(sender, e);
        }

        public event FTPEventHandler<FTPDeleteEventArgs> DeleteStarted = null;

        protected void OnDeleteStarted(object sender, FTPDeleteEventArgs e)
        {
            if (DeleteStarted != null)
                DeleteStarted(sender, e);
        }

        public event FTPEventHandler<FTPDeleteFileTraverseEventArgs> DeleteFileTraverse = null;

        protected void OnDeleteFileTraverse(object sender, FTPDeleteFileTraverseEventArgs e)
        {
            if (DeleteFileTraverse != null)
                DeleteFileTraverse(sender, e);
        }

        public event FTPEventHandler<FTPDeleteEventArgs> DeleteEnded = null;

        protected void OnDeleteEnded(object sender, FTPDeleteEventArgs e)
        {
            if (DeleteEnded != null)
                DeleteEnded(sender, e);
        }

        public event FTPEventHandler<FTPDeleteFileEventArgs> DeleteFileSuccesseded = null;

        protected void OnDeleteFileSuccesseded(object sender, FTPDeleteFileEventArgs e)
        {
            if (DeleteFileSuccesseded != null)
                DeleteFileSuccesseded(sender, e);
        }

        public event FTPEventHandler<FTPDeleteFileErrorEventArgs> DeleteFileFailed = null;

        protected void OnDeleteFileFailed(object sender, FTPDeleteFileErrorEventArgs e)
        {
            if (DeleteFileFailed != null)
                DeleteFileFailed(sender, e);
        }

        public event FTPEventHandler<FTPDownloadEventArgs> DownloadStarted = null;

        protected void OnDownloadStarted(object sender, FTPDownloadEventArgs e)
        {
            if (DownloadStarted != null)
                DownloadStarted(sender, e);
        }

        public event FTPEventHandler<FTPDownloadProgressEventArgs> DownloadProgress = null;

        protected void OnDownloadProgress(object sender, FTPDownloadProgressEventArgs e)
        {
            if (DownloadProgress != null)
                DownloadProgress(sender, e);
        }

        public event FTPEventHandler<FTPDownloadFileTraverseEventArgs> DownloadFileTraverse = null;

        protected void OnDownloadFileTraverse(object sender, FTPDownloadFileTraverseEventArgs e)
        {
            if (DownloadFileTraverse != null)
                DownloadFileTraverse(sender, e);
        }

        public event FTPEventHandler<FTPDownloadErrorEventArgs> DownloadError = null;

        protected void OnDownloadError(object sender, FTPDownloadErrorEventArgs e)
        {
            if (DownloadError != null)
                DownloadError(sender, e);
        }

        public event FTPEventHandler<FTPDownloadEventArgs> DownloadEnded = null;

        protected void OnDownloadEnded(object sender, FTPDownloadEventArgs e)
        {
            if (DownloadEnded != null)
                DownloadEnded(sender, e);
        }

        public event FTPEventHandler<FTPUploadEventArgs> UploadStarted = null;

        protected void OnUploadStarted(object sender, FTPUploadEventArgs e)
        {
            if (UploadStarted != null)
                UploadStarted(sender, e);
        }

        public event FTPEventHandler<FTPUploadProgressEventArgs> UploadProgress = null;

        protected void OnUploadProgress(object sender, FTPUploadProgressEventArgs e)
        {
            if (UploadProgress != null)
                UploadProgress(sender, e);
        }

        public event FTPEventHandler<FTPUploadFileTraverseEventArgs> UploadFileTraverse = null;

        protected void OnUploadFileTraverse(object sender, FTPUploadFileTraverseEventArgs e)
        {
            if (UploadFileTraverse != null)
                UploadFileTraverse(sender, e);
        }

        public event FTPEventHandler<FTPUploadErrorEventArgs> UploadError = null;

        protected void OnUploadError(object sender, FTPUploadErrorEventArgs e)
        {
            if (UploadError != null)
                UploadError(sender, e);
        }

        public event FTPEventHandler<FTPUploadEventArgs> UploadEnded = null;

        protected void OnUploadEnded(object sender, FTPUploadEventArgs e)
        {
            if (UploadEnded != null)
                UploadEnded(sender, e);
        }

        public event FTPEventHandler<FTPCurrentDirectoryEventArgs> CurrentDirectorySucceeded = null;

        protected void OnCurrentDirectorySucceeded(object sender, FTPCurrentDirectoryEventArgs e)
        {
            if (CurrentDirectorySucceeded != null)
                CurrentDirectorySucceeded(sender, e);
        }

        public event FTPEventHandler<FTPErrorEventArgs> CurrentDirectoryFailed = null;

        protected void OnCurrentDirectoryFailed(object sender, FTPErrorEventArgs e)
        {
            if (CurrentDirectoryFailed != null)
                CurrentDirectoryFailed(sender, e);
        }

        public void Connect(IPEndPoint ftpServerHost)
        {   
            FTPReply ftpReply = null;
            try
            {
                lock (_lock)
                {
                    if (this.ftpConnection == null || !this.ftpConnection.Connected)
                    {
                        this.ftpConnection = new FTPConnection();
                        this.ftpConnection.CommandExecuted += new FTPEventHandler<FTPReplyEventArgs>(OnCommandExecuted);
                        this.ftpConnection.Connect(ftpServerHost);
                        ftpReply = FTPCommands.readReply(ftpConnection);
                    }
                    else
                        return;
                }
                
                // If connection is established
                if (ftpReply.FtpCode == "220")
                {
                    OnCommandExecuted(this, new FTPReplyEventArgs(ftpReply));
                    OnConnectSuccsseded(this, FTPEventArgs.Empty);
                }
                else
                {
                    lock (_lock)
                        this.ftpConnection.Disconnect();
                    OnConnectFailed(this, 
                        new FTPErrorEventArgs(
                            new FTPException("Connection to FTP server failed")));
                }
                ///////////////////////////////
            }
            catch (FTPException ex)
            {
                OnConnectFailed(this, new FTPErrorEventArgs(ex));
            }
        }

        public void Disconnect()
        {
            try
            {
                lock (_lock)
                {
                    if (ftpConnection != null)
                    {
                        if (ftpConnection.Connected)
                            this.ftpConnection.Disconnect();
                        else
                            return;
                    }
                    else
                        return;
                }
                OnDisconnectSuccsseded(this, FTPEventArgs.Empty);
            }
            catch (FTPException ex)
            {
                OnDisconnectFailed(this, new FTPErrorEventArgs(ex));
            }
        }

        public void Login(string username, string password = "", string account = "")
        {
            this.Username = username;
            this.Password = password;
            this.Account = account;
            FTPReply ftpReply = null;
            try
            {
                lock (_lock)
                {
                    while (true)
                    {
                        if (ftpReply == null)
                            ftpReply = FTPCommands.USER(ftpConnection, username);

                        if (ftpReply.FtpCode == "331")
                        {
                            ftpReply = FTPCommands.PASS(ftpConnection, password);
                            continue;
                        }

                        if (ftpReply.FtpCode == "332")
                        {
                            ftpReply = FTPCommands.ACCT(ftpConnection, account);
                            continue;
                        }

                        if (ftpReply.FtpCode == "230")
                            break;

                        break;
                    }// end of while
                }// end of lock

                if (ftpReply.FtpCode == "230")
                    OnLoginSuccsseded(this, FTPEventArgs.Empty);
                else
                    OnLoginFailed(this, 
                        new FTPErrorEventArgs(
                            new FTPException("Login failed")));
            }
            catch (FTPException ex)
            {
                OnLoginFailed(this, new FTPErrorEventArgs(ex));
            }
        }

        public void Logoff()
        {
            try
            {
                FTPReply ftpReply = null;
                lock (_lock)
                    ftpReply = FTPCommands.QUIT(ftpConnection);

                if (ftpReply.FtpCode == "221")
                    OnLogoffSuccsseded(this, FTPEventArgs.Empty);
                else
                    OnLogoffFailed(this, 
                        new FTPErrorEventArgs(
                            new FTPException("Logoff failed")));
            }
            catch (FTPException ex)
            {
                OnLogoffFailed(this, new FTPErrorEventArgs(ex));
            }
        }

        public List<FTPFile> ListDirectory(FTPFile dir)
        {
            List<FTPFile> files = null;

            if (dir != null && dir.Type == FTPFileType.Directory)
            {
                try
                {

                    FTPReply reply = null;
                    Socket dataConnection = null;
                    lock (_lock)
                    {
                        while (true)
                        {

                            if (reply == null && this.connectionMode == ConnectionMode.Active)
                            {
                                reply = FTPCommands.PORT(ftpConnection, new IPEndPoint(IPAddress.Parse("127.0.0.1"), ActivePort = ++ActivePort));
                                continue;
                            }
                            else if (reply == null && this.connectionMode == ConnectionMode.Passive)
                            {
                                reply = FTPCommands.PASV(ftpConnection);
                                continue;
                            }

                            //Active
                            if (reply.FtpCode == "200")
                            {
                                reply = FTPCommands.LIST(ftpConnection, dir.AbsoluthFileName);
                                dataConnection = FTPCommands.getDataConnection(reply);
                                continue;
                            }

                            // Passive
                            if (reply.FtpCode == "227")
                            {
                                dataConnection = FTPCommands.getDataConnection(reply);
                                reply = FTPCommands.LIST(ftpConnection, dir.AbsoluthFileName);
                                continue;
                            }

                            if (reply.FtpCode == "125" || reply.FtpCode == "150")
                            {
                                files = FTPCommands.getListInfo(dataConnection,
                                                        new IParseListInfo[] 
                                                        { 
                                                            new UnixParseListInfo(), 
                                                            new WindowsParseListInfo()
                                                        },
                                                        dir
                                                        );
                                reply = FTPCommands.readReply(ftpConnection);
                                OnCommandExecuted(this, new FTPReplyEventArgs(reply));
                                break;
                            }

                            break;

                        }// end of while
                    }// end of lock

                    if (reply.FtpCode == "226" || reply.FtpCode == "250")
                        OnListDirectorySuccesseded(this, new FTPListEventArgs(files.ToArray(), (FTPFile)dir.Clone()));
                    else
                        OnListDirectoryFailed(this, 
                            new FTPErrorEventArgs(
                                new FTPException("Listing of directory " + dir.AbsoluthFileName + " failed")));

                }// end of try
                catch (FTPException ex)
                {
                    OnListDirectoryFailed(this, new FTPErrorEventArgs(ex));
                }// end of catch
            }
            else
            {
                OnListDirectoryFailed(this, 
                    new FTPErrorEventArgs(
                        new FTPException("Only directories can be listed")));
            }

            return files;
        }
        
        public FTPFile ChangeDirectory(FTPFile dir)
        {
            FTPFile currentDirectory = null;
            if (dir.Type == FTPFileType.Directory)
            {
                try
                {
                    FTPReply reply = null;
                    lock (_lock)
                    {
                        reply = FTPCommands.CWD(ftpConnection, dir.AbsoluthFileName);
                        currentDirectory = (FTPFile)dir.Clone();
                    }
                    
                    if (reply.FtpCode == "250")
                        OnChangeDirectorySuccesseded(this, new FTPChangeDirectoryEventArgs((FTPFile)dir.Clone()));
                    else
                        OnChangeDirectoryFailed(this, 
                                                new FTPChangeDirectoryErrorEventArgs(
                                                    new FTPException("Error changing to directory " + dir.AbsoluthFileName), 
                                                    (FTPFile)dir.Clone()));
                }
                catch (FTPException ex)
                {
                    OnChangeDirectoryFailed(this, new FTPChangeDirectoryErrorEventArgs(ex, (FTPFile)dir.Clone()));
                }
            }//end of if

            return currentDirectory;
        }

        public void UpOneDirectory()
        {   
            try
            {
                FTPReply reply = null;
                lock (_lock)
                    reply = FTPCommands.CDUP(ftpConnection);

                if (reply.FtpCode == "200" || reply.FtpCode == "250")
                    OnUpOneDirectorySuccesseded(this, FTPEventArgs.Empty);
                else
                    OnUpOneDirectoryFailed(this, 
                                           new FTPChangeDirectoryErrorEventArgs
                                            (
                                               new FTPException("Error changing to directory")
                                            ));
            }
            catch (FTPException ex)
            {
                OnUpOneDirectoryFailed(this, new FTPChangeDirectoryErrorEventArgs(ex));
            }
        }

        public void Rename(FTPFile oldFile, FTPFile newFile)
        {
            try
            {
                if (oldFile.Type == FTPFileType.Directory && newFile.Type == FTPFileType.Directory)
                {
                    FTPReply reply = null;
                    lock (_lock)
                    {
                        while (true)
                        {
                            if (reply == null)
                            {
                                reply = FTPCommands.RNFR(ftpConnection, oldFile.AbsoluthFileName);
                                continue;
                            }

                            if (reply.FtpCode == "350")
                            {
                                reply = FTPCommands.RNTO(ftpConnection, newFile.AbsoluthFileName);
                                break;
                            }

                            break;

                        }// end of while
                    }// end of lock

                    if (reply.FtpCode == "250")
                        OnRenameSuccesseded(this, new FTPRenameEventArgs((FTPFile)oldFile.Clone(), (FTPFile)newFile.Clone()));
                    else
                        OnRenameFailed(this, 
                            new FTPRenameErrorEventArgs(
                                new FTPException("Rename of directory failed"), 
                                (FTPFile)oldFile.Clone(), (FTPFile)newFile.Clone()));
                }
                else if (oldFile.Type == FTPFileType.File && newFile.Type == FTPFileType.File)
                {
                    FTPReply reply = null;
                    lock (_lock)
                    {
                        while (true)
                        {
                            if (reply == null)
                            {
                                reply = FTPCommands.RNFR(ftpConnection, oldFile.AbsoluthFileName);
                                continue;
                            }

                            if (reply.FtpCode == "350")
                            {
                                reply = FTPCommands.RNTO(ftpConnection, newFile.AbsoluthFileName);
                                break;
                            }

                            break;

                        }// end of while
                    }// end of lock

                    if (reply.FtpCode == "250")
                        OnRenameSuccesseded(this, new FTPRenameEventArgs((FTPFile)oldFile.Clone(), (FTPFile)newFile.Clone()));
                    else
                        OnRenameFailed(this, 
                            new FTPRenameErrorEventArgs(
                                new FTPException("Rename of file failed"),
                                (FTPFile)oldFile.Clone(), (FTPFile)newFile.Clone()));

                }
                else
                {
                    OnRenameFailed(this,
                        new FTPRenameErrorEventArgs(
                            new FTPException("The files should be of same type, eather File or Directory")));
                }
            }// end of try
            catch (FTPException ex)
            {
                OnRenameFailed(this, new FTPRenameErrorEventArgs(ex));
            }
        }

        public void MakeDirectory(FTPFile dir)
        {
            try
            {
                if (dir.Type == FTPFileType.Directory)
                {
                    FTPReply reply = null;
                    lock (_lock)
                        reply = FTPCommands.MKD(ftpConnection, dir.AbsoluthFileName);

                    if (reply.FtpCode == "257")
                        OnMakeDirectorySuccesseded(this, FTPEventArgs.Empty);
                    else
                        OnMakeDirectoryFailed(this, 
                            new FTPErrorEventArgs(
                                new FTPException("Directory " + dir.AbsoluthFileName + " could not be created")));
                }
                else
                {
                    OnMakeDirectoryFailed(this, 
                        new FTPErrorEventArgs(
                            new FTPException(dir.AbsoluthFileName + " is not a directory")));
                }
            }
            catch (FTPException ex)
            {
                OnMakeDirectoryFailed(this, new FTPErrorEventArgs(ex));
            }
        }

        public void MakeFile(FTPFile file)
        {
            try
            {
                if (file.Type == FTPFileType.File)
                {
                    FTPReply reply = null;
                    Socket dataConnection = null;
                    lock (_lock)
                    {
                        while (true)
                        {
                            if (reply == null)
                            {
                                if (this.connectionMode == MkdFtpClient.ConnectionMode.Active)
                                    reply = FTPCommands.PORT(this.ftpConnection, new IPEndPoint(IPAddress.Parse("127.0.0.1"), ActivePort = ++ActivePort));
                                else
                                    reply = FTPCommands.PASV(this.ftpConnection);
                                continue;
                            }

                            // Port command
                            if (reply.FtpCode == "200")
                            {
                                reply = FTPCommands.STOR(this.ftpConnection, file.AbsoluthFileName);
                                if (reply.FtpCode == "125" || reply.FtpCode == "150")
                                {
                                    dataConnection = FTPCommands.getDataConnection(reply);
                                    dataConnection.Shutdown(SocketShutdown.Both);
                                    dataConnection.Close();
                                    reply = FTPCommands.readReply(this.ftpConnection);
                                }
                                break;
                            }

                            // Pasv command
                            if (reply.FtpCode == "227")
                            {
                                dataConnection = FTPCommands.getDataConnection(reply);
                                reply = FTPCommands.STOR(this.ftpConnection, file.AbsoluthFileName);
                                if (reply.FtpCode == "125" || reply.FtpCode == "150")
                                {
                                    dataConnection.Shutdown(SocketShutdown.Both);
                                    dataConnection.Close();
                                    reply = FTPCommands.readReply(this.ftpConnection);
                                }
                                else
                                {
                                    dataConnection.Shutdown(SocketShutdown.Both);
                                    dataConnection.Close();
                                }
                                break;
                            }

                        }// end of while
                    }// end of lock

                    OnMakeFileSuccesseded(this, FTPEventArgs.Empty);

                }// end of if
                else
                {
                    OnMakeFileFailed(this,
                        new FTPErrorEventArgs(
                                new FTPException(file.AbsoluthFileName + " is not a file")));
                }
            }
            catch (FTPException ex)
            {
                OnMakeFileFailed(this, new FTPErrorEventArgs(ex));
            }
        }

        private List<FTPFile> filesBeeingDeleted = new List<FTPFile>();
        public void Delete(FTPFile file)
        {
            lock (_lock)
            {
                var exists = from f in filesBeeingDeleted where f.AbsoluthFileName == file.AbsoluthFileName select f;
                if (exists.Count() == 1)
                    return;
                filesBeeingDeleted.Add(file);
            }

            FTPFile currentFile = file;
            try
            {
                List<FTPFile> list = null;
                OnDeleteStarted(this, new FTPDeleteEventArgs(currentFile));
                list = ListDirectory(file, this.ftpConnection, ListDirectoryInitiator.Delete);
                long deletedFiles = 0;
                if (list != null)
                {
                    for (int i = list.Count - 1; i >= 0; --i)
                    {
                        currentFile = list[i];
                        if (currentFile.Type == FTPFileType.File)
                        {
                            FTPReply reply = null;
                            lock (_lock)
                                reply = FTPCommands.DELE(ftpConnection, currentFile.AbsoluthFileName);

                            if (reply.FtpCode == "250")
                            {
                                FTPDeleteFileEventArgs e = new FTPDeleteFileEventArgs(++deletedFiles, list.Count, currentFile, file);
                                OnDeleteFileSuccesseded(this, e);
                                if (e.CancelDelete)
                                    break;
                            }
                            else
                            {
                                OnDeleteFileFailed(this, 
                                    new FTPDeleteFileErrorEventArgs(
                                        currentFile, 
                                        new FTPException("File " + currentFile.AbsoluthFileName + " could not be deleted")));
                                break;
                            }

                        }// end of if

                        if (currentFile.Type == FTPFileType.Directory)
                        {
                            FTPReply reply = null;
                            lock (_lock)
                                reply = FTPCommands.RMD(ftpConnection, currentFile.AbsoluthFileName);

                            if (reply.FtpCode == "250")
                            {
                                FTPDeleteFileEventArgs e = new FTPDeleteFileEventArgs(++deletedFiles, list.Count, currentFile, file);
                                OnDeleteFileSuccesseded(this, e);
                                if (e.CancelDelete)
                                    break;
                            }
                            else
                            {
                                OnDeleteFileFailed(this, 
                                    new FTPDeleteFileErrorEventArgs(
                                        currentFile,
                                        new FTPException("Directory " + currentFile.AbsoluthFileName + " could not be deleted")));
                                break;
                            }

                        }// end of if
                    }// end of for
                }// end of if

                OnDeleteEnded(this, new FTPDeleteEventArgs(file));
            }
            catch (FTPException ex)
            {
                OnDeleteFileFailed(this, new FTPDeleteFileErrorEventArgs(currentFile, ex));
                OnDeleteEnded(this, new FTPDeleteEventArgs(file));
            }

            lock (_lock)
                filesBeeingDeleted.Remove(file);

        }

        private enum ListDirectoryInitiator { Delete, Download }
        private List<FTPFile> ListDirectory(FTPFile startDir, FTPConnection ftpConnection, ListDirectoryInitiator initiator, List<FTPFile> list = null)
        {
            if (list == null)
                list = new List<FTPFile>() { startDir };

            FTPReply reply = null;
            Socket dataConnection = null;
            List<FTPFile> files = null;
            FTPException ex = null;
            try
            {
                if (this.ftpConnection == ftpConnection)
                    Monitor.Enter(_lock);

                if (startDir.Type == FTPFileType.Directory)
                {
                    while (true)
                    {
                        if (reply == null && this.connectionMode == ConnectionMode.Active)
                        {
                            reply = FTPCommands.PORT(ftpConnection, new IPEndPoint(IPAddress.Parse("127.0.0.1"), ActivePort = ++ActivePort));
                            continue;
                        }
                        else if (reply == null && this.connectionMode == ConnectionMode.Passive)
                        {
                            reply = FTPCommands.PASV(ftpConnection);
                            continue;
                        }

                        //Active
                        if (reply.FtpCode == "200")
                        {
                            reply = FTPCommands.LIST(ftpConnection, startDir.AbsoluthFileName);
                            dataConnection = FTPCommands.getDataConnection(reply);
                            continue;
                        }

                        // Passive
                        if (reply.FtpCode == "227")
                        {
                            dataConnection = FTPCommands.getDataConnection(reply);
                            reply = FTPCommands.LIST(ftpConnection, startDir.AbsoluthFileName);
                            continue;
                        }

                        if (reply.FtpCode == "125" || reply.FtpCode == "150")
                        {
                            files = FTPCommands.getListInfo(dataConnection,
                                                    new IParseListInfo[] 
                                                        { 
                                                            new UnixParseListInfo(), 
                                                            new WindowsParseListInfo()
                                                        },
                                                    startDir
                                                    );
                            reply = FTPCommands.readReply(ftpConnection);
                            list.AddRange(files);
                            continue;
                        }

                        if (reply.FtpCode == "226" || reply.FtpCode == "250")
                            break;

                        ex = new FTPException("Traversing of directories and files failed.\r\n" +
                                              "Could not traverse directory \"" + startDir.AbsoluthFileName + "\"");
                        break;

                    }// end of while
                }// end of if
            }
            finally
            {
                if (this.ftpConnection == ftpConnection)
                    Monitor.Exit(_lock);
                if (ex != null)
                    throw ex;
            }

            if (reply != null && (reply.FtpCode == "226" || reply.FtpCode == "250"))
            {
                if (initiator == ListDirectoryInitiator.Delete)
                {
                    FTPDeleteFileTraverseEventArgs e = new FTPDeleteFileTraverseEventArgs(list[0]);
                    OnDeleteFileTraverse(this, e);
                    if (e.CancelDelete)
                    {
                        files = null;
                        list = null;
                    }
                }
                else if (initiator == ListDirectoryInitiator.Download)
                {
                    FTPDownloadFileTraverseEventArgs e = new FTPDownloadFileTraverseEventArgs(list[0]);
                    OnDownloadFileTraverse(this, e);
                    if (e.CancelDownload)
                    {
                        files = null;
                        list = null;
                    }
                }
            }// end of if
            
            if (files != null)
            {
                foreach (var f in files)
                {
                    if (ListDirectory(f, ftpConnection, initiator, list) == null)
                    {
                        list = null;
                        break;
                    }
                }
            }

            return list;
        }
        
        private void _Download(FTPClient ftp, FTPFile currentFile, FTPFile rootFile, DirectoryInfo downloadPath,
                               ref bool canceled, ref DateTime downloadTime, ref int currentDownloadSpeed,
                               ref long downloadedBytes, long totalToDownloadBytes, byte[] buffer)
        {
            FTPReply reply = null;
            Socket dataConnection = null;
            while (true)
            {
                if (reply == null)
                {
                    if (this.connectionMode == MkdFtpClient.ConnectionMode.Active)
                        reply = FTPCommands.PORT(ftp.ftpConnection, new IPEndPoint(IPAddress.Parse("127.0.0.1"), ActivePort = ++ActivePort));
                    else
                        reply = FTPCommands.PASV(ftp.ftpConnection);
                    continue;
                }

                // Port command
                if (reply.FtpCode == "200")
                {
                    reply = FTPCommands.RETR(ftp.ftpConnection, currentFile.AbsoluthFileName);
                    if (reply.FtpCode == "125" || reply.FtpCode == "150")
                        dataConnection = FTPCommands.getDataConnection(reply);
                    continue;
                }

                // Pasv command
                if (reply.FtpCode == "227")
                {
                    dataConnection = FTPCommands.getDataConnection(reply);
                    reply = FTPCommands.RETR(ftp.ftpConnection, currentFile.AbsoluthFileName);
                    continue;
                }

                if (reply.FtpCode == "125" || reply.FtpCode == "150")
                {   
                    //download file
                    FileStream fs = null;
                    FileInfo fileToDownload = null;

                    try
                    {
                        if (!downloadPath.Exists)
                            downloadPath.Create();
                        fileToDownload = new FileInfo(downloadPath.FullName + Path.DirectorySeparatorChar + currentFile.Name);
                        fs = fileToDownload.Create();

                        while (true)
                        {   
                            int bytesPerRead = dataConnection.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                            currentDownloadSpeed += bytesPerRead;
                            downloadedBytes += bytesPerRead;

                            if (bytesPerRead == 0)
                            {
                                break;
                            }
                            else
                            {
                                //---------------------------------//
                                fs.Write(buffer, 0, bytesPerRead);
                                fs.Flush();
                                //---------------------------------//
                                
                                if (currentDownloadSpeed >= buffer.Length)
                                {
                                    TimeSpan elapsedTime = DateTime.Now - downloadTime;
                                    //Console.WriteLine("currentDownloadSpeed >= expectedDownloadSpeed :" + elapsedTime.TotalMilliseconds);
                                    if (elapsedTime.TotalMilliseconds < 1000)
                                        Thread.Sleep(1000 - (int)elapsedTime.TotalMilliseconds);
                                    if (elapsedTime.TotalSeconds >= 1)
                                        currentDownloadSpeed = currentDownloadSpeed / (int)elapsedTime.TotalSeconds;
                                    FTPDownloadProgressEventArgs e = null;
                                    OnDownloadProgress(this, e = new FTPDownloadProgressEventArgs(rootFile, downloadedBytes, 
                                                                                              totalToDownloadBytes, currentDownloadSpeed));
                                    currentDownloadSpeed = 0;
                                    downloadTime = DateTime.Now;

                                    if ((canceled = e.CancelDownload))
                                        break;
                                    continue;
                                }

                                TimeSpan elapsedTime1 = DateTime.Now - downloadTime;
                                if (elapsedTime1.TotalMilliseconds >= 1000)
                                {
                                    //Console.WriteLine("(DateTime.Now - downloadTime).Milliseconds >= 1000 :" + elapsedTime1.TotalMilliseconds);
                                    FTPDownloadProgressEventArgs e = null;
                                    if (elapsedTime1.TotalSeconds >= 1)
                                        currentDownloadSpeed = currentDownloadSpeed / (int)elapsedTime1.TotalSeconds;
                                    OnDownloadProgress(this, e = new FTPDownloadProgressEventArgs(rootFile, downloadedBytes,
                                                                                              totalToDownloadBytes, currentDownloadSpeed));
                                    currentDownloadSpeed = 0;
                                    downloadTime = DateTime.Now;

                                    if ( (canceled = e.CancelDownload) )
                                        break;
                                }
                            }// end of else if
                        }// end of while

                        dataConnection.Shutdown(SocketShutdown.Both);
                        dataConnection.Close();
                        fs.Close();
                        if (canceled)
                            fileToDownload.Delete();

                        reply = FTPCommands.readReply(ftp.ftpConnection);
                        OnCommandExecuted(this, new FTPReplyEventArgs(reply));
                        break;
                    }// end of try
                    catch (Exception ex)
                    {
                        try
                        {
                            if (dataConnection.Connected)
                            {
                                dataConnection.Shutdown(SocketShutdown.Both);
                                dataConnection.Close();
                            }
                        }
                        catch (Exception) { }
                        
                        try
                        {
                            if (fs != null)
                            {
                                fs.Close();
                                if (fileToDownload.Exists)
                                    fileToDownload.Delete();
                            }
                        }
                        catch (Exception) { }

                        reply = FTPCommands.readReply(ftp.ftpConnection);
                        OnCommandExecuted(this, new FTPReplyEventArgs(reply));
                        throw new FTPException(ex.Message, ex);
                    }
                }// end of if

                throw new FTPException("Download of file " + currentFile.AbsoluthFileName + " failed");

            }// end of while
        }

        private List<FTPFile> filesBeingDownloaded = new List<FTPFile>();
        public void Download(FTPFile file, System.IO.DirectoryInfo downloadPath)
        {
            lock (_lock)
            {
                var s = from f in filesBeingDownloaded where f.AbsoluthFileName == file.AbsoluthFileName select f;
                if (s.Count() == 1)
                    return;
                filesBeingDownloaded.Add(file);
            }

            FTPClient ftp = null;
            FTPReply reply = null;
            try
            {
                if (!downloadPath.FullName.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    downloadPath = new DirectoryInfo(downloadPath.FullName + Path.DirectorySeparatorChar.ToString());

                OnDownloadStarted(this, new FTPDownloadEventArgs(file));
                while (true)
                {
                    if (ftp == null)
                    {
                        ftp = new FTPClient();
                        ftp.ConnectFailed += delegate(object sender, FTPErrorEventArgs e)
                        {
                            throw e.Error;
                        };
                        ftp.LoginFailed += delegate(object sender, FTPErrorEventArgs e)
                        {
                            throw e.Error;
                        };
                        ftp.Connect((IPEndPoint)this.ftpConnection.RemoteEndPoint);
                        ftp.ftpConnection.CommandExecuted += new FTPEventHandler<FTPReplyEventArgs>(OnCommandExecuted);
                        ftp.Login(this.Username, this.Password, this.Account);
                        continue;
                    }

                    if (reply == null)
                    {
                        reply = FTPCommands.MODE(ftp.ftpConnection, Mode.Stream);
                        if (reply.FtpCode == "200")
                        {
                            reply = FTPCommands.TYPE(ftp.ftpConnection, Type.Image);
                            if (reply.FtpCode == "200")
                                continue;
                        }
                        break;
                    }

                    List<FTPFile> files = null;
                    files = ListDirectory(file, ftp.ftpConnection, ListDirectoryInitiator.Download);

                    // if not canceled
                    if (files != null)
                    {
                        long totalToDownloadBytes = (from f in files where f.Type == FTPFileType.File select Convert.ToInt64(f.Size)).Sum();
                        long downloadedBytes = 0;
                        int currentDownloadSpeed = 0;
                        bool canceled = false;
                        string rootDir = file.ParentDir.AbsoluthFileName;
                        ftp.ftpConnection.ReceiveBufferSize = getDownloadSpeed();
                        byte[] buffer = new byte[ftp.ftpConnection.ReceiveBufferSize];
                        DateTime downloadTime = DateTime.Now;
                        for (int i = 0; i < files.Count; ++i)
                        {
                            if (files[i].Type == FTPFileType.File)
                            {
                                DirectoryInfo downloadDir = new DirectoryInfo(downloadPath.FullName +
                                                                      files[i].ParentDir.AbsoluthFileName.Minus(rootDir).Replace('/', Path.DirectorySeparatorChar));
                                _Download(ftp, files[i], file, downloadDir, ref canceled, ref downloadTime,
                                          ref currentDownloadSpeed, ref downloadedBytes, totalToDownloadBytes, buffer);
                            }

                            if (canceled)
                                break;

                        }// end of for
                    }// end of if
                    ftp.Logoff();
                    ftp.Disconnect();
                    break;
                }// end of while
                OnDownloadEnded(this, new FTPDownloadEventArgs(file));
            }
            catch (FTPException ex)
            {
                try
                {
                    ftp.Logoff();
                    ftp.Disconnect();
                }
                catch (FTPException) { }
                OnDownloadError(this, new FTPDownloadErrorEventArgs(file, ex));
                OnDownloadEnded(this, new FTPDownloadEventArgs(file));
            }

            lock (_lock)
                filesBeingDownloaded.Remove(file);
        }

        public void Transfer(FTPClient ftpClient, FTPFile fileToDownload, FTPFile whereToDownload)
        {

        }

        private List<FileSystemInfo> listDirectoryLocal(FileSystemInfo startDir, List<FileSystemInfo> list = null)
        {
            try
            {
                if (list == null)
                    list = new List<FileSystemInfo>() { startDir };

                if (startDir is DirectoryInfo)
                {
                    DirectoryInfo dir = (DirectoryInfo)startDir;
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    FileInfo[] files = dir.GetFiles();
                    list.AddRange(dirs);
                    list.AddRange(files);
                    foreach (var f in dirs)
                        list = listDirectoryLocal(f, list);
                }

                return list;
            }
            catch (Exception ex) {
                throw new FTPException(ex.Message, ex);
            }
        }

        private void uploadFile(FTPClient ftp, FileInfo currentFile, FileSystemInfo fileToUpload, 
                                FTPFile dir, ref long uploaded, long totalToUploadBytes, ref int currentUploadSpeed, 
                                ref bool canceled, byte[] buffer, ref DateTime uploadTime)
        {
            FTPReply reply = null;
            Socket dataConnection = null;
            while (true)
            {
                if (reply == null)
                {
                    if (this.connectionMode == MkdFtpClient.ConnectionMode.Active)
                        reply = FTPCommands.PORT(ftp.ftpConnection, new IPEndPoint(IPAddress.Parse("127.0.0.1"), ActivePort = ++ActivePort));
                    else
                        reply = FTPCommands.PASV(ftp.ftpConnection);
                    continue;
                }

                // Port command
                if (reply.FtpCode == "200")
                {
                    reply = FTPCommands.STOR(ftp.ftpConnection, dir.AbsoluthFileName + "/" + currentFile.Name);
                    if (reply.FtpCode == "125" || reply.FtpCode == "150")
                        dataConnection = FTPCommands.getDataConnection(reply);
                    continue;
                }

                // Pasv command
                if (reply.FtpCode == "227")
                {
                    dataConnection = FTPCommands.getDataConnection(reply);
                    reply = FTPCommands.STOR(ftp.ftpConnection, dir.AbsoluthFileName + "/" + currentFile.Name);
                    continue;
                }

                if (reply.FtpCode == "125" || reply.FtpCode == "150")
                {
                    //upload file
                    FileStream fs = null;
                    try
                    {
                        fs = currentFile.OpenRead();
                        while (true)
                        {
                            int read = 1;
                            int bytesRead = 0;
                            // Fill the buffer until it is full or
                            // end of file is reached
                            while (bytesRead < buffer.Length && read > 0)
                            {
                                read = fs.Read(buffer, bytesRead, buffer.Length - bytesRead);
                                bytesRead += read;
                            }

                            int written = 0;
                            int totoalWritten = 0;
                            // Send the read data to the ftp server
                            // until all data is send or the data connection
                            // is closed by the ftp server
                            while (true)
                            {
                                written = dataConnection.Send(buffer, totoalWritten, bytesRead - totoalWritten, SocketFlags.None);
                                if (written == 0)
                                    break;
                                totoalWritten += written;
                                uploaded += written;
                                currentUploadSpeed += written;
                                var timeElapsed = DateTime.Now - uploadTime;
                                if (currentUploadSpeed >= buffer.Length)
                                {
                                    if (timeElapsed.TotalMilliseconds < 1000.0d)
                                        Thread.Sleep((int)(1000.0d - timeElapsed.TotalMilliseconds));
                                    if (timeElapsed.TotalSeconds > 1)
                                        currentUploadSpeed = currentUploadSpeed / (int)timeElapsed.TotalSeconds;
                                    FTPUploadProgressEventArgs e = new FTPUploadProgressEventArgs(fileToUpload, uploaded, totalToUploadBytes, currentUploadSpeed);
                                    OnUploadProgress(this, e);
                                    currentUploadSpeed = 0;
                                    uploadTime = DateTime.Now;
                                    canceled = e.CancelUpload;
                                    break;
                                }

                                if (timeElapsed.TotalMilliseconds >= 1000.0d)
                                {
                                    currentUploadSpeed = currentUploadSpeed / (int)timeElapsed.TotalSeconds;
                                    FTPUploadProgressEventArgs e = new FTPUploadProgressEventArgs(fileToUpload, uploaded, totalToUploadBytes, currentUploadSpeed);
                                    OnUploadProgress(this, e);
                                    currentUploadSpeed = 0;
                                    uploadTime = DateTime.Now;
                                    if (canceled = e.CancelUpload)
                                        break;
                                }
                            }// end of while

                            // If upload is canceled
                            if (canceled)
                                break;

                            // If end of file is reached or data connection
                            // is closed by the ftp server
                            if (read == 0 || written == 0)
                            {
                                break;
                            }
                        }// end of while

                        dataConnection.Shutdown(SocketShutdown.Both);
                        dataConnection.Close();
                        fs.Close();

                        reply = FTPCommands.readReply(ftp.ftpConnection);
                        OnCommandExecuted(this, new FTPReplyEventArgs(reply));
                        break;
                    }// end of try
                    catch (Exception ex)
                    {
                        try
                        {
                            if (dataConnection.Connected)
                            {
                                dataConnection.Shutdown(SocketShutdown.Both);
                                dataConnection.Close();
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            if (fs != null)
                                fs.Close();
                        }
                        catch (Exception) { }

                        reply = FTPCommands.readReply(ftp.ftpConnection);
                        OnCommandExecuted(this, new FTPReplyEventArgs(reply));
                        throw new FTPException(ex.Message, ex);
                    }
                }// end of if

                throw new FTPException("Upload of file \"" + currentFile.FullName  + "\" failed");

            }// end of while
        }

        private List<FileSystemInfo> filesBeeingUploaded = new List<FileSystemInfo>();
        public void Upload(FileSystemInfo fileToUpload, FTPFile uploadPath)
        {
            lock (_lock)
            {
                var s = from f in filesBeeingUploaded where f.FullName == fileToUpload.FullName select f;
                if (s.Count() == 1)
                    return;
                filesBeeingUploaded.Add(fileToUpload);
            }
            
            FTPClient ftp = null;
            FTPReply reply = null;
            try
            {
                OnUploadStarted(this, new FTPUploadEventArgs(fileToUpload));
                while (true)
                {
                    if (ftp == null)
                    {
                        ftp = new FTPClient();
                        ftp.ConnectFailed += delegate(object sender, FTPErrorEventArgs e)
                        {
                            throw e.Error;
                        };
                        ftp.LoginFailed += delegate(object sender, FTPErrorEventArgs e)
                        {
                            throw e.Error;
                        };
                        ftp.Connect((IPEndPoint)this.ftpConnection.RemoteEndPoint);
                        ftp.ftpConnection.CommandExecuted += new FTPEventHandler<FTPReplyEventArgs>(OnCommandExecuted);
                        ftp.Login(this.Username, this.Password, this.Account);
                        continue;
                    }

                    if (reply == null)
                    {
                        reply = FTPCommands.MODE(ftp.ftpConnection, Mode.Stream);
                        if (reply.FtpCode == "200")
                        {
                            reply = FTPCommands.TYPE(ftp.ftpConnection, Type.Image);
                            if (reply.FtpCode == "200")
                                continue;
                        }
                        break;
                    }

                    var allFiles = listDirectoryLocal(fileToUpload);
                    bool canceled = false;
                    long uploaded = 0;
                    long totalToUpload = (from f in allFiles where f is FileInfo select ((FileInfo)f).Length).Sum();
                    int currentUploadSpeed = 0;
                    string root = ((DirectoryInfo)allFiles[0]).Parent.FullName.Replace(Path.DirectorySeparatorChar.ToString(), "/");
                    ftp.ftpConnection.SendBufferSize = 1024 * 1024; // 1 MB
                    byte[] buffer = new byte[ftp.ftpConnection.SendBufferSize]; // 1 MB buffer
                    DateTime uploadTime = DateTime.Now;
                    foreach (var currentFile in allFiles)
                    {
                        if (currentFile is FileInfo)
                        {
                            FTPFile dir = 
                                new FTPFile(uploadPath.AbsoluthFileName + "/" + currentFile.FullName.Replace(Path.DirectorySeparatorChar.ToString(), "/").Minus(root).Minus(currentFile.Name));
                            if (allFiles.Count > 1)
                                uploadFile(ftp, (FileInfo)currentFile, fileToUpload, dir, ref uploaded, totalToUpload, 
                                           ref currentUploadSpeed, ref canceled, buffer, ref uploadTime);
                            else if(allFiles.Count == 1)
                                uploadFile(ftp, (FileInfo)currentFile, fileToUpload, uploadPath, ref uploaded, totalToUpload, 
                                           ref currentUploadSpeed, ref canceled, buffer, ref uploadTime);

                            if (canceled)
                                break;
                        }
                        else
                        {
                            FTPFile dir = new FTPFile(uploadPath.AbsoluthFileName + "/" + currentFile.FullName.Replace(Path.DirectorySeparatorChar.ToString(), "/").Minus(root));
                            reply = FTPCommands.MKD(ftp.ftpConnection, dir.AbsoluthFileName);
                            if (reply.FtpCode != "257")
                                throw new FTPException("Directory \"" + dir.AbsoluthFileName + "\" could not be created");
                        }
                    }
                    break;
                }// end of while;
                OnUploadEnded(this, new FTPUploadEventArgs(fileToUpload));
            }
            catch (FTPException ex)
            {
                OnUploadError(this, new FTPUploadErrorEventArgs(fileToUpload, ex));
                OnUploadEnded(this, new FTPUploadEventArgs(fileToUpload));
            }

            lock (_lock)
                filesBeeingUploaded.Remove(fileToUpload);
        }
    }
}
