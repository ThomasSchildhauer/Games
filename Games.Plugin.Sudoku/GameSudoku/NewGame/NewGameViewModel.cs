using Autofac;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Games.Plugin.Sudoku.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Games.Plugin.Sudoku.GameSudoku.NewGame
{
    public class NewGameViewModel : ViewModelBase, INewGameViewModel
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


        public ICommand ButtonClickHard;

        public ICommand ButtonClickMiddle;

        public ICommand ButtonClickEasy;

        public ICommand ButtonClickOk;

        public ICommand ButtonClickCancel;

        public int Difficulty
        {
            get => _difficulty;

            set => Set(nameof(Difficulty), ref _difficulty, value);
        }

        public NewGameViewModel()
        {
            InitCommands();
        }

        private void InitCommands()
        {
            ButtonClickHard = new RelayCommand(() =>
            {
                SelectedGameDifficulty = (int)GameDifficulty.Difficulty.Hard;
                OkButtonIsEnabled = true;
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
