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
    private string _name;
    private int _age;
    private int _health;
    private int _happiness;
    private int _hunger;
    private string _species;

    public string Name { get { return _name; } }
    public string Species { get {return _species;}}
    public int Age { get { return _age; } }
    public int Health { get { return _health; } }
    public int Happiness { get { return _happiness; } }
    public int HungerLevel { get { return _hunger; } }

    //if we want to see a dog breed, or a cat color,
    //make a method called getStatistics, override it in the cat and dog to print the special thing

    public Pet(string name, string species, int age)
    {
        _name = name;
        _species = species;
        _age = age;
        _health = 100; // Set health -> maximum
        _happiness = 100; // Set happiness -> maximum
        _hunger = 100; // Set hunger level -> maximum
    }

    public virtual void Play()
    {
        Console.WriteLine($"{Name} is playing with you!");
        
        IncreaseHappiness(10);
        DecreaseHungerLevel(5);

        Console.WriteLine($"{Name} is happy after playing!");
    }

    public void CapHappiness()
    {
        if (_happiness > 100)
        {
            _happiness = 100;
        }
    }

    public void Feed(FoodItem foodItem)
    {
        Console.WriteLine($"{Name} is eating {foodItem.Name}!");
        // Adjust health and hunger level based on the nutritional value of the food
        IncreaseHealth(foodItem.NutritionValue);
        IncreaseHappiness(5);
        IncreaseHungerLevel(10);
        
        if (foodItem.Type == FoodType.Treat){
            IncreaseHappiness(20);
            Console.WriteLine($"Because {Name} ate a treat, they are extra happy!");
        }
    }

    public void Sleep()
    {
        Console.WriteLine($"{Name} is sleeping.");
        IncreaseHealth(5);
        IncreaseHappiness(10);
        DecreaseHungerLevel(5);

        //problem: how do I implement this to check to see if the pet died?
        //AutoCheckHungerLevel(player);
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
        _happiness += amount;
        CapHappiness();
    }

    public void DecreaseHungerLevel(int amount)
    {
        _hunger -= amount;
    }

    public void IncreaseHungerLevel(int amount)
    {
        _hunger += amount;
    }


    public void DecreaseHealth(int amount)
    {
        _health -= amount;
    }

    public void IncreaseHealth(int amount)
    {
        _health += amount;
    }

    public void AutoCheckHungerLevel(Player player) // make it check everything
    {
        //so I need to figure this one out, how do I get it to check frequently and save the result?
        if (_hunger >= 100)
        {
            Console.WriteLine($"{Name} has starved to death!");
            player.RemovePet(this);
        }
    }

    //need a method which runs and checks to see if hunger reaches zero. if yes, then the pet dies.
}
