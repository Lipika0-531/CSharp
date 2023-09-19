// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment5_task3
{
    /// <summary>
    /// Program class contains the <see cref="Main(string[])"/> class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main class would get the user inputs
        /// </summary>
        /// <param name="args"> Console line arguments </param>
        public static void Main(string[] args)
        {
            ValidationMethods validationMethods = new ValidationMethods();

            string numberValidation = @"^(?!-)[1-9][0-9]{0,15}$";
            string accountNoValidation = @"^(?!-)[a-zA-z]*[0-9]+$";
            Console.WriteLine("Enter the account number: ");
            string accountNumber = Console.ReadLine() !;
            accountNumber = validationMethods.RegexValidation(accountNumber, accountNoValidation);

            SavingsAccount savingsAccount = new SavingsAccount(accountNumber, 500);
            CheckingAccount checkingAccount = new CheckingAccount(accountNumber, 500);

            do
            {
                Console.WriteLine("\n1. Savings Account \n2. Checking Account \n3. Exit \nEnter Choice : ");
                string? userinput = Console.ReadLine()!;
                int.TryParse(userinput, out int choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Your current balance : ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Balance {savingsAccount.Balance}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Enter the amount to be deposited : ");
                        string amountDeposited = Console.ReadLine()!;
                        amountDeposited = validationMethods.RegexValidation(amountDeposited, numberValidation);
                        decimal depositedAmount = decimal.Parse(amountDeposited);
                        savingsAccount.Deposit(depositedAmount);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Balance {savingsAccount.Balance}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Enter the amount to withdraw : ");
                        string withdrawAmount = Console.ReadLine() !;
                        withdrawAmount = validationMethods.RegexValidation(withdrawAmount, numberValidation);
                        decimal withdrawAmtSaving = decimal.Parse(withdrawAmount);
                        savingsAccount.Withdraw(withdrawAmtSaving);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Balance {savingsAccount.Balance}");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case 2:
                        Console.WriteLine("Your current balance : ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Balance {checkingAccount.Balance}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Enter the amount to be deposited : ");
                        string withdrawAmtChecking = Console.ReadLine()!;
                        withdrawAmount = validationMethods.RegexValidation(withdrawAmtChecking, numberValidation);
                        decimal withdrawAmtCheckingAccount = decimal.Parse(withdrawAmount);
                        checkingAccount.Deposit(withdrawAmtCheckingAccount);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Balance {checkingAccount.Balance}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Enter the amount to withdraw : ");
                        string amtToWithdraw = Console.ReadLine()!;
                        amtToWithdraw = validationMethods.RegexValidation(amtToWithdraw, numberValidation);
                        decimal withdrawAmtCurrentAccount = decimal.Parse(amtToWithdraw);
                        checkingAccount.Withdraw(withdrawAmtCurrentAccount);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Balance {checkingAccount.Balance}");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Enter valid options");
                        break;
                }
            }
            while (true);
        }
    }
}