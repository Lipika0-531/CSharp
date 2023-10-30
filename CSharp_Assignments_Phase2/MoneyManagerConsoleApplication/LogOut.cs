using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerConsoleApplication
{
    /// <summary>
    /// Represents User LogOut.
    /// </summary>
    internal class LogOut
    {
        Parser parser = new Parser();

        /// <summary>
        /// User LogOut.
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        /// <returns>Task</returns>
        public async Task LogOutUser(User user)
        {
            if(ActiveUsers.ActiveUsersList.Contains(user))
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
                    ActiveUsers.ActiveUsersList.Remove(user);
                    parser.DisplayMessages($"Successfully Logged out ! \n ThankYou {user.UserName}", 5);

                    Thread.Sleep(100);
                });
                Console.Write('\n');
            }
            else
            {
                parser.DisplayMessages("No User found !");
            }
            
            return;
        }
    }
}
