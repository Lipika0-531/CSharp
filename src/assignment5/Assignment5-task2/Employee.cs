// <copyright file="Employee.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment5_task2
{
    using System;

    /// <summary>
    /// Employee class is the base class for all the derived class
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// name, salary, and bonus are defined
        /// </summary>
#pragma warning disable SA1309 // Field names should not begin with underscore
        private string _name;
#pragma warning restore SA1309 // Field names should not begin with underscore
#pragma warning disable SA1309 // Field names should not begin with underscore
        private decimal _salary;
#pragma warning restore SA1309 // Field names should not begin with underscore
#pragma warning disable SA1309 // Field names should not begin with underscore
        private float _bonus;
#pragma warning restore SA1309 // Field names should not begin with underscore

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="name">string name</param>
        /// <param name="salary">decimal salary</param>
        /// <param name="bonus">float bonus</param>
        public Employee(string name, decimal salary, float bonus)
        {
            this._name = name;
            this._salary = salary;
            this._bonus = bonus;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="name">string name</param>
        public Employee(string name)
        {
            this._name = name;
        }

        /// <summary>
        /// CalculateBonus would calculate the bonus
        /// </summary>
        /// <returns>int</returns>
        public abstract int CalculateBonus();
    }
}