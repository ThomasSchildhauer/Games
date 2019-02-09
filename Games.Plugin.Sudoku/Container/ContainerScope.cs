using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Plugin.Sudoku.Container
{
    public static class ContainerScope
    {
        public static ILifetimeScope Scope
        {
            get;
            set;
        }
    }
}
