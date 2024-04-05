using System;
public class GameInterface
{
    public void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Virtual Pet Simulation Game!");
    }
    public void DisplayMainMenu()
    {
        Console.WriteLine("Main Menu:");
        Console.WriteLine("1. Adopt a pet");
        Console.WriteLine("2. Interact with your pets");
        Console.WriteLine("3. Buy Food from Pet Food Store");
        Console.WriteLine("4. Exit");
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
        for (int i = 0; i < player.PetsOwned.Count; i++)
        {
            // Print each pet with a number, so the user can select which pet they want
            Console.WriteLine($"{i + 1}. {player.PetsOwned[i].Name} ({player.PetsOwned[i].Species})");
        }
    }
    public void DisplayInteractMenu()
    {
        Console.WriteLine("Interact Menu:");
        Console.WriteLine("1. Play with a pet");
        Console.WriteLine("2. Choose special pet activity");
        Console.WriteLine("3. Feed a pet");
        Console.WriteLine("4. Check pet's health/happiness");
        Console.WriteLine("5. See Pet's Special Info");
        Console.WriteLine("6. Rename a pet");
        Console.WriteLine("7. Back to Main Menu");
    }
    public void RenamePetMenu(Player player)
    {
        if (player.PetsOwned.Count == 0)
        {
            Console.WriteLine("You currently don't own any pets.");
            return; // Return to the main menu
        }

        DisplayPetsOwned(player);

        int petIndex = GetPetChoice(player);

        Console.Write("Enter the new name for the pet: ");
        string newName = Console.ReadLine();

        player.RenamePet(petIndex, newName);
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
    public int GetActivityChoice(int maxActivityCount)
    {
        Console.Write("Enter the number of the activity: ");
        int activityIndex;
        while (!int.TryParse(Console.ReadLine(), out activityIndex) || activityIndex < 1 || activityIndex > maxActivityCount)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.Write("Enter the number of the activity: ");
        }
        return activityIndex - 1; // Subtract 1 to convert to 0-based index
    }
    public void DisplayExitMessage()
    {
        Console.WriteLine("Thank you for playing the Virtual Pet Simulation Game!");
        Console.WriteLine("Goodbye!");
    }
}
