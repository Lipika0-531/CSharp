// <copyright file="ValidationMethods.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment5_task3
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// ValidationMethods class contains all the methods that have regex validations
    /// </summary>
    public class ValidationMethods
    {
        /// <summary>
        /// RegexValidation method contains all the regex validations
        /// </summary>
        /// <param name="res">validating input string</param>
        /// <param name="pattern">regex validator</param>
        /// <returns>the valid input</returns>
        public string RegexValidation(string res, string pattern)
        {
            while (string.IsNullOrEmpty(res) || !Regex.IsMatch(res, pattern))
            {
                Console.WriteLine("Enter valid numbers!");
                res = Console.ReadLine() !;
            }

            return res;
        }
    }
}