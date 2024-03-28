using System.Collections.Generic;

public class Player
{
    public string PlayerName { get; }
    public List<Pet> PetsOwned { get; }

    public Player(string playerName)
    {
        PlayerName = playerName;
        PetsOwned = new List<Pet>();
    }

    public void AdoptPet(Pet pet)
    {
        PetsOwned.Add(pet);
        Console.WriteLine($"{PlayerName} adopted {pet.Name}!");
    }

    // Add other methods ...
}
