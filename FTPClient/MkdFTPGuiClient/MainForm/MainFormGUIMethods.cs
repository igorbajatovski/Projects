using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MkdFtpClient;
using System.Drawing;
using System.IO;

namespace MkdFTPGuiClient
{
    internal enum CancelDelete { Canceled, NotCanceled }
    internal enum DeleteState { Started, Ended, FileDeleted, FileTraverse }
    internal enum DownloadUploadState { Started, Ended, Progress, FileTraverse }
    
    public partial class MainForm : Form
    {
        private delegate void FillDataGridDeleg(DataGridView dataGrid, List<FTPFile> list);
        private void FillDataGrid(DataGridView dataGrid, List<FTPFile> list)
        {
            if (this.InvokeRequired)
            {
                FillDataGridDeleg deleg =
                    new FillDataGridDeleg(FillDataGrid);
                this.Invoke(deleg, dataGrid, list);
            }
            else
            {
                dataGrid.DataSource = list;
            }
        }

        private delegate void OutputTextDeleg(TextBox output, string text);
        private void OutputText(TextBox output, string text)
        {
            if (this.InvokeRequired)
            {
                OutputTextDeleg deleg = new OutputTextDeleg(OutputText);
                this.Invoke(deleg, output, text);
            }
            else
            {
                if (output.Text.Length == 1024)
                    output.Text = string.Empty;
                output.AppendText(text);
            }
        }

        private delegate void UpdateWorkingDirPathDeleg(ToolStripLabel path, string wdp);
        private void UpdateWorkingDirPath(ToolStripLabel path, string wdp)
        {
            if (this.InvokeRequired)
            {
                UpdateWorkingDirPathDeleg deleg = new UpdateWorkingDirPathDeleg(UpdateWorkingDirPath);
                this.Invoke(deleg, path, wdp);
            }
            else
            {
                path.Text = wdp;
            }
        }

        Dictionary<FTPFile, DataGridViewRow> filesBeeingDeleted = new Dictionary<FTPFile, DataGridViewRow>();
        private delegate void UpdateDeleteActionsInfoDeleg(DataGridView grid, FTPEventArgs args, DeleteState state);
        private void UpdateDeleteActionsInfo(DataGridView grid, FTPEventArgs args, DeleteState state)
        {
            if (this.InvokeRequired)
            {
                UpdateDeleteActionsInfoDeleg deleg =
                    new UpdateDeleteActionsInfoDeleg(UpdateDeleteActionsInfo);
                this.Invoke(deleg, grid, args, state);
            }
            else
            {
                if (state == DeleteState.Started)
                {
                    FTPDeleteEventArgs e = (FTPDeleteEventArgs)args;
                    int index = grid.Rows.Add(1);
                    filesBeeingDeleted.Add(e.File, grid.Rows[index]);
                    grid.Rows[index].Cells[0].Value = Properties.Resources.ProgressPic.Clone();
                    ((Image)grid.Rows[index].Cells[0].Value).Progress(0);
                    grid.InvalidateCell(grid.Rows[index].Cells[0]);
                    grid.Rows[index].Cells[1].Value = "Барам ...";
                    grid.Rows[index].Cells[3].Value = "0 сек";
                    grid.Rows[index].Cells[3].Tag = DateTime.Now;
                    grid.Rows[index].Cells[4].Value = "Откажи";
                    grid.Rows[index].Cells[4].Tag = CancelDelete.NotCanceled;
                }
                else if (state == DeleteState.FileDeleted)
                {
                    FTPDeleteFileEventArgs e = (FTPDeleteFileEventArgs) args;
                    DataGridViewRow row = filesBeeingDeleted[e.FileBeeingDeleted];
                    ((Image)row.Cells[0].Value).Progress((int)( (e.DeletedFiles / (double)e.TotalFilesToDelete) * 100));
                    grid.InvalidateCell(row.Cells[0]);
                    // Status
                    row.Cells[1].Value = e.DeletedFile.Name;
                    // Time elapsed
                    DateTime startTime = (DateTime)row.Cells[3].Tag;
                    var elapsedTime = DateTime.Now - startTime;
                    row.Cells[3].Value = elapsedTime.Hours + ":" + elapsedTime.Minutes + ":" + elapsedTime.Seconds;
                    // Cancel Delete
                    CancelDelete cancel = (CancelDelete)row.Cells[4].Tag;
                    if (cancel == CancelDelete.Canceled)
                        e.CancelDelete = true;
                }
                else if (state == DeleteState.Ended)
                {
                    FTPDeleteEventArgs e = (FTPDeleteEventArgs)args;
                    grid.Rows.Remove(filesBeeingDeleted[e.File]);
                    filesBeeingDeleted.Remove(e.File);
                }
                else if (state == DeleteState.FileTraverse)
                {
                    FTPDeleteFileTraverseEventArgs e = (FTPDeleteFileTraverseEventArgs)args;
                    DataGridViewRow row = filesBeeingDeleted[e.FileBeeingDeleted];
                    // Time elapsed
                    DateTime startTime = (DateTime)row.Cells[3].Tag;
                    var elapsedTime = DateTime.Now - startTime;
                    row.Cells[3].Value = elapsedTime.Hours + ":" + elapsedTime.Minutes + ":" + elapsedTime.Seconds;
                    //Cancel Delete
                    CancelDelete cancel = (CancelDelete)row.Cells[4].Tag;
                    if (cancel == CancelDelete.Canceled)
                        e.CancelDelete = true;
                }
            }
        }

