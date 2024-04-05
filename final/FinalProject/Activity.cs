public class Activity
{
    private string _activityName;
    private int _energyRequirement;
    private int _happinessBoost;
    private Action _action; // hold the action to be performed in the activity for special activities

    public string ActivityName { get { return _activityName; } }

    public Activity(string name, int energyRequirement, int happinessBoost, Action action = null)
    {
        _activityName = name;
        _energyRequirement = energyRequirement;
        _happinessBoost = happinessBoost;
        _action = action; // Assign the provided action
    }

    public void PerformActivity(Pet pet)
    {
        if (pet.HungerLevel >= _energyRequirement) // Check if the pet has enough energy to perform the activity
        {
            Console.WriteLine($"{pet.Name} is performing {_activityName}.");
            // Adjust the pet's happiness and energy level based on the activity
            pet.IncreaseHappiness(_happinessBoost);
            pet.DecreaseHungerLevel(_energyRequirement);

            // Execute special action if provided
            _action?.Invoke();
        }
        else
        {
            Console.WriteLine($"{pet.Name} doesn't have enough energy to {_activityName}.");
        }
        pet.UpdateStatus();
    }
}