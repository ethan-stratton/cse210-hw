public class Dog : Pet
{
    public string Breed { get; }
    public bool IsTrained { get; private set; }
    private List<string> _tricks;

    public Dog(string name, string species) : base(name, species, 0)
    {
        Breed = species;
        IsTrained = false;
    }

    public void Train(string trick)
    {
        Console.WriteLine($"{Name} is learning {trick}!");
        // Logic to train the dog to perform the trick
        IsTrained = true;
        _tricks.Add(trick);
    }
    //method to display known tricks?


    //be able to choose different activities for Playing vvv
    public override void Play()
    {
        Console.WriteLine($"{Name} is playing fetch!");
        // Adjust happiness and hunger level accordingly
        Happiness += 15;
        HungerLevel += 5;
    }
}