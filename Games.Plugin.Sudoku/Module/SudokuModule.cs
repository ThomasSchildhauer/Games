using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using Games.Plugin.Sudoku.Database;
using Games.Plugin.Sudoku.GamePlan;
using Games.Plugin.Sudoku.GamePlan.Compare;
using Games.Plugin.Sudoku.GameSudoku;
using Games.Plugin.Sudoku.GameSudoku.NewGame;

namespace Games.Plugin.Sudoku.Module
{
    public class SudokuModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SudokuPlugin>().As<ISudokuPlugin>()
                    .WithParameter(new TypedParameter(typeof(GameSudokuView), new GameSudokuView()))
                    .WithParameter(new TypedParameter(typeof(NewGameView), new NewGameView()))
                    .WithParameter(new TypedParameter(typeof(GamePlanView), new GamePlanView()));

            builder.RegisterType<DatabaseAccess>().As<IDatabaseAccess>();
            builder.RegisterType<TestDatabase>().As<IDatabase>();
            builder.RegisterType<GamePlanViewModel>().As<IGamePlanViewModel>();
            builder.RegisterType<HashValues>().As<IHashValues>();
            builder.RegisterType<CompareGamePlans>().As<ICompareGamePlans>();
            builder.RegisterType<NewGameViewModel>().As<INewGameViewModel>();
            builder.RegisterType<GameSudokuViewModel>().As<IGameSudokuViewModel>();
            builder.RegisterType<GameSudokuViewToken>().AsSelf().SingleInstance();
        }
    }
}
