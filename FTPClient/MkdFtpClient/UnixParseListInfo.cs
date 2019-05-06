using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MkdFtpClient
{
    public class UnixParseListInfo : IParseListInfo
    {
        string IParseListInfo.getFileName(string fileInfo)
        {
            string[] splits = fileInfo.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            string[] splits1 = fileInfo.Split(new string[] {" "}, StringSplitOptions.None);
            int start = 0;
            int count = 0;
            for (int i = 0; i < splits1.Length; ++i)
            {   
                if (count == 8)
                    break;
                else if (splits1[i] != "")
                {
                    ++count;
                    start += splits1[i].Length + 1;
                }
                else if(splits1[i] == "")
                    start += splits1[i].Length + 1;
            }
            return fileInfo.Substring(start);
        }

        string IParseListInfo.getFileSize(string fileInfo)
        {
            string[] splits = fileInfo.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Convert.ToInt64(splits[4]);
            return splits[4];
        }

        FTPFileType IParseListInfo.getFileType(string fileInfo)
        {
            string[] splits = fileInfo.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            FTPFileType type = FTPFileType.File;
            if (splits[0].StartsWith("d"))
                type = FTPFileType.Directory;
            else if (splits[0].StartsWith("-"))
                type = FTPFileType.File;
            else
                throw new FormatException("File list format exception");
            return type;
        }

        string IParseListInfo.getFilePermisssions(string fileInfo)
        {
            string[] splits = fileInfo.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Regex re = new Regex("[-d]{1}[-rwx]{3}[-rwx]{3}[-rwx]{3}");
            MatchCollection m = re.Matches(splits[0]);
            if (m != null && m.Count == 1)
                return splits[0];
            throw new FormatException("File list format exception");
        }

        string IParseListInfo.getFileOwner(string fileInfo)
        {
            string[] splits = fileInfo.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return splits[2];
        }

        string IParseListInfo.getFileGroup(string fileInfo)
        {
            string[] splits = fileInfo.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return splits[3];
        }

        string IParseListInfo.getFileDateModified(string fileInfo)
        {
            string[] splits = fileInfo.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return splits[5] + " " + splits[6] + " " + splits[7];
        }
    }
}
