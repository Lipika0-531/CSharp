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

            string numbervalidation = @"^(?!-)[0-9]+$";
            string accountNoValidation = @"^(?!-)[a-zA-z]*[0-9]+$";
            string depositAmount = @"^(?!-)[1-9]+$";
            Console.WriteLine("Enter the account number: ");
            string accountnumber = Console.ReadLine() !;
            accountnumber = validationMethods.RegexValidation(accountnumber, accountNoValidation);

            SavingsAccount savingsAccount = new SavingsAccount(accountnumber, 500);
            CheckingAccount checkingAccount = new CheckingAccount(accountnumber, 500);

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
                        string amtDeposited = Console.ReadLine()!;
                        amtDeposited = validationMethods.RegexValidation(amtDeposited, depositAmount);
                        decimal depositedAmt = decimal.Parse(amtDeposited);
                        savingsAccount.Deposit(depositedAmt);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Balance {savingsAccount.Balance}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Enter the amount to withdraw : ");
                        string withdrawAmt = Console.ReadLine()!;
                        withdrawAmt = validationMethods.RegexValidation(withdrawAmt, numbervalidation);
                        decimal withdrawAmtSaving = decimal.Parse(withdrawAmt);
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
                        string despositedamount = Console.ReadLine()!;
                        despositedamount = validationMethods.RegexValidation(despositedamount, numbervalidation);
                        decimal amttobedeposited = decimal.Parse(despositedamount);
                        checkingAccount.Deposit(amttobedeposited);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Balance {checkingAccount.Balance}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Enter the amount to withdraw : ");
                        string amtToWithdraw = Console.ReadLine()!;
                        amtToWithdraw = validationMethods.RegexValidation(amtToWithdraw, numbervalidation);
                        decimal withdrawAmtCurrentAcc = decimal.Parse(amtToWithdraw);
                        checkingAccount.Withdraw(withdrawAmtCurrentAcc);
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