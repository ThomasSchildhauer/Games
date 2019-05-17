using Autofac;
using Base.Interfaces;
using GamesUI.Loader;
using GamesUI.Templates;
using GamesUI.ViewModels;
using GamesUI.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesUI.Autofac
{
    public class UIContainer : IUIContainer
    {
        public IContainer Config()
        {
            // Plugins
            //var modules = GetAllDllTypes<Module>(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            var types = GetAllDllTypes<IGamesPlugin>(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));


            var builder = new ContainerBuilder();

            //var instances = CreateInstances();

            //foreach (var i in instances)
            //{
            //    builder.RegisterInstance(i).As<IGamesPlugin>().WithMetadata("TypeName", i.Name);
            //}

            //modules?.ForEach(m => builder.RegisterModule(Activator.CreateInstance(m) as Module));

            types?.ForEach(t => builder.RegisterType(t).As<IGamesPlugin>().WithMetadata("TypeName", t.Name).SingleInstance());

            // Programm start
            builder.RegisterType<Programm>().As<IProgramm>();
            builder.RegisterType<MainWindowViewLoader>().As<IMainWindowViewLoader>();
            builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>();
            builder.RegisterType<MainWindowView>().AsSelf();
            builder.RegisterType<PluginsTemplate>().As<IPluginsTemplate>();
            builder.RegisterType<PluginViewModel>().As<IPluginViewModel>();
            builder.RegisterType<PluginView>().AsSelf();

            return builder.Build();
        }

        public List<Type> GetAllDllTypes<T>(string path)
        {
            var myType = typeof(T);

            List<Type> types = new List<Type>();

            foreach (var dll in Directory.GetFiles(path + "\\Plugins\\", "*.dll", SearchOption.AllDirectories))
            {
                if (dll != "Autofac.dll")
                {
                    var assembly = System.Reflection.Assembly.LoadFile(dll);
                    assembly?.GetTypes()?.Where(t => !t.IsInterface && !t.IsAbstract && t.IsClass && myType.IsAssignableFrom(t))?.ToList().ForEach(t => types.Add(t));
                }
            }

            return types;
        }

        public List<IGamesPlugin> CreateInstances()
        {
            var list = new List<IGamesPlugin>();
            var types = GetAllDllTypes<IGamesPlugin>(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

            foreach (var t in types)
            {
                var instance = Activator.CreateInstance(t);
                list.Add(instance as IGamesPlugin);
            }

            return list;
        }
    }
}
