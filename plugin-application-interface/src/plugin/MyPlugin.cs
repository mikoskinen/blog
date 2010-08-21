using System.Windows.Forms;
using app_with_plugin_support;

namespace plugin
{
    public class MyPlugin : IPlugin
    {
        private readonly IApplicationFeatures appFeatures;

        public MyPlugin(IApplicationFeatures appFeatures)
        {
            this.appFeatures = appFeatures;
        }

        public void Run()
        {
            appFeatures.ShowOnScreen("Hello from plugin.");
        }
    }
}
