class Fraction
 {
    private int _top = 0;
    private int _bottom = 0;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public int GetTop(){return _top;}
    public void SetTop(int top){_top = top;}
    public int GetBottom(){return _bottom;}
    public void SetBottom(int bottom){_bottom = bottom;}

    public string getFractionString() {
        int numerator = GetTop();
        int denominator = GetBottom();
        //after reviewing the solution, its much easier to just use _top and _bottom than the getters
        return  numerator + "/" + denominator;
    }
    public double getDecimalValue() {
        double numerator = GetTop();
        double denominator = GetBottom();
        double answer = Math.Round((numerator / denominator), 2);
        // alternatively, return (double)_top / (double)_bottom;
        return answer;
    }
    
}