using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Renci.SshNet;

namespace RemoteSFTP
{
    public class SSH
    {
        ConnectionInfo connectionInfo = new ConnectionInfo(new MainWindow().HostSftp.Text = "82.146.57.151", new MainWindow().UserSftp.Text ="1375-20",
                                            new PasswordAuthenticationMethod(new MainWindow().UserSftp.Text ="1375-20", new MainWindow().PassSftp.Text = "Admin123*"),
                                            new PrivateKeyAuthenticationMethod("rsa.key"));
        SftpClient sshClient;
        public SftpClient getConnection()
        {
            return sshClient;
        }
        public void openConnection()
        {
            sshClient = new SftpClient(connectionInfo);
            if (!sshClient.IsConnected)
            {

                sshClient.Connect();
            }
        }
        public void closeConnection()
        {
            sshClient = new SftpClient(connectionInfo);
            if (sshClient.IsConnected)
            {

                sshClient.Disconnect();
            }
            
        }
    }
}
