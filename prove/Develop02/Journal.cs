using System;
using System.Collections.Generic;
using System.IO;
public class Journal 
{
    private List<JournalEntry> entries;
    
    public Journal() // Constructor
        {
            entries = new List<JournalEntry>();
        }

    public void Write() {
        //print random prompt and records prompt and user input to it. all info is saved in the list of entries
        PromptGenerator promptGenerator = new PromptGenerator();
        string user_prompt  = promptGenerator.GeneratePrompt();
        string userInput = Console.ReadLine();
        
        JournalEntry newEntry = new JournalEntry(user_prompt, userInput, DateTime.Now);
        entries.Add(newEntry);

        Console.WriteLine(newEntry.Display());
    }

    public void DisplayAll(){ //print all the responses. shows date and prompt and response
        foreach (JournalEntry entry in entries) {
            Console.WriteLine(entry.Display());
        }        
    }

    public void Load(){
        //asks for filename and displays the file which the user inputs (journal.txt). 
        // you can also add to this file.
        Console.WriteLine("Enter the filename to edit: ");
        string fileName = Console.ReadLine();

        string fileContent = File.ReadAllText(fileName);

        Console.WriteLine("Content of your file:");
        Console.WriteLine(fileContent);

        // makes content editable
        Console.WriteLine("Do you want to edit the file? (Y/N)");
        if (Console.ReadKey().Key == ConsoleKey.Y)
        {
            Console.WriteLine("\nEnter the new content. Press Ctrl+D (on mac) to save and exit\n");
            string newContent = Console.In.ReadToEnd();
            File.WriteAllText(fileName, newContent);
        }
    }

    public void Save(){
        //prompts for filename and saves the user information to that filename
        Console.WriteLine("Enter the filename to save the current journal to: ");
        string user_file = Console.ReadLine();

        //convert list of JournalEntries to strings. yes I struggled with this
        List<string> stringList = entries.ConvertAll(entry => entry.Display());

        File.WriteAllLines(user_file, stringList);

    }
}
