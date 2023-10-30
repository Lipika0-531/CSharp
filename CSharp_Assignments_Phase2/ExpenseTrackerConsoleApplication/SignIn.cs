using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerConsoleApplication
{
    /// <summary>
    /// User SignIn.
    /// </summary>
    internal class SignIn
    {
        Parser parser = new Parser();

        /// <summary>
        /// users will have user list.
        /// </summary>
        public static Dictionary<string, User> users = new Dictionary<string, User>();

        /// <summary>
        /// Add user.
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="password">Password</param>
        /// <returns>Added User</returns>
        public User UserSignIn(string userName, string password)
        {
            var addUser = new User(userName, password);
            ActiveUsers.ActiveUsersList.Add(addUser);
            users[userName] = addUser;
            return addUser;
        }

        /// <summary>
        /// Check userName is unique.
        /// </summary>
        /// <param name="userName">userName</param>
        /// <returns>string</returns>
        public string CheckIfUserNameUnique(string userName)
        {
            while (users.ContainsKey(userName))
            {
                userName = parser.ValidateInputs<string>("UserName already taken, Enter valid UserName : ");
            }
            return userName;
        }
    }
}
