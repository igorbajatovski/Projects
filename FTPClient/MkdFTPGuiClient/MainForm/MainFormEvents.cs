using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using MkdFtpClient;
using System.ComponentModel;
using System.IO;

namespace MkdFTPGuiClient
{
    public partial class MainForm : Form
    {
        private delegate void ExecuteDeleg();

        private bool leftConnectInProcess = false;
        private object leftConnectInProcessLock = new object();
        private bool rightConnectInProcess = false;
        private object rightConnectInProcessLock = new object();
        private void LoginButton_Click(object sender, EventArgs e)
        {
            ExecuteDeleg deleg = new ExecuteDeleg(
                delegate()
                {
                    ToolStripMenuItem connect = (ToolStripMenuItem)sender;
                    switch (connect.Name)
                    {
                        case "leftLoginMenuItem":
                            {
                                lock (leftConnectInProcessLock)
                                {
                                    if (leftConnectInProcess)
                                        return;
                                    else
                                        leftConnectInProcess = true;
                                }
                                
                                try
                                {   
                                    ftpLeft.Connect(new IPEndPoint(IPAddress.Parse(leftHostTextBox.Text), Convert.ToInt16(leftPortTextBox.Text)));
                                }
                                catch (FormatException)
                                {
                                    OutputText(leftOutputTextBox, "Wrong address or port format\r\n");
                                }

                                lock (leftConnectInProcessLock)
                                    leftConnectInProcess = false;

                                break;
                            }
                        case "rightLoginMenuItem":
                            {
                                lock (rightConnectInProcessLock)
                                {
                                    if (rightConnectInProcess)
                                        return;
                                    else
                                        rightConnectInProcess = true;
                                }
                                
                                try
                                {
                                    ftpRight.Connect(new IPEndPoint(IPAddress.Parse(rightHostTextBox.Text), Convert.ToInt16(rightPortTextBox.Text)));
                                }
                                catch (FormatException) 
                                {
                                    OutputText(rightOutputTextBox, "Wrong address or port format\r\n");
                                }

                                lock (rightConnectInProcessLock)
                                    rightConnectInProcess = false;

                                break;
                            }
                    }
                });
            deleg.BeginInvoke(null, null);
        }

        private void LogoffButton_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem connect = (ToolStripMenuItem)sender;
            ExecuteDeleg deleg = new ExecuteDeleg(
                delegate()
                {
                    switch (connect.Name)
                    {
                        case "leftLogoffMenuItem":
                            {
                                ftpLeft.Logoff();
                                break;
                            }
                        case "rightLogoffMenuItem":
                            {
                                ftpRight.Logoff();
                                break;
                            }
                    }
                });
            deleg.BeginInvoke(null, null);
        }

        private object leftChangeOfDirectoryInProgressLock = new object();
        private bool leftChangeOfDirectoryInProgress = false;
        private object rightChangeOfDirectoryInProgressLock = new object();
        private bool rightChangeOfDirectoryInProgress = false;

