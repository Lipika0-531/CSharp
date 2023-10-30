﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerConsoleApplication
{
    /// <summary>
    /// Base class for Income and Expense.
    /// </summary>
    internal class Transaction
    {
        /// <summary>
        /// Date
        /// </summary>
        public DateOnly DateOnly { get; set; }

        /// <summary>
        /// Category value
        /// </summary>
        public Category? Categories { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Mode of Cash
        /// </summary>
        public ModesOfCash AmountMode { get; set; }

        /// <summary>
        /// Account Number
        /// </summary>
        public int Account { get; set; }

        /// <summary>
        /// Notes
        /// </summary>
        public string? Note { get; set; }


    }
}
