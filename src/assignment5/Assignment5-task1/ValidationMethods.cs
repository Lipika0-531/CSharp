// <copyright file="ValidationMethods.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment5_task1
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
        /// <param name="result">validating input string</param>
        /// <param name="pattern">regex validator</param>
        /// <returns>the valid input</returns>
        public string RegexValidation(string result, string pattern)
        {
            while (string.IsNullOrEmpty(result) || !Regex.IsMatch(result, pattern))
            {
                Console.WriteLine("Enter valid values!");
                result = Console.ReadLine() !;
            }

            return result;
        }
    }
}