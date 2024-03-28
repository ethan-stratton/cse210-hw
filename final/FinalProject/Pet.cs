using System;

public class Pet
{
    public string Name { get; }
    public string Species { get; }
    public int Age { get; }
    public int Health { get; protected set; }
    public int Happiness { get; protected set; }
    public int HungerLevel { get; protected set; }

    public Pet(string name, string species, int age)
    {
        Name = name;
        Species = species;
        Age = age;
        Health = 100; // Set health -> maximum
        Happiness = 100; // Set happiness -> maximum
        HungerLevel = 0; // Set hunger level -> minimum
    }

    public virtual void Play()
    {
        Console.WriteLine($"{Name} is playing with you!");
        // Adjust happiness and hunger level accordingly
        Happiness += 10;
        HungerLevel += 5;
    }

    public void Feed(FoodItem foodItem)
    {
        // Logic for feeding the pet with a specific food item
        Console.WriteLine($"{Name} is eating {foodItem.Name}!");
        // Adjust health and hunger level based on the nutritional value of the food
        Health += foodItem.NutritionValue;
        Happiness += 5;
        HungerLevel -= 10;
        if (foodItem.Type == FoodType.Treat){
            Happiness += 20;
            Console.WriteLine($"Because {Name} ate a treat, they are extra happy!");
            // Ensure happiness doesn't exceed maximum value
            if (Happiness > 100)
            {
                Happiness = 100;
            }
        }
    }

    public void Sleep()
    {
        // Logic for the pet to sleep
        Console.WriteLine($"{Name} is sleeping.");
        // Adjust health, happiness, and hunger level accordingly
        Health += 5;
        Happiness += 10;
        HungerLevel -= 5;
    }

//should maybe make a method which displays it in a table, very easy to read (like "CheckStatus" or smth)
    public void CheckHealth()
    {
        // Logic to check the pet's health status
        Console.WriteLine($"{Name}'s health: {Health}");
    }

    public void CheckHappiness()
    {
        // Logic to check the pet's happiness status
        Console.WriteLine($"{Name}'s happiness: {Happiness}");
    }

//IncreaseHappiness and DecreaseHungerLevel were implemented in order to give access to the member variables from Activity class
    public void IncreaseHappiness(int amount)
    {
        Happiness += amount;
    }

    public void DecreaseHungerLevel(int amount)
    {
        HungerLevel -= amount;
    }
}
