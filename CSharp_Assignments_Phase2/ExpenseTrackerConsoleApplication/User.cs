using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExpenseTrackerConsoleApplication
{
    /// <summary>
    /// Define user.
    /// </summary>
    internal partial class User
    {
        Parser parser = new Parser();
        public User(string userName, string password)
        {
            UserName = userName;
            Password = new Password(password);
            Incomes = new List<Income>();
            Expenses = new List<Expense>();
        }

        /// <summary>
        /// Get UserName.
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// Get Password.
        /// </summary>
        public Password Password { get; }

        /// <summary>
        /// Get Incomes.
        /// </summary>
        public List<Income> Incomes { get; }

        /// <summary>
        /// Get Expenses.
        /// </summary>
        public List<Expense> Expenses { get; }

        /// <summary>
        /// Adding Income.
        /// </summary>
        /// <param name="income">Income</param>
        public void AddIncome(Income income)
        {
            Incomes.Add(income);
            parser.DisplayMessages("Income Successfully Added !", 5);
        }

        /// <summary>
        /// Adding Expense.
        /// </summary>
        /// <param name="expense">Expense</param>
        public void AddExpense(Expense expense)
        {
            Expenses.Add(expense);
            parser.DisplayMessages("Expense Successfully Added !", 5);
        }

        /// <summary>
        /// View Expense.
        /// </summary>
        /// <param name="user">User</param>
        public void ViewExpense(User user)
        {
            if (user.Expenses != null)
            {
                Console.WriteLine($"Expense Table : \nUserName : {user.UserName}");
                ConsoleTable viewExpenseTable = new ConsoleTable("Date", "Amount", "Mode of cash", "Category", "Account", "Notes");
                foreach (var value in this.Expenses)
                {
                    viewExpenseTable.AddRow(value.DateOnly.ToString(), value.Amount, value.AmountMode.ToString(), Category.CategoryValue, value.Account, value.Note);
                }
                viewExpenseTable.Write();
            }
            else
            {
                parser.DisplayMessages("No expense Added !");
            }
        }

        public void ViewTotalExpense(User user)
        {
            double totalExpense = 0;
            if (user.Expenses != null && user.Expenses.Count > 0)
            {
                foreach (var value in this.Expenses)
                {
                    totalExpense += value.Amount;
                }

                parser.DisplayMessages($"Total expense: {totalExpense}");
            }
            else
            {
                parser.DisplayMessages("No expense Added !");
            }
        }

        public void ViewTotalIncome(User user)
        {
            double totalIncome = 0;
            if (user.Incomes != null && user.Expenses.Count > 0)
            {
                foreach (var value in this.Incomes)
                {
                    totalIncome += value.Amount;
                }
                parser.DisplayMessages($"Total Income: {totalIncome}");
            }
            else
            {
                parser.DisplayMessages("No Income Added !");
            }
        }

        /// <summary>
        /// View Income.
        /// </summary>
        /// <param name="user">User</param>
        public void ViewIncome(User user)
        {
            if (user.Incomes != null)
            {
                Console.WriteLine($"Income Table : \nUserName : {user.UserName}");
                ConsoleTable viewIncomeTable = new ConsoleTable("Date", "Amount", "Amount Mode ", "Category", "Account", "Notes");
                foreach (var value in user.Incomes)
                {
                    viewIncomeTable.AddRow(value.DateOnly.ToString(), value.Amount, value.AmountMode.ToString(), Category.CategoryValue, value.Account, value.Note);
                }
                viewIncomeTable.Write();
            }
            else
            {
                parser.DisplayMessages("No expense Added !");
            }

        }

        Services services = new Services();

        /// <summary>
        /// Update Expense.
        /// </summary>
        public void UpdatingValuesForUserExpense()
        {
            try
            {

                int i = 1;
                int countTobeUpdated = 0;
                if (this.Expenses.Count > 0)
                {
                    ConsoleTable userMenuTableForUpdate = new("S.No", "Date", "Amount", " Amount Mode", "Category", " Account", " Notes");
                    foreach (var value in this.Expenses)
                    {
                        userMenuTableForUpdate.AddRow(i, value.DateOnly, value.Amount, value.AmountMode, Category.CategoryValue, value.Account, value.Note);
                        i++;
                    }
                    userMenuTableForUpdate.Write();


                    countTobeUpdated = parser.ValidateInputs<int>("Choose which expense data to be updated :");
                }
                else
                {
                    parser.DisplayMessages("No Expenses ! Please add expense to update !");
                    return;
                }
                int choice = services.UpdateMenu();
                if (choice <= 6)
                {
                    switch (choice)
                    {
                        case 1:
                            DateOnly updatedDate = DateOnly.Parse(parser.ValidateInputs<string>("Enter Date to be Updated : "));
                            this.Expenses[countTobeUpdated - 1].DateOnly = updatedDate;
                            parser.DisplayMessages($"Value Updated to {updatedDate}", 5);
                            break;
                        case 2:
                            var updatedAmount = parser.ValidateInputs<double>("Enter Amount to be Updated : ");
                            this.Expenses[countTobeUpdated - 1].Amount = updatedAmount;
                            parser.DisplayMessages($"Value Updated to {updatedAmount}", 5);
                            break;
                        case 3:
                            var amountupdatedAmountModeMode = parser.ValidateInputs<int>("Choose Mode of cash : 1. ECash \n2.Cash : ");
                            if (amountupdatedAmountModeMode == 1)
                            {
                                this.Expenses[countTobeUpdated - 1].AmountMode = ModesOfCash.ECash;
                            }
                            else
                            {
                                this.Expenses[countTobeUpdated - 1].AmountMode = ModesOfCash.Cash;
                            }
                            parser.DisplayMessages($"Value Updated to {amountupdatedAmountModeMode}", 5);
                            break;
                        case 4:
                            var category = services.GetCategory();
                            Category.CategoryValue = category;
                            parser.DisplayMessages($"Value Updated to {category}", 5);
                            break;
                        case 5:
                            var updatedAccountNumber = parser.ValidateInputs<int>("Enter Account Number : ");
                            this.Expenses[countTobeUpdated - 1].Account = updatedAccountNumber;
                            parser.DisplayMessages($"Value Updated to {updatedAccountNumber}", 5);
                            break;
                        case 6:
                            var updatedNotes = parser.ValidateInputs<string>("Enter Notes : ");
                            this.Expenses[countTobeUpdated - 1].Note = updatedNotes;
                            parser.DisplayMessages($"Value Updated to {updatedNotes}", 5);
                            break;
                        default:
                            parser.DisplayMessages("Invalid Input !");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                parser.DisplayMessages(ex.Message);
            }
        }

        /// <summary>
        /// Update Income.
        /// </summary>
        public void UpdatingValuesForUserIncome()
        {
            try
            {
                int i = 1;
                int countTobeUpdated = 0;
                if (this.Incomes.Count > 0)
                {
                    ConsoleTable userMenuTableForUpdate = new("S.No", "Date", "Amount", " Amount Mode", "Category", " Account", " Notes");
                    foreach (var value in this.Incomes)
                    {
                        userMenuTableForUpdate.AddRow(i, value.DateOnly, value.Amount, value.AmountMode, Category.CategoryValue, value.Account, value.Note);
                        i++;
                    }
                    userMenuTableForUpdate.Write();


                    countTobeUpdated = parser.ValidateInputs<int>("Choose which Income data to be updated :");
                }
                else
                {
                    parser.DisplayMessages("No Incomes ! Please add Income to update !");
                    return;
                }
                int choice = services.UpdateMenu();
                if (choice <= 6)
                {
                    switch (choice)
                    {
                        case 1:
                            DateOnly updatedDate = DateOnly.Parse(parser.ValidateInputs<string>("Enter Date to be Updated : "));
                            this.Incomes[countTobeUpdated - 1].DateOnly = updatedDate;
                            parser.DisplayMessages($"Value Updated to {updatedDate}", 5);
                            break;
                        case 2:
                            var updatedAmount = parser.ValidateInputs<double>("Enter Amount to be Updated : ");
                            this.Incomes[countTobeUpdated - 1].Amount = updatedAmount;
                            parser.DisplayMessages($"Value Updated to {updatedAmount}", 5);
                            break;
                        case 3:
                            var amountupdatedAmountModeMode = parser.ValidateInputs<int>("Choose Mode of cash : 1. ECash \n2.Cash : ");
                            if (amountupdatedAmountModeMode == 1)
                            {
                                this.Incomes[countTobeUpdated - 1].AmountMode = ModesOfCash.ECash;
                            }
                            else
                            {
                                this.Incomes[countTobeUpdated - 1].AmountMode = ModesOfCash.Cash;
                            }
                            parser.DisplayMessages($"Value Updated to {amountupdatedAmountModeMode}", 5);
                            break;
                        case 4:
                            var category = services.GetCategory();
                            Category.CategoryValue = category;
                            parser.DisplayMessages($"Value Updated to {category}", 5);
                            break;
                        case 5:
                            var updatedAccountNumber = parser.ValidateInputs<int>("Enter Account Number : ");
                            this.Incomes[countTobeUpdated - 1].Account = updatedAccountNumber;
                            parser.DisplayMessages($"Value Updated to {updatedAccountNumber}", 5);
                            break;
                        case 6:
                            var updatedNotes = parser.ValidateInputs<string>("Enter Notes : ");
                            this.Incomes[countTobeUpdated - 1].Note = updatedNotes;
                            parser.DisplayMessages($"Value Updated to {updatedNotes}", 5);
                            break;
                        default:
                            parser.DisplayMessages("Invalid Input !");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                parser.DisplayMessages(ex.Message);
            }
        }

        /// <summary>
        /// Delete Income.
        /// </summary>
        /// <param name="user">User</param>
        public void DeleteIncome(User user)
        {
            int i = 1;
            int countTobeUpdated = 0;
            if (this.Incomes.Count > 0)
            {
                ConsoleTable userMenuTableForDelete = new("S.No", "Date", "Amount", " Amount Mode", "Category", " Account", " Notes");
                foreach (var value in this.Incomes)
                {
                    userMenuTableForDelete.AddRow(i, value.DateOnly, value.Amount, value.AmountMode, Category.CategoryValue, value.Account, value.Note);
                    i++;
                }
                userMenuTableForDelete.Write();

                countTobeUpdated = parser.ValidateInputs<int>("Choose which Income data to be Deleted :");

                Incomes.Remove(user.Incomes[countTobeUpdated - 1]);
                parser.DisplayMessages("Successfully Deleted !", 5);
            }
            else
            {
                parser.DisplayMessages("No Incomes ! Please add Income to Delete !");
            }
        }

        /// <summary>
        /// Delete Expense.
        /// </summary>
        /// <param name="user">User</param>
        public void DeleteExpense(User user)
        {
            int i = 1;
            int countTobeUpdated = 0;
            if (this.Expenses.Count > 0)
            {
                ConsoleTable userMenuTableForDelete = new("S.No", "Date", "Amount", " Amount Mode", "Category", " Account", " Notes");
                foreach (var value in this.Expenses)
                {
                    userMenuTableForDelete.AddRow(i, value.DateOnly, value.Amount, value.AmountMode, Category.CategoryValue, value.Account, value.Note);
                    i++;
                }
                userMenuTableForDelete.Write();

                countTobeUpdated = parser.ValidateInputs<int>("Choose which Expense data to be Deleted :");

                Expenses.Remove(user.Expenses[countTobeUpdated - 1]);
                parser.DisplayMessages("Successfully Deleted !", 5);
            }
            else
            {
                parser.DisplayMessages("No Expenses ! Please add Expense to delete !");
            }
        }
    }
}
