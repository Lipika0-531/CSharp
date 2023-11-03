using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpenseTrackerConsoleApplication
{
    public class Constants
    {
        public static Regex regexForDate = new Regex(@"^(19|20)\d{2}\/(0[1-9]|1[0,1,2])\/(0[1-9]|[12][0-9]|3[01])$");

        public static Regex regexForAmount = new Regex(@"^(?!-)[0-9]+[.]?[0-9]*$");

        public static Regex regexForModes = new Regex(@"^[1-2]$");

        public static Regex regexForAccountNumber = new Regex(@"^[0-9]{0,7}$");
    }
}
