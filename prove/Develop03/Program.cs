using System;

class Program
{
    static void Main(string[] args)
    {
        // Store a scripture, including both the reference (for example "John 3:16") and the text of the scripture.
        Reference reference1 = new Reference("John", "3", "16");
        Scripture scripture1 = new Scripture("For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");

        // Accommodate scriptures with multiple verses, such as "Proverbs 3:5-6".
        //add multi verse accommodation
//         Scripture scripture2 = new Scripture
//         ("Proverbs 3:5-6", 
// @"Trust in the Lord with all your heart
//     and lean not on your own understanding;
//  in all your ways submit to him,
//     and he will make your paths straight.");

        Console.WriteLine("Choose Difficulty: Easy, Medium, Hard, or Impossible");
        string userDifficulty = Console.ReadLine();
        scripture1.setDifficulty(userDifficulty.ToLower());

        // Clear the console screen and display the complete scripture, including the reference and the text.
        Console.Clear();

        Console.WriteLine(reference1.DisplayReference());
        Console.WriteLine(scripture1.DisplayScripture());

        // Prompt the user to press the enter key or type quit.
        // If the user types quit, the program should end.
        Console.WriteLine("Press Enter or type: 'quit'");
        string userInput = Console.ReadLine();

        while (userInput.ToLower() != "quit"){
            //hide a few words in the scripture.
            Console.WriteLine(scripture1.Hide());
            //clear screen
            Console.Clear();
            Console.WriteLine(reference1.DisplayReference());
            Console.WriteLine(scripture1.DisplayScripture()); //display scripture again but this time it should display the scripture missing words


            // When all words in the scripture are hidden, the program should end.
            // if (scripture1.AllWordsHidden == true)
            // {
            //     Console.WriteLine("You memorized it! Quitting Program.");
            //     break;
            // }

            // The program should continue prompting the user and hiding more words until all words in the scripture are hidden
            Console.WriteLine("Press Enter or type: 'quit'");
            userInput = Console.ReadLine();
        }
        Console.WriteLine("Quitting Program.");
    }
}

//Stretch goal: add "easy" "medium" "hard" and "impossible" modes. They remove different amounts of words each time.

// Use the principles of Encapsulation, including proper use of classes, methods, public/private access modifiers, and follow good style throughout.
// Contain at least 3 classes in addition to the Program class: one for the scripture itself, one for the reference (for example "John 3:16"), and to represent a word in the scripture.
// Provide multiple constructors for the scripture reference to handle the case of a single verse and a verse range ("Proverbs 3:5" or "Proverbs 3:5-6").