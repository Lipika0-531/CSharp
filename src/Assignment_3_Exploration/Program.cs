// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Assignment_3_Exploration
{
    using Newtonsoft.Json;

    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method where the program starts
        /// </summary>
        /// <param name="args">Argument</param>
        public static void Main(string[] args)
        {
            var json = @"{""Name"":""Lipika"",""ID"":""24018"",""Number"": ""9597629825""}";
            Product? p = JsonConvert.DeserializeObject<Product>(json) !;
            Console.WriteLine(p.Name);
        }
    }
}
