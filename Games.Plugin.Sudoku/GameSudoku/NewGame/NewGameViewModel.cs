using Autofac;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Games.Plugin.Sudoku.Events;
using GamesBase.Messages;
using GamesBase.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Games.Plugin.Sudoku.GameSudoku.NewGame
{
    public class NewGameViewModel : ViewModelVisibilityBase, INewGameViewModel
    {
        private readonly bool _canExecute = true;
        private int _difficulty;

        public event EventHandler SetDifficulty;

        public int SelectedGameDifficulty
        {
            get => _difficulty;
            set => Set(nameof(Difficulty), ref _difficulty, value);
        }

        private bool _okButtonIsEnabled;

        public bool OkButtonIsEnabled
        {
            get => _okButtonIsEnabled;
            set => Set(nameof(OkButtonIsEnabled), ref _okButtonIsEnabled, value);
        }

        public ICommand ButtonClickHard { get; private set; }
        public ICommand ButtonClickMiddle { get; private set; }
        public ICommand ButtonClickEasy { get; private set; }
        public ICommand ButtonClickOk { get; private set; }
        public ICommand ButtonClickCancel { get; private set; }

        private GameSudokuViewToken _token;

        public int Difficulty
        {
            get => _difficulty;

            set => Set(nameof(Difficulty), ref _difficulty, value);
        }

        public NewGameViewModel(GameSudokuViewToken token) : base(nameof(NewGameViewModel))
        {
            _token = token;

            MessengerInstance.Register<ControleVisible>(this, _token, CheckVisibility);

            InitCommands();
        }

        private void InitCommands()
        {
            ButtonClickHard = new RelayCommand(() =>
            {
                SelectedGameDifficulty = (int)GameDifficulty.Difficulty.Hard;
                OkButtonIsEnabled = true;
                Visible = false;
            }
            , _canExecute);

            ButtonClickMiddle = new RelayCommand(() =>
            {
                SelectedGameDifficulty = (int)GameDifficulty.Difficulty.Middle;
                OkButtonIsEnabled = true;
            }
            , _canExecute);

            ButtonClickEasy = new RelayCommand(() =>
            {
                SelectedGameDifficulty = (int)GameDifficulty.Difficulty.Easy;
                OkButtonIsEnabled = true;
            }
            , _canExecute);

            ButtonClickOk = new RelayCommand(() =>
            {
                SetDifficulty?.Invoke(this, EventArgs.Empty);
                Visible = false;
            }
            , _canExecute);

            ButtonClickCancel = new RelayCommand(() =>
            {
                SelectedGameDifficulty = (int)GameDifficulty.Difficulty.Default;
            }
            , _canExecute);
        }
    }
}
