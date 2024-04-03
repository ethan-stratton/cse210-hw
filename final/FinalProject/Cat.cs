using System.Collections.Generic;

//somehow be able to see what color the cat is
public class Cat : Pet
{   private string _color;
    private bool _isScratching;
    private readonly List<string> _catColors = new List<string> { 
        "Black",
        "White",
        "Grey", 
        "Calico", 
        "Orange", 
        "Tortoiseshell", 
        "Siamese", 
        "Blue",
        "Tabby",
        "Cream",
        };
    public string Color {get {return _color;}}
    public bool IsScratching { get {return _isScratching;} }
    public Cat(string name, string species, int age) : base(name, species, age)
    {
        Random random = new Random();
        int index = random.Next(0, _catColors.Count);
        _color = _catColors[index]; // generate random color for the cat in the constructor

        SetDeathAge(20);
        AddNewActivity("Hunt Mice", 15, 15);
        AddNewActivity("Cuddle", 5, 5);
        AddNewActivity($"Watch {Name} Clean Itself", 5, 3);

        _isScratching = false;
    }
    public override string GetSpecialStats()
    {
        return $"Your {Name} is a {Species}, age {Age}. It has a {Color} color.";
    }
    public void Scratch()
    {
        Console.WriteLine($"{Name} is scratching!");
        // simulate scratching behavior
        _isScratching = true;
        //if isScratching... do stuff elsewhere?
    }
    public override void Play()
    {
        Console.WriteLine($"{Name} is chasing a toy!");
        IncreaseHappiness(10);
        DecreaseHungerLevel(5);
        UpdateStatus();
    }
    public override void UpdateStatus()
    {
        DecreaseHealth(1); 
        DecreaseHappiness(7);
        DecreaseHungerLevel(5);

        _ageCounter++; //every 5 times you do an activity or play with your pet, they age one year.
        if (_ageCounter >= 5)
        {
            GetOlder();
            _ageCounter = 0;
        }
    }
}
