using System;

class Program
{
  static void Main(string[] args)
  {
    List<Shape> shapes = new List<Shape>();

    shapes.Add(new Square(13, "Chartreuse"));
    shapes.Add(new Rectangle(3.2, 4.6, "Fuschia"));
    shapes.Add(new Circle(2.3, "Cerulean"));

    foreach (Shape shape in shapes)
    {
      Console.WriteLine($"{shape.GetArea()}, {shape.GetColor()}");
    }
  }
}