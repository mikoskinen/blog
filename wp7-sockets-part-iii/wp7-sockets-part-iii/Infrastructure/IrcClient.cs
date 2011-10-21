using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace wp7_sockets_part_iii.Infrastructure
{
    public class IrcClient
    {
        private Socket connection;
        private string server;
        private int serverPort;
        private const int bufferSize = 2048;

        public event EventHandler<CreateConnectionAsyncArgs> CreateConnectionCompleted;
        public event EventHandler<IrcMessageReceivedFromServer> IrcMessageReceivedFromServer;

        public void CreateConnection(string serverAddress, int port)
        {
            this.connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.server = serverAddress;
            this.serverPort = port;

            var connectionOperation = new SocketAsyncEventArgs { RemoteEndPoint = new DnsEndPoint(this.server, this.serverPort) };
            connectionOperation.Completed += OnConnectionToServerCompleted;

            this.connection.ConnectAsync(connectionOperation);
        }

        public void SendToServer(string message)
        {
            var asyncEvent = new SocketAsyncEventArgs { RemoteEndPoint = new DnsEndPoint(server, serverPort) };

            var buffer = Encoding.UTF8.GetBytes(message + Environment.NewLine);
            asyncEvent.SetBuffer(buffer, 0, buffer.Length);

            connection.SendAsync(asyncEvent);
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

            ReceiveMessage();
        }

        private void ReceiveMessage()
        {
            var responseListener = new SocketAsyncEventArgs();
            responseListener.Completed += OnMessageReceivedFromServer;

            var responseBuffer = new byte[bufferSize];
            responseListener.SetBuffer(responseBuffer, 0, bufferSize);

            connection.ReceiveAsync(responseListener);
        }

        private string trailingMessage;
        private void OnMessageReceivedFromServer(object sender, SocketAsyncEventArgs e)
        {
            // Convert the received message into a string
            var message = Encoding.UTF8.GetString(e.Buffer, 0, e.BytesTransferred);

            var bufferWasPreviouslyFull = !string.IsNullOrWhiteSpace(trailingMessage);
            if (bufferWasPreviouslyFull)
            {
                message = trailingMessage + message;
                trailingMessage = null;
            }

            var isConnectionLost = string.IsNullOrWhiteSpace(message);
            if (isConnectionLost)
            {
                // We lost the connection for some reason
                // Handle the situation
                return;
            }

            // Convert the received string into a string array
            var lines = new List<string>(message.Split("\n\r".ToCharArray(), StringSplitOptions.None));

            var lastLine = lines.LastOrDefault();
            var isBufferFull = !string.IsNullOrWhiteSpace(lastLine);
            if (isBufferFull)
            {
                trailingMessage = lastLine;
                lines.Remove(lastLine);
            }

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                ProcessIncomingMessage(line);
            }

            // Start listening for the next message
            ReceiveMessage();
        }

        private void ProcessIncomingMessage(string ircMessage)
        {
            Debug.WriteLine(ircMessage);

            // Future hook for handling the message in somewhere else.
            // It's most probably wise to put the parsing logic in some other class.
            if (IrcMessageReceivedFromServer != null)
                IrcMessageReceivedFromServer(this, new IrcMessageReceivedFromServer(ircMessage));
        }
    }
}
