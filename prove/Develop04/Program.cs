using System;

class Program
{
    static void Main(string[] args)
    {

        string welcome = @"Menu Options:
        1. Start Breathing Activity
        2. Start Reflecting Activity
        3. Start Listing Activity
        4. Quit";


        ConsoleKeyInfo userInput;

do
{
    Console.Clear();
    Console.WriteLine(welcome);
    Console.WriteLine("Select a choice from the menu");

    userInput = Console.ReadKey();

    switch (userInput.KeyChar)
    {
        case '1':
            BreathingActivity breath = new BreathingActivity();
            breath.RunBreathingActivity();
            break;

        case '2':
            ReflectionActivity reflection = new ReflectionActivity();
            reflection.RunReflection();
            break;

        case '3':
            ListingActivity listing = new ListingActivity();
            listing.RunListActivity();
            break;

        case '4':
            Console.WriteLine("Thanks for being with us today.");
            break;

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();

} while (userInput.KeyChar != '4');
    }
}