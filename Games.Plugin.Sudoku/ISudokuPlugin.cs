using System;
using System.Threading.Tasks;

namespace Games.Plugin.Sudoku
{
    public interface ISudokuPlugin
    {
        void ProceedAfterLoading(object sende, EventArgs e);
        Task RunAsync();
    }
}