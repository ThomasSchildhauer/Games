using Games.Plugin.Sudoku.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Games.Plugin.Sudoku.NewGame
{
    public class NewGameViewModel : OnPropertyCange
    {
        private int _difficulty;
        private bool _canExecute = true;

        private ICommand _buttonClickHard;
        public ICommand ButtonClickHard
        {
            get => new CommandHandler(() => _difficulty = 0, _canExecute);
        }

        private ICommand _buttonClickMiddle;
        public ICommand ButtonClickMiddle
        {
            get => new CommandHandler(() => _difficulty = 1, _canExecute);
        }

        private ICommand _buttonClickEasy;
        public ICommand ButtonClickEasy
        {
            get => new CommandHandler(() => _difficulty = 2, _canExecute);
        }

        private ICommand _buttonClickOk;
        public ICommand ButtonClickOk
        {
            get => new CommandHandler(??, _canExecute);
        }

        private ICommand _buttonClickCancel;
        public ICommand ButtonClickCancel
        {
            get => new CommandHandler(??, _canExecute);
        }

        public int Difficulty
        {
            get => _difficulty;

            set => ChangedProperty(value, ref _difficulty);
        }

        public NewGameViewModel()
        {

        }

        private void SetDifficultyToHard(object sender, RoutedEventArgs e)
        {

        }
    }
}
