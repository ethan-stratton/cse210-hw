using System;
using System.ComponentModel;

// add new list of activites every pet can do. add more to the list in the derived classes.
// use the activity class and initialize them.
// add "activity menu" to the game interface

public class Pet
{
    private string _name;
    private int _age;
    private int _health;
    private int _happiness;
    private int _hunger;
    private string _species;
    private int _ageOfDeath;
    private bool _isDead; // player can see if a Pet is dead, and if one of the pets is dead, remove it from list
    protected int _ageCounter;
    private List<Activity> _petActivites;
    public string Name { get { return _name; } }
    public string Species { get {return _species;}}
    public int Age { get { return _age; } }
    public int Health { get { return _health; } }
    public int Happiness { get { return _happiness; } }
    public int HungerLevel { get { return _hunger; } }
    public bool IsDead { get { return _isDead; } }
    public List<Activity> PetActivities {get {return _petActivites;}}


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

        _petActivites = new List<Activity>();

        Activity Stare = new Activity("Do Nothing With Your Pet", 0, 0);
        _petActivites.Add(Stare);
    }

    public void AddNewActivity(string name, int energyRequired, int happinessBoost)
    {
        Activity activity = new Activity(name, energyRequired, happinessBoost);
        _petActivites.Add(activity);
    }

    public void Rename(string newName)
    {
        _name = newName;
    }

    public virtual void Play()
    {
        Console.WriteLine($"{Name} is playing with you!");
        IncreaseHappiness(10);
        DecreaseHungerLevel(5);
        Console.WriteLine($"{Name} is happy after playing!");
    }
    public void ListActivities(){
        Console.WriteLine($"Activities for {Name}:");
        for (int i = 0; i < PetActivities.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {PetActivities[i].ActivityName}");
        }
    }

    
    public virtual string GetSpecialStats()
    {
        return $"{Name}, {Species}, {Age}";
    }
    public void CapHappiness()
    {
        if (_happiness > 100)
        {
            _happiness = 100;
        }
        if (_happiness < 0 )
        {
            _happiness = 0;
        }
        DeathCheck();
    }
    public void CapHealth()
    {
        if (_health > 100)
        {
            _health = 100;
        }
        if (_health < 0)
        {
            _health = 0;
            // kill pet
        }
        DeathCheck();
    }
    public void CapHunger()
    {
        if (_hunger > 100)
        {
            _hunger = 100;
        }
        if (_hunger < 0)
        {
            _hunger = 0;
            //kill pet
        }
        DeathCheck();
    }
    public void Feed(FoodItem foodItem)
    {
        Console.WriteLine($"{Name} is eating {foodItem.Name}!");
        // Adjust health and hunger level based on the nutritional value of the food
        IncreaseHealth(foodItem.NutritionValue);
        IncreaseHappiness(5);
        IncreaseHungerLevel(15);
        
        if (foodItem.Type == FoodType.Treat){
            IncreaseHappiness(20);
            Console.WriteLine($"Because {Name} ate a treat, they are extra happy!");
        }
    }


    public void SetDeathAge(int age)
    {
        _ageOfDeath = age;
    }
    public void Sleep()
    {
        Console.WriteLine($"{Name} is sleeping.");
        IncreaseHealth(5);
        IncreaseHappiness(10);
        DecreaseHungerLevel(5);
    }
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
    public virtual void UpdateStatus()
    {
        DecreaseHealth(5); 
        DecreaseHappiness(5);
        IncreaseHungerLevel(5);

        _ageCounter++; //every 5 times you do an activity or play with your pet, they age one year.
        if (_ageCounter >= 5)
        {
            GetOlder();
            _ageCounter = 0;
        }
    }
    public void GetOlder()
    {
        _age++; //pet ages one year
    }
    public void IncreaseHappiness(int amount)
    {
        _happiness += amount;
        CapHappiness();
    }
    public void DecreaseHappiness(int amount)
    {
        _happiness -= amount;
        CapHappiness();
    }
    public void DecreaseHungerLevel(int amount)
    {
        _hunger -= amount;
        CapHunger();
    }
    public void IncreaseHungerLevel(int amount)
    {
        _hunger += amount;
        CapHunger();
    }
    public void DecreaseHealth(int amount)
    {
        _health -= amount;
        CapHealth();
    }
    public void IncreaseHealth(int amount)
    {
        _health += amount;
        CapHealth();
    }
    public void Die()
    {
        _isDead = true;
    }
    public void DeathCheck() 
    //the player would need to have a method to check if the pet is dead adn remove it from their list.
    {
        if (_hunger <= 0)
        {
            Console.WriteLine($"{Name} has starved!");
            Die();
        }
        if (_health <= 0)
        {
            Console.WriteLine($"{Name} is disease-ridden!");
            Die();
        }
        if (_age >= _ageOfDeath)
        {
            Console.WriteLine($"{Name} became frail and old.");
            Die();
        }
        if (_happiness <= 0)
        {
            Console.WriteLine($"{Name} was very depressed and lethargic.");
            Die();
        }
    }
}
