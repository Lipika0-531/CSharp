// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectA
{
    /// <summary>
    /// Program class acts as a base class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main class would call the greeting method
        /// </summary>
        /// <param name="args">string arguments</param>
        public static void Main(string[] args)
        {
            Greeting greet = new Greeting();
            greet.GreetingMsg();
            ProjectB.Program.MathematicalOperation();
        }
    }
}