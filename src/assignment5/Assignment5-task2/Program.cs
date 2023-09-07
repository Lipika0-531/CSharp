// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment5_task2
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program class is the base for all the derived class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main class would receive the inputs from the user
        /// </summary>
        /// <param name="args">string arguments</param>
        public static void Main(string[] args)
        {
            ValidationMethods validationMethods = new ValidationMethods();

            string numbervalidation = @"^(?!-)[0-9]+$";
            string alphabetvalidation = "^[A-Za-z]+$";

            Console.WriteLine("Enter the Name of the Manager : ");
            string name = Console.ReadLine() !;
            name = validationMethods.RegexValidation(name, alphabetvalidation);

            decimal salary;
            Console.WriteLine("Enter the Salary of the Manager: ");
            string? results = Console.ReadLine() !;
            results = validationMethods.RegexValidation(results, numbervalidation);

            salary = decimal.Parse(results);
            Manager employee = new Manager(name, salary);
            int employeebonus = employee.CalculateBonus();
            employee.PrintDetails(employeebonus);

            Console.WriteLine("Enter the Name of the Developer : ");
            string? resultDeveloper = Console.ReadLine() !;
            resultDeveloper = validationMethods.RegexValidation(resultDeveloper, alphabetvalidation);

            decimal salaryDeveloper;
            Console.WriteLine("Enter the Salary of the Developer: ");
            string? resultSalary = Console.ReadLine() !;
            resultSalary = validationMethods.RegexValidation(resultSalary, numbervalidation);

            salaryDeveloper = decimal.Parse(resultSalary);
            Developer develop = new Developer (salaryDeveloper, resultDeveloper);
            int developerBonus = develop.CalculateBonus();
            develop.PrintDetails(developerBonus);
        }
    }
}