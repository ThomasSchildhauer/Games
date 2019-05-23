using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesBase.Interfaces
{
    public interface IGamesPlugin
    {
        string Name { get; }
        void OnStartup();
    }
}
