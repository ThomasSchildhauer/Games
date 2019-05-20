using GamesUI;
using GamesUI.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Plugin.Random
{
    public class StartRandom : IPlugin
    {
        public string Name { get; } = "Test";

        public string Text { get; private set; }

        public void OnStartup()
        {
            Text = "It works";
        }
    }
}
