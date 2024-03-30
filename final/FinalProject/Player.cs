using System.Collections.Generic;

//potential ideas, play class which lists all the different ways you can play with your pet
public class Player
{
    private string _playerName;
    private List<Pet> _petsOwned;

    public string PlayerName { get { return _playerName;} }
    public List<Pet> PetsOwned {get {return _petsOwned;} }

    public Player(string playerName)
    {
        _playerName = playerName;
        _petsOwned = new List<Pet>();
    }
    public void AddPetToList(Pet pet)
    {   
        PetsOwned.Add(pet);
        Console.WriteLine($"{PlayerName} adopted {pet.Name}!");
    }
    public void AdoptPet(PetShop petShop)
    {
        // Display available pets in the pet shop
        petShop.DisplayAvailablePets();

        // Prompt the user to choose a pet to adopt
        Console.WriteLine("Enter the name of the pet you want to adopt:");
        string petName = Console.ReadLine();

        // tries to adopt the chosen pet from the pet shop
        Pet adoptedPet = petShop.AdoptPet(petName);

        if (adoptedPet != null)
        {
            // Add the adopted pet to the player's list of pets
            AddPetToList(adoptedPet);
        }
        else
        {
            Console.WriteLine("Sorry, the selected pet is not available for adoption.");
        }
    }
    public void RemovePet(Pet pet) // method which removes pet from list. (it died)
    {
        PetsOwned.Remove(pet);
    }

    public void PlayWithPet(int petIndex)
    {
        Pet selectedPet = PetsOwned[petIndex];

        selectedPet.Play(); // doesn't do overloaded method...?
    }

    public void FeedPet(int petIndex, FoodItem food)
    {
        Pet selectedPet = PetsOwned[petIndex];

        //somehow do functionality to feed the pets different food items you have on hand...
        selectedPet.Feed(food);
        Console.WriteLine($"{selectedPet.Name} is being fed!");
    }

    
    public void CheckPetHealth(int petIndex)
    {
        Pet selectedPet = PetsOwned[petIndex];

        // Display pet's health/happiness/Hunger/Age
        Console.WriteLine($"Health: {selectedPet.CheckHealth()}");
        Console.WriteLine($"Happiness: {selectedPet.CheckHappiness()}");
        Console.WriteLine($"Hunger: {selectedPet.CheckHunger()}");
        Console.WriteLine($"Age: {selectedPet.CheckAge()}");

    }

}
