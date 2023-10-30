using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.ComponentModel;

namespace ExpenseTrackerConsoleApplication
{
    /// <summary>
    /// Parsing Inputs.
    /// </summary>
    internal class Parser
    {
        /// <summary>
        /// Display messages in color.
        /// </summary>
        /// <param name="colorValue">ColorValue</param>
        /// <returns>ConsoleColor</returns>
        public ConsoleColor DisplayColor(int colorValue)
        {
            if (colorValue == 1)
            {
                return ConsoleColor.Cyan;
            }
            else if (colorValue == 2)
            {
                return ConsoleColor.Red;
            }
            else if (colorValue == 3)
            {
                return ConsoleColor.Yellow;
            }
            else if (colorValue == 4)
            {
                return ConsoleColor.Magenta;
            }
            else
            {
                return ConsoleColor.Green;
            }
        }

        /// <summary>
        /// Display Messages in color.
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="colorToBeDisplayed">ColorToBeDisplayed</param>
        public void DisplayMessages(string input = " ", int colorToBeDisplayed = 2)
        {
            var color = this.DisplayColor(colorToBeDisplayed);

            Console.ForegroundColor = color;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Validating Inputs.
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="input">Input</param>
        /// <param name="colorToBeDisplayed">ColorToBeDisplayed</param>
        /// <param name="errorMessage">ErrorMessage</param>
        /// <returns>T</returns>
        /// <exception cref="InvalidCastException">Exception</exception>
        public T ValidateInputs<T>(string input = "Enter Input", int colorToBeDisplayed = 3, string errorMessage = "Invalid Input")
        {
            var color = this.DisplayColor(colorToBeDisplayed);

            Console.ForegroundColor = color;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.White;

            string value = Console.ReadLine()!;

            while (string.IsNullOrEmpty(value) && TypeDescriptor.GetConverter(typeof(T)).IsValid(value))
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{errorMessage} Enter value : ");
                Console.ForegroundColor = ConsoleColor.White;

                value = Console.ReadLine()!;
            }
            return (T)Convert.ChangeType(value, typeof(T));

            throw new InvalidCastException();
        }
    }
}
