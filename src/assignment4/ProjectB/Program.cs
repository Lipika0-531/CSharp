// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectB
{
    /// <summary>
    /// Program internal class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main class
        /// </summary>
        /// <param name="args"> arguments </param>
        public static void Main(string[] args)
        {
            /*MathUtils myobj = new MathUtils();*/
        }

        /// <summary>
        /// MathematicalOperation()
        /// </summary>
        public static void MathematicalOperation()
        {
            Console.WriteLine("For Addition");
            Add();
            Console.WriteLine("For Division");
            try
            {
                Divide();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine($"Cannot divide by zero");
            }

            Console.WriteLine("For Subtraction");
            Subtract();
            Console.WriteLine("For Multiplication");
            Multiply();
            ProjectC.Program.Addition();
        }

        /// <summary>
        /// Add function will perform addition operation
        /// </summary>
        /// <param name="x">x denotes variable x</param>
        /// <param name="y">y denotes variable y</param>
        public static void Add()
        {
            ProjectC.Program.Print($"addition result is {ProjectCommon.Program.Add()}");
        }

        /// <summary>
        /// Subtraction method would subtract two values
        /// </summary>
        /// <param name="x">x denotes variable x</param>
        /// <param name="y">y denotes variable y</param>
        public static void Subtract()
        {
            int x = ProjectCommon.Program.GetInputs("Enter x value");
            int y = ProjectCommon.Program.GetInputs("Enter y value");
            ProjectC.Program.Print($"subtraction of {x} and {y} is {x - y}");
        }

        /// <summary>
        /// Multiply method would multiply two values
        /// </summary>
        /// <param name="x">x denotes variable x</param>
        /// <param name="y">y denotes variable y</param>
        ///
        public static void Multiply()
        {
            int x = ProjectCommon.Program.GetInputs("Enter x value");
            int y = ProjectCommon.Program.GetInputs("Enter y value");
            ProjectC.Program.Print($"multiplication of {x} and {y} is {x * y}");
        }

        /// <summary>
        /// Divide method will divide the two values
        /// </summary>
        /// <param name="x">x denotes variable x</param>
        /// <param name="y">y denotes variable y</param>
        public static void Divide()
        {
            int x = ProjectCommon.Program.GetInputs("Enter x value");
            int y = ProjectCommon.Program.GetInputs("Enter y value");
            if (y == 0)
            {
                throw new DivideByZeroException();
            }
            else
            {
                ProjectC.Program.Print($"division of {x} and {y} is {x / y}");
            }
        }
    }
}