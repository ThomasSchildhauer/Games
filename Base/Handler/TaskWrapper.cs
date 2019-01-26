using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Handler
{
    public class TaskWrapper : ITaskWrapper
    {
        private readonly Action _task;

        public TaskWrapper(Action task)
        {
            _task = task;
        }
    }
}
