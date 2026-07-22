using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHierarchy.Models
{
    public abstract class Shape
    {
        public Shape(string color)
        {
            Color = color;
        }
        public string Color { get; set; }
        public double Area { get; set; }
        public abstract double CalculateArea();
        public virtual string GetDetails()
        {
            return $"\nColor: {Color}";
        }
    }
}