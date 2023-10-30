using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static MoneyManager.AmountModes;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace MoneyManagerConsoleApplication
{
    internal class Parser
    {
        public ConsoleColor DisplayColor(int colorValue)
        {
            if(colorValue == 1)
            {
                return ConsoleColor.Cyan;
            }
            else if (colorValue == 2)
            {
                return ConsoleColor.Red;
            }
            else if(colorValue == 3)
            {
                return ConsoleColor.Yellow;
            }
            else if( colorValue == 4)
            {
                return ConsoleColor.Magenta;
            }
            else
            {
                return ConsoleColor.Green;
            }
        }

        public void DisplayMessages(string input = " ", int colorToBeDisplayed = 2)
        {
            var color = this.DisplayColor(colorToBeDisplayed);

            Console.ForegroundColor = color;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public T ValidateInputs<T>( string input = "Enter Input", int colorToBeDisplayed = 3, string errorMessage = "Invalid Input")
        {
            var color = this.DisplayColor(colorToBeDisplayed);

            Console.ForegroundColor = color;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.White;


            string value = Console.ReadLine() !;

            try
            {
                while (string.IsNullOrWhiteSpace(value))
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{errorMessage} Enter value : ");
                    Console.ForegroundColor = ConsoleColor.White;

                    value = Console.ReadLine()!;
                }
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error : {ex.Message}", ex);
                Console.ForegroundColor = ConsoleColor.White;

                return default!;
            }
        }
    }
}