        private Dictionary<FTPFile, DataGridViewRow> filesBeingDownloaded = new Dictionary<FTPFile, DataGridViewRow>();
        private Dictionary<FileSystemInfo, DataGridViewRow> filesBeingUploaded = new Dictionary<FileSystemInfo, DataGridViewRow>();
        private delegate void UpdateDownloadUploadedActionsInfoDeleg(DataGridView grid, FTPEventArgs args, DownloadUploadState state);
        private void UpdateDownloadUploadedActionsInfo(DataGridView grid, FTPEventArgs args, DownloadUploadState state)
        {
            if (this.InvokeRequired)
            {
                UpdateDownloadUploadedActionsInfoDeleg deleg =
                    new UpdateDownloadUploadedActionsInfoDeleg(UpdateDownloadUploadedActionsInfo);
                this.Invoke(deleg, grid, args, state);
            }
            else
            {
                if (state == DownloadUploadState.Started)
                {
                    if (args is FTPDownloadEventArgs)
                    {
                        FTPDownloadEventArgs dea = (FTPDownloadEventArgs)args;
                        int index = grid.Rows.Add(1);
                        filesBeingDownloaded.Add(dea.File, grid.Rows[index]);
                        grid.Rows[index].Cells[0].Value = Properties.Resources.ProgressPic.Clone();
                        // Progress
                        ((Image)grid.Rows[index].Cells[0].Value).Progress(0);
                        grid.InvalidateCell(grid.Rows[index].Cells[0]);
                        // Status
                        grid.Rows[index].Cells[1].Value = "Симнувам " + dea.File.Name;
                        // Speed
                        grid.Rows[index].Cells[2].Value = "0 kb/s";
                        // Elapsed time
                        grid.Rows[index].Cells[3].Value = "0 сек";
                        grid.Rows[index].Cells[3].Tag = DateTime.Now;
                        // Cancel
                        grid.Rows[index].Cells[4].Value = "Откажи";
                        grid.Rows[index].Cells[4].Tag = CancelDelete.NotCanceled;
                    }
                    if (args is FTPUploadEventArgs)
                    {
                        FTPUploadEventArgs uea = (FTPUploadEventArgs)args;
                        int index = grid.Rows.Add(1);
                        filesBeingUploaded.Add(uea.File, grid.Rows[index]);
                        grid.Rows[index].Cells[0].Value = Properties.Resources.ProgressPic.Clone();
                        // Progress
                        ((Image)grid.Rows[index].Cells[0].Value).Progress(0);
                        grid.InvalidateCell(grid.Rows[index].Cells[0]);
                        // Status
                        grid.Rows[index].Cells[1].Value = "Качувам " + uea.File.Name;
                        // Speed
                        grid.Rows[index].Cells[2].Value = "0 kb/s";
                        // Elapsed time
                        grid.Rows[index].Cells[3].Value = "0 сек";
                        grid.Rows[index].Cells[3].Tag = DateTime.Now;
                        // Cancel
                        grid.Rows[index].Cells[4].Value = "Откажи";
                        grid.Rows[index].Cells[4].Tag = CancelDelete.NotCanceled;
                    }
                }
                else if (state == DownloadUploadState.Ended)
                {
                    if (args is FTPDownloadEventArgs)
                    {
                        FTPDownloadEventArgs e = (FTPDownloadEventArgs)args;
                        grid.Rows.Remove(filesBeingDownloaded[e.File]);
                        filesBeingDownloaded.Remove(e.File);
                    }

                    if (args is FTPUploadEventArgs)
                    {
                        FTPUploadEventArgs e = (FTPUploadEventArgs)args;
                        grid.Rows.Remove(filesBeingUploaded[e.File]);
                        filesBeingUploaded.Remove(e.File);
                    }
                }
                else if (state == DownloadUploadState.Progress)
                {
                    if (args is FTPDownloadProgressEventArgs)
                    {
                        FTPDownloadProgressEventArgs e = (FTPDownloadProgressEventArgs)args;
                        DataGridViewRow row = filesBeingDownloaded[e.File];
                        // Update Progress
                        ((Image)row.Cells[0].Value).Progress((int)((e.DownloadedBytes / (double)e.TotalToDownloadBytes) * 100));
                        grid.InvalidateCell(row.Cells[0]);
                        // Speed
                        string speed = (e.BytesPerSecond / 1024.0d).ToString();
                        int index = -1;
                        if((index = speed.IndexOf('.')) != -1)
                            row.Cells[2].Value = speed.Substring(0, index) + " kb/s";
                        else
                            row.Cells[2].Value = speed + " kb/s";
                        // Time elapsed
                        DateTime startTime = (DateTime)row.Cells[3].Tag;
                        var elapsedTime = DateTime.Now - startTime;
                        row.Cells[3].Value = elapsedTime.Hours + ":" + elapsedTime.Minutes + ":" + elapsedTime.Seconds;
                        //Cancel Delete
                        CancelDelete cancel = (CancelDelete)row.Cells[4].Tag;
                        if (cancel == CancelDelete.Canceled)
                            e.CancelDownload = true;
                    }

                    if (args is FTPUploadProgressEventArgs)
                    {
                        FTPUploadProgressEventArgs e = (FTPUploadProgressEventArgs)args;
                        DataGridViewRow row = filesBeingUploaded[e.File];
                        // Update Progress
                        ((Image)row.Cells[0].Value).Progress((int)((e.UploadedBytes / (double)e.TotalToUploadedBytes) * 100));
                        grid.InvalidateCell(row.Cells[0]);
                        // Speed
                        string speed = (e.BytesPerSecond / 1024.0d).ToString();
                        int index = -1;
                        if ((index = speed.IndexOf('.')) != -1)
                            row.Cells[2].Value = speed.Substring(0, index) + " kb/s";
                        else
                            row.Cells[2].Value = speed + " kb/s";
                        // Time elapsed
                        DateTime startTime = (DateTime)row.Cells[3].Tag;
                        var elapsedTime = DateTime.Now - startTime;
                        row.Cells[3].Value = elapsedTime.Hours + ":" + elapsedTime.Minutes + ":" + elapsedTime.Seconds;
                        //Cancel Delete
                        CancelDelete cancel = (CancelDelete)row.Cells[4].Tag;
                        if (cancel == CancelDelete.Canceled)
                            e.CancelUpload = true;
                    }
                }
                else if (state == DownloadUploadState.FileTraverse)
                {
                    if (args is FTPDownloadFileTraverseEventArgs)
                    {
                        FTPDownloadFileTraverseEventArgs e = (FTPDownloadFileTraverseEventArgs)args;
                        DataGridViewRow row = filesBeingDownloaded[e.File];
                        // Time elapsed
                        DateTime startTime = (DateTime)row.Cells[3].Tag;
                        var elapsedTime = DateTime.Now - startTime;
                        row.Cells[3].Value = elapsedTime.Hours + ":" + elapsedTime.Minutes + ":" + elapsedTime.Seconds;
                        //Cancel Delete
                        CancelDelete cancel = (CancelDelete)row.Cells[4].Tag;
                        if (cancel == CancelDelete.Canceled)
                            e.CancelDownload = true;
                    }

                    if (args is FTPUploadFileTraverseEventArgs)
                    {
                        FTPUploadFileTraverseEventArgs e = (FTPUploadFileTraverseEventArgs)args;
                        DataGridViewRow row = filesBeingUploaded[e.File];
                        // Time elapsed
                        DateTime startTime = (DateTime)row.Cells[3].Tag;
                        var elapsedTime = DateTime.Now - startTime;
                        row.Cells[3].Value = elapsedTime.Hours + ":" + elapsedTime.Minutes + ":" + elapsedTime.Seconds;
                        //Cancel Delete
                        CancelDelete cancel = (CancelDelete)row.Cells[4].Tag;
                        if (cancel == CancelDelete.Canceled)
                            e.CancelUpload = true;
                    }
                }
            }
        }

        private delegate void SortFilesDeleg(DataGridView dataGrid, IComparer<FTPFile> comparer, int columnIndex);
        private void SortFiles(DataGridView dataGrid, IComparer<FTPFile> comparer, int columnIndex)
        {
            if (this.InvokeRequired)
            {
                SortFilesDeleg deleg = new SortFilesDeleg(SortFiles);
                this.Invoke(deleg, dataGrid, comparer, columnIndex);
            }
            else
            {
                List<FTPFile> files = (List<FTPFile>)dataGrid.DataSource;
                if (files != null && files.Count > 0)
                {
                    dataGrid.DataSource = null;
                    FTPFile backDir = files[0];
                    files.RemoveAt(0);
                    files.Sort(comparer);
                    files.Insert(0, backDir);
                    dataGrid.DataSource = files;
                    if(comparer is IAsscending)
                        dataGrid.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                    if(comparer is IDescending)
                        dataGrid.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                }
            }
        }

    }
}
