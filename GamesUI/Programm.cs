using Autofac.Features.Metadata;
using GamesBase.Interfaces;
using GamesUI.Loader;
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
        IMainWindowViewLoader _mainWindowViewLoader;

        public Programm(IMainWindowViewLoader mainWindowViewLoader)
        {
            _mainWindowViewLoader = mainWindowViewLoader;
        }

        public void Run()
        {
            _mainWindowViewLoader.LoadView();
        }
    }
}
