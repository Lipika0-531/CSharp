using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerConsoleApplication
{
    /// <summary>
    /// Income of the User.
    /// </summary>
    internal class Income : Transaction
    {
        /// <summary>
        /// Initializing Constructor for Income.
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="category">Category</param>
        /// <param name="amount">Amount</param>
        /// <param name="amountModes">AmountModes</param>
        /// <param name="note">Notes</param>
        /// <param name="account">Account</param>
        public Income(DateOnly date, string category, double amount, ModesOfCash amountModes,string note, int account = 0) 
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
