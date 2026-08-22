using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ShapeHierarchy.Models;

namespace ShapeHierarchy.Models
{
    /// <summary>
    /// Represents a rectangle shape that inherits from the base Shape class and handles area calculations.
    /// </summary>
    internal class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class with a specified color, width, and length.
        /// </summary>
        /// <param name="color">The color of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="length">The length of the rectangle.</param>
        public Rectangle(string color, double width, double length) 
            : base(color)
        {
            Width = width;
            Length = length;
        }

        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// </summary>
        /// <value>
        /// The width of the rectangle
        /// </value>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the length of the rectangle.
        /// </summary>
        /// <value>
        /// The length of the rectangle.
        /// </value>
        public double Length { get; set; }

        /// <summary>
        /// Calculates and returns the area of the rectangle by multiplying its length and width.
        /// </summary>
        /// <returns>The calculated area of the rectangle as a double.</returns>
        public override double CalculateArea()
        {
            Area = Length * Width;
            return Area;
        }

        /// <summary>
        /// Returns a formatted string detailing the rectangle's properties, including its base details, length, and width.
        /// </summary>
        /// <returns>A string containing the complete details of the rectangle.</returns>
        public override string GetDetails()
        {
            return $"{base.GetDetails()} \nLength: {Length:F2} \nWidth: {Width:F2} \nArea:{CalculateArea()}";
        }
    }
}
