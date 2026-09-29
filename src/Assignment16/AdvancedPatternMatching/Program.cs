using System;
using System.Collections.Generic;
using AdvancedPatternMatching;

namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            var shapes = new List<Shape>()
            {
                new Circle(7, "Red"),
                new Rectangle(2, 3, "Blue"),
                new Triangle(2, 4, "Green"),
                new Circle(4, "Blue"),
                null,
                new Rectangle(4, 5, "Red"),
                new Triangle(3, 9, "Green"),
            };

            foreach (var shape in shapes)
            {
                DisplayShapeDetails(shape);
            }

            // Cannot access other Shape types, Should be of Subclass of Shape Type
            // DisplayShapeDetails(new Hexagon("Red"));
        }

        private static void DisplayShapeDetails(Shape shape)
        {
            switch (shape)
            {
                case Triangle:
                    DisplayTriangleDetails(shape as Triangle);
                    break;
                case Rectangle:
                    DisplayRectangleDetails(shape as Rectangle);
                    break;
                case Circle:
                    DisplayCircleDetails(shape as Circle);
                    break;
                case null:
                    Console.WriteLine(DisplayResource.NullObject);
                    break;
                default:
                    Console.WriteLine(DisplayResource.TypeMismatch);
                    break;
            }
        }

        private static void DisplayTriangleDetails(Triangle triangle)
        {
            Console.WriteLine(string.Format(DisplayResource.TriangleDetails, triangle.Color, triangle.Base, triangle.Height, triangle.CalculateArea()));
        }

        private static void DisplayRectangleDetails(Rectangle rectangle)
        {
            Console.WriteLine(string.Format(DisplayResource.RectangleDetails, rectangle.Color, rectangle.Length, rectangle.Width, rectangle.CalculateArea()));
        }

        private static void DisplayCircleDetails(Circle circle)
        {
            Console.WriteLine(string.Format(DisplayResource.CircleDetails, circle.Color, circle.Radius, circle.CalculateArea()));
        }
    }
}