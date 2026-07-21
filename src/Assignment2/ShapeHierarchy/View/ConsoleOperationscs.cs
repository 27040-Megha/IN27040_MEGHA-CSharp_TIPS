using System;
using System.Collections.Generic;
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
        Console.WriteLine("Shape Hierarchy ");
        Console.WriteLine("Enter Choice 1.RECTANGLE or 2.CIRCLE");
        int choice = int.Parse(Console.ReadLine());
        if (choice == 1)
        {
            Console.WriteLine("RECTANGLE");
            ViewRectangleService();
        }
        else if (choice == 2)
        {
            Console.WriteLine("CIRCLE");
            ViewCircleService();
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
    private void ViewRectangleService()
    {
        string color = GetInputcolor();
        Console.WriteLine("Enter Length:");
        double length = ReturnValidInput();
        Console.WriteLine("Enter Width:");
        double width = ReturnValidInput();
        ShapeService shapeService = new ShapeService();
        Console.WriteLine(shapeService.RectangleShapeService(color, length, width));
    }

    private void ViewCircleService()
    {
        string color = GetInputcolor();
        Console.WriteLine("Enter Radius:");
        double radius = ReturnValidInput();
        ShapeService shapeService = new ShapeService();
        Console.WriteLine(shapeService.CircleShapeService(color, radius));
    }

    private double ReturnValidInput()
    {
        bool isWidthValid = double.TryParse(Console.ReadLine(), out double resultNumber);
        if (!isWidthValid)
        {
            Console.WriteLine("Invalid Input");
            Console.WriteLine("Press any key to exit and start from beginning");
            Console.ReadKey();
        }
        return resultNumber;
    }
}
}