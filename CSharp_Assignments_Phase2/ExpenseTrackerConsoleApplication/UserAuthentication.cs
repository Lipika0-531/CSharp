
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerConsoleApplication
{
    public class UserAuthentication
    {
        volatile int isLoggedIn = 0;
        FileManager fileManager;
        Services services;
        Category category;

        public UserAuthentication(FileManager fileManagerInstance, Services serviceInstance, Category categoryInstance)
        {
            fileManager = fileManagerInstance;
            services = serviceInstance;
            category = categoryInstance;
        }

        /// <summary>
        /// User logIn.
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        /// <returns>Task</returns>
        public async Task LogIn(string userName, string password, User user)
        {

            if (fileManager.LogInDetailsToFile(userName, password, user))
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

                    Parser.DisplayMessages(ConsoleColor.Green, $"Successfully Logged in ! \n Welcome {userName}");
                    Thread.Sleep(100);
                });
            }
            else
            {
                Parser.DisplayMessages(ConsoleColor.Red, "No User found ! \nTry Signing In or Try again! :)");
            }
        }

        /// <summary>
        /// User LogOut.
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        /// <returns>Task</returns>
        public async Task LogOut(User user)
        {
            if (ActiveUsers.ActiveUser != null)
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
                    ActiveUsers.ActiveUser = null;
                    Parser.DisplayMessages(ConsoleColor.Green, $"Successfully Logged out ! \n ThankYou {user.UserName}");

                    Thread.Sleep(100);
                });
                Console.Write('\n');
            }
            else
            {
                Parser.DisplayMessages(ConsoleColor.Red, "No User found !");
            }

            return;
        }

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
        public User UserSignIn(string userName, string password, FileManager fileManager)
        {
            var addUser = new User(userName, password, category, services);
            ActiveUsers.ActiveUser = addUser.UserName;
            fileManager.WriteSignInDetailsToFile(addUser);
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
                userName = Parser.ValidateInputs<string>(ConsoleColor.Yellow, "UserName already taken, Enter valid UserName : ");
            }
            return userName;
        }
    }
}
