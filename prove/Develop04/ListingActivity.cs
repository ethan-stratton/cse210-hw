public class ListingActivity : Activity 
{
// The activity should begin with the standard starting message and prompt for the duration that is used by all activities.
// The description of this activity should be something like: "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
// After the starting message, select a random prompt to show the user
// After displaying the prompt, the program should give them a countdown of several seconds to begin thinking about the prompt. Then, it should prompt them to keep listing items.
// The user lists as many items as they can until they they reach the duration specified by the user at the beginning.
// The activity them displays back the number of items that were entered.
// The activity should conclude with the standard finishing message for all activities.

private List<string> _prompts = new List<string>{"Who are people that you appreciate?",
"What are personal strengths of yours?",
"Who are people that you have helped this week?",
"When have you felt the Holy Ghost this month?",
"Who are some of your personal heroes?"};

public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
{
    //nothing
}

public void ListActivity(int numOfPrompts)
{
    //do stuff
}

public string RandomPrompt()
{
    return "Random Prompt";
}

public string DisplayPrompt()
{
    return "Display Prompt";
}

public void RunListActivity()
{
    //runs list activity
}

}