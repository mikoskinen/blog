using System;
using System.Threading;
using messages;
using NServiceBus;

namespace server
{
    public class CreateUserCommandHandler : IHandleMessages<CreateUserCommand>
    {
        public void Handle(CreateUserCommand message)
        {
            Thread.Sleep(300);
            Console.WriteLine("***********{0}", message.UserId);
        }
    }
}
