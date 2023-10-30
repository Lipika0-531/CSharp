using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerConsoleApplication
{
    internal class SignOut
    {
        Parser parser = new Parser();
        public async Task SignOutFromUserList(User user)
        {
            if (ActiveUsers.ActiveUsersList.Contains(user))
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
