using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace MkdFtpClient
{
    public class FTPConnection : Socket, ICommandNotify
    {
        public event FTPEventHandler<FTPReplyEventArgs> CommandExecuted = null;

        void ICommandNotify.OnCommandExecuted(FTPReply reply)
        {
            if (CommandExecuted != null)
                CommandExecuted(this, new FTPReplyEventArgs(reply));
        }

        public FTPConnection():
            base(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        { }

        public void Connect(IPEndPoint ftpServerHost)
        {
            try
            {
                if (ftpServerHost != null)
                {
                    if (!this.Connected)
                        base.Connect(ftpServerHost);
                }
            }
            catch (ArgumentNullException ex) { throw new FTPException(ex.Message, ex); }
            catch (SocketException ex) { throw new FTPException(ex.Message, ex); }
            catch (System.Security.SecurityException ex) { throw new FTPException(ex.Message, ex); }
            catch (InvalidOperationException ex) { throw new FTPException(ex.Message, ex); }
        }

        public void Disconnect()
        {
            try
            {
                if (this.Connected)
                {
                    this.Shutdown(SocketShutdown.Both);
                    base.Disconnect(true);
                }
            }
            catch (SocketException ex) { throw new FTPException(ex.Message, ex); }
        }
    }
}
