using Autofac.Features.Metadata;
using GamesBase.Interfaces;
using GalaSoft.MvvmLight;
using GamesUI.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using GamesUI.Messages;

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
                Set(nameof(PluginTemplates), ref _pluginTemplates, value);
            }
        }

        private bool _visible;

        public bool Visible
        {
            get => _visible;
            set
            {
                Set(nameof(Visible), ref _visible, value);
            }
        }

        private IEnumerable<Meta<IGamesPlugin>> _plugins;

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

            MessengerInstance.Register<ControleVisible>(this, CheckVisibility);
        }

        private void CheckVisibility(ControleVisible controleVisible)
        {
            if (string.Compare(controleVisible.Owner, nameof(PluginViewModel)) == 0)
            {
                Visible = true;
            }
            else
            {
                Visible = false;
            }
        }
    }
}
