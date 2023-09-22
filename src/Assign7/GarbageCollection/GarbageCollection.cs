// <copyright file="GarbageCollection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GarbageCollection
{
    /// <summary>
    /// GarbageCollection class which contains a method to implement garbage collection
    /// </summary>
    public class GarbageCollection
    {
        /// <summary>
        /// Garbage method creates and destroys a large number of objects
        /// </summary>
        public static void Garbage()
        {
            for (int i = 0; i < 100000; i++)
            {
                object obj = new object();
                obj = null;
            }

            Console.WriteLine("press any key to start GC...");
            Console.ReadKey();
            GC.Collect();
        }
    }
}