using System;
using StructureMap;

namespace app_with_plugin_support
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var container = CreateContainer();

            var mainApp = container.GetInstance<IMainApplication>();
            mainApp.Start();

        }

        private static IContainer CreateContainer()
        {
            var container = new Container(x =>
                                              {

                                                  x.AddRegistry<PluginRegistry>();
                                                  x.For<IMainApplication>().Use<MainApplication>();
                                              });

            return container;
        }
    }
}
