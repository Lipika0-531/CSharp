﻿// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Errorhandling
{
    /// <summary>
    /// Program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main class
        /// </summary>
        /// <param name="args">arguments</param>
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Eventhandler);
            Operations.GetInputs();
        }

        private static void Eventhandler(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Unhandled exceptions");
        }
    }

    /// <summary>
    /// InvalidUserInputException
    /// </summary>
    public class InvalidUserInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class.
        /// InvalidUserInputException
        /// </summary>
        /// <param name="innerException">innerException</param>
        /// <param name="message">message</param>
        public InvalidUserInputException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Operation class
    /// </summary>
    public class Operations
    {
        /// <summary>
        /// GetInputs
        /// </summary>
        public static void GetInputs()
        {
            Console.WriteLine("Task 1: Understanding and Using try/catch/finally blocks");
            Console.WriteLine("Enter x value :");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter y value :");
            int y = Convert.ToInt32(Console.ReadLine());
            Operations operations = new Operations();
            double value;
            try
            {
                value = Operations.Divide(x, y);
                Console.WriteLine($"Result : {value}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine($"Any value is not divisible by zero");
            }
            finally
            {
                Console.WriteLine("The DivideByZeroException task was executed");
            }

            Console.WriteLine("Task 2: Catching and Throwing Different Types of Exceptions");
            Console.WriteLine("Enter the index value");
            try
            {
                value = Operations.ArrayInteger();
                Console.WriteLine($"Result of adding all the values : {value}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Index entered to out of range");
            }
            catch (InvalidUserInputException ex)
            {
                Console.WriteLine($"Invalid input value");
            }
            finally
            {
                Console.WriteLine("The IndexOutOfRangeException task got executed");
            }
        }

        /// <summary>
        /// Divide exception
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>exception</returns>
        /// <exception cref="DivideByZeroException">exception.</exception>
        public static double Divide(int x, int y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException();
            }

            return x / y;
        }

        /// <summary>
        /// ArrayInteger() method return InvalidUserInputException
        /// </summary>
        /// <returns>exception</returns>
        /// <exception cref="InvalidUserInputException">InvalidUserInputException</exception>
        /// <exception cref="IndexOutOfRangeException">IndexOutOfRangeException</exception>
        public static int ArrayInteger()
        {
            int index = 0;
            try
            {
                index = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                throw new InvalidUserInputException("invalid exception", new Exception());
            }

            int[] arr = new int[10];
            int add = 0;
            if (index < arr.Length)
            {
                for (int i = 0; i < index; i++)
                {
                    arr[i] = i;
                    add += arr[i];
                    Console.WriteLine(arr[i]);
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

            return add;
        }
    }
}