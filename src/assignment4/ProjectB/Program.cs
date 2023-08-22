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
        /// Add function will perform addition operation
        /// </summary>
        /// <param name="x">x denotes variable x</param>
        /// <param name="y">y denotes variable y</param>
        /// <returns>it returns x + y</returns>
        public long Add()
        { 
            int x = ProjectCommon.Program.GetInputs("Enter x value");
            int y = ProjectCommon.Program.GetInputs("Enter y value");
            return (long)x + y;
        }
        /// <summary>
        /// Subtraction method would subtract two values
        /// </summary>
        /// <param name="x">x denotes variable x</param>
        /// <param name="y">y denotes variable y</param>
        /// <returns>subtract</returns>
        public long Subtract()
        {
            int x = ProjectCommon.Program.GetInputs("Enter x value");
            int y = ProjectCommon.Program.GetInputs("Enter y value");
            return (long)x - y;
        }

        /// <summary>
        /// Multiply method would multiply two values
        /// </summary>
        /// <param name="x">x denotes variable x</param>
        /// <param name="y">y denotes variable y</param>
        /// 
        public void Multiply()
        {
            int x = ProjectCommon.Program.GetInputs("Enter x value");
            int y = ProjectCommon.Program.GetInputs("Enter y value");
            
        }

        /// <summary>
        /// Divide method will divide the two values
        /// </summary>
        /// <param name="x">x denotes variable x</param>
        /// <param name="y">y denotes variable y</param>
        /// <returns>it returns division of two values</returns>
        public double Divide()
        {
            int x = ProjectCommon.Program.GetInputs("Enter x value");
            int y = ProjectCommon.Program.GetInputs("Enter y value");
            if (y == 0)
            {
                throw new DivideByZeroException();
            }

            return x / y;
        }
    }
}