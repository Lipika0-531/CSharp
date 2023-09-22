// <copyright file="Greeting.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectA
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Greeting class would send greeting message
    /// </summary>
    internal class Greeting
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Greeting"/> class.
        /// Greeting
        /// </summary>
        public void GreetingMsg()
        {
            string? name;
            Console.WriteLine("Enter your Name");
            name = Console.ReadLine();
            string pattern = "^[A-Za-z]+$";
            while (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, pattern))
            {
                Console.WriteLine("Value can't be empty, reenter it");
                name = Console.ReadLine() !;
            }

            Console.WriteLine($"Welcome to Math World! {name}");
        }
    }
}
