using System;
using System.Threading;
using messages;
using NServiceBus;

namespace server.Handlers
{
    public class ChangeUserEmailAddressCommandHandler : IHandleMessages<ChangeUserEmailAddressCommand>
    {
        public void Handle(ChangeUserEmailAddressCommand message)
        {
            Thread.Sleep(100);
            Console.WriteLine("###########{0}", message.UserId);
        }
    }
}
