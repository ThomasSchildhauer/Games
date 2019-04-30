using Autofac;
using Base.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesUI.Autofac
{
    public class Container
    {
        private List<Type> _types = new List<Type>();
        public IContainer Config()
        {
            var myType = typeof(IGamesPlugin);

            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            foreach (var dll in Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories))
            {
                var assembly = System.Reflection.Assembly.LoadFile(dll);
                assembly.GetTypes().Where(t => !t.IsInterface && myType.IsAssignableFrom(t)).ToList().ForEach(t => _types.Add(t));
            }

            var builder = new ContainerBuilder();

            _types.ForEach(t => builder.RegisterType(t).As<IGamesPlugin>().WithMetadata("TypeName", t.Name).SingleInstance());

            return builder.Build();
        }
    }
}
