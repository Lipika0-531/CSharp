using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerConsoleApplication
{
    /// <summary>
    /// List of Category to be updated later.
    /// </summary>
    internal class Category
    {
        /// <summary>
        /// List of Categories available.
        /// </summary>
#pragma warning disable SA1401 // Fields should be private
        public static List<string> Categories = new List<string>() { "Groceries", "Food", "Electronics", "Beauty"};
#pragma warning restore SA1401 // Fields should be private

        /// <summary>
        /// Value of particular category.
        /// </summary>
#pragma warning disable SA1609 // Property documentation should have value
        public static string? CategoryValue { get; set; }
#pragma warning restore SA1609 // Property documentation should have value
    }
}
