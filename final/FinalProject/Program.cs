using System;

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
    PetShop petShop = new PetShop(); // possible to modify the constructor to populate the pet shop with initial pets. also make random generation possible
    
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
                    break;
                case 2:
                    InteractWithPetsMenu(player, game);
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
        game.DisplayExitMessage();
}
static void InteractWithPetsMenu(Player player, GameInterface gameInterface)
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
                player.PlayWithPet(gameInterface.GetPetChoice(player));
                break;
            case 2:
                // Feed a pet
                FoodItem default_pet_food = new FoodItem("DefaultFood", 10.00, FoodType.DryFood);
                player.FeedPet(gameInterface.GetPetChoice(player), default_pet_food);
                break;
            case 3:
                // Check pet's health/happiness
                player.CheckPetHealth(gameInterface.GetPetChoice(player));
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

}