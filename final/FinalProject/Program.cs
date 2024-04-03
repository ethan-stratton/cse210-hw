using System;

// need to save data on the pets in a text file...? too much work... could save user info to it

/// <summary>
/// summarize the code here
/// </summary>
class Program {
    static void Main(string[] args)
    {
        
        (GameInterface game, Player player, PetShop petshop) = InitializeGame();

        RunGame(game, player, petshop);
        
    }
static (GameInterface, Player, PetShop) InitializeGame(){
    Console.Clear();

    GameInterface gameInterface = new GameInterface();
    gameInterface.DisplayWelcomeMessage();

    Console.Write("Please enter your name: ");
    string userName = Console.ReadLine();
    // Instantiate the player, perhaps add login function at a later time...
    Player player = new Player($"{userName}");

    // Instantiate the pet shop, players get their pets here
    PetShop petShop = new PetShop();
    
    return (gameInterface, player, petShop);
}
static void RunGame(GameInterface game, Player player, PetShop petShop){
    // Main game loop
        bool isRunning = true;
        while (isRunning)
        {
            //main menu options
            game.DisplayMainMenu();

            //gets user choice
            int choice = game.GetUserChoice();

            switch (choice)
            {
                case 1:
                    player.AdoptPet(petShop); // Pass petShop to the AdoptPet method
                    player.RemoveDeadPets();
                    break;
                case 2:
                    InteractWithPetsMenu(player, game);
                    player.RemoveDeadPets();
                    break;
                case 3:
                    // Exits game
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice... Please try again.");
                    break;
            }
        }
        // exit
        game.DisplayExitMessage();
}
static void InteractWithPetsMenu(Player player, GameInterface gameInterface)
{
    bool interacting = true;
    
    while (interacting)
    {
        if (player.PetsOwned.Count == 0) // we need this if statement in case the user's pet dies while they are in the Interact Menu
        {
            Console.WriteLine("You currently don't own any pets.");
            return; // Return to the main menu
        }
        // Display the interaction menu for the pets
        gameInterface.DisplayInteractMenu();

        // Get user's action...
        int actionChoice = gameInterface.GetUserChoice();

        // Process the user's choice
        switch (actionChoice)
        {
            case 1:
                // Play with a pet
                player.PlayWithPet(gameInterface.GetPetChoice(player));
                player.RemoveDeadPets();
                break;
            case 2:
                int petIndex = gameInterface.GetPetChoice(player);
                int numberOfActivities = player.GetNumberOfActivitiesForPet(petIndex); // one of the toughest challenges to surmount
                // was finding a way to get interaction with the pet class, the program, the player class, and the game interface
                // I somehow wonder if the design is very poor because of that
                if (numberOfActivities > 0)
                {
                    player.SeePetActivities(petIndex);
                    int activityChoice = gameInterface.GetActivityChoice(numberOfActivities);
                    player.PerformPetActivity(petIndex, activityChoice);
                }
                else
                {
                    Console.WriteLine("This pet doesn't have any activities.");
                }
                break;
            case 3:
                // Feed a pet
                FoodItem default_pet_food = new FoodItem("DefaultFood", 10.00, FoodType.DryFood);
                player.FeedPet(gameInterface.GetPetChoice(player), default_pet_food);
                player.RemoveDeadPets();
                break;
            case 4:
                // Check pet's health/happiness
                player.CheckPetHealth(gameInterface.GetPetChoice(player));
                player.RemoveDeadPets();
                break;
            case 5:
                // get pets special info
                player.SeePetSpecialStats(gameInterface.GetPetChoice(player));
                player.RemoveDeadPets();
                break;
            case 6:
                // Rename a pet
                gameInterface.RenamePetMenu(player);
                player.RemoveDeadPets();
                break;
            case 7:
                // Back to Main Menu
                interacting = false;
                break;
            default:
                Console.WriteLine("Invalid choice... Please try again.");
                break;
        }
    }
}

}