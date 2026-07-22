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
        public override double CalculateArea()
        {
            Area = Length * Width;
            return Area;
        }
        public override string GetDetails()
        {
            return $"{base.GetDetails()} \nLength: {Length:F2} \nWidth: {Width:F2}";
        }
    }
}