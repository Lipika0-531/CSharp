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

            string name = null!;
            Console.WriteLine("Enter the Name of the Manager : ");
            string? result = Console.ReadLine() !;
            result = validationMethods.RegexValidation(result, alphabetvalidation);

            decimal salary;
            Console.WriteLine("Enter the Salary of the Manager: ");
            string? results = Console.ReadLine() !;
            results = validationMethods.RegexValidation(results, numbervalidation);

            salary = decimal.Parse(results);
            Manager emp = new Manager(name, salary);
            int empbonus = emp.CalculateBonus();
            emp.PrintDetails(empbonus);

            Console.WriteLine("Enter the Name of the Developer : ");
            string? resultn = Console.ReadLine() !;
            resultn = validationMethods.RegexValidation(resultn, alphabetvalidation);

            decimal salaryDeveloper;
            Console.WriteLine("Enter the Salary of the Developer: ");
            string? resultdeveloper = Console.ReadLine() !;
            resultdeveloper = validationMethods.RegexValidation(resultdeveloper, numbervalidation);

            salaryDeveloper = decimal.Parse(resultdeveloper);
            Developer develop = new Developer (salaryDeveloper, resultn);
            int devBonus = develop.CalculateBonus();
            develop.PrintDetails(devBonus);
        }
    }
}