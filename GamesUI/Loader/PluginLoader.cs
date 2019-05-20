using Autofac.Features.Metadata;
using GamesUI.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesUI.Loader
{
    public class PluginLoader : IPluginLoader
    {
        private IEnumerable<Meta<IPlugin>> _plugins;
        public PluginLoader(IEnumerable<Meta<IPlugin>> plugins)
        {
            _plugins = plugins;
        }

        public void LoadPlugins()
        {
            foreach (var plugin in _plugins)
            {
                plugin.Value.OnStartup();
            }
        }

        public List<string> GetPluginNames()
        {
            List<string> names = new List<string>();
            _plugins.ToList().ForEach(p => names.Add(p.Metadata.ToString()));

            return names;
        }
    }
}
