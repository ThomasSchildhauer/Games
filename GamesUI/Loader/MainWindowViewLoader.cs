using GamesUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesUI.Loader
{
    public class MainWindowViewLoader : IMainWindowViewLoader
    {
        private MainWindowView _mainWindowView { get; }

        public MainWindowViewLoader(MainWindowView mainWindowView)
        {
            _mainWindowView = mainWindowView;
        }

        public void LoadView()
        {
            _mainWindowView.Show();
        }
    }
}
