using ConsoleTables;
using static ExpenseTrackerConsoleApplication.User;

namespace ExpenseTrackerConsoleApplication
{
    /// <summary>
    /// Income and Expense services.
    /// </summary>
    public class Services
    {
        Category category;
        public Services( Category categoryInstance)
        {
            category = categoryInstance;
        }

        /// <summary>
        /// Get inputs for Expense.
        /// </summary>
        /// <returns>Expense</returns>
        public Expense GetPropertiesOfExpense()
        {
            try
            {
                DateOnly date = DateOnly.Parse(Parser.ValidateInputs<string>(ConsoleColor.Yellow, "Enter Date (yyyy/mm/dd) : ").ToString());

                var category = GetCategory();

                var amountMode = Parser.ValidateInputs<int>(ConsoleColor.Yellow, "Choose Mode of cash : \n1. ECash \n2.Cash : ");

                int account = 0;
                ModesOfCash AmountMode;
                if (amountMode == 1)
                {
                    AmountMode = ModesOfCash.ECash;
                    account = Parser.ValidateInputs<int>(ConsoleColor.Yellow, "Enter Account Number : ");
                }
                else
                {
                    AmountMode = ModesOfCash.Cash;
                }
                var amount = Parser.ValidateInputs<double>(ConsoleColor.Yellow, "Enter amount : ");

                var note = Parser.ValidateInputs<string>(ConsoleColor.Yellow, "Enter notes : ");

                var newExpense = new Expense(date, category, account, AmountMode, note, amount);
                return newExpense;
            }
            catch (Exception ex)
            {
                Parser.DisplayMessages(ConsoleColor.Red, ex.Message);
                return default!;
            }
        }

        /// <summary>
        /// Get Inputs for income.
        /// </summary>
        /// <returns>Income</returns>
        public Income GetPropertiesOfIncome()
        {
            try
            {
                DateOnly date = DateOnly.Parse(Parser.ValidateInputs<string>(ConsoleColor.Yellow, "Enter Date (yyyy/mm/dd) : "));

                var category = GetCategory();

                int account = 0;

                var amountMode = Parser.ValidateInputs<int>(ConsoleColor.Yellow, "Choose Mode of cash : \n1. ECash \n2.Cash : ");
                ModesOfCash AmountMode;

                if (amountMode == 1)
                {
                    AmountMode = ModesOfCash.ECash;
                    account = Parser.ValidateInputs<int>(ConsoleColor.Yellow, "Enter Account Number : ");

                }
                else
                {
                    AmountMode = ModesOfCash.Cash;
                }

                var amount = Parser.ValidateInputs<double>(ConsoleColor.Yellow, "Enter amount : ");

                var note = Parser.ValidateInputs<string>(ConsoleColor.Yellow, "Enter notes : ");

                var newIncome = new Income(date, category, account,AmountMode, note, amount);
                return newIncome;
            }
            catch (Exception ex)
            {
                Parser.DisplayMessages(ConsoleColor.Red, ex.Message);
                return default!;
            }

        }

        /// <summary>
        /// Get category for expense and income.
        /// </summary>
        /// <returns>string</returns>
        public string GetCategory()
        {
            ConsoleTable categoryTable = new("Category Available ");
            foreach (var categoryValue in this.category.Categories)
            {
                categoryTable.AddRow(categoryValue);
            }
            categoryTable.Write();

            var category = Parser.ValidateInputs<string>(ConsoleColor.Yellow, "Choose category from the above options : ");

            while (!this.category.Categories.Contains(category))
            {
                category = Parser.ValidateInputs<string>(ConsoleColor.Magenta, "Enter category was not found, Please enter valid category : ");
            }
            return category;
        }

        /// <summary>
        /// Menu for updating values.
        /// </summary>
        /// <returns>int</returns>
        public int UpdateMenu()
        {
            int i = 1;
            Console.WriteLine("Choose which to update : ");
            foreach (var updateValue in Enum.GetValues(typeof(Attributes)))
            {
                Console.WriteLine($"{i} . {updateValue}");
                i++;
            }
            int.TryParse(Console.ReadLine(), out int choice);
            return choice;
        }
    }
}
