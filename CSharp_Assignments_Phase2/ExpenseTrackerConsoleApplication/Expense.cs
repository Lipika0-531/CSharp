using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerConsoleApplication
{
    /// <summary>
    /// Expense of the User.
    /// </summary>
    internal class Expense : Transaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class.
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="category">Category</param>
        /// <param name="amount">Amount</param>
        /// <param name="amountModes">AmountModes</param>
        /// <param name="note">Notes</param>
        /// <param name="account">Account</param>
        public Expense(DateOnly date, string category, double amount, ModesOfCash amountModes, string note, int account = 0)
        {
            DateOnly = date;
            Category.CategoryValue = category;
            Amount = amount;
            AmountMode = amountModes;
            Account = account;
            Note = note;
        }
    }
}
