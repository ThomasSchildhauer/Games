using System;
using System.Threading.Tasks;
using Autofac;

namespace Games.Plugin.Sudoku
{
    public interface ISudokuPlugin
    {
        void ProceedAfterLoading(object sende, EventArgs e);
        Task RunAsync();
    }
}