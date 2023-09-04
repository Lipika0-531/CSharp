// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GarbageCollection
{
    /// <summary>
    /// Program class for GarbageCollection
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main class to initiate the garbage collection method
        /// </summary>
        /// <param name="args">arguments passed</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Press any key to enter garbage collection");
            Console.ReadKey();
            GarbageCollection.Garbage();

            Console.WriteLine("press any key to Exit..");
            Console.ReadKey();
        }
    }
}