using NServiceBus;

namespace messages
{
    public class ChangeUserEmailAddressCommand : IMessage
    {
        public int UserId;
    }
}
