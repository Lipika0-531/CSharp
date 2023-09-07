// <copyright file="SavingsAccount.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment5_task3
{
    using System;

    /// <summary>
    /// Savingsaccount will have the details of the savingsaccount
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// SavingsAccount
        /// </summary>
        /// <param name="accountNumber">string accountNumber</param>
        /// <param name="initialBalance">decimal initialBalance</param>
        /// <param name="minimumBalance">decimal minimumBalance</param>
        public SavingsAccount(string accountNumber, decimal initialBalance)
            : base(accountNumber, initialBalance)
        {
        }

        /// <summary>
        /// Withdraw method would allow the user to withdraw certain amount from the account
        /// </summary>
        /// <param name="amount">decimal amount</param>
        public override void Withdraw(decimal amount)
        {
            if (this.Balance - amount < 500)
            {
                Console.WriteLine("Withdrawal could not be done when the current balance is below the minimum balance.");
                return;
            }

            this.Balance -= amount;
        }
    }
}