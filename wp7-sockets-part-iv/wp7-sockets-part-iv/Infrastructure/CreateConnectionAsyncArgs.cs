using System;

namespace wp7_sockets_part_iii.Infrastructure
{
    public class CreateConnectionAsyncArgs : EventArgs
    {
        public bool ConnectionOk { get; private set; }

        public CreateConnectionAsyncArgs(bool connectionOk)
        {
            ConnectionOk = connectionOk;
        }
    }
}