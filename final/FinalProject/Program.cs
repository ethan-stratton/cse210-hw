using System;
class Program {
    static void Main(string[] args)
{
    // Instantiates the game interface
    GameInterface gameInterface = new GameInterface();
    gameInterface.DisplayWelcomeMessage(); // welcomes user

    // Instantiate the player, perhaps add login function at a later time.,
    Player player = new Player("Player1");

    // Instantiate the pet shop, players get their pets here
    PetShop petShop = new PetShop(); // possible to modify the constructor to populate the pet shop with initial pets. also make random generation possible

    // Main game loop
    bool isRunning = true;
    while (isRunning)
    {
        // Displays main menu options
        gameInterface.DisplayMainMenu();

        // Gets user choice
        int choice = gameInterface.GetUserChoice();

        // Process user choice
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
                // testing out animation, remove in the final iteration
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
        Console.WriteLine("Sorry, the selected pet is not available.");
    }
}

static void InteractWithPets(Player player, GameInterface gameInterface)
{
    // Display the pets owned by the player
    Console.WriteLine("Interacting with pets...");
    gameInterface.DisplayPetsOwned(player);
    // Logic to choose a pet to interact with and perform actions (e.g., play, feed)
}
}

// Pet myPet = new Pet("Buddy");

//         // Instantiate activities
//         Activity playActivity = new Activity("playing", 10, 15);
//         Activity sleepActivity = new Activity("sleeping", 5, 20);

//         // Simulate interactions
//         playActivity.PerformActivity(myPet);
//         myPet.CheckHappiness();

//         sleepActivity.PerformActivity(myPet);
//         myPet.CheckHappiness();