        private void FilesInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {   
            ExecuteDeleg deleg =
                new ExecuteDeleg(
                    delegate()
                    {
                        DataGridView grid = (DataGridView)sender;

                        if (grid.Name == "leftFilesInfo")
                        {
                            int columnHeadersHeight = grid.ColumnHeadersHeight;
                            int columnHeadersWidth = grid.Width;
                            if (e.Y <= columnHeadersHeight && e.X <= columnHeadersWidth)
                                return;
                        }
                        if (grid.Name == "rightFilesInfo")
                        {
                            int columnHeadersHeight = grid.ColumnHeadersHeight;
                            int columnHeadersWidth = grid.Width;
                            if (e.Y <= columnHeadersHeight && e.X <= columnHeadersWidth)
                                return;
                        }

                        switch (grid.Name)
                        {
                            case "leftFilesInfo":
                                {
                                    lock (leftSortingInProgressLock)
                                    {
                                        if (leftSortingInProgress)
                                            return;
                                    }

                                    lock (leftChangeOfDirectoryInProgressLock)
                                    {
                                        if (leftChangeOfDirectoryInProgress)
                                            return;
                                        else
                                            leftChangeOfDirectoryInProgress = true;
                                    }

                                    List<FTPFile> files = (List<FTPFile>)leftFilesInfo.DataSource;
                                    if (leftFilesInfo.SelectedRows != null &&
                                        leftFilesInfo.SelectedRows.Count > 0)
                                        ftpLeft.ChangeDirectory(files[leftFilesInfo.SelectedRows[0].Index]);

                                    this.leftSortAsccending = true;
                                    lock (leftChangeOfDirectoryInProgressLock)
                                        leftChangeOfDirectoryInProgress = false;

                                    break;
                                }
                            case "rightFilesInfo":
                                {
                                    lock (rightSortingInProgressLock)
                                    {
                                        if (rightSortingInProgress)
                                            return;
                                    }
                                    
                                    lock (rightChangeOfDirectoryInProgressLock)
                                    {
                                        if (rightChangeOfDirectoryInProgress)
                                            return;
                                        else
                                            rightChangeOfDirectoryInProgress = true;
                                    }

                                    List<FTPFile> files = (List<FTPFile>)rightFilesInfo.DataSource;
                                    if (leftFilesInfo.SelectedRows != null &&
                                        rightFilesInfo.SelectedRows.Count > 0)
                                        ftpRight.ChangeDirectory(files[rightFilesInfo.SelectedRows[0].Index]);

                                    this.rightSortAsccending = true;
                                    lock (rightChangeOfDirectoryInProgressLock)
                                        rightChangeOfDirectoryInProgress = false;

                                    break;
                                }
                        }
                    }
                );
            deleg.BeginInvoke(null, null);
        }

        private void UpOneDirButton_Click(object sender, EventArgs e)
        {
            ExecuteDeleg deleg = 
                new ExecuteDeleg(
                    delegate()
                    {
                        ToolStripButton upOneDir = (ToolStripButton)sender;
                        switch (upOneDir.Name)
                        {
                            case "leftUpOneDirButton":
                                {
                                    lock (leftSortingInProgressLock)
                                    {
                                        if (leftSortingInProgress)
                                            return;
                                    }

                                    lock (leftChangeOfDirectoryInProgressLock)
                                    {
                                        if (leftChangeOfDirectoryInProgress)
                                            return;
                                        else
                                            leftChangeOfDirectoryInProgress = true;
                                    }

                                    List<FTPFile> files = (List<FTPFile>)leftFilesInfo.DataSource;
                                    if (files.Count > 0)
                                    {
                                        if (files[0].Equals(FTPFile.BACK_DIR))
                                            ftpLeft.ChangeDirectory(files[0]);
                                    }

                                    this.leftSortAsccending = true;

                                    lock (leftChangeOfDirectoryInProgressLock)
                                        leftChangeOfDirectoryInProgress = false;

                                    break;
                                }
                            case "rightUpOneDirButton":
                                {   
                                    lock (rightSortingInProgressLock)
                                    {
                                        if (rightSortingInProgress)
                                            return;
                                    }

                                    lock (rightChangeOfDirectoryInProgressLock)
                                    {
                                        if (rightChangeOfDirectoryInProgress)
                                            return;
                                        else
                                            rightChangeOfDirectoryInProgress = true;
                                    }

                                    List<FTPFile> files = (List<FTPFile>)rightFilesInfo.DataSource;
                                    if (files.Count > 0)
                                    {
                                        if (files[0].Equals(FTPFile.BACK_DIR))
                                            ftpRight.ChangeDirectory(files[0]);
                                    }

                                    this.rightSortAsccending = true;
                                    lock (rightChangeOfDirectoryInProgressLock)
                                        rightChangeOfDirectoryInProgress = false;

                                    break;
                                }
                        }
                    }
                );
            deleg.BeginInvoke(null, null);
        }

