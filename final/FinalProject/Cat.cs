public class Cat : Pet
{
    public string _color { get; }
    public bool IsScratching { get; private set; }

    public Cat(string name, string species) : base(name, species, 0)
    {
        _color = species;
        IsScratching = false;
    }

    public void Scratch()
    {
        Console.WriteLine($"{Name} is scratching!");
        // Logic to simulate scratching behavior
        IsScratching = true;
    }

    public override void Play()
    {
        Console.WriteLine($"{Name} is chasing a toy!");
        // Adjust happiness and hunger level accordingly
        Happiness += 10;
        HungerLevel += 5;
    }
}
