using System.Collections.Generic;

//somehow be able to see what color the cat is
public class Cat : Pet
{
    public string _color { get; }
    public bool IsScratching { get; private set; }
    private readonly List<string> _catColors = new List<string> { "Red", "Green", "Blue", "Yellow", "Orange", "Purple", "Cyan", "Magenta" };
    private Random _random;
    private int _ageOfDeath = 20; //once age hits 20 for cats, it dies.

    public Cat(string name, string species) : base(name, species, 0)
    {
        int index = _random.Next(0, _catColors.Count);

        _color = _catColors[index]; // generate random color for the cat in the constructor
        IsScratching = false;
    }
    public void Scratch()
    {
        Console.WriteLine($"{Name} is scratching!");
        // simulate scratching behavior
        IsScratching = true;
        //if isScratching... do stuff elsewhere
    }

    public override void Play()
    {
        Console.WriteLine($"{Name} is chasing a toy!");
        Happiness += 10;
        HungerLevel += 5;
    }
}
