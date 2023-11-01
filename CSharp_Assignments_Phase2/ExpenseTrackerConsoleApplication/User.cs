using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExpenseTrackerConsoleApplication
{
    /// <summary>
    /// Define user.
    /// </summary>
    public partial class User
    {
        Category category;
        Services services;
        public User()
        {

        }
        public User(string userName, string password, Category categoryInstance, Services serviceInstance)
        {
            UserName = userName;
            Password = new Password(password);
            Incomes = new List<Income>();
            Expenses = new List<Expense>();
            category = categoryInstance;
            services = serviceInstance;
        }

        /// <summary>
        /// Get UserName.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Get Password.
        /// </summary>
        public Password Password { get; set; }

        /// <summary>
        /// Get Incomes.
        /// </summary>
        public List<Income> Incomes { get; set; }

        /// <summary>
        /// Get Expenses.
        /// </summary>
        public List<Expense> Expenses { get; set; }

        /// <summary>
        /// Adding Income.
        /// </summary>
        /// <param name="income">Income</param>
        public void AddIncome(Income income)
        {
            Incomes.Add(income);
            Parser.DisplayMessages(ConsoleColor.Green, "Income Successfully Added !");
        }

        /// <summary>
        /// Adding Expense.
        /// </summary>
        /// <param name="expense">Expense</param>
        public void AddExpense(Expense expense)
        {
            Expenses.Add(expense);
            Parser.DisplayMessages(ConsoleColor.Green, "Expense Successfully Added !");
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
                    viewExpenseTable.AddRow(value.DateOnly.ToString(), value.Amount, value.AmountMode.ToString(), value.Category, value.Account, value.Note);
                }
                viewExpenseTable.Write();
            }
            else
            {
                Parser.DisplayMessages(ConsoleColor.Red, "No expense Added !");
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
                    viewIncomeTable.AddRow(value.DateOnly.ToString(), value.Amount, value.AmountMode.ToString(), value.Category, value.Account, value.Note);
                }
                viewIncomeTable.Write();
            }
            else
            {
                Parser.DisplayMessages(ConsoleColor.Red, "No expense Added !");
            }

        }

        public double ViewTotalExpense(User user)
        {
            double totalExpense = 0;
            if (user.Expenses.Count > 0)
            {
                foreach (var value in this.Expenses)
                {
                    totalExpense += value.Amount;
                }

                for(int i = 0; i < totalExpense; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(" ");
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Parser.DisplayMessages(ConsoleColor.Magenta, $"Total expense: {totalExpense}");
                Console.ForegroundColor = ConsoleColor.White;
                return totalExpense;
            }
            else
            {
                Parser.DisplayMessages(ConsoleColor.Red, "No expense Added !");
                return default;
            }
        }

        public double ViewTotalIncome(User user)
        {
            double totalIncome = 0;
            if (user.Incomes != null && user.Incomes.Count > 0)
            {
                foreach (var value in this.Incomes)
                {
                    totalIncome += value.Amount;
                }

                for (int i = 0; i < totalIncome; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Parser.DisplayMessages(ConsoleColor.Magenta, $"Total Income: {totalIncome}");
                Console.ForegroundColor = ConsoleColor.White;
                return totalIncome;
            }
            else
            {
                Parser.DisplayMessages(ConsoleColor.Red, "No Income Added !");
                return default;
            }
        }


        /// <summary>
        /// Update Expense.
        /// </summary>
        public void UpdatingValuesForExpense()
        {
            try
            {
                int indexToUpdate = this.IndexForExpense("Choose which Expense to be updated :");
                int choice = services.UpdateMenu();
                int accountNumber = 0;
                if (choice <= 6)
                {
                    switch (choice)
                    {
                        case 1:
                            DateOnly date = DateOnly.Parse(Parser.ValidateInputs<string>(ConsoleColor.Yellow, "Enter Date to be Updated : "));
                            this.UpdateDateForExpense(indexToUpdate, date);
                            Parser.DisplayMessages(ConsoleColor.Yellow, $"Value Updated to {date}");
                            break;
                        case 2:
                            var amount = Parser.ValidateInputs<double>(ConsoleColor.Yellow, "Enter Amount to be Updated : ");
                            this.UpdateAmountForExpense(indexToUpdate, amount);
                            Parser.DisplayMessages(ConsoleColor.Yellow, $"Value Updated to {amount}");
                            break;
                        case 3:
                            var amountMode = Parser.ValidateInputs<int>(ConsoleColor.Yellow, "Choose Mode of cash : 1.ECash \n2.Cash : ");
                            if (amountMode == 1)
                            {
                                UpdateModeOfCashForExpense(indexToUpdate, ModesOfCash.ECash);
                                accountNumber = Parser.ValidateInputs<int>(ConsoleColor.Yellow, "Enter Account Number : ");
                                this.UpdateAccountNumberForExpense(indexToUpdate, accountNumber);
                            }
                            else
                            {
                                this.UpdateModeOfCashForExpense(indexToUpdate, ModesOfCash.Cash);
                            }
                            Parser.DisplayMessages(ConsoleColor.Yellow, $"Value Updated to {amountMode}");
                            break;
                        case 4:
                            var category = services.GetCategory();
                            this.UpdateCategoryForExpense(indexToUpdate, category);
                            Parser.DisplayMessages(ConsoleColor.Yellow, $"Value Updated to {category}");
                            break;
                        case 5:
                            if(accountNumber != 0)
                            {
                                var accountNumberToUpdate = Parser.ValidateInputs<int>(ConsoleColor.Yellow, "Enter Account Number : ");
                                this.UpdateAccountNumberForExpense(indexToUpdate, accountNumberToUpdate);

                                Parser.DisplayMessages(ConsoleColor.Yellow, $"Value Updated to {accountNumberToUpdate}");
                            }
                            break;
                        case 6:
                            var notes = Parser.ValidateInputs<string>(ConsoleColor.Yellow, "Enter Notes : ");
                            this.UpdateNotesForExpense(indexToUpdate, notes);
                            Parser.DisplayMessages(ConsoleColor.Yellow, $"Value Updated to {notes}");
                            break;
                        default:
                            Parser.DisplayMessages(ConsoleColor.Red, "Invalid Input !");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Parser.DisplayMessages(ConsoleColor.Red, ex.Message);
            }
        }

        /// <summary>
        /// Gets the index for the expense.
        /// </summary>
        /// <param name="message">message</param>
        /// <returns>index</returns>
        public int IndexForExpense(string message)
        {
            int i = 1;
            int countTobeUpdated = 0;
            if (this.Expenses.Count > 0)
            {
                ConsoleTable userMenuTable = new("S.No", "Date", "Amount", " Amount Mode", "Category", " Account", " Notes");
                foreach (var value in this.Expenses)
                {
                    userMenuTable.AddRow(i, value.DateOnly, value.Amount, value.AmountMode, value.Category, value.Account, value.Note);
                    i++;
                }
                userMenuTable.Write();

                countTobeUpdated = Parser.ValidateInputs<int>(ConsoleColor.Yellow, message);
            }
            else
            {
                Parser.DisplayMessages(ConsoleColor.Red, "No Expense ! Please add Expense to update !");
                return default;
            }

            return countTobeUpdated;
        }



        /// <summary>
        /// Update the date for expense.
        /// </summary>
        /// <param name="indexToUpdate">index</param>
        /// <param name="dateToUpdate">date</param>
        public void UpdateDateForExpense(int indexToUpdate, DateOnly dateToUpdate)
        {
            this.Expenses[indexToUpdate - 1].DateOnly = dateToUpdate;
        }

        /// <summary>
        /// Update the amount for expense
        /// </summary>
        /// <param name="indexToUpdate">index</param>
        /// <param name="amountToUpdate">amount</param>
        public void UpdateAmountForExpense(int indexToUpdate, double amountToUpdate)
        {
            this.Expenses[indexToUpdate - 1].Amount = amountToUpdate;
        }

        /// <summary>
        /// Update the mode of cash for expense.
        /// </summary>
        /// <param name="indexToUpdate">index</param>
        /// <param name="modes">mode</param>
        public void UpdateModeOfCashForExpense(int indexToUpdate, ModesOfCash modes)
        {
            this.Expenses[indexToUpdate - 1].AmountMode = modes;
        }

        /// <summary>
        /// Update the account number for expense.
        /// </summary>
        /// <param name="indexToUpdate">index</param>
        /// <param name="accountNumberToUpdate">account</param>
        public void UpdateAccountNumberForExpense(int indexToUpdate, int accountNumberToUpdate)
        {
            this.Expenses[indexToUpdate - 1].Account = accountNumberToUpdate;

        }

        /// <summary>
        /// Update the category for expense.
        /// </summary>
        /// <param name="indexToUpdate">index</param>
        /// <param name="categoryToUpdate"><category/param>
        public void UpdateCategoryForExpense(int indexToUpdate, string categoryToUpdate)
        {
            this.Expenses[indexToUpdate - 1].Category = categoryToUpdate;
        }

        /// <summary>
        /// Update the note for expense.
        /// </summary>
        /// <param name="indexToUpdate">index</param>
        /// <param name="notesToUpdate">note</param>
        public void UpdateNotesForExpense(int indexToUpdate, string notesToUpdate)
        {
            this.Expenses[indexToUpdate - 1].Note = notesToUpdate;
        }

        /// <summary>
        /// Update Income.
        /// </summary>
        public void UpdatingValuesForUserIncome()
        {
            try
            {
                int indexToUpdate = this.IndexForIncome("Choose which Income to be updated :");
                int choice = services.UpdateMenu();
                int accountNumberToUpdate = 0;
                if (choice <= 6)
                {
                    switch (choice)
                    {
                        case 1:
                            DateOnly date = DateOnly.Parse(Parser.ValidateInputs<string>(ConsoleColor.Yellow, "Enter Date to be Updated : "));
                            this.UpdateDateForIncome(indexToUpdate, date);
                            Parser.DisplayMessages(ConsoleColor.Yellow, $"Value Updated to {date}");
                            break;
                        case 2:
                            var amount = Parser.ValidateInputs<double>(ConsoleColor.Yellow, "Enter Amount to be Updated : ");
                            this.UpdateAmountForIncome(indexToUpdate, amount);
                            Parser.DisplayMessages(ConsoleColor.Yellow, $"Value Updated to {amount}");
                            break;
                        case 3:
                            var amountMode = Parser.ValidateInputs<int>(ConsoleColor.Yellow, "Choose Mode of cash : 1. ECash \n2.Cash : ");
                            if (amountMode == 1)
                            {
                                UpdateModeOfCashForIncome(indexToUpdate,ModesOfCash.ECash );
                                accountNumberToUpdate = Parser.ValidateInputs<int>(ConsoleColor.Yellow, "Enter Account Number : ");
                                this.UpdateAccountNumberForIncome(indexToUpdate, accountNumberToUpdate);
                            }
                            else
                            {
                                this.UpdateModeOfCashForIncome(indexToUpdate, ModesOfCash.Cash);
                            }
                            Parser.DisplayMessages(ConsoleColor.Yellow, $"Value Updated to {amountMode}");
                            break;
                        case 4:
                            var category = services.GetCategory();
                            this.UpdateCategoryForIncome(indexToUpdate, category);
                            Parser.DisplayMessages(ConsoleColor.Yellow, $"Value Updated to {category}");
                            break;
                        case 5:
                            if(accountNumberToUpdate != 0)
                            {
                                var accountNumber = Parser.ValidateInputs<int>(ConsoleColor.Yellow, "Enter Account Number : ");
                                this.UpdateAccountNumberForIncome(indexToUpdate, accountNumber);
                                Parser.DisplayMessages(ConsoleColor.Yellow, $"Value Updated to {accountNumber}");
                            }
                            break;
                        case 6:
                            var note = Parser.ValidateInputs<string>(ConsoleColor.Yellow, "Enter Notes : ");
                            this.UpdateNotesForIncome(indexToUpdate, note);
                            Parser.DisplayMessages(ConsoleColor.Yellow, $"Value Updated to {note}");
                            break;
                        default:
                            Parser.DisplayMessages(ConsoleColor.Red, "Invalid Input !");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Parser.DisplayMessages(ConsoleColor.Red, ex.Message);
            }
        }

        /// <summary>
        /// Update the date for income
        /// </summary>
        /// <param name="indexToUpdate">index</param>
        /// <param name="dateToUpdate">date</param>

        public void UpdateDateForIncome(int indexToUpdate, DateOnly dateToUpdate)
        {
            this.Incomes[indexToUpdate - 1].DateOnly = dateToUpdate;
        }

        /// <summary>
        /// Update amount for income
        /// </summary>
        /// <param name="indexToUpdate"><index/param>
        /// <param name="amountToUpdate">amount</param>
        public void UpdateAmountForIncome(int indexToUpdate, double amountToUpdate)
        {
            this.Incomes[indexToUpdate - 1].Amount = amountToUpdate;
        }

        /// <summary>
        /// Update the mode of cash for income.
        /// </summary>
        /// <param name="indexToUpdate">index</param>
        /// <param name="mode">mode</param>
        public void UpdateModeOfCashForIncome(int indexToUpdate, ModesOfCash mode)
        {
            this.Incomes[indexToUpdate - 1].AmountMode = mode;
        }

        /// <summary>
        /// Update the accountNumber for income.
        /// </summary>
        /// <param name="indexToUpdate">index</param>
        /// <param name="accountNumberToUpdate">accountNumber</param>
        public void UpdateAccountNumberForIncome(int indexToUpdate, int accountNumberToUpdate)
        {
            this.Incomes[indexToUpdate - 1].Account = accountNumberToUpdate;

        }

        /// <summary>
        /// Update the category for income.
        /// </summary>
        /// <param name="indexToUpdate">index</param>
        /// <param name="categoryToUpdate">category</param>
        public void UpdateCategoryForIncome(int indexToUpdate, string categoryToUpdate)
        {
            this.Incomes[indexToUpdate - 1].Category = categoryToUpdate;
        }

        /// <summary>
        /// Update the note for income.
        /// </summary>
        /// <param name="indexToUpdate">index</param>
        /// <param name="notesToUpdate">note</param>
        public void UpdateNotesForIncome(int indexToUpdate, string notesToUpdate)
        {
            this.Incomes[indexToUpdate - 1].Note = notesToUpdate;
        }

        /// <summary>
        /// Gets the index of specific income.
        /// </summary>
        /// <param name="message">message</param>
        /// <returns>index</returns>
        public int IndexForIncome(string message)
        {
            int i = 1;
            int index = 0;
            if (this.Incomes.Count > 0)
            {
                ConsoleTable userMenuTable = new("S.No", "Date", "Amount", " Amount Mode", "Category", " Account", " Notes");
                foreach (var value in this.Incomes)
                {
                    userMenuTable.AddRow(i, value.DateOnly, value.Amount, value.AmountMode, value.Category, value.Account, value.Note);
                    i++;
                }
                userMenuTable.Write();

                index = Parser.ValidateInputs<int>(ConsoleColor.Yellow, message);
            }
            else
            {
                Parser.DisplayMessages(ConsoleColor.Red, "No Income ! Please add Income !");
                return default;
            }

            return index;
        }
        /// <summary>
        /// Delete Income.
        /// </summary>
        /// <param name="user">User</param>
        public void DisplayDeleteMessageForIncome(User user)
        {
            int indexToBeDeleted = this.IndexForIncome("Choose which Income data to be deleted : ");
            this.DeleteIncome(indexToBeDeleted, user);
            Parser.DisplayMessages(ConsoleColor.Green, "Successfully Deleted !");
        }

        public void DeleteIncome(int index, User user)
        {
            Incomes.Remove(user.Incomes[index - 1]);
        }
        /// <summary>
        /// Delete Expense.
        /// </summary>
        /// <param name="user">User</param>
        public void DisplayDeleteMessageForExpense(User user)
        {
            int indexToDelete = this.IndexForExpense("Choose which expense data to be deleted : ");
            this.DeleteExpense(indexToDelete, user);
            Parser.DisplayMessages(ConsoleColor.Green, "Successfully Deleted !");
        }
        public void DeleteExpense(int index, User user)
        {
            Expenses.Remove(user.Expenses[index - 1]);
        }
    }
}