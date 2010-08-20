using StructureMap.Configuration.DSL;

namespace app_with_plugin_support
{
    public class PluginRegistry : Registry
    {
        public PluginRegistry()
        {
            Scan( x=>
                      {
                          x.AssembliesFromPathDynamically(@".\plugins");
                          x.AddAllTypesOf<IPlugin>();
                      });
        }
    }
}
