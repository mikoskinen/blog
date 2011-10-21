using System;

namespace wp7_sockets_part_ii
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