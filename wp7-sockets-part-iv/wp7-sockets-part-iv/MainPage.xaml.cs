using System;
using System.Windows;
using Microsoft.Phone.Controls;
using wp7_sockets_part_iii.Infrastructure;

namespace wp7_sockets_part_iii
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly IrcClient client;
        private readonly MessageObserver observer;

        public MainPage()
        {
            InitializeComponent();

            this.client = new IrcClient();
            this.client.CreateConnectionCompleted += OnCreateConnectionCompleted;

            this.observer = new MessageObserver(client);
        }

        private void HandleCreateConnectionClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var serverAddress = Server.Text;
                var port = int.Parse(Port.Text);

                this.client.CreateConnection(serverAddress, port);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid server or port.");
            }
        }
        
        private void OnCreateConnectionCompleted(object sender, CreateConnectionAsyncArgs e)
        {
            if (!e.ConnectionOk)
            {
                UpdateStatus("Connection failed");
                return;
            }

            UpdateStatus("Connection OK");

            SendCredentialsToServer();
        }

        private void SendCredentialsToServer()
        {
            var myNickName = "myNick" + DateTime.Now.Millisecond;
            client.SendToServer("NICK " + myNickName);

            var userMessage = string.Format("USER {0} 0 * :{1}", myNickName, myNickName);
            client.SendToServer(userMessage);
        }

        private void UpdateStatus(string newStatus)
        {
            Dispatcher.BeginInvoke(() => this.ConnectionStatus.Text = newStatus);
        }
    }
}