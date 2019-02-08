using Autofac;
using Base.Handler;
using Games.Plugin.Sudoku.Events;
using Games.Plugin.Sudoku.GameSudoku.NewGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Games.Plugin.Sudoku.GameSudoku
{
    public class GameSudokuViewModel : OnPropertyCange, IGameSudokuViewModel
    {
        private IContainer _container;
        private Func<Action, bool, ICommand> _commandFactory;
        private NewGameView _newGameView;
        private readonly bool _isExecutable = true;
        private INewGameViewModel _newGameViewModel;

        public int MyProperty { get; set; }
        //ToDo has to be refactored
        //public ICommand NewGameCommand = new CommandHandler(()=>new NewGameView(new NewGameViewModel(new Window())).InitializeComponent(), true);

        public ICommand NewGameCommand
        {
            get => _commandFactory(()=>_newGameView.InitializeComponent(), _isExecutable);
        }

        public GameSudokuViewModel(NewGameView newGameView, INewGameViewModel newGameViewModel)
        {
            _newGameView = newGameView;
            _newGameViewModel = newGameViewModel;
            _newGameView.DataContext = _newGameViewModel;
            _container = ContainerConfig.ContainerConfig.Config();
            _commandFactory = _container.Resolve<Func<Action, bool, ICommand>>();
        }
    }
}
