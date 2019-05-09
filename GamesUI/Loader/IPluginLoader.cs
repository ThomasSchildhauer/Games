using System.Collections.Generic;

namespace GamesUI.Loader
{
    public interface IPluginLoader
    {
        void LoadPlugins();

        List<string> GetPluginNames();
    }
}