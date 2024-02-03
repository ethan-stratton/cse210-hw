using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.Clear();
        Journal journal = new Journal();
        Console.WriteLine("Welcome to the Journal Program!");
        Menu(journal);
    }
    static void Menu(Journal journal)
{
    bool exit = false;

    while (!exit)
    {
        
        // if (journal != null) {
        //     journal.DisplayAll();
        // }

        Console.Write("Please select one of the following choices:\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit\nWhat would you like to do? ");

        ConsoleKeyInfo userInput = Console.ReadKey();
        Console.WriteLine();

        switch (userInput.KeyChar)
        {
            case '1':
            journal.Write();
                break;
            case '2':
            journal.DisplayAll();
                break;
            case '3':
            journal.Load();
                break;
            case '4':
            journal.Save();
                break;
            case '5':
                exit = true;
                break;
        }
    }
}
}