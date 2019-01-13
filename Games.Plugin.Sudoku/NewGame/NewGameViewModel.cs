using Games.Plugin.Sudoku.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Games.Plugin.Sudoku.NewGame
{
    public class NewGameViewModel : OnPropertyCange
    {
        private int _difficulty;

        public int Difficulty
        {
            get => _difficulty;

            set => ChangedProperty(value, ref _difficulty);
        }

        public NewGameViewModel()
        {
            Hard_Click += SetDifficultyToHard;
        }

        private void SetDifficultyToHard(object sender, RoutedEventArgs e)
        {

        }
    }
}
