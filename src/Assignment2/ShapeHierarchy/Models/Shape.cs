using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHierarchy.Models
{
    /// <summary>
    /// 	Abstract base class containing common shape properties and area calculation method.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        /// <param name="color">Color of shape</param>
        public Shape(string color)
        {
            Color = color;
        }

        /// <summary>
        /// Gets or sets the color of shape
        /// </summary>
        /// <value>
        /// The color of shape
        /// </value>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the Area of the shape.
        /// </summary>
        /// <value>
        /// The area of the shape
        /// </value>
        public double Area { get; set; }
        
        /// <summary>
        /// Abstarct method to calculate Area
        /// </summary>
        /// <returns>Area of shape</returns>
        public abstract double CalculateArea();
        
        /// <summary>
        /// Returns Details of Shape
        /// </summary>
        /// <returns>Color will be returned</returns>
        public virtual string GetDetails()
        {
            return $"\nColor: {Color}";
        }
    }
}