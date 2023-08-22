namespace ProjectCommon
{
    /// <summary>
    /// Program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main class is the base class
        /// </summary>
        /// <param name="args">arguments</param>
        public static void Main(string[] args)
        {
        }

        /// <summary>
        /// Get Inputs would get inputs from the user
        /// </summary>
        /// <param name="msg">string message</param>
        /// <returns>message</returns>
        public static int GetInputs(string msg)
        {
            Console.WriteLine(msg);
            int x;
            string? input1 = Console.ReadLine();
            if (string.IsNullOrEmpty(input1))
            {
                Console.WriteLine("value can't be empty! Input your value once more");
                input1 = Console.ReadLine();
            }

            int.TryParse(input1, out x);
            return x;
        }
    }
}