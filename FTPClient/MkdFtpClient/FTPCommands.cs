using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;

namespace MkdFtpClient
{
    public enum Type { Ascii, Image};

    public enum Structure { File };

    public enum Mode { Stream }
    
    public static class FTPCommands
    {
        private static string AddressPortToString(IPEndPoint address_port)
        {
            string address = address_port.Address.ToString().Replace('.', ',');
            int port1 = address_port.Port / 256;
            int port2 = address_port.Port - (port1 * 256);
            return address + "," + port1 + "," + port2;
        }

        private static IPEndPoint StringToAddressPort(string reply)
        {
            try
            {
                Regex reg = new Regex(@"[0-9]{1,3},[0-9]{1,3},[0-9]{1,3},[0-9]{1,3},[0-9]{1,3},[0-9]{1,3}");
                MatchCollection mc = reg.Matches(reply);
                if (mc != null && mc.Count == 1)
                {
                    string[] s = mc[0].Value.Split(',');
                    string address = s[0] + "." + s[1] + "." + s[2] + "." + s[3];
                    int port = Convert.ToInt32(s[4]) * 256 + Convert.ToInt32(s[5]);
                    return new IPEndPoint(IPAddress.Parse(address), port);
                }
                return new IPEndPoint(null, 0);
            }
            catch (Exception)
            {
                return new IPEndPoint(null, 0);
            }
        }
        
        public static FTPReply readReply(FTPConnection ftpConnection)
        {
            string reply = string.Empty;
            string code = null;
            byte[] buffer = new byte[1];
            byte[] bReply = null;

            while (true)
            {
                try
                {
                    int count = ftpConnection.Receive(buffer, buffer.Length, System.Net.Sockets.SocketFlags.None);
                    if (count == 1)
                    {
                        bReply = bReply.Insert(buffer);
                        reply = Encoding.UTF8.GetString(bReply, 0, bReply.Length);
                        if (reply.EndsWith("\r\n"))
                        {
                            if (code == null)
                            {
                                code = reply.Substring(0, 3);
                                int result;
                                if (!Int32.TryParse(code, out result))
                                    throw new FTPReplyMessageException("FTP reply does not begin with numeric code");
                                if ( reply.IndexOf(code + " ") == 0 )
                                    break;
                                if ( !(reply.IndexOf(code + "-") == 0) )
                                    throw new FTPReplyMessageException("FTP multiline reply has wrong format");

                                bReply = null;
                                continue;
                            }
                            if (reply.IndexOf(code + " ") == 0)
                                break;
                            bReply = null;
                        }
                    }
                    else if (count == 0)
                    {
                        throw new FTPConnectionClosedException("The FTP server closed the connection");
                    }
                }
                catch (SocketException ex)
                {
                    //An established connection was aborted by 
                    //the software in your host computer, possibly 
                    //due to a data transmission time-out or protocol error.
                    if (ex.ErrorCode == 10053)
                        throw new FTPConnectionClosedException(ex.Message, ex);
                    
                    throw new FTPReplyException(ex.Message, ex);
                }
                catch (ObjectDisposedException ex)
                {
                    throw new FTPConnectionClosedException(ex.Message, ex);
                }
                catch (System.Security.SecurityException ex)
                {
                    throw new FTPSecurityException(ex.Message, ex);
                }
            }

            return new FTPReply(reply, code);
        }

        public static FTPReply sendCommand(FTPConnection ftpConnection, string command, params string[] arguments)
        {
            if (command != null && command != "" && arguments != null)
            {
                if (ftpConnection != null && ftpConnection.Connected)
                {
                    try
                    {   
                        command = command.ToUpper();
                        string args = string.Empty;
                        for (int i = 0; i < arguments.Length; ++i)
                        {
                            if (i == (arguments.Length - 1))
                                args += arguments[i];
                            else
                                args += arguments[i] + " ";
                        }

                        if (arguments.Length > 0)
                            ftpConnection.Send(Encoding.UTF8.GetBytes(command + " " + args + "\r\n"));
                        else
                            ftpConnection.Send(Encoding.UTF8.GetBytes(command + "\r\n"));
                        FTPReply r = FTPCommands.readReply(ftpConnection);
                        r = new FTPReply(command, arguments, r.Reply, r.FtpCode);
                        ICommandNotify notify = (ICommandNotify)ftpConnection;
                        notify.OnCommandExecuted(r);
                        return r;
                    }
                    catch (SocketException ex)
                    {
                        //An established connection was aborted by 
                        //the software in your host computer, possibly 
                        //due to a data transmission time-out or protocol error.
                        if (ex.ErrorCode == 10053)
                            throw new FTPConnectionClosedException(ex.Message, ex);

                        throw new FTPCommandException(ex.Message, ex);
                    }
                    catch (FTPException)
                    {
                        throw;
                    }
                }// end of if (ftpConnection.ControlConnection.Connected)
                else
                {
                    throw new FTPConnectionClosedException("The connection to the FTP server is closed");
                }
            }// end of if (command != null && command != "" && arguments != null)
            else
            {
                throw new FTPNoCommandSpecifiedException("No ftp command specified or ftp command arguments are null");
            }
        }

