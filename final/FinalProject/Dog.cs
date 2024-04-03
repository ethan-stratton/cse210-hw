using System.Collections.Generic;

public class Dog : Pet
{

    //add list of activities that can be performed with your pet. allow ability to train the dog
    private string _breed;
    private List<string> _tricks;
    private bool _isTrained;
    private readonly List<string> _dogBreeds = new List<string> {
        "Mutt", 
        "Pit Bull", 
        "Jack Russell Terrier", 
        "Portuguese Water Dog", 
        "Rottweiler", 
        "Doberman Pinscher", 
        "Bloodhound", 
        "Pug", 
        "Bulldog",
        };
    public string Breed { get { return _breed; } }
    public List<string> Tricks {get {return _tricks;}}
    public bool IsTrained { get {return _isTrained;} }

    public Dog(string name, string species, int age) : base(name, species, age)
    {
        Random random = new Random();
        int index = random.Next(0, _dogBreeds.Count);
        _breed = _dogBreeds[index]; // generate random breed

        SetDeathAge(15); // hardcoded right now

        _isTrained = false;
        _tricks = new List<string>{};
        AddNewActivity("Teach a New Trick", 15, 20); // somehow be able to call the Train method from Activity?
        AddNewActivity("Go For a Walk", 13, 21);
    }
    public void Train(string trick)
    {
        Console.WriteLine($"{Name} is learning {trick}!");
        _isTrained = true;
        _tricks.Add(trick);
    }
    //method to display known tricks?

    //be able to choose different activities for Playing vvv
    public override void Play()
    {
        Console.WriteLine($"{Name} is playing fetch!");
        IncreaseHappiness(15);
        DecreaseHealth(5);
        UpdateStatus();
    }
    public override string GetSpecialStats()
    {
        return $"Your {Name} is a {Species}, age {Age}. It is of type {Breed} and knows {_tricks.Count} tricks.";
    }
    public override void UpdateStatus()
    {
        DecreaseHealth(2); 
        DecreaseHappiness(1);
        DecreaseHungerLevel(10);

        _ageCounter++; //every 4 times you do an activity or play with your pet, they age one year.
        if (_ageCounter >= 4)
        {
            GetOlder();
            _ageCounter = 0;
        }
    }
}