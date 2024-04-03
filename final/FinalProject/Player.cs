using System.Collections.Generic;

//potential ideas, play class which lists all the different ways you can play with your pet, or perform different activites
public class Player
{    private string _playerName;
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
        petShop.DisplayAvailablePets();

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

        if (selectedPet is Dog dog)
        {
            dog.Play();
        }
        else if (selectedPet is Cat cat)
        {
            cat.Play();
        }
        else if (selectedPet is Fish fish)
        {
            fish.Play();
        }
        else
        {
            selectedPet.Play();
        }
    }
    public void RenamePet(int petIndex, string newName)
{
    if (petIndex >= 0 && petIndex < PetsOwned.Count)
    {
        Pet pet = PetsOwned[petIndex];
        Console.WriteLine($"Renaming {pet.Name} to {newName}.");
        pet.Rename(newName);
    }
    else
    {
        Console.WriteLine("Invalid pet index.");
    }
}
    public void FeedPet(int petIndex, FoodItem food)
    {
        Pet selectedPet = PetsOwned[petIndex];

        //somehow do functionality to feed the pets different food items you have on hand...
        //access FoodShop
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

    public void SeePetSpecialStats(int petIndex)
    {
        Pet selectedPet = PetsOwned[petIndex];
        Console.WriteLine($"{selectedPet.GetSpecialStats()}");
    }

    public void SeePetActivities(int petIndex)
    {
        Pet selectedPet = PetsOwned[petIndex];
        selectedPet.ListActivities();

    }
    public int GetNumberOfActivitiesForPet(int petIndex)
    {
        if (petIndex >= 0 && petIndex < PetsOwned.Count)
        {
            Pet selectedPet = PetsOwned[petIndex];
            return selectedPet.PetActivities.Count;
        }
        return 0; // Return 0 if pet index is invalid or if pet has no activities
    }
    public void PerformPetActivity(int petIndex, int activityIndex)
    {
        Pet selectedPet = PetsOwned[petIndex];
        Activity selectedActivity = selectedPet.PetActivities[activityIndex];

        Console.WriteLine($"{selectedPet.Name} is going to perform the {selectedActivity.ActivityName} activity.");
        // Perform the selected activity
        selectedActivity.PerformActivity(selectedPet);

    }

    public void RemoveDeadPets()
    {
        for (int i = PetsOwned.Count - 1; i >= 0; i--)
        {
            if (PetsOwned[i].IsDead)
            {
                Console.WriteLine($"{PlayerName}'s pet {PetsOwned[i].Name} has passed away.");
                PetsOwned.RemoveAt(i);
            }
        }
    }

}