        public static List<FTPFile> getListInfo(Socket dataConnection, IParseListInfo[] parse, FTPFile parentDir)
        {
            string reply = string.Empty;
            byte[] buffer = new byte[1024];
            byte[] bReply = null;

            while (true)
            {
                try
                {
                    int count = dataConnection.Receive(buffer, buffer.Length, System.Net.Sockets.SocketFlags.None);
                    if (count >= 1)
                    {
                        bReply = bReply.Insert(buffer, 0, count);
                    }
                    else if (count == 0)
                    {
                        if (bReply != null)
                            reply = Encoding.UTF8.GetString(bReply, 0, bReply.Length);
                        break;
                    }
                }
                catch (SocketException ex)
                {
                    throw new FTPListException(ex.Message, ex);
                }
                catch (ObjectDisposedException ex)
                {
                    throw new FTPConnectionClosedException(ex.Message, ex);
                }
                catch (System.Security.SecurityException ex)
                {
                    throw new FTPSecurityException(ex.Message, ex);
                }
            }

            List<FTPFile> ftpFiles = new List<FTPFile>();
            if (parentDir.Type != FTPFileType.Directory)
                return ftpFiles;
            string[] splits = reply.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parse.Length; ++i)
            {
                try
                {
                    foreach (var r in splits)
                    {
                        FTPFile ftpFile = new FTPFile(parentDir.AbsoluthFileName + "/" + parse[i].getFileName(r),
                                                      parse[i].getFileType(r),
                                                      parse[i].getFileSize(r),
                                                      parse[i].getFileDateModified(r),
                                                      parse[i].getFilePermisssions(r),
                                                      parse[i].getFileOwner(r) != "" && parse[i].getFileGroup(r) != "" ?
                                                        parse[i].getFileOwner(r) + "/" + parse[i].getFileGroup(r) : ""
                                                    );
                        ftpFiles.Add(ftpFile);
                    }
                    break;
                }
                catch (Exception) { ftpFiles.Clear(); }
            }

            return ftpFiles;
        }

        public static string[] getNListInfo(Socket dataConnection)
        {
            string reply = string.Empty;
            byte[] buffer = new byte[1024];
            byte[] bReply = null;

            while (true)
            {
                try
                {
                    int count = dataConnection.Receive(buffer, buffer.Length, System.Net.Sockets.SocketFlags.None);
                    if (count > 0)
                        bReply = bReply.Insert(buffer, 0, count);
                    else if (count == 0)
                    {
                        reply = Encoding.UTF8.GetString(bReply, 0, bReply.Length);
                        break;
                    }
                }
                catch (SocketException ex)
                {
                    throw new FTPListException(ex.Message, ex);
                }
                catch (ObjectDisposedException ex)
                {
                    throw new FTPConnectionClosedException(ex.Message, ex);
                }
                catch (System.Security.SecurityException ex)
                {
                    throw new FTPSecurityException(ex.Message, ex);
                }
            }

            List<string> ftpFiles = new List<string>();
            string[] splits = reply.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var fileName in ftpFiles)
                ftpFiles.Add(fileName);

