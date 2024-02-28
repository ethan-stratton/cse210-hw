public class BreathingActivity : Activity 
{

public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clearn your mind and focus on your breathing.")
{
    //nothing
}
public void RunBreathingActivity()
{

    int duration = Activity.WelcomeMessage();
    BreathingActivity.LoadingSymbol();
    //do breathing activity
    //loop

    for (int i = 0; i  < Math.Round((double)duration / 20); i++){
        Console.WriteLine("Breathe In...");
        BreathingActivity.Countdown(5);
        Console.WriteLine("Now Breathe Out...");
        BreathingActivity.Countdown(5);
    }
    //breathe in and countdown
    //breahte out and countdown

    BreathingActivity.EndActivity(duration, _name);
}

}