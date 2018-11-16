using Games.Plugin.Sudoku.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Plugin.Sudoku
{
    public class SudokuPlugin : ISudokuPlugin
    {
        private IDatabaseAccess _databaseAccess;
        public SudokuPlugin(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public void Run()
        {

        }
    }
}
