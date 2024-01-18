using System;

class Program
{

    static void WelcomeMessage() 
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName() 
    {
        Console.Write("What is your name? ");
        string username = Console.ReadLine();
        return username;
    }

    static int PromptUserNumber()
    {
        Console.Write("What is your favorite number? ");
        string favNum = Console.ReadLine();
        int num = int.Parse(favNum); 
        return num;
    }

    static int SquareNumber(int number)
    {
        int sqdNum = number * number;
        return sqdNum;
    }

    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, your favorite number squared is: {squaredNumber}");
    }

    static void Main(string[] args)
    {
        WelcomeMessage();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int sqdNum = SquareNumber(number);
        DisplayResult(name, sqdNum);
    }
}