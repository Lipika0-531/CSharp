using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager
{
    /// <summary>
    /// Signing Out.
    /// </summary>
    internal class SignOut
    {
        Parser parser = new Parser();

        /// <summary>
        /// Signing Out From User List.
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Task</returns>
        public async Task SignOutFromUserList(User user)
        {
            if (ActiveUsers.activeUsers.Contains(user))
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
                    ActiveUsers.activeUsers.Remove(user);
                    SignIn.users.Remove(user.UserName);

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
