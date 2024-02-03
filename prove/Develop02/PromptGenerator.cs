using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> prompts;
    private Random random;
    public string generated_prompt {get; set;}

    public PromptGenerator()
    {
        prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
        };
        random = new Random();
    }
    public string GeneratePrompt()
    {
        int randIndex = random.Next(prompts.Count);
        string selectedPrompt = prompts[randIndex];

        Console.WriteLine(selectedPrompt);
        
        return selectedPrompt;
    }
}

