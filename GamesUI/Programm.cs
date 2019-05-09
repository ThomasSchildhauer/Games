using Autofac.Features.Metadata;
using Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesUI
{
    public class Programm : IProgramm
    {
        private IEnumerable<Meta<IGamesPlugin>> _plugins;

        public Programm(IEnumerable<Meta<IGamesPlugin>> plugins)
        {
            _plugins = plugins;
        }

        public void Run()
        {

        }


    }
}
