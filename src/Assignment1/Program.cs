using System.Text.RegularExpressions;
using System.Xml.Linq;

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
            string pattern = "^[0-9]+$";
            while (string.IsNullOrWhiteSpace(input1) || !Regex.IsMatch(input1, pattern))
            {
                Console.WriteLine("value must be numbers Input your value once more");
                input1 = Console.ReadLine();
            }

            Console.WriteLine("Enter the number (Y) : ");
            string? input2 = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input2) || !Regex.IsMatch(input2, pattern))
            {
                Console.WriteLine("value can't be empty! Input your value once more");
                input2 = Console.ReadLine();
            }
            double.TryParse(input1, out double x);
            double.TryParse(input2, out double y);
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