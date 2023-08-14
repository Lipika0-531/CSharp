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
            if (string.IsNullOrEmpty(input1))
            {
                Console.WriteLine("value can't be empty! Input your value once more");
                input1 = Console.ReadLine();
            }
            Console.WriteLine("Enter the number (Y) : ");
            string? input2 = Console.ReadLine();
            if (string.IsNullOrEmpty(input2))
            {
                Console.WriteLine("value can't be empty! Input your value once more");
                input1 = Console.ReadLine();
            }
            int.TryParse(input1, out int x);
            int.TryParse(input2, out int y);
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