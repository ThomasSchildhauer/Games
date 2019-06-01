using Autofac.Features.Metadata;
using GamesBase.Interfaces;
using GalaSoft.MvvmLight;
using GamesUI.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using GamesBase.Messages;
using GamesBase.ViewModel;

namespace GamesUI.ViewModels
{
    public class PluginViewModel : ViewModelVisibilityBase, IPluginViewModel
    {
        private UIViewModelToken _token;
        private List<IPluginsTemplate> _pluginTemplates;

        public List<IPluginsTemplate> PluginTemplates
        {
            get => _pluginTemplates;
            private set
            {
                Set(nameof(PluginTemplates), ref _pluginTemplates, value);
            }
        }

        private IEnumerable<Meta<IGamesPlugin>> _plugins;

        public PluginViewModel(
            UIViewModelToken token,
            IEnumerable<Meta<IGamesPlugin>> plugins,
            Func<Meta<IGamesPlugin>, IPluginsTemplate> templatesFunc,
            IEnumerable<IPluginsTemplate> pluginTemplates):base(nameof(PluginViewModel))
        {
            _plugins = plugins;
            _pluginTemplates = pluginTemplates.ToList();
            _pluginTemplates.RemoveAt(0);
            _token = token;

            MessengerInstance.Register<ControleVisible>(this, _token, CheckVisibility);

            foreach (var p in _plugins)
            {
                var template = templatesFunc(p);

                _pluginTemplates.Add(template);
            }
        }
    }
}
