using System;

public static class Program {
    static void Main(string[] args)
    {
        (GameInterface game, Player player, PetShop petshop, FoodShop foodShop) = InitializeGame();
        RunGame(game, player, petshop, foodShop);   
    }
    static (GameInterface, Player, PetShop, FoodShop) InitializeGame(){
        Console.Clear();

        GameInterface gameInterface = new GameInterface();
        gameInterface.DisplayWelcomeMessage();

        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        // Instantiate the player
        Player player = new Player($"{userName}");
        // Instantiate the pet shop, players get their pets here
        PetShop petShop = new PetShop();
        // Instantiate the food shop, players get food for their here. Currently no mechanics to earn money
        FoodShop foodShop = new FoodShop();
        
        return (gameInterface, player, petShop, foodShop);
    }
    static void RunGame(GameInterface game, Player player, PetShop petShop, FoodShop foodShop){
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
                    // adopt pet
                    player.AdoptPet(petShop);
                    player.RemoveDeadPets();
                    break;
                case 2:
                    // go to pet interaction menu
                    InteractWithPetsMenu(player, game);
                    player.RemoveDeadPets();
                    break;
                case 3:
                    //the food store appears when the player Buys Food below
                    player.BuyFoodItem(foodShop);
                    break;
                case 4:
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

            // Get user's action
            int actionChoice = gameInterface.GetUserChoice();

            switch (actionChoice)
            {
                case 1:
                    // Play with a pet
                    player.PlayWithPet(gameInterface.GetPetChoice(player));
                    player.RemoveDeadPets();
                    break;
                case 2:
                    // do special pet activities. method below views the pet activities and enables user to choose one
                    player.InteractWithPetActivities(gameInterface);
                    player.RemoveDeadPets();
                    break;
                case 3: 
                    // Feed a pet
                    player.FeedPet(gameInterface.GetPetChoice(player));
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
                    // rename a pet
                    gameInterface.RenamePetMenu(player);
                    player.RemoveDeadPets();
                    break;
                case 7:
                    // back to Main Menu
                    interacting = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice... Please try again.");
                    break;
            }
        }
    }

}