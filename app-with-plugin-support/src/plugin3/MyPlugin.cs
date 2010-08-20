using System.Windows.Forms;
using app_with_plugin_support;

namespace plugin3
{
    public class MyPlugin : IPlugin
    {
        public void Run()
        {
            MessageBox.Show("Hello, I'm a new feature.", "Version 1.0");
        }
    }
}
