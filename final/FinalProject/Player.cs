using System.Collections.Generic;
public class Player
{    
    private string _playerName;
    private List<Pet> _petsOwned;
    private double _playerCash;
    public string PlayerName { get { return _playerName;} }
    public List<Pet> PetsOwned {get {return _petsOwned;} }
    public double PlayerCash {get {return _playerCash;}}
    private List<FoodItem> _inventory;

    public Player(string playerName)
    {
        _playerName = playerName;
        _petsOwned = new List<Pet>();

        _playerCash = 100.00; // Default player cash. Only have 100 bucks
        _inventory = new List<FoodItem>();
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
    public void FeedPet(int petIndex)
    {
        Console.WriteLine("Select a food item to feed your pet:");
        for (int i = 0; i < _inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_inventory[i].Name} - {_inventory[i].NutritionValue} Nutrition");
        }

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            if (choice >= 1 && choice <= _inventory.Count)
            {
                Pet selectedPet = PetsOwned[petIndex];
                selectedPet.Feed(_inventory[choice - 1]);
                _inventory.RemoveAt(choice - 1); // Remove the fed food item from inventory
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
    public void BuyFoodItem(FoodShop foodShop)
    {
        if (!CheckPlayerHasEnoughCash())
        {
            Console.WriteLine("You don't have enough money to buy food.");
            return;
        }

        int selectedFoodIndex = GetSelectedFoodIndex(foodShop);
        if (selectedFoodIndex == -1)
        {
            Console.WriteLine("Invalid input or food item is not available.");
            return;
        }

        FoodItem selectedFood = foodShop.PurchaseFoodItem(selectedFoodIndex);
        if (selectedFood == null)
        {
            Console.WriteLine("Invalid choice or food item is not available.");
            return;
        }

        if (CheckPlayerHasEnoughCashForFood(selectedFood))
        {
            _inventory.Add(selectedFood);
            _playerCash -= selectedFood.Price;
            Console.WriteLine($"You have purchased {selectedFood.Name}.");
        }
        else
        {
            Console.WriteLine("You don't have enough money to buy this food item.");
        }
    }
    private bool CheckPlayerHasEnoughCash()
    {
        return _playerCash > 0;
    }
    private int GetSelectedFoodIndex(FoodShop foodShop)
    {
        foodShop.DisplayAvailableFoodItems();
        Console.WriteLine("Enter the number of the food item you want to purchase:");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 4)
        {
            return choice;
        }
        return -1;
    }
    private bool CheckPlayerHasEnoughCashForFood(FoodItem selectedFood)
    {
        return _playerCash >= selectedFood.Price;
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
    private void SeePetActivities(int petIndex)
    {
        Pet selectedPet = PetsOwned[petIndex];
        selectedPet.ListActivities();
    }
    private int GetNumberOfActivitiesForPet(int petIndex)
    {
        if (petIndex >= 0 && petIndex < PetsOwned.Count)
        {
            Pet selectedPet = PetsOwned[petIndex];
            return selectedPet.PetActivities.Count;
        }
        return 0; // Return 0 if pet has no activities
    }
    private void PerformPetActivity(int petIndex, int activityIndex)
    {
        Pet selectedPet = PetsOwned[petIndex];
        Activity selectedActivity = selectedPet.PetActivities[activityIndex];

        Console.WriteLine($"{selectedPet.Name} is going to perform the {selectedActivity.ActivityName} activity.");
        // Perform the selected activity
        selectedActivity.PerformActivity(selectedPet);

    }
    public void InteractWithPetActivities(GameInterface gameInterface) //this method uses the above three methods
    {
        int petIndex = gameInterface.GetPetChoice(this);
        int numberOfActivities = GetNumberOfActivitiesForPet(petIndex);

        if (numberOfActivities > 0)
        {
            SeePetActivities(petIndex);
            int activityChoice = gameInterface.GetActivityChoice(numberOfActivities);
            PerformPetActivity(petIndex, activityChoice);
        }
        else
        {
            Console.WriteLine("This pet doesn't have any activities.");
        }
    }
    public void RemoveDeadPets()
    {
        for (int i = PetsOwned.Count - 1; i >= 0; i--)
        {
            if (PetsOwned[i].IsDead)
            {
                Console.WriteLine($"{PlayerName}'s pet {PetsOwned[i].Name} has passed away...");
                PetsOwned.RemoveAt(i);
            }
        }
    }

}
