using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming.Models
{
    public class Shape
    {
        public string Color { get; set; }
        public abstract double CalculateArea();
        public string PrintDetails(double area)
        {
            return $""
        }
    }

    public class Rectangle:Shape
    {

    }

}