        void ActionsInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (e.ColumnIndex == 4)
                grid[e.ColumnIndex, e.RowIndex].Tag = CancelDelete.Canceled;
        }

        private void PopupMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            switch (menuItem.Name)
            {
                case "rightDeleteMenuItem":
                    {
                        ExecuteDeleg deleg = new ExecuteDeleg(
                                delegate()
                                {
                                    if (rightFilesInfo.SelectedRows.Count == 1)
                                        ftpRight.Delete(((List<FTPFile>)rightFilesInfo.DataSource)[rightFilesInfo.SelectedRows[0].Index]);
                                }
                            );
                        deleg.BeginInvoke(null, null);
                        break;
                    }
                case "rightNewDirectoryMenuItem":
                    {
                        ExecuteDeleg deleg = new ExecuteDeleg(
                            delegate()
                            {
                                if (rightFilesInfo.SelectedRows != null &&
                                    rightFilesInfo.SelectedRows.Count > 0)
                                {   
                                    RenameMakeForm make = new RenameMakeForm(this.RightCurrentDirectory, RenameMakeForm.MODE.MakeDir);
                                    DialogResult OkCancel = make.ShowDialog();
                                    switch (OkCancel)
                                    {
                                        case DialogResult.OK:
                                            {
                                                ftpRight.MakeDirectory(make.File);
                                                break;
                                            }

                                        case DialogResult.Cancel:
                                            {
                                                break;
                                            }
                                    }
                                }
                            }
                        );
                        deleg.BeginInvoke(null, null);
                        break;
                    }
                case "rightNewFileMenuItem":
                    {
                        ExecuteDeleg deleg = new ExecuteDeleg(
                            delegate()
                            {
                                if (rightFilesInfo.SelectedRows != null &&
                                    rightFilesInfo.SelectedRows.Count > 0)
                                {
                                    RenameMakeForm make = new RenameMakeForm(this.RightCurrentDirectory, RenameMakeForm.MODE.MakeFile);
                                    DialogResult OkCancel = make.ShowDialog();
                                    switch (OkCancel)
                                    {
                                        case DialogResult.OK:
                                            {
                                                ftpRight.MakeFile(make.File);
                                                break;
                                            }

                                        case DialogResult.Cancel:
                                            {
                                                break;
                                            }
                                    }
                                }
                            }
                        );
                        deleg.BeginInvoke(null, null);
                        break;
                    }
                case "rightDownloadMenuItem":
                    {
                        ExecuteDeleg deleg = new ExecuteDeleg(
                                delegate()
                                {
                                    if (rightFilesInfo.SelectedRows.Count == 1)
                                        ftpRight.Download(((List<FTPFile>)rightFilesInfo.DataSource)[rightFilesInfo.SelectedRows[0].Index],
                                                           new System.IO.DirectoryInfo("C:\\Users\\Igor Bajatovski\\Desktop\\")); 
                                }
                            );
                        deleg.BeginInvoke(null, null);
                        break;
                    }
                case "rightRefreshMenuItem":
                    {
                        ftpRight.ListDirectory(FTPFile.CURRENT_DIR);
                        break;
                    }
                case "rightUploadMenuItem":
                    {
                        ExecuteDeleg deleg = new ExecuteDeleg(
                               delegate()
                               {
                                   if (rightFilesInfo.SelectedRows.Count == 1)
                                       ftpRight.Upload(new DirectoryInfo("C:\\Users\\Igor Bajatovski\\Desktop\\Dokumentacija"), ((List<FTPFile>)rightFilesInfo.DataSource)[rightFilesInfo.SelectedRows[0].Index]);
                               }
                           );
                        deleg.BeginInvoke(null, null);
                        break;
                    }
                case "rightRenameMenuItem":
                    {
                        ExecuteDeleg deleg = new ExecuteDeleg(
                            delegate()
                            {
                                if (rightFilesInfo.SelectedRows != null &&
                                    rightFilesInfo.SelectedRows.Count > 0)
                                {
                                    List<FTPFile> files = (List<FTPFile>)rightFilesInfo.DataSource;
                                    FTPFile oldFile = files[rightFilesInfo.SelectedRows[0].Index];
                                    RenameMakeForm rename = new RenameMakeForm(oldFile, RenameMakeForm.MODE.Rename);
                                    DialogResult OkCancel = rename.ShowDialog();
                                    switch (OkCancel)
                                    {
                                        case DialogResult.OK:
                                            {
                                                ftpRight.Rename(oldFile, rename.File);
                                                break;
                                            }

                                        case DialogResult.Cancel:
                                            {
                                                break;
                                            }
                                    }
                                }
                            }
                        );
                        deleg.BeginInvoke(null, null);
                        break;
                    }
                case "leftDeleteMenuItem":
                    {
                        ExecuteDeleg deleg = new ExecuteDeleg(
                               delegate()
                               {
                                   if (leftFilesInfo.SelectedRows.Count == 1)
                                       ftpLeft.Delete(((List<FTPFile>)leftFilesInfo.DataSource)[leftFilesInfo.SelectedRows[0].Index]);
                               }
                           );
                        deleg.BeginInvoke(null, null);
                        break;
                    }
                case "leftNewDirectoryMenuItem":
                    {
                        ExecuteDeleg deleg = new ExecuteDeleg(
                            delegate()
                            {
                                if (leftFilesInfo.SelectedRows != null &&
                                    leftFilesInfo.SelectedRows.Count > 0)
                                {   
                                    RenameMakeForm make = new RenameMakeForm(this.LeftCurrentDirectory, RenameMakeForm.MODE.MakeDir);
                                    DialogResult OkCancel = make.ShowDialog();
                                    switch (OkCancel)
                                    {
                                        case DialogResult.OK:
                                            {
                                                ftpLeft.MakeDirectory(make.File);
                                                break;
                                            }

                                        case DialogResult.Cancel:
                                            {
                                                break;
                                            }
                                    }
                                }
                            }
                        );
                        deleg.BeginInvoke(null, null);
                        break;
                    }
                case "leftNewFileMenuItem":
                    {
                        ExecuteDeleg deleg = new ExecuteDeleg(
                            delegate()
                            {
                                if (leftFilesInfo.SelectedRows != null &&
                                    leftFilesInfo.SelectedRows.Count > 0)
                                {
                                    RenameMakeForm make = new RenameMakeForm(this.LeftCurrentDirectory, RenameMakeForm.MODE.MakeFile);
                                    DialogResult OkCancel = make.ShowDialog();
                                    switch (OkCancel)
                                    {
                                        case DialogResult.OK:
                                            {
                                                ftpLeft.MakeFile(make.File);
                                                break;
                                            }

                                        case DialogResult.Cancel:
                                            {
                                                break;
                                            }
                                    }
                                }
                            }
                        );
                        deleg.BeginInvoke(null, null);
                        break;
                    }
                case "leftDownloadMenuItem":
                    {
                        ExecuteDeleg deleg = new ExecuteDeleg(
                                delegate()
                                {
                                    if (leftFilesInfo.SelectedRows.Count == 1)
                                        ftpLeft.Download(((List<FTPFile>)leftFilesInfo.DataSource)[leftFilesInfo.SelectedRows[0].Index],
                                                           new System.IO.DirectoryInfo("C:\\Users\\Igor Bajatovski\\Desktop")); 
                                }
                            );
                        deleg.BeginInvoke(null, null);
                        break;
                    }
                case "leftRefreshMenuItem":
                    {
                        ftpLeft.ListDirectory(FTPFile.CURRENT_DIR);
                        break;
                    }
                case "leftUploadMenuItem":
                    {
                        ExecuteDeleg deleg = new ExecuteDeleg(
                                delegate()
                                {
                                    if (leftFilesInfo.SelectedRows.Count == 1)
                                        ftpLeft.Upload(new DirectoryInfo("C:\\Users\\Igor Bajatovski\\Desktop\\Dokumentacija"), ((List<FTPFile>)leftFilesInfo.DataSource)[leftFilesInfo.SelectedRows[0].Index]);
                                }
                            );
                        deleg.BeginInvoke(null, null);
                        break;
                    }
                case "leftRenameMenuItem":
                    {
                        ExecuteDeleg deleg = new ExecuteDeleg(
                            delegate()
                            {
                                if (leftFilesInfo.SelectedRows != null &&
                                    leftFilesInfo.SelectedRows.Count > 0)
                                {
                                    List<FTPFile> files = (List<FTPFile>)leftFilesInfo.DataSource;
                                    FTPFile oldFile = files[leftFilesInfo.SelectedRows[0].Index];
                                    RenameMakeForm rename = new RenameMakeForm(oldFile, RenameMakeForm.MODE.Rename);
                                    DialogResult OkCancel = rename.ShowDialog();
                                    switch (OkCancel)
                                    {
                                        case DialogResult.OK:
                                            {
                                                ftpLeft.Rename(oldFile, rename.File);
                                                break;
                                            }

                                        case DialogResult.Cancel:
                                            {
                                                break;
                                            }
                                    }
                                }
                            }
                        );
                        deleg.BeginInvoke(null, null);
                        break;
                    }
            }
        }

        private void MenuStrip_Opening(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.ContextMenuStrip contextMenuStrip =
                (System.Windows.Forms.ContextMenuStrip)sender;

            if (contextMenuStrip.Name == "leftMenuStrip")
            {
                if (leftFilesInfo.Rows.Count == 0)
                    e.Cancel = true;
            }

            if (contextMenuStrip.Name == "rightMenuStrip")
            {
                if (rightFilesInfo.Rows.Count == 0)
                    e.Cancel = true;
            }
        }

        private bool leftSortAsccending = true;
        private bool rightSortAsccending = true;
        private object leftSortingInProgressLock = new object();
        private bool leftSortingInProgress = false;
        private object rightSortingInProgressLock = new object();
        private bool rightSortingInProgress = false;
        private void FilesInfo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ExecuteDeleg deleg = new ExecuteDeleg(
                delegate()
                {
                    DataGridView grid = (DataGridView)sender;
                    switch (grid.Name)
                    {
                        case "leftFilesInfo":
                            {
                                lock (leftChangeOfDirectoryInProgressLock)
                                {
                                    if (leftChangeOfDirectoryInProgress)
                                        return;
                                }

                                lock (leftSortingInProgressLock)
                                {
                                    if (leftSortingInProgress)
                                        return;
                                    else
                                        leftSortingInProgress = true;
                                }

                                if (e.ColumnIndex == 0)
                                {
                                    if (leftSortAsccending)
                                    {
                                        SortFiles(grid, new FTPFileNameDescendingComparer(), e.ColumnIndex);
                                        leftSortAsccending = false;
                                    }
                                    else
                                    {
                                        SortFiles((DataGridView)sender, new FTPFileNameAsscendingComparer(), e.ColumnIndex);
                                        leftSortAsccending = true;
                                    }
                                }

                                if (e.ColumnIndex == 1)
                                {
                                    if (leftSortAsccending)
                                    {
                                        SortFiles(grid, new FTPFileSizeDescendingComparer(), e.ColumnIndex);
                                        leftSortAsccending = false;
                                    }
                                    else
                                    {
                                        SortFiles((DataGridView)sender, new FTPFileSizeAsscendingComparer(), e.ColumnIndex);
                                        leftSortAsccending = true;
                                    }
                                }

                                if (e.ColumnIndex == 4)
                                {

                                }

                                lock (leftSortingInProgressLock)
                                    leftSortingInProgress = false;

                                break;
                            }// end of case

                        case "rightFilesInfo":
                            {
                                lock (rightChangeOfDirectoryInProgressLock)
                                {
                                    if (rightChangeOfDirectoryInProgress)
                                        return;
                                }

                                lock (rightSortingInProgressLock)
                                {
                                    if (rightSortingInProgress)
                                        return;
                                    else
                                        rightSortingInProgress = true;
                                }

                                if (e.ColumnIndex == 0)
                                {
                                    if (rightSortAsccending)
                                    {
                                        SortFiles(grid, new FTPFileNameDescendingComparer(), e.ColumnIndex);
                                        rightSortAsccending = false;
                                    }
                                    else
                                    {
                                        SortFiles((DataGridView)sender, new FTPFileNameAsscendingComparer(), e.ColumnIndex);
                                        rightSortAsccending = true;
                                    }
                                }

                                if (e.ColumnIndex == 1)
                                {
                                    if (rightSortAsccending)
                                    {
                                        SortFiles(grid, new FTPFileSizeDescendingComparer(), e.ColumnIndex);
                                        rightSortAsccending = false;
                                    }
                                    else
                                    {
                                        SortFiles((DataGridView)sender, new FTPFileSizeAsscendingComparer(), e.ColumnIndex);
                                        rightSortAsccending = true;
                                    }
                                }

                                if (e.ColumnIndex == 4)
                                {

                                }

                                lock (rightSortingInProgressLock)
                                    rightSortingInProgress = false;

                                break;
                            }// end of case
                    }// end of switch
                });

            deleg.BeginInvoke(null, null);
        }

    }
}
