using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeHierarchy.Models;

namespace ShapeHierarchy.Services
{
    internal class ShapeService
    {
        public string CircleShapeService(string color, double radius)
        {
            Circle circleObject = new Circle(color, radius);
            double areaOfCircle = circleObject.CalculateArea();
            return $"Color : {color} \nRadius: {radius} \nArea: {areaOfCircle}";
        }
        public string RectangleShapeService(string color, double length, double width)
        {
            Rectangle rectangleObject = new Rectangle(color, length, width);
            double areaOfCircle = rectangleObject.CalculateArea();
            return $"Color : {color} \nLength: {length} \nWidth: {width} \nArea: {areaOfCircle}";
        }
    }
}