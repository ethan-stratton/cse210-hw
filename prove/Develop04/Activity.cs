using System;
using System.Threading;

public class Activity 
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected int _numOfPrompts;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void setDuration(int duration)
    {
        _duration = duration;
    }
    public void EndActivity(int duration, string name)
    {
        //do stuff
        Console.WriteLine("Well Done!");
        Console.WriteLine($"You have successfully completed another {duration} seconds of {name}.");
        Activity.LoadingSymbol();

    }
    public void Countdown(int j)
    {
        //do stuff
        for (int i = j; i >= 0; i--)
        {
            Console.Write($"{i}");
            Thread.Sleep(1000);
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
            Console.Write("  "); // Clear the previous number
        }
    }
    public static void LoadingSymbol()
    {
        //do animation
        char[] loadingChars = { '|', '/', '-', '\\' };

        for (int i = 0; i < 20; i++)
        {
            Console.Write($"{loadingChars[i % loadingChars.Length]} ");
            Thread.Sleep(100);
            Console.Write("\b\b"); // Move the cursor back twice to overwrite the last two characters
        }
    }
    public static int WelcomeMessage()
    {
        Console.WriteLine(@$"Hi! Welcome to the {_name} activity! 
        {_description}");
        
        Console.WriteLine("How long, in seconds, would you like the duration of your activity to be? ");
        string userInput = Console.ReadLine();

        // Convert the string to an int
        if (int.TryParse(userInput, out int desiredDuration))
        {
            _duration = desiredDuration;
            Console.WriteLine("OK, please prepare to begin:");
            return _duration;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for the duration.");
            return 20; // Default value or handle the error in another way
        }
    }
}