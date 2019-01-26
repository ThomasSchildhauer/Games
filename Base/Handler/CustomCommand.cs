using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Base.Handler
{
    class CustomCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public CustomCommand(Func<Action, ITaskWrapper> taskWrapperFactory)
        {
            var taskWrapper = taskWrapperFactory(Connect);
        }

        private void Connect()
        {
            //do something
        }
    }
}
