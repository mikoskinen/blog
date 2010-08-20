using System.IO;
using System.Windows.Forms;
using StructureMap;

namespace app_with_plugin_support
{
    public interface IMainApplication
    {
        void Start();
    }

    public partial class MainApplication : Form, IMainApplication
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

        private void UpdateFeatures_Click(object sender, System.EventArgs e)
        {
            var appPath = Application.StartupPath;

            var sourcePath = Path.Combine(appPath, @"pluginarchive\plugin.dll");
            var destinationPath = Path.Combine(appPath, @"plugins\plugin.dll");

            File.Copy(sourcePath, destinationPath, true);

            ReloadPlugins();

        }

        private void AddFeatures_Click(object sender, System.EventArgs e)
        {

            var appPath = Application.StartupPath;

            var sourcePath = Path.Combine(appPath, @"pluginarchive\plugin3.dll");
            var destinationPath = Path.Combine(appPath, @"plugins\plugin2.dll");

            File.Copy(sourcePath, destinationPath, true);

            ReloadPlugins();

        }

        private void ReloadPlugins()
        {
            container.EjectAllInstancesOf<IPlugin>();

            container.Configure(x => 
                x.AddRegistry<PluginRegistry>()
                );
        }
    }
}
