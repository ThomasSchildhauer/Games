using Autofac.Features.Metadata;
using Base.Interfaces;
using GamesUI.ViewModels;
using GamesUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesUI
{
    public class Programm : IProgramm
    {
        private IMainWindowViewModel _mainWindowViewModel;
        private MainWindowView _mainWindowView;

        public Programm(IMainWindowViewModel mainWindowViewModel, MainWindowView mainWindowView)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _mainWindowView = mainWindowView;
        }

        public void Run()
        {
            _mainWindowView.DataContext = _mainWindowViewModel;
            _mainWindowView.InitializeComponent();
            _mainWindowView.Show();
        }
    }
}
