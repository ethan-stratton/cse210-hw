using System;

public class GameInterface
{
    public void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Virtual Pet Simulation Game!");
        Console.WriteLine("Let's get started...");
    }

    public void DisplayMainMenu()
    {
        Console.WriteLine("Main Menu:");
        Console.WriteLine("1. Adopt a pet");
        Console.WriteLine("2. Interact with your pets");
        Console.WriteLine("3. Exit");
    }

    public int GetUserChoice()
    {
        Console.Write("Enter your choice: ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            Console.Write("Enter your choice: ");
        }
        return choice;
    }

    public void DisplayPetsOwned(Player player)
    {
        Console.WriteLine($"You currently own {player.PetsOwned.Count} pet(s):");
        foreach (Pet pet in player.PetsOwned)
        {
            Console.WriteLine($"- {pet.Name} ({pet.Species})");
        }
    }

    public void DisplayInteractMenu()
    {
        Console.WriteLine("Interact Menu:");
        Console.WriteLine("1. Play with a pet");
        Console.WriteLine("2. Feed a pet");
        Console.WriteLine("3. Check pet's health/happiness");
        Console.WriteLine("4. Back to Main Menu");
    }

    public int GetPetChoice(Player player)
    {
        Console.WriteLine("Choose a pet to interact with:");
        DisplayPetsOwned(player);
        Console.Write("Enter the number of the pet: ");
        int petIndex;
        while (!int.TryParse(Console.ReadLine(), out petIndex) || petIndex < 1 || petIndex > player.PetsOwned.Count)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.Write("Enter the number of the pet: ");
        }
        return petIndex - 1; // - 1 so list is read properly (0-based list)
    }

    public void DisplayExitMessage()
    {
        Console.WriteLine("Thank you for playing the Virtual Pet Simulation Game!");
        Console.WriteLine("Goodbye!");
    }
}
