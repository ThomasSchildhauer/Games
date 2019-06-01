using Autofac;
using GamesBase.Interfaces;
using GamesBase.Messages;
using GamesUI.Loader;
using GamesUI.Templates;
using GamesUI.ViewModels;
using GamesUI.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GamesUI.Autofac
{
    public class UIContainer : IUIContainer
    {
        private List<Type> _types = new List<Type>();
        private List<System.Reflection.Assembly> _assembly = new List<System.Reflection.Assembly>();

        public IContainer Config()
        {
            var builder = new ContainerBuilder();

            //######################//
            // Dynamic registration //
            //######################//
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            // Plugin Registration
            var myType = typeof(IGamesPlugin);

            var moduleType = typeof(Module);

            // Check if Directory exists
            if (Directory.Exists(path))
            {
                // get all filenames in directory, take all dlls and only search top directory. Search options could be changed to all directories
                IEnumerable<string> fileNames = Directory.EnumerateFiles(path, "*.dll", SearchOption.AllDirectories);

                foreach (var fileName in fileNames)
                {
                    // load all assemblies
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile(fileName);

                    // export all types from the current assembly
                    IEnumerable<Type> types = assembly.ExportedTypes;

                    foreach (var t in types)
                    {
                        // check if the type meets the criterias: type is a class and type is inherited from myType
                        if (t.IsClass && myType.IsAssignableFrom(t))
                        {
                            // add types that meet all criterias to a list
                            _types.Add(t);

                            // add all assemblies, that have mytype in it
                            _assembly.Add(assembly);
                        }
                    }
                }

                if (_types.Count > 0)
                {
                    // this is for autofac module registration
                    foreach (var a in _assembly)
                    {
                        IEnumerable<Type> autofacModules = a.ExportedTypes;

                        foreach (var t in autofacModules)
                        {
                            if (t.IsClass && moduleType.IsAssignableFrom(t))
                            {
                                var instance = Activator.CreateInstance(t);
                                builder.RegisterModule(instance as Module);
                            }
                        }
                    }

                    // register all types in the List
                    foreach (var t in _types)
                    {
                        builder.RegisterType(t)
                            .As<IGamesPlugin>()
                            .WithMetadata("TypeName", t.Name)
                            .SingleInstance();
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
            //builder.RegisterType<ControleHelper>().As<IControleHelper>();
            builder.RegisterType<PluginViewModel>().As<IPluginViewModel>();
            builder.RegisterType<LoginViewModel>().As<ILoginViewModel>();
            builder.RegisterType<PluginView>().AsSelf();
            builder.RegisterType<UIViewModelToken>().AsSelf().SingleInstance();

            return builder.Build();
        }
    }
}
