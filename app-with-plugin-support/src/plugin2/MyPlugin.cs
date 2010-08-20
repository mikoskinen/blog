using System.Windows.Forms;
using app_with_plugin_support;

namespace plugin2
{
    public class MyPlugin : IPlugin
    {
        public void Run()
        {
            MessageBox.Show("Hello from plugin, I've been updated.", "Version 2.0");
        }
    }
}
