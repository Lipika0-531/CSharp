// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment7
{
    /// <summary>
    /// Program class is the base class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main class is initiated
        /// </summary>
        /// <param name="args">Console Line arguments</param>
        public static void Main(string[] args)
        {
            MemoryEater me = new MemoryEater();
            me.Allocate();
            Console.WriteLine("Completed!");
            Console.ReadKey();
        }
    }
}