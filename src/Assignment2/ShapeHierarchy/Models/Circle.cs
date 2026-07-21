using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeHierarchy.Models;

namespace ShapeHierarchy.Models
{
    public class Circle : Shape
    {
        public Circle(string color, double radius)
            : base(color)
        {
            Radius = radius;
        }
        public double Radius { get; set; }
        public double AreaOfCircle { get; set; }

        public override double CalculateArea()
        {
            AreaOfCircle = Math.PI * Math.Pow(Radius, 2);
            return AreaOfCircle;
        }
    }
}