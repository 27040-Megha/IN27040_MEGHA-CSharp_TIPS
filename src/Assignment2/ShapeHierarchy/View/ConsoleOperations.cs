using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ShapeHierarchy.Services;

namespace ShapeHierarchy.View
{
    /// <summary>
    /// Handles user interaction through the console.
    /// </summary>
    internal class ConsoleOperations
    {
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
                    HandleRectangleService();
                    break;
                case 2:
                    Console.WriteLine(UserMessages.CircleHeader);
                    HandleCircleService();
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

        private void HandleRectangleService()
        {
            var (color, length, width) = GetRectangleInput();
            if (color == null || length == -1 || width == -1)
            {
                return;
            }
            string result = ProcessRectangleService(color, length, width);
            PrintRectangleResult(result);
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
            if (color == null || radius == -1)
            {
                return;
            }
            string result = ProcessCircleService(color, radius);
            PrintCircleResult(result);
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
            if (!isWidthValid || resultNumber <= 0)
            {
                Console.WriteLine(UserMessages.InvalidNumberInput);
                return -1;
            }
            return resultNumber;
        }
    }
}
