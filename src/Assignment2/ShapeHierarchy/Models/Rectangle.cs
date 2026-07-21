using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeHierarchy.Models;

namespace ShapeHierarchy.Models
{
    internal class Rectangle : Shape
    {
        public Rectangle(string color, double width, double length)
            : base(color)
        {
            Width = width;
            Length = length;
        }
        public double Width { get; set; }
        public double Length { get; set; }
        public double AreaOfRectangle { get; set; }
        public override double CalculateArea()
        {
            AreaOfRectangle = Length * Width;
            return AreaOfRectangle;
        }
    }
}