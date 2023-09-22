// <copyright file="Manager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment5_task2
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// Manager class is derived from the employee class
    /// </summary>
    public class Manager : Employee
    {
#pragma warning disable SA1309 // Field names should not begin with underscore
        private static float _bonus = 0.25f;
#pragma warning restore SA1309 // Field names should not begin with underscore

        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        /// <param name="name">string name</param>
        /// <param name="salary">decimal salary</param>
        public Manager(string name, decimal salary)
            : base(name, salary, _bonus)
        {
            this.Name = name;
            this.Salary = salary;
        }

        /// <summary>
        /// Gets or sets the salary
        /// </summary>
        /// <value> Decimal Salary </value>
        public decimal Salary { get; set; }

        /// <summary>
        /// Gets or sets the salary
        /// </summary>
        /// <value> Name of manager </value>
        public string Name { get; set; }

        /// <summary>
        /// Calculate the bonus for the manager
        /// </summary>
        /// <returns> Bonus amount </returns>
        public override int CalculateBonus()
        {
            return Convert.ToInt32(this.Salary * (decimal)_bonus);
        }

        /// <summary>
        /// PrintDetails will print the details about the manager
        /// </summary>
        /// <param name="bonus">float bonus</param>
        public void PrintDetails(float bonus)
        {
            Console.WriteLine($"The name of the Manager is :  {this.Name}");
            Console.WriteLine($"Salary of {this.Name} is : {this.Salary}");
            Console.WriteLine($"The amount of bonus added is :  {bonus}");
        }
    }
}