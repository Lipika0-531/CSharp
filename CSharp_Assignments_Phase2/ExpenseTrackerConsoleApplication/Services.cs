using ConsoleTables;
using static ExpenseTrackerConsoleApplication.User;

namespace ExpenseTrackerConsoleApplication
{
    /// <summary>
    /// Income and Expense services.
    /// </summary>
    internal class Services
    {
        Parser parser = new Parser();

        /// <summary>
        /// Get inputs for Expense.
        /// </summary>
        /// <returns>Expense</returns>
        public Expense GetInputsForExpense()
        {
            try
            {
                DateOnly date = DateOnly.Parse(parser.ValidateInputs<string>("Enter Date (yyyy/mm/dd) : ").ToString());

                var category = GetCategory();

                var amountMode = parser.ValidateInputs<int>("Choose Mode of cash : \n1. ECash \n2.Cash : ");

                int account = 0;
                ModesOfCash AmountMode;
                if (amountMode == 1)
                {
                    AmountMode = ModesOfCash.ECash;
                    account = parser.ValidateInputs<int>("Enter Account Number : ");
                }
                else
                {
                    AmountMode = ModesOfCash.Cash;
                }
                var amount = parser.ValidateInputs<double>("Enter amount : ");

                var note = parser.ValidateInputs<string>("Enter notes : ");

                var newExpense = new Expense(date, category, amount, AmountMode, note, account);
                return newExpense;
            }
            catch (Exception ex)
            {
                parser.DisplayMessages(ex.Message);
                return default;
            }
        }

        /// <summary>
        /// Get Inputs for income.
        /// </summary>
        /// <returns>Income</returns>
        public Income GetInputsForIncome()
        {
            try
            {
                DateOnly date = DateOnly.Parse(parser.ValidateInputs<string>("Enter Date (yyyy/mm/dd) : "));

                var category = GetCategory();

                int account = 0;

                var amountMode = parser.ValidateInputs<int>("Choose Mode of cash : \n1. ECash \n2.Cash : ");
                ModesOfCash AmountMode;

                if (amountMode == 1)
                {
                    AmountMode = ModesOfCash.ECash;
                    account = parser.ValidateInputs<int>("Enter Account Number : ");

                }
                else
                {
                    AmountMode = ModesOfCash.Cash;
                }

                var amount = parser.ValidateInputs<double>("Enter amount : ");

                var note = parser.ValidateInputs<string>("Enter notes : ");

                var newIncome = new Income(date, category, amount, AmountMode, note, account);
                return newIncome;
            }
            catch (Exception ex)
            {
                parser.DisplayMessages(ex.Message);
                return default;
            }

        }

        /// <summary>
        /// Get category for expense and income.
        /// </summary>
        /// <returns>string</returns>
        public string GetCategory()
        {
            ConsoleTable categoryTable = new("Categories Available ");
            foreach (var categoryValue in Category.Categories)
            {
                categoryTable.AddRow(categoryValue);
            }
            categoryTable.Write();
            var category = parser.ValidateInputs<string>("Choose category from the above options : ");
            while (!Category.Categories.Contains(category))
            {
                category = parser.ValidateInputs<string>("Enter category was not found, Please enter valid category : ");
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
            foreach (var updateValue in Enum.GetValues(typeof(UpdateAttributes)))
            {
                Console.WriteLine($"{i} . {updateValue}");
                i++;
            }
            int.TryParse(Console.ReadLine(), out int choice);
            return choice;
        }
    }
}
