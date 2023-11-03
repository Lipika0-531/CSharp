using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerConsoleApplication
{
    internal interface ILogger
    {
        public void LogErrors(string message);
    }
}
