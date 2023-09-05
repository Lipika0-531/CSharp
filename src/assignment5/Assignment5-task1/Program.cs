// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment5_task1
{
    /// <summary>
    /// Program class is the base class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main class will get all the inputs from the user
        /// </summary>
        /// <param name="args"> Console Line arguments</param>
        public static void Main(string[] args)
        {
            ValidationMethods validationMethods = new ValidationMethods();

            string numbervalidation = @"^(?!-)[0-9.]+$";
            string alphabetvalidation = "^[A-Za-z]+$";
            double radius;

            Console.Write("Enter the radius of the circle : ");
            string? result = Console.ReadLine() !;
            result = validationMethods.RegexValidation(result, numbervalidation);
            radius = double.Parse(result);

            Console.Write("Enter the color of the circle : ");
            string? resultcolor = Console.ReadLine() !;
            resultcolor = validationMethods.RegexValidation(resultcolor, alphabetvalidation);

            Circle circle = new Circle(radius, resultcolor);
            double area = circle.CalculateArea();
            circle.PrintDetails(area, resultcolor);

            double length;
            Console.Write("Enter the length of the Rectangle : ");
            string? resultl = Console.ReadLine() !;
            resultl = validationMethods.RegexValidation(resultl, numbervalidation);
            length = double.Parse(resultl);

            double breadth;
            Console.Write("Enter the breadth of the Rectangle : ");
            string? resultb = Console.ReadLine() !;
            resultb = validationMethods.RegexValidation(resultb, numbervalidation);
            breadth = double.Parse(resultb);

            Console.Write("Enter the color of the Rectangle : ");
            string? reccolor = Console.ReadLine() !;
            validationMethods.RegexValidation(reccolor, alphabetvalidation);
            Rectangle rectangle = new Rectangle(length, breadth, reccolor);
            double rectarea = rectangle.CalculateArea();
            rectangle.PrintDetails(rectarea, reccolor);
        }
    }
}