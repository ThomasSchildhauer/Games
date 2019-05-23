using Autofac.Features.Metadata;
using GamesBase.Interfaces;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;

namespace GamesUI.Templates
{
    public class PluginsTemplate : IPluginsTemplate
    {
        // ToDo make a template for buttons for all plugins
        public string ButtonText { get; }

        public ICommand ButtonCommand { get; }

        private Meta<IGamesPlugin> _plugin;

        public PluginsTemplate(Meta<IGamesPlugin> plugin)
        {
            _plugin = plugin;
            ButtonText = _plugin.Value.Name;
            ButtonCommand = new RelayCommand(() => _plugin.Value.OnStartup());
        }
    }
}
