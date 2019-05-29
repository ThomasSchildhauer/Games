using System;

namespace Games.Plugin.Sudoku.GameSudoku.NewGame
{
    public interface INewGameViewModel
    {
        int Difficulty { get; set; }
        bool OkButtonIsEnabled { get; set; }
        int SelectedGameDifficulty { get; set; }

        event EventHandler SetDifficulty;
    }
}