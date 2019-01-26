using Base.Handler;
using Games.Plugin.Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Games
{
    public class MainWindowViewModel
    {
        private static readonly log4net.ILog log = Logger.GetNewLogger();

        public ICommand StartSudoku
        {
            get => new CommandHandler(()=>StartSudokuPlugin.Start(), true);
        }

        public MainWindowViewModel()
        {
            log.Debug("Start Games Programm");
        }
    }
}
