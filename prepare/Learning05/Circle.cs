using System.Drawing;

public class Circle : Shape {
    private double _radius;
    public Circle(string color, double radius) : base(color) {
        _color = color;
        _radius = radius;
    }

    public override double getArea()
    {
        return 3.14 * (_radius * _radius);
    }
}