            return ftpFiles.ToArray();
        }

        public static Socket getDataConnection(FTPReply ftpReply)
        {
            Socket dataConnection = null;
            if (ftpReply.Command == "PORT")
            {
                Socket ftpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ftpServer.Bind(StringToAddressPort(ftpReply.Arguments[0]));
                ftpServer.Listen(0);
                dataConnection = ftpServer.Accept();
            }
            else if (ftpReply.Command == "PASV")
            {
                dataConnection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                dataConnection.Connect(StringToAddressPort(ftpReply.Reply));
            }
            else
            {
                throw new FTPException("First execute the PORT or PASV command");
            }
            return dataConnection;
        }

        public static FTPFile getCurrentDirectory(string reply)
        {
            Regex reg = new Regex("(/{1}[^\"]*)+");
            MatchCollection mc = reg.Matches(reply);
            if (mc != null && mc.Count == 1)
            {
                string dir = mc[0].ToString();
                return new FTPFile(dir, FTPFileType.Directory);
            }
            return null;
        }

        public static FTPReply USER(FTPConnection ftpConnection, string user)
        {
            return sendCommand(ftpConnection, "USER", user);
        }

        public static FTPReply PASS(FTPConnection ftpConnection, string password)
        {
            return sendCommand(ftpConnection, "PASS", password);
        }

        public static FTPReply ACCT(FTPConnection ftpConnection, string account)
        {
            return sendCommand(ftpConnection, "ACCT", account);
        }

        public static FTPReply CWD(FTPConnection ftpConnection, string workingDirectory)
        {
            return sendCommand(ftpConnection, "CWD", workingDirectory);
        }

        public static FTPReply CDUP(FTPConnection ftpConnection)
        {
            return sendCommand(ftpConnection, "CDUP", "");
        }

        public static FTPReply SMNT(FTPConnection ftpConnection, string filePath)
        {
            return sendCommand(ftpConnection, "SMNT", filePath);
        }

        public static FTPReply REIN(FTPConnection ftpConnection)
        {
            return sendCommand(ftpConnection, "REIN");
        }

        public static FTPReply QUIT(FTPConnection ftpConnection)
        {
            return sendCommand(ftpConnection, "QUIT");
        }

        public static FTPReply PORT(FTPConnection ftpConnection, System.Net.IPEndPoint ip_port)
        {
            return sendCommand(ftpConnection, "PORT", AddressPortToString(ip_port));
        }

        public static FTPReply PASV(FTPConnection ftpConnection)
        {
            return sendCommand(ftpConnection, "PASV", "");
        }

        public static FTPReply TYPE(FTPConnection ftpConnection, Type type)
        {
            return sendCommand(ftpConnection, "TYPE", type.ToString().First().ToString());
        }

        public static FTPReply STRU(FTPConnection ftpConnection, Structure stru)
        {
            return sendCommand(ftpConnection, "STRU", stru.ToString().First().ToString());
        }

        public static FTPReply MODE(FTPConnection ftpConnection, Mode mode)
        {
            return sendCommand(ftpConnection, "MODE", mode.ToString().First().ToString());
        }

        public static FTPReply RETR(FTPConnection ftpConnection, string file)
        {
            return sendCommand(ftpConnection, "RETR", file);
        }

        public static FTPReply STOR(FTPConnection ftpConnection, string file)
        {
            return sendCommand(ftpConnection, "STOR", file);
        }

        public static FTPReply STOU(FTPConnection ftpConnection)
        {
            return sendCommand(ftpConnection, "STOU", "");
        }

        public static FTPReply APPE(FTPConnection ftpConnection, string file)
        {
            return sendCommand(ftpConnection, "APPE", file);
        }

        public static FTPReply RNFR(FTPConnection ftpConnection, string file)
        {
            return sendCommand(ftpConnection, "RNFR", file);
        }

        public static FTPReply RNTO(FTPConnection ftpConnection, string file)
        {
            return sendCommand(ftpConnection, "RNTO", file);
        }

        public static FTPReply ABOR(FTPConnection ftpConnection)
        {
            return sendCommand(ftpConnection, "ABOR");
        }

        public static FTPReply DELE(FTPConnection ftpConnection, string file)
        {
            return sendCommand(ftpConnection, "DELE", file);
        }

        public static FTPReply RMD(FTPConnection ftpConnection, string folder)
        {
            return sendCommand(ftpConnection, "RMD", folder);
        }

        public static FTPReply MKD(FTPConnection ftpConnection, string folder)
        {
            return sendCommand(ftpConnection, "MKD", folder);
        }

        public static FTPReply PWD(FTPConnection ftpConnection)
        {
            return sendCommand(ftpConnection, "PWD");
        }

        public static FTPReply LIST(FTPConnection ftpConnection, string file)
        {
            return sendCommand(ftpConnection, "LIST", file);
        }

        public static FTPReply NLST(FTPConnection ftpConnection, string file)
        {
            return sendCommand(ftpConnection, "NLST", file);
        }

        public static FTPReply SYST(FTPConnection ftpConnection)
        {
            return sendCommand(ftpConnection, "SYST");
        }

        public static FTPReply STAT(FTPConnection ftpConnection, string argument)
        {
            return sendCommand(ftpConnection, "STAT", argument);
        }

        public static FTPReply HELP(FTPConnection ftpConnection, string argument)
        {
            return sendCommand(ftpConnection, "HELP", argument);
        }

        public static FTPReply NOOP(FTPConnection ftpConnection)
        {
            return sendCommand(ftpConnection, "NOOP");
        }
    }
}
