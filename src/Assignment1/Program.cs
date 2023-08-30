// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment1
{
    /// <summary>
    /// Program internal class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main class
        /// </summary>
        /// <param name="args"> arguments </param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the number (X) : ");
            string? input1 = Console.ReadLine();
            double x;
            while (!double.TryParse(input1, out x))
            {
                Console.Write("Input your value once again : ");
                input1 = Console.ReadLine();
            }

            Console.WriteLine("Enter the number (Y) : ");
            string? input2 = Console.ReadLine();
            double y;
            while (!double.TryParse(input2, out y))
            {
                Console.Write("Input your value once again : ");
                input2 = Console.ReadLine();
            }

            MathUtils myobj = new MathUtils();
            Console.WriteLine($"Addition: {myobj.Add(x, y)}");
            Console.WriteLine($"Subtraction: {myobj.Subtract(x, y)}");
            Console.WriteLine($"Multiply: {myobj.Multiply(x, y)}");
            try
            {
                double division = myobj.Divide(x, y);
                Console.WriteLine($"Divide: {division}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine($"Cannot divide by zero");
            }
        }
    }
}