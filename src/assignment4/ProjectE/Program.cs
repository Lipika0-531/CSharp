// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectE
{
    /// <summary>
    /// Program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main class
        /// </summary>
        /// <param name="args">arguments</param>
        public static void Main(string[] args)
        {
        }

        /// <summary>
        /// Name method
        /// </summary>
        public static void Name()
        {
            string? name;
            Console.WriteLine("Enter your Name : ");
            name = Console.ReadLine() !;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(name);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}