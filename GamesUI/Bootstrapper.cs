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
        public SimpleContainer container = new SimpleContainer();

        protected override void BuildUp(object instance)
        {
            base.BuildUp(instance);
        }

        protected override void Configure()
        {
            // register viewmodels...
            container.RegisterSingleton
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            container.BuildUp(sender);
        }
    }
}
