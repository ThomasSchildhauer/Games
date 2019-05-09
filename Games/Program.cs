using Autofac;
using Games.Loader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    class Program
    {
        //here comes the plugin system the GamesUI trigger and the http client
        static void Main(string[] args)
        {
            var Container = new Autofac.Container();

            var contaier = Container.Config();

            using (var scope = contaier.BeginLifetimeScope())
            {
                var loader = scope.Resolve<IPluginLoader>();

                loader.LoadPlugins();

                Console.ReadKey();
            }
        }
    }
}
