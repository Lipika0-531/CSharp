// <copyright file="MemoryEater.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment7
{
    /// <summary>
    /// MemoreEater class is iniatiated
    /// </summary>
    public class MemoryEater
    {
#pragma warning disable SX1309 // Field names should begin with underscore
        private List<int[]> memAlloc = new List<int[]>();
#pragma warning restore SX1309 // Field names should begin with underscore
        /// <summary>
        /// Allocate method is iniatiated to allocate the memory
        /// </summary>
        public void Allocate()
        {
            try
            {
                while (true)
                {
                    this.memAlloc.Add(new int[1000000000]);
                    Thread.Sleep(1000);
                    Console.WriteLine("File added!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Due to memory leak, we have to delete the first 2 task, Enter Y is proceed and N to exit");
                string? value = Console.ReadLine();
                if (value == "Y" || value == "y")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        this.memAlloc.RemoveAt(0);
                    }
                }
                else if (value == "N" || value == "n")
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}