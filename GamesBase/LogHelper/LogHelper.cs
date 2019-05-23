using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GamesBase.LogHelper
{
    public class LogHelper
    {
        public static log4net.ILog GetNewLogger([CallerFilePath]string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }
    }
}
