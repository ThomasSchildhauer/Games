using Autofac.Features.Metadata;
using Base.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GamesUI.Templates
{
    public class PluginsTemplate : IPluginsTemplate
    {
        // ToDo make a template for buttons for all plugins
        public string ButtonText { get; set; }

        public ICommand ButtonCommand { get; set; }

        public PluginsTemplate() //Meta<IGamesPlugin> gamesPlugin)
        {
            //ButtonText = gamesPlugin.Metadata.Values.ToString();
            //ButtonCommand = new RelayCommand(() => gamesPlugin.Value.OnStartup());
        }
    }
}
