using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Plugin.Sudoku.NewGame
{
    public class GameDifficulty
    {
        public enum Difficulty : int
        {
            Hard = 0,
            Middle = 1,
            Easy = 2
        };
    }
}
