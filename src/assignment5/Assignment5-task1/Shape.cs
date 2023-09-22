// <copyright file="Shape.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Assignment5_task1
{
    /// <summary>
    /// Shape class is the base class
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// _color is defined to get the color of the shape
        /// </summary>
#pragma warning disable SA1309 // Field names should not begin with underscore
        private string _color;
#pragma warning restore SA1309 // Field names should not begin with underscore

        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// Shape
        /// </summary>
        /// <param name="color">arguments</param>
        public Shape(string color)
        {
            this._color = color;
        }

        /// <summary>
        /// CalculateArea is abstract method to calculate the area of the respected shape
        /// </summary>
        /// <returns>double arguments</returns>
        public abstract double CalculateArea();
    }
}
