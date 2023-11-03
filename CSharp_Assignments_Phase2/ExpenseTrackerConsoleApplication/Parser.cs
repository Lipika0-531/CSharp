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
    public class Parser
    {

        /// <summary>
        /// Display Messages in color.
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="colorToBeDisplayed">ColorToBeDisplayed</param>
        public static void DisplayMessages(Enum ConsoleColor, string input = " ")
        {
            Console.ForegroundColor = (ConsoleColor)ConsoleColor;
            Console.WriteLine(input);
            Console.ForegroundColor = System.ConsoleColor.White;
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
        public static T ValidateInputs<T>(Enum ConsoleColor, string input = "Enter Input", string errorMessage = "Invalid Input")
        {
            DisplayMessages(System.ConsoleColor.Yellow, input);

            string value = Console.ReadLine()!;

            while (string.IsNullOrWhiteSpace(value) && TypeDescriptor.GetConverter(typeof(T)).IsValid(value))
            {
                DisplayMessages(System.ConsoleColor.Yellow, $"{errorMessage} Enter value : ");

                value = Console.ReadLine()!;
            }
            return (T)Convert.ChangeType(value, typeof(T));

            throw new InvalidCastException();
        }

        public static T ValidateInputsUsingRegex<T>(Regex regex, Enum ConsoleColor, string input = "Enter Input", string errorMessage = "Invalid Input")
        {
            DisplayMessages(System.ConsoleColor.Yellow, input);

            string? value = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(value) || !regex.IsMatch(value))
            {
                Console.Write($"{errorMessage}\nTry again : ");

                value = Console.ReadLine()!;
            }

            return (T)Convert.ChangeType(value, typeof(T));

            throw new InvalidCastException();
        }
    }
}
