using Autofac;
using Base.Handler;
using Games.Plugin.Sudoku.Database;
using Games.Plugin.Sudoku.GamePlan;
using Games.Plugin.Sudoku.GamePlan.Compare;
using Games.Plugin.Sudoku.GameSudoku;
using Games.Plugin.Sudoku.GameSudoku.NewGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Games.Plugin.Sudoku.Container
{
    public static class Container
    {       
        public static IContainer Config()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SudokuPlugin>().As<ISudokuPlugin>();
            builder.RegisterType<DatabaseAccess>().As<IDatabaseAccess>();
            builder.RegisterType<TestDatabase>().As<IDatabase>();
            builder.RegisterType<GamePlanViewModel>().As<IGamePlanViewModel>();
            builder.RegisterType<HashValues>().As<IHashValues>();
            builder.RegisterType<CompareGamePlans>().As<ICompareGamePlans>();
            builder.RegisterType<NewGameView>();
            builder.RegisterType<NewGameViewModel>().As<INewGameViewModel>().WithParameter(new TypedParameter(typeof(NewGameView), new NewGameView()));
            builder.RegisterType<GameSudokuViewModel>().As<IGameSudokuViewModel>();
            builder.RegisterType<CommandHandler>().As<ICommand>();

            return builder.Build();
        }
    }
}
