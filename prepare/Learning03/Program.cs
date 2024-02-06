using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");
        //create an instance for 1/1 (using the first constructor), 
        // for 6/1 (using the second constructor), for 6/7 (using the third constructor).
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(6);
        Fraction fraction3 = new Fraction(6, 7);

        //Verify that you can call all of these methods and get the correct values, 
        //using setters to change the values and then getters to retrieve these new values and then display 
        //them to the console.

        //fraction 3 is 6 / 7
        Console.WriteLine(fraction3.GetTop());
        Console.WriteLine(fraction3.GetBottom());

        Console.WriteLine(fraction3.getFractionString());
        Console.WriteLine(fraction3.getDecimalValue());

        //fraction 3 gets changed to 10 / 5
        fraction3.SetTop(10);
        fraction3.SetBottom(5);

        Console.WriteLine(fraction3.GetTop());
        Console.WriteLine(fraction3.GetBottom());

        Console.WriteLine(fraction3.getFractionString());
        Console.WriteLine(fraction3.getDecimalValue());








    }
}