using Base.Handler;
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
    public class NewGameViewModel : OnPropertyCange, INewGameViewModel
    {
        private bool _canExecute = true;
        private Window _window;
        public event EventHandler SetDifficulty;
        private int _difficulty;

        public int SelectedGameDifficulty
        {
            get => _difficulty;
            set => ChangedProperty(value, ref _difficulty);
        }

        private bool _okButtonIsEnabled;

        public bool OkButtonIsEnabled
        {
            get => _okButtonIsEnabled;
            set => ChangedProperty(value, ref _okButtonIsEnabled);
        }


        public ICommand ButtonClickHard
        {
            get => new CommandHandler(() =>
            {
                SelectedGameDifficulty = (int)GameDifficulty.Difficulty.Hard;
                OkButtonIsEnabled = true;
            }
            , _canExecute);
        }

        public ICommand ButtonClickMiddle
        {
            get => new CommandHandler(() =>
            {
                SelectedGameDifficulty = (int)GameDifficulty.Difficulty.Middle;
                OkButtonIsEnabled = true;
            }
            , _canExecute);
        }

        public ICommand ButtonClickEasy
        {
            get => new CommandHandler(() =>
            {
                SelectedGameDifficulty = (int)GameDifficulty.Difficulty.Easy;
                OkButtonIsEnabled = true;
            }
            , _canExecute);
        }

        public ICommand ButtonClickOk
        {
            get => new CommandHandler(() =>
            {
                SetDifficulty.Invoke(this, EventArgs.Empty);
                SystemCommands.CloseWindow(_window);
            }
            , _canExecute);
        }

        public ICommand ButtonClickCancel
        {
            get => new CommandHandler(() =>
            {
                SystemCommands.CloseWindow(_window);
                SelectedGameDifficulty = (int)GameDifficulty.Difficulty.Default;
            }
            , _canExecute);
        }

        public int Difficulty
        {
            get => _difficulty;

            set => ChangedProperty(value, ref _difficulty);
        }

        public NewGameViewModel(Window window)
        {
            _window = window;
        }
    }
}
