using System;
using System.IO;
using System.Windows.Forms;
using StructureMap;

namespace app_with_plugin_support
{
    public interface IMainApplication
    {
        void Start();
    }

    public partial class MainApplication : Form, IMainApplication, IApplicationFeatures
    {
        private readonly IContainer container;


        public MainApplication(IContainer container)
        {
            this.container = container;
            InitializeComponent();
        }

        public void Start()
        {
            this.ShowDialog();
        }

        public void ShowOnScreen(string message)
        {
            this.messageFromPlugin.Text = message;
        }

        private void RunFeatures_Click(object sender, System.EventArgs e)
        {
            var plugins = container.GetAllInstances<IPlugin>();
            if (plugins == null)
                return;

            foreach (var plugin in plugins)
            {
                plugin.Run();
            }
        }


    }
}
