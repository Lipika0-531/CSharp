// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectC
{
    /// <summary>
    /// Program class is a base class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main class would print the details
        /// </summary>
        /// <param name="args">string arguments</param>
        public static void Main(string[] args)
        {
        }

        /// <summary>
        /// Print details would print the details
        /// </summary>
        /// <param name="name">name</param>
        public static void Print(string name)
        {
            Console.WriteLine($"{name}");
        }

        /// <summary>
        /// Add two integers
        /// </summary>
        public static void Addition()
        {
            Console.WriteLine($"The addition of two numbers is {ProjectCommon.Program.Add()}");
            ProjectE.Program.Name();
        }
    }
}