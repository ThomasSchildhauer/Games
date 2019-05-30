using Autofac;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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
    public class GameSudokuViewModel : ViewModelBase, IGameSudokuViewModel
    {
        private readonly bool _isExecutable = true;

        public INewGameViewModel NewGameViewModel { get; }

        public ICommand NewGameCommand;
        //public event EventHandler OpenNewGame;

        public GameSudokuViewModel(INewGameViewModel newGameViewModel)
        {
            NewGameViewModel = newGameViewModel;
            InitCommands();
        }

        private void InitCommands()
        {
            NewGameCommand = new RelayCommand(() =>
            {
                // ToDo here is something missing
            }, _isExecutable);
        }
    }
}
