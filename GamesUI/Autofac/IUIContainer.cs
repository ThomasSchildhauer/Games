using System;
using System.Collections.Generic;
using Autofac;

namespace GamesUI.Autofac
{
    public interface IUIContainer
    {
        IContainer Config();
        List<Type> GetAllDllTypes<T>(string path);
    }
}