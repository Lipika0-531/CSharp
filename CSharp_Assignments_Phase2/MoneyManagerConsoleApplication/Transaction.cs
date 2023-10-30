using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagerConsoleApplication
{
    /// <summary>
    /// Transaction
    /// </summary>
    internal class Transaction
    {
        public DateOnly DateOnly { get; set; }

        public Category? Categories { get; set; }

        public double Amount { get; set; }

        public ModesOfCash AmountMode { get; set; }

        public int Account { get; set; }

        public string? Note { get; set; }


    }
}
