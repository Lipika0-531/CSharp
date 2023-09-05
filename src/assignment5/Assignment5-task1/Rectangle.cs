// <copyright file="Rectangle.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment5_task1
{
    /// <summary>
    /// Rectangle class is derived class from Shape
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// Rectangle
        /// </summary>
        /// <param name="length">double length</param>
        /// <param name="breadth">double breadth</param>
        /// <param name="color">string color</param>
        public Rectangle(double length, double breadth, string color)
            : base(color)
        {
            this.RectLen = length;
            this.RectBreadth = breadth;
        }

        /// <summary>
        /// gets or sets method would get and set Length of the rectangle
        /// </summary>
        /// <value>
        /// length of rectangle
        /// </value>
        public double RectLen { get; set; }

        /// <summary>
        /// gets or sets method would get and set breadth of the rectangle
        /// </summary>
        /// <value>
        /// breadth of rectangle
        /// </value>
        public double RectBreadth { get; set; }

        /// <summary>
        /// CalculateArea() would calculate the area of the rectangle
        /// </summary>
        /// <returns>arguments</returns>
        public override double CalculateArea()
        {
            return this.RectLen * this.RectBreadth;
        }

        /// <summary>
        /// PrintDetails would print the details about the shape
        /// </summary>
        /// <param name="area">double area</param>
        /// <param name="color">string color</param>
        public void PrintDetails(double area, string color)
        {
            Console.WriteLine($"The color of the Rectangle is {color}");
            Console.WriteLine($"Area of the Rectangle is {area}");
        }
    }
}