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

            string numberValidation = @"^(?!-)[0-9]+[.]?[0-9]*$";
            string alphabetValidation = "^[A-Za-z]+$";
            double radius;

            Console.Write("Enter the radius of the circle : ");
            string? result = Console.ReadLine() !;
            result = validationMethods.RegexValidation(result, numberValidation);
            radius = double.Parse(result);

            Console.Write("Enter the color of the circle : ");
            string? resultColor = Console.ReadLine() !;
            resultColor = validationMethods.RegexValidation(resultColor, alphabetValidation);

            Circle circle = new Circle(radius, resultColor);
            double area = circle.CalculateArea();
            circle.PrintDetails(area, resultColor);

            double length;
            Console.Write("Enter the length of the Rectangle : ");
            string? resultLength = Console.ReadLine() !;
            resultLength = validationMethods.RegexValidation(resultLength, numberValidation);
            length = double.Parse(resultLength);

            double breadth;
            Console.Write("Enter the breadth of the Rectangle : ");
            string? resultBreadth = Console.ReadLine() !;
            resultBreadth = validationMethods.RegexValidation(resultBreadth, numberValidation);
            breadth = double.Parse(resultBreadth);

            Console.Write("Enter the color of the Rectangle : ");
            string? rectangleColor = Console.ReadLine() !;
            validationMethods.RegexValidation(rectangleColor, alphabetValidation);
            Rectangle rectangle = new Rectangle(length, breadth, rectangleColor);
            double rectangleArea = rectangle.CalculateArea();
            rectangle.PrintDetails(rectangleArea, rectangleColor);
        }
    }
}