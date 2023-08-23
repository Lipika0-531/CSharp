// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectCommon
{
    /// <summary>
    /// Program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main class is the base class
        /// </summary>
        /// <param name="args">arguments</param>
        public static void Main(string[] args)
        {
        }

        /// <summary>
        /// Add function will perform addition operation
        /// </summary>
        /// <param name="x">x denotes variable x</param>
        /// <param name="y">y denotes variable y</param>
        /// <returns> Addition </returns>
        public static int Add()
        {
            int x = GetInputs("Enter x value");
            int y = GetInputs("Enter y value");
            return x + y;
        }

        /// <summary>
        /// Get Inputs would get inputs from the user
        /// </summary>
        /// <param name="msg">string message</param>
        /// <returns>message</returns>
        public static int GetInputs(string msg)
        {
            Console.WriteLine(msg);
            int x;
            string? input1 = Console.ReadLine();
            if (string.IsNullOrEmpty(input1))
            {
                Console.WriteLine("value can't be empty! Input your value once more");
                input1 = Console.ReadLine();
            }

            int.TryParse(input1, out x);
            return x;
        }
    }
}