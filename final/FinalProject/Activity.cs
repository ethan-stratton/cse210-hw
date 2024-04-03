public class Activity
{
    //get rid of variables that don't need to be there
    private string _activityName;
    private int _energyRequirement;
    private int _happinessBoost;

    public string ActivityName {get {return _activityName; }}

    public Activity(string name, int energyRequirement, int happinessBoost)
    {
        _activityName = name;
        _energyRequirement = energyRequirement;
        _happinessBoost = happinessBoost;
    }
    public void PerformActivity(Pet pet)
    {
        if (pet.HungerLevel >= _energyRequirement) // Check if the pet has enough energy to perform the activity
        {
            Console.WriteLine($"{pet.Name} is performing qctivity.");
            // Adjust the pet's happiness and energy level based on the activity
            pet.IncreaseHappiness(_happinessBoost);
            pet.DecreaseHungerLevel(_energyRequirement);
        }
        else
        {
            Console.WriteLine($"{pet.Name} doesn't have enough energy to {_activityName}.");
        }
        pet.UpdateStatus();
    }
}
