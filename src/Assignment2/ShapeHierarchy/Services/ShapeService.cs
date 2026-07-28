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
        internal Rectangle CreateRectangleShape(string color, double length, double width)
        {
            return new Rectangle(color, length, width);
        }

        internal string PrintRectangleDetails(Rectangle rectangle)
        {
            return $"{rectangle.GetDetails()}";
        }

        internal Circle CreateCircle(string color, double radius)
        {
            return new Circle(color, radius);
        }

        internal string PrintCircleDetails(Circle circle)
        {
            return $"{circle.GetDetails()}";
        }
    }
}