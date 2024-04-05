using System.Collections.Generic;
public class Fish : Pet
{    private string _type;
    private readonly List<string> _fishList = new List<string> 
    { "Salmon","Tuna","Cod","Trout","Bass","Mackerel","Sardine","Haddock", "Catfish", "Perch"};
    public string Type {get {return _type;}}
    public Fish(string name, string species, int age) : base(name, species, age)
    {
        Random random = new Random();
        int index = random.Next(0, _fishList.Count);
        _type = _fishList[index]; 
        SetPreferredFoodType(FoodType.SpecialDiet);

        SetDeathAge(5);
        AddNewActivity("Swim Around", 5, 5, StartFishBowlAnimation); //run the StartFishBowlAnimation
    }
    public override string GetSpecialStats()
    {
        return $"Your {Name} is a {Species}, age {Age}. It is of the {Type} type. ";
    }
    public override void Play()
    {
        Console.WriteLine($"{Name} is swimming gracefully!");
        IncreaseHappiness(5);
        DecreaseHungerLevel(5);
        UpdateStatus();
    }
    public override void UpdateStatus()
    {
        DecreaseHealth(5); 
        DecreaseHappiness(5);
        DecreaseHungerLevel(5);

        _ageCounter++; //every 3 times you do an activity or play with your pet, they age one year.
        if (_ageCounter >= 3)
        {
            GetOlder();
            _ageCounter = 0;
        }
    }
    public void StartFishBowlAnimation()
    {
        FishBowlAnimation.RunAnimation();
    }

}