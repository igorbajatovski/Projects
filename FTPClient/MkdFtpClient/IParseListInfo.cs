using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public interface IParseListInfo
    {
        string getFileName(string fileInfo);
        string getFileSize(string fileInfo);
        FTPFileType getFileType(string fileInfo);
        string getFilePermisssions(string fileInfo);
        string getFileOwner(string fileInfo);
        string getFileGroup(string fileInfo);
        string getFileDateModified(string fileInfo);
    }
}
