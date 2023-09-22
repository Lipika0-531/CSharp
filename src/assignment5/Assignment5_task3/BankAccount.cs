// <copyright file="BankAccount.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment5_task3
{
    /// <summary>
    /// Bankaccount class is initiated to get accountnum and balance
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// Bankaccount
        /// </summary>
        /// <param name="accountNumber">string accountNumber</param>
        /// <param name="initialBalance">decimal initialBalance</param>
        public BankAccount(string accountNumber, decimal initialBalance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = initialBalance;
        }

        /// <summary>
        /// Gets the AccountNumber
        /// </summary>
        /// <value>string accountnumber</value>
        public string AccountNumber { get; }

        /// <summary>
        /// Gets or sets the Balance
        /// </summary>
        /// <value>string balance</value>
        public decimal Balance { get; set; }

        /// <summary>
        /// Deposit method would allow the user to deposit the certain amount into the account
        /// </summary>
        /// <param name="amount">decimal amount</param>
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Cannot deposit");
            }
            else
            {
                this.Balance += amount;
                Console.WriteLine("Deposited successfully");
            }
        }

        /// <summary>
        /// Withdraw method would allow the user to withdraw the certain amount from the account
        /// </summary>
        /// <param name="amount">decimal amount</param>
        public virtual void Withdraw(decimal amount)
        {
            if (amount > this.Balance)
            {
                Console.WriteLine("Insufficient funds.");
            }
            else
            {
                this.Balance -= amount;
                Console.WriteLine("Withdraw successful");
            }
        }
    }
}