using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager
{
    /// <summary>
    /// List of Category to be updated later.
    /// </summary>
    internal class Category
    {
        /// <summary>
        /// List of categories available.
        /// </summary>
        public static List<string> categories = new List<string>() { "Groceries", "Food", "Electronics", "Beauty"};

        /// <summary>
        /// Value of particular category.
        /// </summary>
        public static string? CategoryValue { get; set; }
    }
}
