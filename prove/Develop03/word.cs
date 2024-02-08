using System;
using System.Collections.Generic;


public class Word {

    // public string scripture {get;}

    // public List<string> allWords = SplitString(scripture);

    public List<string> SplitString(string scripture)
    {
        // Split the string into words
        string[] wordsArray = scripture.Split(' ');

        // Convert the array to a list
        List<string> wordsList = new List<string>(wordsArray);

        return wordsList;
    }

    public void RemoveWords(List<string> wordsInScripture, int count)
    {
        Random random = new Random();

        for (int i = 0; i < count && wordsInScripture.Count > 0; i++)
        {
            int randomWord = random.Next(0, wordsInScripture.Count);

            string removedElement = wordsInScripture[randomWord];
            wordsInScripture.RemoveAt(randomWord);

            //Console.WriteLine($"Removed word: {removedElement}");
        }

        Console.WriteLine("Scripture: ");
        foreach (var words in wordsInScripture)
        {
            Console.Write(words + " ");
        }
    }

}