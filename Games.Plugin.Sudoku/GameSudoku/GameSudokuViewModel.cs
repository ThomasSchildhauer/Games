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
    public class GameSudokuViewModel : OnPropertyCange
    {
        //ToDo has to be refactored
        public ICommand NewGameCommand = new CommandHandler(()=>new NewGameView(new NewGameViewModel(new Window())).InitializeComponent(), true);
        public GameSudokuViewModel()
        {
        }
    }
}
