using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeHierarchy.Models;

namespace ShapeHierarchy.Services
{
    /// <summary>
    /// Contains the business logic of the application.
    /// </summary>
    internal class ShapeService
    {
        internal Rectangle CreateRectangle(string color, double length, double width)
        {
            return new Rectangle(color, length, width);
        }

        internal double GetRectangleArea(Rectangle rectangle)
        {
            return rectangle.CalculateArea();
        }

        internal string PrintRectangleDetails(Rectangle rectangle, double area)
        {
            return $"{rectangle.GetDetails()} \nArea: {area}";
        }

        internal Circle CreateCircle(string color, double radius)
        {
            return new Circle(color, radius);
        }

        internal double GetCircleArea(Circle circle)
        {
            return circle.CalculateArea();
        }

        internal string PrintCircleDetails(Circle circle, double area)
        {
            return $"{circle.GetDetails()} \nArea: {area}";
        }
    }
}