public class Fish : Pet
{
    public string _species { get; }

    //once age hits 10 for fish, it dies.
    public Fish(string name, string species) : base(name, species, 0)
    {
        _species = species;
    }

    public override void Play()
    {
        Console.WriteLine($"{Name} is swimming gracefully!");
        Happiness += 5;
        HungerLevel += 3;
    }

    public void StartFishBowlAnimation()
    {
        FishBowlAnimation.RunAnimation();
    }

}