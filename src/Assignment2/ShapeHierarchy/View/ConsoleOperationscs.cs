using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeHierarchy.Services;

namespace ShapeHierarchy.View
{
    internal class ConsoleOperations
    {
        internal void ShowShapeHierarchy()
        {
            Console.WriteLine("Shape Hierarchy "+
                "Enter Choice 1.RECTANGLE or 2.CIRCLE");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("RECTANGLE");
                HandleRectangleService();
            }
            else if (choice == 2)
            {
                Console.WriteLine("CIRCLE");
                HandleCircleService();
            }
            else
            {
                Console.WriteLine("Enter valid choice!");
            }
            Console.ReadKey();
        }

        private string GetInputcolor()
        {
            Console.WriteLine("Enter color:");
            string color = Console.ReadLine();
            return color;
        }

        private void HandleRectangleService()
        {
            var (color, length, width) = GetRectangleInput();
            string result = ProcessRectangleService(color, length, width);
            PrintRectangleResult(result);
        }

        private (string color, double length, double width) GetRectangleInput()
        {
            string color = GetInputcolor();
            Console.WriteLine("Enter Length:");
            double length = ReturnValidInput();
            Console.WriteLine("Enter Width:");
            double width = ReturnValidInput();
            return (color, length, width);
        }

        private string ProcessRectangleService(string color, double length, double width)
        {
            ShapeService shapeService = new ShapeService();
            return shapeService.RectangleShapeService(color, length, width);
        }

        private void PrintRectangleResult(string result)
        {
            Console.WriteLine(result);
        }

        private void HandleCircleService()
        {
            var (color, radius) = GetCircleInputs();
            string result = ProcessCircleService(color, radius);
            PrintCircleResult(result);
        }

        private (string color, double radius) GetCircleInputs()
        {
            string color = GetInputcolor();
            Console.WriteLine("Enter Radius:");
            double radius = ReturnValidInput();
            return (color, radius);
        }

        private string ProcessCircleService(string color, double radius)
        {
            ShapeService shapeService = new ShapeService();
            return shapeService.CircleShapeService(color, radius);
        }

        private void PrintCircleResult(string result)
        {
            Console.WriteLine(result);
        }

        private double ReturnValidInput()
        {
            bool isWidthValid = double.TryParse(Console.ReadLine(), out double resultNumber);
            if (!isWidthValid)
            {
                Console.WriteLine("Invalid Input" +
                                  "Press any key to exit and start from beginning");
                Console.ReadKey();
            }
            return resultNumber;
        }
    }
}