using Games.Plugin.Sudoku.GameSudoku.NewGame;

namespace Games.Plugin.Sudoku.GameSudoku
{
    public interface IGameSudokuViewModel
    {
        INewGameViewModel NewGameViewModel { get; }
    }
}