using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Games.Plugin.Sudoku
{
    public static class Start
    {
        public static void Main(string[] arg)
        {
            var container = ContainerConfig.ContainerConfig.Config();

            using (var scope = container.BeginLifetimeScope())
            {
                var _programm = scope.Resolve<IProgramm>();

                _programm.Run();
            }
        }
    }
}
