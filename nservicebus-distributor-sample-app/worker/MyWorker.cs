using NServiceBus;

namespace server
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server { }

    public class ServerInit : IWantCustomInitialization, IWantCustomLogging
    {
        public void Init()
        {
            NServiceBus.SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure);
        }
    }
}
