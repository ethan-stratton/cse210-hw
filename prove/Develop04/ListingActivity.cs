using System;
using System.Diagnostics;
using System.Threading;

public class ListingActivity : Activity 
{

private readonly List<string> _prompts = new List<string>{"Who are people that you appreciate?",
"What are personal strengths of yours?",
"Who are people that you have helped this week?",
"When have you felt the Holy Ghost this month?",
"Who are some of your personal heroes?"};

private int _userListedPrompts;

public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
{
    //nothing
}

// public void ListActivity(int numOfPrompts)
// {
//     //do stuff
// }

public string RandomPrompt()
{
    Random random = new Random();
    int randomIndex = random.Next(_prompts.Count);
    string randomPrompt = _prompts[randomIndex];
    return $"     -----   {randomPrompt}   -----     ";
}

// public string DisplayPrompt()
// {
//     return "Display Prompt";
// }

public void RunListActivity()
{
    //runs list activity
    int duration = WelcomeMessage();
    LoadingSymbol();
    Console.WriteLine(RandomPrompt());

    // After displaying the prompt, the program should give them a countdown of several seconds to begin thinking about the prompt. 
    // Then, it should prompt them to keep listing items.
    Console.WriteLine("Begin thinking about the prompt. After the countdown ends, begin listing items.");
    Countdown(5);
    // The user lists as many items as they can until they they reach the duration specified by the user at the beginning.
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    List<string> user_items = new List<string>();
    string userInput;

    while (stopwatch.Elapsed.TotalSeconds < duration)
    {
        // add functionality here
        // for each entry increment _userListedPrompts +=1.
        userInput = Console.ReadLine();
        user_items.Add(userInput);

    }
    stopwatch.Stop();

    foreach (string item in user_items)
    {
        _userListedPrompts++;
    }

    // The activity them displays back the number of items that were entered.
    Console.WriteLine($"You wrote down {_userListedPrompts} different items.");

    // The activity should conclude with the standard finishing message for all activities.
    EndActivity(duration, _name);    
}

}