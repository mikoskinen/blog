namespace wp7_sockets_part_iii.Infrastructure
{
    public class MessageObserver
    {
        private readonly IrcClient client;

        public MessageObserver(IrcClient client)
        {
            this.client = client;

            this.client.IrcMessageReceivedFromServer += OnIrcMessageReceivedFromServer;
        }

        private void OnIrcMessageReceivedFromServer(object sender, IrcMessageReceivedFromServer e)
        {
            if (string.IsNullOrWhiteSpace(e.Message))
                return;

            if (e.Message.IndexOf("PING :") == 0)
            {
                HandlePing(e.Message);
                return;
            }
        }

        private void HandlePing(string message)
        {
            var index = message.LastIndexOf(":");
            var pingNumber = message.Substring(index + 1);

            var pongMessage = string.Format("PONG :{0}", pingNumber);
            client.SendToServer(pongMessage);
        }
    }
}
