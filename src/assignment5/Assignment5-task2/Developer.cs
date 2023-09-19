// <copyright file="Developer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment5_task2
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// Developer class is derived class from Employee
    /// </summary>
    public class Developer : Employee
    {
#pragma warning disable SA1309 // Field names should not begin with underscore
        private static float _bonus = 0.15f;
#pragma warning restore SA1309 // Field names should not begin with underscore

        /// <summary>
        /// Initializes a new instance of the <see cref="Developer"/> class.
        /// </summary>
        /// <param name="name">string name</param>
        /// <param name="salary">decimal salary</param>
        public Developer(decimal salary, string name)
            : base(name)
        {
            this.NameDeveloper = name;
            this.SalaryDeveloper = salary;
        }

        /// <summary>
        /// Gets or sets the salary of the developer
        /// </summary>
        /// <value>
        /// Decimal
        /// </value>
        public decimal SalaryDeveloper { get; set; }

        /// <summary>
        /// Gets or sets the Name of the developer
        /// </summary>
        /// <value>
        /// Decimal
        /// </value>
        public string NameDeveloper { get; set; }

        /// <summary>
        /// CalculateBonus method would calculate the bonus of the developer
        /// </summary>
        /// <returns> Bonus amount </returns>
        public override int CalculateBonus()
        {
            return Convert.ToInt32(this.SalaryDeveloper * (decimal)_bonus);
        }

        /// <summary>
        /// PrintDetails will print the details about the developer
        /// </summary>
        /// <param name="bonus">float bonus</param>
        public void PrintDetails(float bonus)
        {
            Console.WriteLine($"The Name of the Developer is : {this.NameDeveloper}");
            Console.WriteLine($"Salary of {this.NameDeveloper} is : {this.SalaryDeveloper}");
            Console.WriteLine($"The Amount of bonus added is :  {bonus}");
        }
    }
}