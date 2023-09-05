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
            Console.WriteLine("Enter the account number : ");
            string accnum = Console.ReadLine() !;
            accnum = validationMethods.RegexValidation(accnum, numbervalidation)

            SavingsAccount savingsAccount = new SavingsAccount(accnum, 500);
            CheckingAccount checkingAccount = new CheckingAccount(accnum, 500);

            Console.WriteLine("Choice :");
            string userinput = Console.ReadLine();
            int.TryParse(userinput, out int choice);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the amount to be deposited : ");
                    string amtDeposited = Console.ReadLine()!;
                    amtDeposited = validationMethods.RegexValidation(amtDeposited, numbervalidation);
                    decimal depositedAmt = decimal.Parse(amtDeposited);
                    savingsAccount.Deposit(depositedAmt);


                    Console.WriteLine("Enter the amount to withdraw : ");
                    string withdrawAmt = Console.ReadLine()!;
                    withdrawAmt = validationMethods.RegexValidation(withdrawAmt, numbervalidation);
                    decimal withdrawAmtSaving = decimal.Parse(withdrawAmt);
                    savingsAccount.Withdraw(withdrawAmtSaving);

                    Console.WriteLine($"Balance {savingsAccount.Balance}");
                    break;

                case 2:

                    Console.WriteLine("Enter the amount to be deposited : ");
                    string despositedamt = Console.ReadLine()!;
                    despositedamt = validationMethods.RegexValidation(despositedamt, numbervalidation);
                    decimal amttobedeposited = decimal.Parse(despositedamt);
                    checkingAccount.Deposit(amttobedeposited);
                    
                    Console.WriteLine("Enter the amount to withdraw : ");
                    string amtToWithdraw = Console.ReadLine()!;
                    amtToWithdraw = validationMethods.RegexValidation(amtToWithdraw, numbervalidation);
                    decimal withdrawAmtCurrentAcc = decimal.Parse(amtToWithdraw);
                    checkingAccount.Withdraw(withdrawAmtCurrentAcc);

                    Console.WriteLine($"Balance {savingsAccount.Balance}");
            }
        }
    }
}