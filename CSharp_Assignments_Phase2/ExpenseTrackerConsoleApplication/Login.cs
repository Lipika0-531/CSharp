using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerConsoleApplication
{
    /// <summary>
    /// Represents User Login.
    /// </summary>
    internal class Login
    {
        Parser parser = new Parser();

        /// <summary>
        /// User logIn.
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        /// <returns>Task</returns>
        public async Task LogIn(string userName, string password)
        {
            if(SignIn.users.ContainsKey(userName) && SignIn.users[userName].Password.PasswordChecker(password))
            {
                int i = 0;
                await Task.Run(() =>
                {
                    while (i <= 3)
                    {
                        Console.Write(".");
                        Thread.Sleep(1000);
                        i++;
                    }
                    ActiveUsers.ActiveUsersList.Add(SignIn.users[userName]);
                    parser.DisplayMessages($"Successfully Logged in ! \n Welcome {SignIn.users[userName]}", 5);
                    Thread.Sleep(100);
                });

            }
            else 
            {
                parser.DisplayMessages("No User found ! \nTry Signing In or Try again! :)");
            }
        }
    }
}
