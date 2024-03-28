using System;

//somehow make it so values cannot exceed:
//health cannot exceed 100, nor go below 0. It dies if it hits 0
//hunger cannot go below 0, neither can it go above 100. it dies if it hits 100
//happiness cannot got above 100 or below 0. it dies if it hits 0

//might get points off if they are all get and set
//all have to be private...?

//pets need to constantly decrease in health and happiness at different rates
//they need to increase in age slowly

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

        // Ensure happiness doesn't exceed maximum value
        if (Happiness > 100)
        {
            Happiness = 100;
        }
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

        //problem: how do I implement this to check to see if the pet died?
        //this.AutoCheckHungerLevel(player);
    }

//should maybe make a method which displays it in a table, very easy to read (like "CheckStatus" or smth)
    public int CheckHealth()
    {
        return Health;
    }

    public int CheckHappiness()
    {
        return Happiness;
    }
    public int CheckHunger()
    {
        return HungerLevel;
    }
    public int CheckAge()
    {
        return Age;
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

    public void AutoCheckHungerLevel(Player player)
    {
        //so I need to figure this one out, how do I get it to check frequently and save the result?
        if (HungerLevel >= 100)
        {
            Console.WriteLine($"{Name} has starved to death!");
            player.RemovePet(this);
        }
    }

    //need a method which runs and checks to see if hunger reaches zero. if yes, then the pet dies.
}
