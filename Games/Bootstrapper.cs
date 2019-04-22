using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GamesUI
{
    public class Bootstrapper : BootstrapperBase
    {
        protected override void BuildUp(object instance)
        {
            base.BuildUp(instance);
        }

        protected override void Configure()
        {
            base.Configure();
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return base.GetAllInstances(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return base.GetInstance(service, key);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);
        }
    }
}
