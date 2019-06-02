using System;
using System.Windows.Input;

namespace Games.Plugin.Sudoku.GameSudoku.NewGame
{
    public interface INewGameViewModel
    {
        ICommand ButtonClickCancel { get; }
        ICommand ButtonClickEasy { get; }
        ICommand ButtonClickHard { get; }
        ICommand ButtonClickMiddle { get; }
        ICommand ButtonClickOk { get; }
        bool Visible { get; set; }
        int Difficulty { get; set; }
        bool OkButtonIsEnabled { get; set; }
        int SelectedGameDifficulty { get; set; }

        event EventHandler SetDifficulty;
    }
}