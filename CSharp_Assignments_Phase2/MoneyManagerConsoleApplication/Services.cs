using ConsoleTables;
using static MoneyManager.User;

namespace MoneyManagerConsoleApplication
{
    internal class Services
    {
        Parser parser = new Parser();
        public Expense GetInputsForExpense()
        {
            DateOnly date = DateOnly.Parse(parser.ValidateInputs<string>("Enter Date (yyyy/mm/dd) : ").ToString());

            var category = GetCategory();

            var amountMode = parser.ValidateInputs<int>("Choose Mode of cash : 1. ECash \n2.Cash : ");
            if (amountMode == 1)
            {
                AmountModes.modes = AmountModes.ModesOfCash.ECash;
            }
            else
            {
                AmountModes.modes = AmountModes.ModesOfCash.Cash;
            }

            var amount = parser.ValidateInputs<double>("Enter amount : ");

            var account = parser.ValidateInputs<int>("Enter Account Number : ");

            var note = parser.ValidateInputs<string>("Enter notes : ");

            var newExpense = new Expense(date, category, amount, AmountModes.modes, account, note);
            return newExpense;

        }
        public Income GetInputsForIncome()
        {
            DateOnly date = DateOnly.Parse(parser.ValidateInputs<string>("Enter Date (yyyy/mm/dd) : "));

            var category = GetCategory();

            var amountMode = parser.ValidateInputs<int>("Choose Mode of cash : 1. ECash \n2.Cash : ");
            if (amountMode == 1)
            {
                AmountModes.modes = AmountModes.ModesOfCash.ECash;
            }
            else
            {
                AmountModes.modes = AmountModes.ModesOfCash.Cash;
            }

            var amount = parser.ValidateInputs<double>("Enter amount : ");

            var account = parser.ValidateInputs<int>("Enter account Number : ");

            var note = parser.ValidateInputs<string>("Enter notes : ");

            var newIncome = new Income(date, category, amount, AmountModes.modes, account, note);
            return newIncome;
        }

        public string GetCategory()
        {
            foreach (var categoryValue in Category.Categories)
            {
                Console.WriteLine(categoryValue);
            }

            var category = parser.ValidateInputs<string>("Choose category from the above options : ");
            while (!Category.Categories.Contains(category))
            {
                category = parser.ValidateInputs<string>("Enter category was not found, Please enter valid category : ");
            }
            return category;
        }

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
