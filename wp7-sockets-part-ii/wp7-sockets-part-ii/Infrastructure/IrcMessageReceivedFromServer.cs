using System;

namespace wp7_sockets_part_ii
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