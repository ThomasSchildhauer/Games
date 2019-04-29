using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Games.Autofac
{
    public static class PluginLoader
    {
        // does not work like it should
        public static IEnumerable<Assembly> GetAllPlugins(string relativeDirectoryName, Type baseType)
        {
            List<Assembly> allAssemblies = new List<Assembly>();
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.Combine(basePath, relativeDirectoryName);

            var fileList = Directory.GetFiles(path, "*.dll");

            foreach (string dll in Directory.GetFiles(path, "*.dll"))
            {
                var assembly = Assembly.LoadFile(dll);

                var type = assembly.GetTypes().Where(t => t.IsSubclassOf(baseType)).FirstOrDefault();

                if (type != default(Type))
                {
                    allAssemblies.Add(Assembly.LoadFile(dll));
                }
            }

            return allAssemblies;
        }
    }
}
