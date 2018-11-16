﻿using Autofac;
using Games.Plugin.Sudoku.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Plugin.Sudoku.ContainerConfig
{
    public static class ContainerConfig
    {       
        public static IContainer Config()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SudokuPlugin>().As<ISudokuPlugin>();
            builder.RegisterType<DatabaseAccess>().As<IDatabaseAccess>();
            builder.RegisterType<TestDatabase>().As<IDatabase>();

            return builder.Build();
        }
    }
}
