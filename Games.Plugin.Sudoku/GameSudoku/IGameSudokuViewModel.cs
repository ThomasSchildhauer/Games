using Games.Plugin.Sudoku.GameSudoku.NewGame;
using System.Windows.Input;

namespace Games.Plugin.Sudoku.GameSudoku
{
    public interface IGameSudokuViewModel
    {
        INewGameViewModel NewGameViewModel { get; }
        ICommand NewGameCommand { get; }
    }
}