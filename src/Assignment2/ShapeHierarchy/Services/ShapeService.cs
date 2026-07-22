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
        /// <summary>
        /// Creates circle objects, calculates their area and returns circle details
        /// </summary>
        /// <param name="color">color of circle</param>
        /// <param name="radius">radius of circle</param>
        /// <returns>Details of circle after calculating area</returns>
        public string CircleShapeService(string color, double radius)
        {
            Circle circleObject = CreateCircle(color, radius);
            double areaOfCircle = GetCircleArea(circleObject);
            return PrintCircleDetails(circleObject, areaOfCircle);
        }

        /// <summary>
        /// Creates rectangle objects, calculates their area and returns rectangle details
        /// </summary>
        /// <param name="color">color of rectangle</param>
        /// <param name="length">length of rectangle</param>
        /// <param name="width">width of rectangle</param>
        /// <returns>Details of circle after calculating area</returns>
        public string RectangleShapeService(string color, double length, double width)
        {
            Rectangle rectangleObject = CreateRectangle(color, length, width);
            double areaofRectangle = GetRectangleArea(rectangleObject);
            return PrintRectangleDetails(rectangleObject, areaofRectangle);
        }

        private Rectangle CreateRectangle(string color, double length, double width)
        {
            return new Rectangle(color, length, width);
        }

        private double GetRectangleArea(Rectangle rectangle)
        {
            return rectangle.CalculateArea();
        }

        private string PrintRectangleDetails(Rectangle rectangle, double area)
        {
            return $"{rectangle.GetDetails()} \nArea: {area}";
        }

        private Circle CreateCircle(string color, double radius)
        {
            return new Circle(color, radius);
        }

        private double GetCircleArea(Circle circle)
        {
            return circle.CalculateArea();
        }

        private string PrintCircleDetails(Circle circle, double area)
        {
            return $"{circle.GetDetails()} \nArea: {area}";
        }
    }
}