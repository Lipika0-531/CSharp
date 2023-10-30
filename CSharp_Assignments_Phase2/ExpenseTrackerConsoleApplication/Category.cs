using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerConsoleApplication
{
    /// <summary>
    /// List of Category to be updated later.
    /// </summary>
    internal class Category
    {
        /// <summary>
        /// List of Categories available.
        /// </summary>
        public static List<string> Categories = new List<string>() { "Groceries", "Food", "Electronics", "Beauty"};

        /// <summary>
        /// Value of particular category.
        /// </summary>
        public static string? CategoryValue { get; set; }
    }
}
