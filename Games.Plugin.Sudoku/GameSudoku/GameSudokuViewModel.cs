using Autofac;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Games.Plugin.Sudoku.Events;
using Games.Plugin.Sudoku.GameSudoku.NewGame;
using GamesBase.Messages;
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
        private GameSudokuViewToken _token;

        public ICommand NewGameCommand
        {
            get => new RelayCommand(() =>
            {
                MessengerInstance.Send(new ControleVisible(nameof(Games.Plugin.Sudoku.GameSudoku.NewGame.NewGameViewModel)), _token);
            });
        }

        private INewGameViewModel _newGameViewModel;

        public INewGameViewModel NewGameViewModel
        {
            get => _newGameViewModel;
            set
            {
                Set(nameof(NewGameViewModel), ref _newGameViewModel, value);
            }
        }

        public GameSudokuViewModel(
            INewGameViewModel newGameViewModel,
            GameSudokuViewToken token)
        {
            _token = token;
            NewGameViewModel = newGameViewModel;
        }
    }
}
