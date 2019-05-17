using Autofac.Features.Metadata;
using Base.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GamesUI.Loader;
using GamesUI.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesUI.ViewModels
{
    public class PluginViewModel : ViewModelBase, IPluginViewModel
    {
        private List<IPluginsTemplate> _pluginTemplates;
        public List<IPluginsTemplate> PluginTemplates
        {
            get => _pluginTemplates;
            private set
            {
                Set(nameof(PluginTemplates), ref _pluginTemplates);
            }
        }

        private IEnumerable<Meta<IGamesPlugin>> _plugins;
        //private Func<Meta<IGamesPlugin>, IPluginsTemplate> _templatesFunc;

        public PluginViewModel(
            IEnumerable<Meta<IGamesPlugin>> plugins,
            Func<Meta<IGamesPlugin>, IPluginsTemplate> templatesFunc,
            IEnumerable<IPluginsTemplate> pluginTemplates)
        {
            _plugins = plugins;
            _pluginTemplates = pluginTemplates.ToList();
            _pluginTemplates.RemoveAt(0);

            foreach (var p in _plugins)
            {
                var template = templatesFunc(p);
                
                _pluginTemplates.Add(template);
            }
        }

        public PluginViewModel()
        {

        }
    }
}
