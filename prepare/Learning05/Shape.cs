public abstract class Shape {

    protected string _color;

    public void setColor(string color){
        _color = color;
    }
    public string getColor(){
        return _color;
    }

    public Shape(string color){
        setColor(color);
    }

    public abstract double getArea();
        
}