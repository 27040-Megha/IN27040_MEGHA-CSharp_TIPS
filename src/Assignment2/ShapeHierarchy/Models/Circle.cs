using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeHierarchy.Models;

namespace ShapeHierarchy.Models
{
    /// <summary>
    /// Inherits from Shape and calculates the area of a circle
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="color">Color of Circle</param>
        /// <param name="radius">Radius of circle</param>
        public Circle(string color, double radius)
            : base(color)
        {
            Radius = radius;
        }

        /// <summary>
        /// Gets or sets the radius of the circle.
        /// </summary>
        /// <value>
        /// The radius of the circle
        /// </value>
        public double Radius { get; set; }

        /// <summary>
        /// Calculates and returns the area of the circle using its radius.
        /// </summary>
        /// <returns>The calculated area of the circle as a double.</returns>
        public override double CalculateArea()
        {
            Area = Math.PI * Math.Pow(Radius, 2);
            return Area;
        }

        /// <summary>
        /// Returns a string representation of the circle's details, including base details and the radius.
        /// </summary>
        /// <returns>A string containing the formatted details of the circle.</returns>
        public override string GetDetails()
        {
            return $"{base.GetDetails()} \nRadius: {Radius:F2} \nArea:{CalculateArea()}";
        }
    }
}
