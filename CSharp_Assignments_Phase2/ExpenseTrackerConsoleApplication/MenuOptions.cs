using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerConsoleApplication
{
    /// <summary>
    /// Represents the Menu options of the current user.
    /// </summary>
    public enum MenuOptions
    {
        /// <summary>
        /// To SignUp with userName and Password.
        /// </summary>
        SignUp = 1,

        /// <summary>
        /// To LogIn with userName and Password.
        /// </summary>
        LogIn = 2, 

        /// <summary>
        /// To add new income to the current user income list.
        /// </summary>
        AddIncome = 3,

        /// <summary>
        /// To add new expense to the current user expense list.
        /// </summary>
        AddExpense = 4,

        /// <summary>
        /// To view all the incomes.
        /// </summary>
        ViewIncomes = 5,

        /// <summary>
        /// To view all the expenses.
        /// </summary>
        ViewExpenses = 6,

        /// <summary>
        /// To Update the income from current user income list.
        /// </summary>
        UpdateIncomes = 7,

        /// <summary>
        /// To Update the expense from the current user expense list.
        /// </summary>
        UpdateExpenses = 8,

        /// <summary>
        /// To remove income from the current user income list.
        /// </summary>
        RemoveIncome = 9,

        /// <summary>
        /// To remove expense from the current user expense list.
        /// </summary>
        RemoveExpense = 10,

        /// <summary>
        /// Displays statistics of income and expense.
        /// </summary>
        ViewStatistic = 11,

        /// <summary>
        /// Logging Out from ACtiver user.
        /// </summary>
        LogOut = 12,

        /// <summary>
        /// To exit the application.
        /// </summary>
        Exit = 13,
    }
}
