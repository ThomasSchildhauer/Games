using GalaSoft.MvvmLight;
using GamesUI.Loader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesUI.ViewModels
{
    public class PluginViewModel : ViewModelBase, IPluginViewModel
    {
        public List<string> Plugins { get; set; }

        private IPluginLoader _pluginLoader;

        public PluginViewModel(IPluginLoader pluginLoader)
        {
            _pluginLoader = pluginLoader;
            Plugins = _pluginLoader.GetPluginNames();
        }
    }
}
