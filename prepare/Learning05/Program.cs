using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        Square mySquare = new Square("red", 3);
        //Console.WriteLine(mySquare.getColor());
        //Console.WriteLine(mySquare.getArea());

        // Repeat the steps above for the Rectangle and Circle classes, putting them each in their own files, storing the necessary variables, and overriding the GetArea() for each.
        // Test these classes back in Main and make sure they work as expected.

        Circle myCircle = new Circle("blue", 5);
        //Console.WriteLine(myCircle.getColor());
        //Console.WriteLine(myCircle.getArea());

        Rectangle myRect = new Rectangle("green", 10, 3);
        //Console.WriteLine(myRect.getColor());
        //Console.WriteLine(myRect.getArea());

        // Build a List
        // In your Main method, create a list to hold shapes (Hint: The data type should be List<Shape>).
        List<Shape> listOfShapes = new List<Shape>();
        listOfShapes.Add(mySquare);
        listOfShapes.Add(myRect);
        listOfShapes.Add(myCircle);
        // Add a square, rectangle, and circle to this list.
        // Iterate through the list of shapes. For each one, call and display the GetColor() and GetArea() methods.

        foreach (Shape shape in listOfShapes){
            //Console.WriteLine(shape.getColor());
            //Console.WriteLine(shape.getArea());

            string color = shape.getColor();
            double area = shape.getArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }

    }
}