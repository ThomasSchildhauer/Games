using Base.Handler;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Games.Plugin.Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GamesUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private static readonly log4net.ILog log = Logger.GetNewLogger();

        public ICommand StartSudoku
        {
            get => new RelayCommand(()=>StartSudokuPlugin.Start(), true);
        }

        public MainWindowViewModel()
        {
            log.Debug("Start Games Programm");
        }
    }
}
