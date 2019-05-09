﻿using Autofac;
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
        public IContainer Config()
        {
            var types = GetAllDllTypes<IGamesPlugin>(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

            var builder = new ContainerBuilder();

            types?.ForEach(t => builder.RegisterType(t).As<IGamesPlugin>().WithMetadata("TypeName", t.Name).SingleInstance());

            return builder.Build();
        }

        public List<Type> GetAllDllTypes<T>(string path)
        {
            var myType = typeof(T);

            List<Type> types = new List<Type>();

            foreach (var dll in Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories))
            {
                var assembly = System.Reflection.Assembly.LoadFile(dll);
                assembly?.GetTypes()?.Where(t => !t.IsInterface && t.IsClass && myType.IsAssignableFrom(t)).ToList().ForEach(t => types.Add(t));
            }

            return types;
        }
    }
}