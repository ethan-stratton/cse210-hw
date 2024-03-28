public class Activity
{
    public string Name { get; }
    public int EnergyRequirement { get; }
    public int HappinessBoost { get; }

    public Activity(string name, int energyRequirement, int happinessBoost)
    {
        Name = name;
        EnergyRequirement = energyRequirement;
        HappinessBoost = happinessBoost;
    }

    public void PerformActivity(Pet pet)
    {
        // Check if the pet has enough energy to perform the activity
        if (pet.HungerLevel >= EnergyRequirement)
        {
            // Perform the activity // do smth??
            Console.WriteLine($"{pet.Name} is performing qctivity.");
            // Adjust the pet's happiness and energy level based on the activity
            pet.IncreaseHappiness(HappinessBoost);
            pet.DecreaseHungerLevel(EnergyRequirement);
        }
        else
        {
            Console.WriteLine($"{pet.Name} doesn't have enough energy to {Name}.");
        }
    }
}
