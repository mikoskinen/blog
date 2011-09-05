using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace wp7_sockets_part_i
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly IrcClient client;

        public MainPage()
        {
            InitializeComponent();

            this.client = new IrcClient();
            this.client.CreateConnectionCompleted += OnCreateConnectionCompleted;
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
        }

        private void UpdateStatus(string newStatus)
        {
            Dispatcher.BeginInvoke(() => this.ConnectionStatus.Text = newStatus);
        }
    }
}