using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square square = new Square("red", 3);
        Rectangle rectangle = new Rectangle("white", 4, 5);
        Circle circle = new Circle("black", 6);

        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetColor()}");
            Console.WriteLine($"{shape.GetArea():F2}");
        }


    }
}