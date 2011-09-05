using System;
using System.Net;
using System.Net.Sockets;

namespace wp7_sockets_part_i
{
    public class IrcClient
    {
        private Socket connection;
        private string server;
        private int serverPort;

        public event EventHandler<CreateConnectionAsyncArgs> CreateConnectionCompleted;

        public void CreateConnection(string serverAddress, int port)
        {
            this.connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.server = serverAddress;
            this.serverPort = port;

            var connectionOperation = new SocketAsyncEventArgs { RemoteEndPoint = new DnsEndPoint(this.server, this.serverPort) };
            connectionOperation.Completed += OnConnectionToServerCompleted;

            this.connection.ConnectAsync(connectionOperation);
        }

        private void OnConnectionToServerCompleted(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError != SocketError.Success)
            {
                if (CreateConnectionCompleted != null)
                    CreateConnectionCompleted(this, new CreateConnectionAsyncArgs(false));

                return;
            }
        
            if (CreateConnectionCompleted != null)
                CreateConnectionCompleted(this, new CreateConnectionAsyncArgs(true));
        }

    }

    public class CreateConnectionAsyncArgs : EventArgs
    {
        public bool ConnectionOk { get; private set; }

        public CreateConnectionAsyncArgs(bool connectionOk)
        {
            ConnectionOk = connectionOk;
        }
    }
}
