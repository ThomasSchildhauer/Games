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
        public int MyProperty { get; set; }

        public event EventHandler OpenNewGame;

        public ICommand NewGameCommand;

        public GameSudokuViewModel()
        {
            InitCommands();
        }

        private void InitCommands()
        {
            NewGameCommand = new RelayCommand(() =>
            {
                OpenNewGame?.Invoke(this, EventArgs.Empty);
            }, _isExecutable);
        }
    }
}
