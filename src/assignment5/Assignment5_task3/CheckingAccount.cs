// <copyright file="CheckingAccount.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment5_task3
{
    using System;

    /// <summary>
    /// CheckingAccount class is to check the account details
    /// </summary>
    public class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// CheckingAccount.
        /// </summary>
        /// <param name="accountNumber">string accountNumber</param>
        /// <param name="initialBalance">decimal initialBalance</param>
        public CheckingAccount(string accountNumber, decimal initialBalance)
            : base(accountNumber, initialBalance)
        {
        }
    }
}