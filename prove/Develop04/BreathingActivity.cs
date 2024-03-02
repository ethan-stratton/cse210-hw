using System.Diagnostics;

public class BreathingActivity : Activity 
{

public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
{
    //nothing
}
public void RunBreathingActivity()
{
    int duration = WelcomeMessage();
    LoadingSymbol();
    //do breathing activity
    //loop
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    TextAnimator textAnimator = new TextAnimator(totalFrames: 50, initialSize: 10, sizeChangeRate: 2);

    while (stopwatch.Elapsed.TotalSeconds < duration)
    {
        //if remaining seconds is less than or equal to 10, breathe in then breathe out for 5 each and end.
        if (duration - stopwatch.Elapsed.TotalSeconds <= 10)
        {
            // Start growing animation
            textAnimator.StartGrowingAnimation("Breathe In...");
            Countdown(5);
            // Start shrinking animation
            textAnimator.StartShrinkingAnimation("Breathe Out...");
            Countdown(5);


            // Console.WriteLine("Breathe In...");
            // Countdown(5);
            // Console.WriteLine("Now Breathe Out...");
            // Countdown(5);
            // break;
        }
        //else go for the longer loop with a breath hold

        textAnimator.StartGrowingAnimation("Breathe In...");
        Countdown(5);
        textAnimator.PrintAnySize("Hold...", 20);
        Countdown(5);
        textAnimator.StartShrinkingAnimation("Breathe Out...");
        Countdown(5);

        // Console.WriteLine("Breathe In...");
        // Countdown(5);
        // Console.WriteLine("Hold..."); // added because Michael Norton explained the importance of holding the breath
        // Countdown(5);
        // Console.WriteLine("Now Breathe Out...");
        // Countdown(5);

    }
    stopwatch.Stop();
    EndActivity(duration, _name);
}
}