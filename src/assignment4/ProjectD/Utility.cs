using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectD
{
    /// <summary>
    /// Utility class is base class
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Display method would display the entered details
        /// </summary>
        /// <returns>string</returns>
        public static string Display()
        {
            string? name;
            Console.WriteLine("Enter your Name : ");
            name = Console.ReadLine()!;
            return name;
        }
    }
}
