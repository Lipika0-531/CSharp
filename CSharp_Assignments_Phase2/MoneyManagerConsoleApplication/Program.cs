namespace MoneyManagerConsoleApplication
{
    internal class Program
    {
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