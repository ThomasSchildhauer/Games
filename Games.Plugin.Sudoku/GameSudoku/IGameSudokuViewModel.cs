using System;

namespace Games.Plugin.Sudoku.GameSudoku
{
    public interface IGameSudokuViewModel
    {
        event EventHandler OpenNewGame;
        int MyProperty { get; set; }
    }
}