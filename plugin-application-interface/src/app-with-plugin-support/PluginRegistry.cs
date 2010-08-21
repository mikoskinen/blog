using StructureMap.Configuration.DSL;

namespace app_with_plugin_support
{
    public class PluginRegistry : Registry
    {
        public PluginRegistry()
        {
            Scan( x=>
                      {
                          x.AssembliesFromPath(@".\plugins", null, true);
                          x.AddAllTypesOf<IPlugin>();
                      });
        }
    }
}
