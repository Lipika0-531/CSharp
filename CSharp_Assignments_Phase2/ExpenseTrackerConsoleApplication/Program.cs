namespace ExpenseTrackerConsoleApplication
{
    /// <summary>
    /// Driver class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Driver method.
        /// </summary>
        /// <returns>Task</returns>
        public static async Task Main()
        {
            try
            {
                MainMenu mainMenu = new MainMenu();
                await mainMenu.UserMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}