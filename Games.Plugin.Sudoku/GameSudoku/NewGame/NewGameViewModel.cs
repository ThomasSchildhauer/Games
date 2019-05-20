using Autofac;
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
        private readonly bool _canExecute = true;
        private int _difficulty;

        private ILifetimeScope _scope;
        private Func<Action, bool, ICommand> _commandFactory;

        public event EventHandler SetDifficulty;

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
            get => _commandFactory(() =>
            {
                SelectedGameDifficulty = (int)GameDifficulty.Difficulty.Hard;
                OkButtonIsEnabled = true;
            }
            , _canExecute);
        }

        public ICommand ButtonClickMiddle
        {
            get => _commandFactory(() =>
            {
                SelectedGameDifficulty = (int)GameDifficulty.Difficulty.Middle;
                OkButtonIsEnabled = true;
            }
            , _canExecute);
        }

        public ICommand ButtonClickEasy
        {
            get => _commandFactory(() =>
            {
                SelectedGameDifficulty = (int)GameDifficulty.Difficulty.Easy;
                OkButtonIsEnabled = true;
            }
            , _canExecute);
        }

        public ICommand ButtonClickOk
        {
            get => _commandFactory(() =>
            {
                SetDifficulty?.Invoke(this, EventArgs.Empty);
            }
            , _canExecute);
        }

        public ICommand ButtonClickCancel
        {
            get => _commandFactory(() =>
            {
                SelectedGameDifficulty = (int)GameDifficulty.Difficulty.Default;
            }
            , _canExecute);
        }

        public int Difficulty
        {
            get => _difficulty;

            set => ChangedProperty(value, ref _difficulty);
        }

        public NewGameViewModel()
        {
            _scope = Container.ContainerScope.Scope;
            _commandFactory = _scope.Resolve<Func<Action, bool, ICommand>>();
        }
    }
}
