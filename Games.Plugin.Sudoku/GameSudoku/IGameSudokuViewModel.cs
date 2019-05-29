using System;

namespace Games.Plugin.Sudoku.GameSudoku
{
    public interface IGameSudokuViewModel
    {
        int MyProperty { get; set; }

        event EventHandler OpenNewGame;
    }
}