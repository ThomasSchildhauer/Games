using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Interfaces
{
    public interface IGamesPlugin
    {
        string Name { get; set; }
        void OnStartup();
    }
}
