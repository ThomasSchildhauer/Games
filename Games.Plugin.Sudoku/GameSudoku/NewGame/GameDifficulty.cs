using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Plugin.Sudoku.GameSudoku.NewGame
{
    public class GameDifficulty
    {
        public enum Difficulty : int
        {
            Default = 0,
            Hard = 1,
            Middle = 2,
            Easy = 3
        };
    }
}
