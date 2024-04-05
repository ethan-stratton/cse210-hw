using System.Collections.Generic;

public class PetShop
{
    private List<Pet> _availablePets;
    private List<string> dogNames = new List<string>
        {"Buddy","Max","Bailey","Charlie","Lucy","Molly","Sadie","Daisy","Rocky","Lola"};
    private List<string> catNames = new List<string>
        {"Whiskers","Luna","Simba","Tiger","Shadow","Milo","Oreo","Leo","Smokey","Cleo"};
    private List<string> fishNames = new List<string>
        {"Bubbles","Nemo","Finley","Splash","Goldie","Blue","Dory","Gill","Sushi","Marlin"};
    public PetShop()
    {
        //generate random pet names
        Random random = new Random();
        int randomIndexDog = random.Next(0, dogNames.Count);
        string randomDogName = dogNames[randomIndexDog];

        int randomIndexCat = random.Next(0, catNames.Count);
        string randomCatName = catNames[randomIndexCat];

        int randomIndexFish = random.Next(0, fishNames.Count);
        string randomFishName = fishNames[randomIndexFish];

        //random age generation too
        _availablePets = new List<Pet>();
        _availablePets.Add(new Cat($"{randomCatName}", "Cat", random.Next(1, 4)));
        _availablePets.Add(new Dog($"{randomDogName}", "Dog", random.Next(1, 4)));
        _availablePets.Add(new Fish($"{randomFishName}", "Fish", random.Next(1, 4)));
        // Add more pets if desired. It is possible to repopulate the pet store as well
    }

    public void DisplayAvailablePets() // displays pets in the pet shop
    {
        Console.WriteLine("Available Pets:");
        foreach (Pet pet in _availablePets)
        {
            Console.WriteLine($"Name: {pet.Name}, Species: {pet.Species}, Age: {pet.Age}");
        }
    }
    public Pet AdoptPet(string name)
    {
        Pet petToAdopt = _availablePets.Find(pet => pet.Name == name);
        if (petToAdopt != null)
        {
            _availablePets.Remove(petToAdopt);
        }
        return petToAdopt;
    }

}
