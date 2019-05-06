using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkdFtpClient
{
    public class WindowsParseListInfo : IParseListInfo
    {
        string IParseListInfo.getFileName(string fileInfo)
        {
            string[] splits = fileInfo.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] splits1 = fileInfo.Split(new string[] { " " }, StringSplitOptions.None);
            int start = 0;
            foreach (string s in splits1)
            {
                if (s != splits[3])
                    start += s.Length + 1;
                else
                    break;
            }
            return fileInfo.Substring(start);
        }

        string IParseListInfo.getFileSize(string fileInfo)
        {
            string[] splits = fileInfo.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string size = splits[2] != "<DIR>" ? splits[2] : "0";
            Convert.ToInt64(size);
            return size;
        }

        FTPFileType IParseListInfo.getFileType(string fileInfo)
        {
            string[] splits = fileInfo.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            FTPFileType type = FTPFileType.File;
            if (splits[2] == "<DIR>")
                type = FTPFileType.Directory;
            else
            {
                try
                {
                    Convert.ToInt64(splits[2]);
                    type = FTPFileType.File;
                }
                catch(FormatException){
                    throw new FormatException("File list format exception");
                }
            }
            return type;
        }

        string IParseListInfo.getFilePermisssions(string fileInfo)
        {
            return "";
        }

        string IParseListInfo.getFileOwner(string fileInfo)
        {
            return "";
        }

        string IParseListInfo.getFileGroup(string fileInfo)
        {
            return "";
        }

        string IParseListInfo.getFileDateModified(string fileInfo)
        {
            string[] splits = fileInfo.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return splits[0] + " " + splits[1];
        }
    }
}
