using System.Diagnostics;
using System.Threading;
public class ReflectionActivity : Activity 
{
// The activity should begin with the standard starting message and prompt for the duration that is used by all activities.
// After the starting message, select a random prompt to show the user such as:

// After each question the program should pause for several seconds before continuing to the next one. While the program is paused it should display a kind of spinner.
// It should continue showing random questions until it has reached the number of seconds the user specified for the duration.
// The activity should conclude with the standard finishing message for all activities.
private readonly List<string> _prompts = new List<string>{"Think of a time when you stood up for someone else.", 
"Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", 
"Think of a time when you did something truly selfless."};

private readonly List<string> _questions = new List<string>{"Why was this experience meaningful to you?",
"Have you ever done anything like this before?",
"How did you get started?",
"How did you feel when it was complete?",
"What made this time different than other times when you were not as successful?",
"What is your favorite thing about this experience?",
"What could you learn from this experience that applies to other situations?",
"What did you learn about yourself through this experience?",
"How can you keep this experience in mind in the future?"};


 public ReflectionActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        //nothing
    }
public void RunReflection()
{
    //run reflection program
    int duration = WelcomeMessage();
    LoadingSymbol();

    Random random = new Random();
    int randomIndex = random.Next(_prompts.Count);
    string randomPrompt = _prompts[randomIndex];
    Console.WriteLine($"     -----   {randomPrompt}   -----     ");

    Console.WriteLine("When you have something in mind, press 'enter' to continue. ");
    Console.ReadLine();

    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    while (stopwatch.Elapsed.TotalSeconds < duration)
    {
        randomIndex = random.Next(_questions.Count);
        string question = _questions[randomIndex];

        Console.WriteLine($"{question}");

        // Display the spinner animation for a specific amount of time
        for (int i = 0; i < 5; i++)
        {
            LoadingSymbol();
            //couldn't get the loading symbol to disappear afterwards
        }
    }
    stopwatch.Stop();
    EndActivity(duration, _name);
}
}