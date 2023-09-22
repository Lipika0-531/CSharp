// <copyright file="Circle.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment5_task1
{
    /// <summary>
    /// Circle class is a derived class from Shape class
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// Circle class would calculate the area of the circle
        /// </summary>
        /// <param name="radius">double radius</param>
        /// <param name="color">string color</param>
        public Circle(double radius, string color)
            : base(color)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// gets or sets method to get and set value of Radius
        /// </summary>
        /// <value>
        /// radius of the circle
        /// </value>
        public double Radius { get; set; }

        /// <summary>
        /// CalculateArea() method would calculate the area of the circle
        /// </summary>
        /// <returns>arguments</returns>
        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        /// <summary>
        /// PrintDetails would print the details about the shape
        /// </summary>
        /// <param name="area">double area</param>
        /// <param name="color">string color</param>
        public void PrintDetails(double area, string color)
        {
            Console.WriteLine($"The Color of the Circle is {color}");
            Console.WriteLine($"Radius of the Circle is {area}");
        }
    }
}