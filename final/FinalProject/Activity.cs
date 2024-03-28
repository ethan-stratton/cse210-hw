public class Activity
{
    public string _activityName { get; }
    public int _energyRequirement { get; }
    public int _happinessBoost { get; }

    public Activity(string name, int energyRequirement, int happinessBoost)
    {
        _activityName = name;
        _energyRequirement = energyRequirement;
        _happinessBoost = happinessBoost;
    }

    public void PerformActivity(Pet pet)
    {
        // Check if the pet has enough energy to perform the activity
        if (pet.HungerLevel >= _energyRequirement)
        {
            // Perform the activity // do smth??
            Console.WriteLine($"{pet.Name} is performing qctivity.");
            // Adjust the pet's happiness and energy level based on the activity
            pet.IncreaseHappiness(_happinessBoost);
            pet.DecreaseHungerLevel(_energyRequirement);
        }
        else
        {
            Console.WriteLine($"{pet.Name} doesn't have enough energy to {_activityName}.");
        }
    }
}
