using System;

//problems: not enough encapsulation
// need to save data on the pets in a text file...? too much work... could save user info to it
// needs to be able to access overloaded methods from each pet class, so the dog will play fetch, cat 
//will scratch. etc/ always says "is playing with you" never the overloaded method!!
//use polymorphism in a meaningful way

/// <summary>
/// summarize the code here
/// </summary>
class Program {
    static void Main(string[] args)
    {
        Console.Clear();
        // Instantiates the game interface
        GameInterface gameInterface = new GameInterface();
        gameInterface.DisplayWelcomeMessage(); // welcomes user

        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();

        // Instantiate the player, perhaps add login function at a later time...
        Player player = new Player($"{userName}");

        // Instantiate the pet shop, players get their pets here
        PetShop petShop = new PetShop(); // possible to modify the constructor to populate the pet shop with initial pets. also make random generation possible

        // Main game loop
        bool isRunning = true;
        while (isRunning)
        {
            //main menu options
            gameInterface.DisplayMainMenu();

            //gets user choice
            int choice = gameInterface.GetUserChoice();

            switch (choice)
            {
                case 1:
                    AdoptPet(player, petShop); // Pass petShop to the AdoptPet method
                    break;
                case 2:
                    InteractWithPets(player, gameInterface);
                    break;
                case 3:
                    // Exits game
                    isRunning = false;
                    break;
                case 4:
                    // testing out animation, remove in the final iteration lol
                    Fish myFish = new Fish("Bubbles", "Goldfish");
                    myFish.StartFishBowlAnimation();
                    break;
                default:
                    Console.WriteLine("Invalid choice... Please try again.");
                    break;
            }
        }
        // exit
        gameInterface.DisplayExitMessage();
    }
static void AdoptPet(Player player, PetShop petShop)
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
        player.AdoptPet(adoptedPet);
    }
    else
    {
        Console.WriteLine("Sorry, the selected pet is not available for adoption.");
    }
}

//so before I add anything to be able to InteractWithPets, I'm going to see if there is a different way to
// split up functionality so it doesn't look like AdoptPet.

//ok I lied I went ahead and did it all here first without finding a better way.
    static void InteractWithPets(Player player, GameInterface gameInterface)
{

    if (player.PetsOwned.Count == 0)
    {
        Console.WriteLine("You currently don't own any pets.");
        return; // Return to the main menu
    }

    bool interacting = true;
    
    while (interacting)
    {
        // Display the interaction menu for the pets
        gameInterface.DisplayInteractMenu();

        // Get user's action...
        int actionChoice = gameInterface.GetUserChoice();

        // Process the user's choice
        switch (actionChoice)
        {
            case 1:
                // Play with a pet
                PlayWithPet(player, gameInterface);
                break;
            case 2:
                // Feed a pet
                FeedPet(player, gameInterface);
                break;
            case 3:
                // Check pet's health/happiness
                CheckPetHealth(player, gameInterface);
                break;
            case 4:
                // Back to Main Menu
                interacting = false;
                break;
            default:
                Console.WriteLine("Invalid choice... Please try again.");
                break;
        }
    }
}

    static void PlayWithPet(Player player, GameInterface gameInterface)
    {
        // Get the pet to interact with
        int petIndex = gameInterface.GetPetChoice(player);
        Pet selectedPet = player.PetsOwned[petIndex];

        // Perform action
        selectedPet.Play(); // doesn't do overloaded method...?
        Console.WriteLine($"{selectedPet.Name} is happy after playing!");
    }

    static void FeedPet(Player player, GameInterface gameInterface)
    {
        // Get the pet to interact with
        int petIndex = gameInterface.GetPetChoice(player);
        Pet selectedPet = player.PetsOwned[petIndex];

        // Perform action
        //somehow do functionality to feed the pets different food items you have on hand...
        FoodItem default_pet_food = new FoodItem("DefaultFood", 10.00, FoodType.DryFood);
        selectedPet.Feed(default_pet_food);
        Console.WriteLine($"{selectedPet.Name} is being fed!");
    }

    static void CheckPetHealth(Player player, GameInterface gameInterface)
    {
        // Get the pet to interact with
        int petIndex = gameInterface.GetPetChoice(player);
        Pet selectedPet = player.PetsOwned[petIndex];

        // Display pet's health/happiness/Hunger/Age
        Console.WriteLine($"Health: {selectedPet.CheckHealth()}");
        Console.WriteLine($"Happiness: {selectedPet.CheckHappiness()}");
        Console.WriteLine($"Hunger: {selectedPet.CheckHunger()}");
        Console.WriteLine($"Age: {selectedPet.CheckAge()}");
    }
}