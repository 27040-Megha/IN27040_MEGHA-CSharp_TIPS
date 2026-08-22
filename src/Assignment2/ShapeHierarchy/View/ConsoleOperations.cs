using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ShapeHierarchy.Models;
using ShapeHierarchy.Services;

namespace ShapeHierarchy.View
{
    /// <summary>
    /// Handles user interaction through the console.
    /// </summary>
    internal class ConsoleOperations
    {
        private readonly ShapeService _shapeService = new ShapeService();

        /// <summary>
        /// Displays the menu, accepts user input, invokes service methods and prints shape details.
        /// </summary>
        internal void ShowShapeHierarchy()
        {
            int choice;
            do
            {
                PrintMenu();
                choice = GetMenuChoice();
                ProcessMenuChoice(choice);
            } 
            while (choice != 3);
        }

        private void PrintMenu()
        {
            Console.WriteLine(UserMessages.MenuOptions);
        }

        private int GetMenuChoice()
        {
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            return 0;
        }

        private void ProcessMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine(UserMessages.RectangleHeader);
                    var rectangleObject = CreateRectangle();
                    PrintDetails(_shapeService.PrintRectangleDetails(rectangleObject));
                    break;
                case 2:
                    Console.WriteLine(UserMessages.CircleHeader);
                    var circleObject = CreateCircle();
                    PrintDetails(_shapeService.PrintCircleDetails(circleObject));
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine(UserMessages.InvalidChoice);
                    break;
            }
        }
        private string GetInputcolor()
        {
            Console.WriteLine(UserMessages.ColorPrompt);
            string color = Console.ReadLine();
            if (!string.IsNullOrEmpty(color) && color.All(char.IsLetter))
            {
                return color;
            }
            Console.WriteLine(UserMessages.InvalidColor);
            return null;
        }

        private Rectangle CreateRectangle()
        {
            var (color, length, width) = GetRectangleInput();
            if (color == null || length == -1 || width == -1)
            {
                return null;
            }
            var rectangleObject = _shapeService.CreateRectangleShape(color, length, width);
            return rectangleObject;
        }

        private void PrintDetails(string shapeDetails)
        {
            Console.WriteLine(shapeDetails);
        }

        private (string color, double length, double width) GetRectangleInput()
        {
            string color = GetInputcolor();
            if (color == null)
            {
                return (null, -1, -1);
            }
            Console.WriteLine(UserMessages.LengthPrompt);
            double length = ReturnValidInput();
            if (length == -1)
            {
                return (null, -1, -1);
            }
            Console.WriteLine(UserMessages.WidthPrompt);
            double width = ReturnValidInput();
            if (width == -1)
            {
                return (null, -1, -1);
            }
            return (color, length, width);
        }

        private Circle CreateCircle()
        {
            var (color, radius) = GetCircleInputs();
            if (color == null || radius == -1)
            {
                return null;
            }
            var circleObject = _shapeService.CreateCircle(color, radius);
            return circleObject;
        }

        private (string color, double radius) GetCircleInputs()
        {
            string color = GetInputcolor();
            if (color == null)
            {
                return (null, -1);
            }
            Console.WriteLine(UserMessages.RadiusPrompt);
            double radius = ReturnValidInput();
            if (radius == -1)
            {
                return (null, -1);
            }
            return (color, radius);
        }

        private double ReturnValidInput()
        {
            bool isWidthValid = double.TryParse(Console.ReadLine(), out double resultNumber);
            if (!isWidthValid || resultNumber <= 0)
            {
                Console.WriteLine(UserMessages.InvalidNumberInput);
                return -1;
            }
            return resultNumber;
        }
    }
}
