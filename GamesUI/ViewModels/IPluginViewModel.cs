using System.Collections.Generic;
using GamesUI.Templates;

namespace GamesUI.ViewModels
{
    public interface IPluginViewModel
    {
        List<IPluginsTemplate> PluginTemplates { get; }
    }
}