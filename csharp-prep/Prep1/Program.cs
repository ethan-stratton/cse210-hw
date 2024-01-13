using System;

class Program
{
    static void Main(string[] args)
    {
        //Prompt the user for their first name. 
        //Then, prompt them for their last name. 
        //Display the text back all on one line saying, "Your name is last-name, first-name, last-name"

        Console.Write("What is your first name? ");
        string user_Fname = Console.ReadLine();
        Console.Write("What is your last name? ");
        string user_Lname = Console.ReadLine();

        Console.WriteLine($"Your name is {user_Lname}, {user_Fname} {user_Lname}.");

    }
}