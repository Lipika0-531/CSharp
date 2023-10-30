using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerConsoleApplication
{
    /// <summary>
    /// Contains menu to be displayed.
    /// </summary>
    internal class MainMenu
    {
        /// <summary>
        /// Menu to be displayed.
        /// </summary>
        /// <returns>Task</returns>
        public async Task UserMenu()
        {
            Parser parser = new Parser();
            try
            {
                Services services = new Services();
                Login login = new Login();
                SignIn signIn = new SignIn();
                FileManager fileManager = new FileManager();


                User user = null;
                while (true)
                {
                    parser.DisplayMessages("Welcome to Money manager ! \n" +
                        "Choose any options below \n" +
                        "1. LogIn\n" +
                        "2. SignUp\n" +
                        "3. Add Expense\n" +
                        "4. Add Income\n" +
                        "5. View Expense\n" +
                        "6. View Income\n" +
                        "7. Update Expense \n" +
                        "8. Update Income \n" +
                        "9. Delete Expense \n" +
                        "10. Delete Income \n" +
                        "11. Statistics \n" +
                        "12. LogOut \n" +
                        "13. SignOut \n" +
                        "14. Exit", 1);
                    int.TryParse(Console.ReadLine(), out int choice);
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("LogIn");
                            string userNameToLogin = parser.ValidateInputs<string>("Enter User Name : ");
                            string passwordToLogin = parser.ValidateInputs<string>("Enter Password : ");
                            await login.LogIn(userNameToLogin, passwordToLogin);
                            break;
                        case 2:
                            Console.WriteLine("SignUp");
                            string userNameToSignUp = parser.ValidateInputs<string>("Enter UserName : ");
                            string passwordToSignUp = parser.ValidateInputs<string>("Enter Password : ");
                            userNameToSignUp = signIn.CheckIfUserNameUnique(userNameToSignUp);
                            user = signIn.UserSignIn(userNameToSignUp, passwordToSignUp);
                            foreach (var activeUsers in ActiveUsers.ActiveUsersList)
                            {
                                Console.WriteLine($"Active Users : {activeUsers.UserName}");
                            }

                            break;
                        case 3:
                            if (ActiveUsers.ActiveUsersList.Contains(user))
                            {
                                parser.DisplayMessages("Add Expense", 4);
                                Expense expenseToAdd = services.GetInputsForExpense();
                                user?.AddExpense(expenseToAdd);
                            }
                            else
                            {
                                parser.DisplayMessages("Login or SignUp !");
                            }

                            break;
                        case 4:
                            if (ActiveUsers.ActiveUsersList.Contains(user))
                            {
                                parser.DisplayMessages("Add Income !", 4);
                                Income incomeToAdd = services.GetInputsForIncome();
                                user?.AddIncome(incomeToAdd);
                            }
                            else
                            {
                                parser.DisplayMessages("Login or SignUp !");
                            }
                            break;
                        case 5:
                            if (ActiveUsers.ActiveUsersList.Contains(user))
                            {
                                parser.DisplayMessages("View Expense ", 4);
                                user?.ViewExpense(user);
                            }
                            else
                            {
                                parser.DisplayMessages("Login or SignUp !");
                            }
                            break;
                        case 6:
                            if (ActiveUsers.ActiveUsersList.Contains(user))
                            {
                                parser.DisplayMessages("View Income ", 4);
                                user?.ViewIncome(user);
                            }
                            else
                            {
                                parser.DisplayMessages("Login or SignUp !");
                            }
                            break;
                        case 7:
                            if (ActiveUsers.ActiveUsersList.Contains(user))
                            {
                                user.UpdatingValuesForUserExpense();
                            }
                            else
                            {
                                parser.DisplayMessages("Login or SignUp !");
                            }
                            break;
                        case 8:
                            if (ActiveUsers.ActiveUsersList.Contains(user))
                            {
                                user.UpdatingValuesForUserIncome();
                            }
                            else
                            {
                                parser.DisplayMessages("Login or SignUp !");
                            }
                            break;
                        case 9:
                            if (ActiveUsers.ActiveUsersList.Contains(user))
                            {
                                user?.DeleteExpense(user);
                            }
                            else
                            {
                                parser.DisplayMessages("Login or SignUp !");
                            }
                            break;
                        case 10:
                            if (ActiveUsers.ActiveUsersList.Contains(user))
                            {
                                user?.DeleteIncome(user);
                            }
                            else
                            {
                                parser.DisplayMessages("Login or SignUp !");
                            }
                            break;
                        case 11:
                            if (ActiveUsers.ActiveUsersList.Contains(user))
                            {
                                user?.ViewTotalExpense(user);
                                user?.ViewTotalIncome(user);
                            }
                            else
                            {
                                parser.DisplayMessages("Login or SignUp !");
                            }
                            break;
                        case 12:
                            if (ActiveUsers.ActiveUsersList.Contains(user))
                            {
                                parser.DisplayMessages("Logging out !", 4);
                                LogOut logOut = new LogOut();
                                await logOut.LogOutUser(user);
                            }
                            else
                            {
                                parser.DisplayMessages("Login or SignUp !");
                            }
                            break;
                        case 13:
                            if (ActiveUsers.ActiveUsersList.Contains(user))
                            {
                                parser.DisplayMessages("Signing Out !", 4);
                                SignOut signOut = new SignOut();
                                await signOut.SignOutFromUserList(user);
                                parser.DisplayMessages("Successfully Signed Out !");
                            }
                            else
                            {
                                parser.DisplayMessages("Login or SignUp !");
                            }

                            break;
                        case 14:
                            fileManager.WriteUserDetailsToFile(user);

                            ActiveUsers.ActiveUsersList.Clear();
                            ActiveUsers.ActiveUsersList.Clear();

                            Environment.Exit(0);
                            break;
                        default:
                            parser.DisplayMessages("Invalid Input !");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                parser.DisplayMessages($"Error: {ex}");
            }
        }
    }
}
