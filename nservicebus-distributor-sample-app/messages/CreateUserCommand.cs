using NServiceBus;

namespace messages
{
    public class CreateUserCommand : IMessage
    {
        public int UserId;
    }
}
