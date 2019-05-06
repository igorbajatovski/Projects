using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MkdFtpClient
{
    public enum FTPFileType { File, Directory, None }

    public class FTPFile : ICloneable
    {
        private readonly string absoluthFileName = string.Empty;
        public string AbsoluthFileName
        {
            get { return absoluthFileName; }
        }

        private readonly string parentDir = string.Empty;
        public FTPFile ParentDir
        {
            get 
            {
                if (this.parentDir == "")
                    return null;
                return new FTPFile(this.parentDir, FTPFileType.Directory); 
            }
        }

        private readonly string name = string.Empty;
        public string Name
        {
            get { return name; }
        }

        private readonly string size = "0";
        public string Size
        {
            get { return size; }
        }

        private readonly FTPFileType type = FTPFileType.File;
        public FTPFileType Type
        {
            get { return type; }
        }

        private readonly string lastModified = string.Empty;
        public string LastModified
        {
            get { return lastModified; }
        }

        private readonly string permissions = string.Empty;
        public string Permissions
        {
            get { return permissions; }
        }

        private readonly string ownerGroup = string.Empty;
        public string OwnerGroup
        {
            get { return ownerGroup; }
        }

        public override bool Equals(object obj)
        {
            FTPFile rh = (FTPFile)obj;
            if (this.type == rh.type &&
               this.absoluthFileName == rh.absoluthFileName)
                return true;
            return false;
        }

        public static FTPFile ROOT = new FTPFile("/", FTPFileType.Directory);
        public static FTPFile CURRENT_DIR = new FTPFile(".", FTPFileType.Directory);
        public static FTPFile BACK_DIR = new FTPFile("..", FTPFileType.Directory);

        public FTPFile(string fileName, FTPFileType fileType = FTPFileType.File, string fileSize = "", 
                       string _lastModified = "", string _permissions = "", string owner_group = "")
        {
            if (fileName == null)
                throw new FormatException("File name is null");

            this.size = fileSize;
            this.type = fileType;
            this.lastModified = _lastModified;
            this.permissions = _permissions;
            this.ownerGroup = owner_group;

            if (fileName == "" || fileName == ".")
            {
                this.name = ".";
                this.parentDir = "";
                this.absoluthFileName = this.name;
                return;
            }

            if (fileName == "..")
            {
                this.name = "..";
                this.parentDir = "";
                this.absoluthFileName = this.name;
                return;
            }

            Regex regEx = new Regex("(/[^/]*)+");
            MatchCollection mc = regEx.Matches(fileName);
            if (mc == null || mc.Count != 1)
                throw new FormatException("Wrong file format");

            fileName = fileName.Replace("//", "/");
            if (fileName != "/")
            {
                if (fileName.EndsWith("/"))
                    fileName = fileName.Substring(0, fileName.Length - 1);
                this.name = fileName.Substring(fileName.LastIndexOf("/") + 1, fileName.Length - (fileName.LastIndexOf("/") + 1));
                this.parentDir = fileName.Substring(0, fileName.LastIndexOf("/"));
                if (this.parentDir == "")
                {
                    this.parentDir = "/";
                    this.absoluthFileName = this.parentDir + this.name;
                }
                else
                    this.absoluthFileName = this.parentDir + "/" + this.name;
            }
            else if(fileName == "/")
            {
                this.name = fileName;
                this.parentDir = "";
                this.absoluthFileName = this.name;
            }
        }

        public object Clone()
        {
            return new FTPFile((string)this.absoluthFileName.Clone(), this.type, (string)this.size.Clone(),
                               (string)this.lastModified.Clone(), (string)this.permissions.Clone(), (string)this.ownerGroup.Clone());
        }
    }
}
