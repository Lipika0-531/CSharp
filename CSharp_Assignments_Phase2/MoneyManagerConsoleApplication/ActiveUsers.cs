using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerConsoleApplication
{
    /// <summary>
    /// Users that are active currently.
    /// </summary>
    internal class ActiveUsers
    {
        /// <summary>
        /// List of users that are active.
        /// </summary>
#pragma warning disable SA1401 // Fields should be private
        public static List<User> ActiveUsersList = new List<User>();
#pragma warning restore SA1401 // Fields should be private
    }
}
