public class Fish : Pet
{
    public string _species { get; }

    public Fish(string name, string species) : base(name, species, 0)
    {
        _species = species;
    }

    public override void Play()
    {
        Console.WriteLine($"{Name} is swimming gracefully!");
        // Adjust happiness and hunger level accordingly
        Happiness += 5;
        HungerLevel += 3;
    }

    public void StartFishBowlAnimation()
    {
        FishBowlAnimation.RunAnimation();
    }

}