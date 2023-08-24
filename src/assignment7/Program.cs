// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment7
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main class
        /// </summary>
        /// <param name="args">arguments</param>
        public static void Main(string[] args)
        {
            MemoryEater me = new MemoryEater();
            me.Allocate();
            Console.WriteLine("Completed!");
            Console.ReadKey();
        }
    }
}