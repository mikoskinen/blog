using System;

namespace wp7_sockets_part_iii.Infrastructure
{
    public class IrcMessageReceivedFromServer : EventArgs
    {
        public string Message { get; private set; }

        public IrcMessageReceivedFromServer(string message)
        {
            Message = message;
        }
    }
}