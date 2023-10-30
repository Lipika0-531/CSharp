using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MoneyManagerConsoleApplication
{
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

        public string UserName { get; }
        public Password Password { get; }
        public List<Income> Incomes { get; }
        public List<Expense> Expenses { get; }

        public void AddIncome(Income income)
        {
            Incomes.Add(income);
            parser.DisplayMessages("Income Successfully Added !",5);
        }

        public void AddExpense(Expense expense)
        {
            Expenses.Add(expense);
            parser.DisplayMessages("Expense Successfully Added !",5);
        }

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
       
        public void UpdatingValuesForUserExpense()
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
            }
            int choice = services.UpdateMenu();
            if (choice <= 6)
            {
                switch (choice)
                {
                    case 1:
                        DateOnly updatedDate = DateOnly.Parse(parser.ValidateInputs<string>("Enter Date to be Updated : "));
                        this.Expenses[countTobeUpdated - 1].DateOnly = updatedDate;
                        parser.DisplayMessages($"Value Updated to {updatedDate}",5);
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
                            this.Expenses[countTobeUpdated - 1].AmountMode = AmountModes.ModesOfCash.ECash;
                        }
                        else
                        {
                            this.Expenses[countTobeUpdated - 1].AmountMode = AmountModes.ModesOfCash.Cash;
                        }
                        parser.DisplayMessages($"Value Updated to {amountupdatedAmountModeMode}",5);
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

        public void UpdatingValuesForUserIncome()
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
            }
            int choice = services.UpdateMenu();
            if (choice <= 6)
            {
                switch (choice)
                {
                    case 1:
                        DateOnly updatedDate = DateOnly.Parse(parser.ValidateInputs<string>("Enter Date to be Updated : "));
                        this.Incomes[countTobeUpdated - 1].DateOnly = updatedDate;
                        parser.DisplayMessages($"Value Updated to {updatedDate}",5);
                        break;
                    case 2:
                        var updatedAmount = parser.ValidateInputs<double>("Enter Amount to be Updated : ");
                        this.Incomes[countTobeUpdated - 1].Amount = updatedAmount;
                        parser.DisplayMessages($"Value Updated to {updatedAmount}",5);
                        break;
                    case 3:
                        var amountupdatedAmountModeMode = parser.ValidateInputs<int>("Choose Mode of cash : 1. ECash \n2.Cash : ");
                        if (amountupdatedAmountModeMode == 1)
                        {
                            this.Incomes[countTobeUpdated - 1].AmountMode = AmountModes.ModesOfCash.ECash;
                        }
                        else
                        {
                            this.Incomes[countTobeUpdated - 1].AmountMode = AmountModes.ModesOfCash.Cash;
                        }
                        parser.DisplayMessages($"Value Updated to {amountupdatedAmountModeMode}",5);
                        break;
                    case 4:
                        var category = services.GetCategory();
                        Category.CategoryValue = category;
                        parser.DisplayMessages($"Value Updated to {category}",5);
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

        public void DeleteIncome(User user)
        {
            if (SignIn.users.ContainsKey(user.UserName))
            {
                // Incomes.Remove(Incomes.ToString());
            }
        }

        public void DeleteExpense(User user)
        {
            if (SignIn.users.ContainsKey(user.UserName))
            {
                SignIn.users.Remove(user.UserName);
            }
        }
    }
}
