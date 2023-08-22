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
            string? uppercase = ProjectD.Utility.Display();
            uppercase = uppercase.ToUpper();
            Console.WriteLine($"The Name you entered is {uppercase} ");
        }

        /*public static void MethodCall()
        {
            Con*//*sole.WriteLine($"Addition: {ProjectB.Program.add()}");
        }*/
    }
}