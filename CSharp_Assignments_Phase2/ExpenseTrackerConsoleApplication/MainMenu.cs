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
    public class MainMenu
    {
        UserAuthentication userAuthentication;
        FileManager fileManager;
        Services services;
        Category category;

        public MainMenu()
        {
            fileManager = new FileManager(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            category = new Category();
            services = new Services(category);
            userAuthentication = new UserAuthentication(fileManager, services, category);
        }

        /// <summary>
        /// Menu to be displayed.
        /// </summary>
        /// <returns>Task</returns>
        public async Task UserMenu()
        {
            try
            {
                
                string userData = string.Empty;
                User user = null!;

                string userNameToSignUp = string.Empty;
                string passwordToSignUp = string.Empty;
                ActiveUsers.ActiveUser = string.Empty;

                while (true)
                {
                    Parser.DisplayMessages(ConsoleColor.Cyan, "\nWelcome to Expense Tracker");
                    Parser.DisplayMessages(ConsoleColor.Cyan, "1. SignUp");
                    Parser.DisplayMessages(ConsoleColor.Cyan, "2. LogIn");
                    Parser.DisplayMessages(ConsoleColor.Cyan, "3. Add Income");
                    Parser.DisplayMessages(ConsoleColor.Cyan, "4. Add Expense");
                    Parser.DisplayMessages(ConsoleColor.Cyan, "5. View Income");
                    Parser.DisplayMessages(ConsoleColor.Cyan, "6. View Expense");
                    Parser.DisplayMessages(ConsoleColor.Cyan, "7. Update Income");
                    Parser.DisplayMessages(ConsoleColor.Cyan, "8. Update Expense");
                    Parser.DisplayMessages(ConsoleColor.Cyan, "9. Delete Income");
                    Parser.DisplayMessages(ConsoleColor.Cyan, "10. Delete Expense");
                    Parser.DisplayMessages(ConsoleColor.Cyan, "11. View Statistics");
                    Parser.DisplayMessages(ConsoleColor.Cyan, "12. LogOut");
                    Parser.DisplayMessages(ConsoleColor.Cyan, "13. Exit");

                    Console.Write("Choose option : ");

                    if (Enum.TryParse(Console.ReadLine(), out MenuOptions option))
                    {
                        switch (option)
                        {
                            case MenuOptions.SignUp:
                                Console.WriteLine("SignUp");
                                userNameToSignUp = Parser.ValidateInputs<string>(ConsoleColor.Yellow, "Enter UserName : ");
                                passwordToSignUp = Parser.ValidateInputs<string>(ConsoleColor.Yellow, "Enter Password : ");
                                userNameToSignUp = userAuthentication.CheckIfUserNameUnique(userNameToSignUp);
                                user = userAuthentication.UserSignIn(userNameToSignUp, passwordToSignUp, fileManager);

                                Console.WriteLine($"Active Users : {ActiveUsers.ActiveUser}");
                                break;
                            case MenuOptions.LogIn:
                                Console.WriteLine("LogIn");
                                string userNameToLogin = Parser.ValidateInputs<string>(ConsoleColor.Yellow, "Enter User Name : ");
                                string passwordToLogin = Parser.ValidateInputs<string>(ConsoleColor.Yellow, "Enter Password : ");
                                User userLogin = new User(userNameToLogin, passwordToLogin, category, services);
                                await userAuthentication.LogIn(userNameToLogin, passwordToLogin, userLogin);
                                user = userLogin;

                                ActiveUsers.ActiveUser = user.UserName;

                                break;
                            case MenuOptions.AddIncome:
                                if (ActiveUsers.ActiveUser == user!.UserName)
                                {
                                    Parser.DisplayMessages(ConsoleColor.Yellow, "Add Income");
                                    Income incomeToAdd = services.GetPropertiesOfIncome();
                                    user?.AddIncome(incomeToAdd);
                                }
                                else
                                {
                                    Parser.DisplayMessages(ConsoleColor.Red, "Login or SignUp !");
                                }

                                break;
                            case MenuOptions.AddExpense:

                                if (ActiveUsers.ActiveUser == user!.UserName)
                                {
                                    Parser.DisplayMessages(ConsoleColor.Yellow, "Add Income");
                                    Expense expenseToAdd = services.GetPropertiesOfExpense();
                                    user?.AddExpense(expenseToAdd);
                                }
                                else
                                {
                                    Parser.DisplayMessages(ConsoleColor.Red, "Login or SignUp !");
                                }
                                break;
                            case MenuOptions.ViewIncomes:
                                if (ActiveUsers.ActiveUser == user!.UserName)
                                {
                                    Parser.DisplayMessages(ConsoleColor.Yellow, "View Income ");
                                    user?.ViewIncome(user);
                                }
                                else
                                {
                                    Parser.DisplayMessages(ConsoleColor.Red, "Login or SignUp !");
                                }
                                break;
                            case MenuOptions.ViewExpenses:
                                if (ActiveUsers.ActiveUser == user!.UserName)
                                {
                                    Parser.DisplayMessages(ConsoleColor.Yellow, "View Expense ");
                                    user?.ViewExpense(user);
                                }
                                else
                                {
                                    Parser.DisplayMessages(ConsoleColor.Red, "Login or SignUp !");
                                }

                                break;
                            case MenuOptions.UpdateIncomes:
                                if (ActiveUsers.ActiveUser == user!.UserName)
                                {
                                    user.UpdatingValuesForUserIncome();
                                }
                                else
                                {
                                    Parser.DisplayMessages(ConsoleColor.Red, "Login or SignUp !");
                                }
                                break;
                            case MenuOptions.UpdateExpenses:
                                if (ActiveUsers.ActiveUser == user!.UserName)
                                {
                                    user.UpdatingValuesForExpense();
                                }
                                else
                                {
                                    Parser.DisplayMessages(ConsoleColor.Red, "Login or SignUp !");
                                }
                                break;
                            case MenuOptions.RemoveIncome:
                                if (ActiveUsers.ActiveUser == user!.UserName)
                                {
                                    user?.DisplayDeleteMessageForIncome(user);
                                }
                                else
                                {
                                    Parser.DisplayMessages(ConsoleColor.Red, "Login or SignUp !");
                                }
                                break;
                            case MenuOptions.RemoveExpense:
                                if (ActiveUsers.ActiveUser == user!.UserName)
                                {
                                    user?.DisplayDeleteMessageForExpense(user);
                                }
                                else
                                {
                                    Parser.DisplayMessages(ConsoleColor.Red, "Login or SignUp !");
                                }
                                break;
                            case MenuOptions.ViewStatistic:
                                if (ActiveUsers.ActiveUser == user!.UserName)
                                {
                                    user?.ViewTotalExpense(user);
                                    user?.ViewTotalIncome(user);
                                }
                                else
                                {
                                    Parser.DisplayMessages(ConsoleColor.Red, "Login or SignUp !");
                                }
                                break;
                            case MenuOptions.LogOut:
                                if (ActiveUsers.ActiveUser == user!.UserName)
                                {
                                    Parser.DisplayMessages(ConsoleColor.Magenta, "Logging out !");

                                    await userAuthentication.LogOut(user);
                                    fileManager.WriteSignInDetailsToFile(user);

                                }
                                else
                                {
                                    Parser.DisplayMessages(ConsoleColor.Red, "Login or SignUp !");
                                }
                                break;
                            case MenuOptions.Exit:
                                Parser.DisplayMessages(ConsoleColor.Green, $"ThankYou {user!.UserName}");
                                Environment.Exit(0);
                                break;
                            default:
                                Parser.DisplayMessages(ConsoleColor.Red, "Invalid Input !");
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Parser.DisplayMessages(ConsoleColor.Red,$"Error: {ex}");
            }
        }
    }
}
