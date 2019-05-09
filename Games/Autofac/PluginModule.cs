using Autofac;
using Games.PluginLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Autofac
{
    class PluginModule : Module
    {


        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = PluginLoader.GetAllPlugins("Plugin", IGamesPlugin);
            base.Load(builder);
        }
    }
}
