using System;
using System.Windows.Forms;
using app_with_plugin_support;

namespace plugin
{
    public class MyPlugin : IPlugin
    {
        public void Run()
        {
            MessageBox.Show("Hello from plugin.", "Version 1.0");
        }
    }
}
