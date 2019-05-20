using Autofac;
using GamesUI.Loader;
using GamesUI.PluginInterfaces;
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
        private List<Type> _types = new List<Type>();

        public IContainer Config()
        {
            var builder = new ContainerBuilder();

            //######################//
            // Dynamic registration //
            //######################//
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            // Plugin Registration
            var myType = typeof(IPlugin);

            // Check if Directory exists
            if (Directory.Exists(path))
            {
                // get all filenames in directory, take all dlls and only search top directory. Search options could be changed to all directories
                IEnumerable<string> fileNames = Directory.EnumerateFiles(path, "*.dll", SearchOption.AllDirectories);

                foreach (var fileName in fileNames)
                {
                    // load all assemblies
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(fileName);

                    // export all types from the current assembly
                    IEnumerable<Type> types = assembly.ExportedTypes;
                    
                    foreach (Type t in types)
                    {
                        // check if the type meets the criterias: type is a class and type is inherited from myType
                        if (t.IsClass && myType.IsAssignableFrom(t))
                        {
                            // add types that meet all criterias to a list
                            _types.Add(t);
                        }

                        //if (t.IsClass && t.IsAssignableFrom(myType))
                        //{
                        //    // add types that meet all criterias to a list
                        //    _types.Add(t);
                        //}
                    }
                }

                // register all types in the List
                foreach (var t in _types)
                {
                    builder.RegisterType(t)
                        .As<IPlugin>()
                        .WithMetadata("TypeName", t.Name)
                        .SingleInstance();
                }
            }



            // Plugin Autofac Modul registration
            // for testing purposes i implement this again to find bugs
            var moduleType = typeof(Module);

            // check if directory exists
            if (Directory.Exists(path))
            {
                // get all filenames in the directory, that are dlls and which are located in top directory only
                IEnumerable<string> fileNames = Directory.EnumerateFiles(path, "*.dll", SearchOption.AllDirectories);

                foreach (var fileName in fileNames)
                {
                    // loads all assemblies from file
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(fileName);

                    // exports all types from a assembly
                    IEnumerable<Type> types = assembly.ExportedTypes;

                    // check if the type meets the criterias: type is a class and type is inherited from myType
                    // the inheritance has to be checked because only the types of a assembly that holds a class that inherits from myType have be loaded
                    var isPlugin = types.Where(t => t.IsClass && myType.IsAssignableFrom(t));

                    // if the there is a type in the assembly that inherits from myType the check for Autofac.Module goes on
                    if (isPlugin.Count() > 0)
                    {
                        foreach (var t in types)
                        {
                            // only classes that inherit from Autofac.Module have to be registered
                            if (t.IsClass && moduleType.IsAssignableFrom(t))
                            {
                                // the RegisterModule only takes a instance of an object
                                var instance = Activator.CreateInstance(t);
                                builder.RegisterModule(instance as Module);
                            }
                        }
                    }
                }
            }


            // Register Types
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
    }
}
