class Scripture 
{ 
    private string _text;
    public List <Word> _wordsInScripture;

    public int _difficulty = 1;
    public Scripture()
    {
        _text = "empty verse";
    }

    public Scripture(string text)
    {
        //_text = text;
        List <Word> _wordsInScripture = SplitString(text);
    }

    public List<Word> DisplayScripture(){
        return _wordsInScripture;
    }

    public void setDifficulty(string difficulty){
        switch (difficulty) 
            {
            case "easy":
                _difficulty = 1;
                break;
            case "medium":
                _difficulty = 2;
                break;
            case "hard":
                _difficulty = 3;
                break;
            case "impossible":
                _difficulty = 4;
                break;
            default :
                _difficulty = 1;
                break;
            }
    }

    public List<Word> SplitString(string sentence)
    {
        List<Word> listOfWords = new List<Word>();

        //break the string up into individual words
        string[] wordsArray = sentence.Split(' ');
        // Convert the array to a list
        List<string> wordsList = new List<string>(wordsArray);
        
        //make a list of those words -> turn them into word objects
        foreach (string word in wordsList)
        {
            // Create a new Word object named Part (Part of Scripture)
            Word Part = new Word(word);
            listOfWords.Add(Part);
        }

        return listOfWords;
        //return the list of word objects
    }
    
    public string Hide()
    {
        Random random = new Random();

        int count = _difficulty; // get "easy", "medium", "hard", or "impossible" at the start.

        for (int i = 0; i < count; i++)
        {
            //get random index in range of the list
            int randomIndex = random.Next(_wordsInScripture.Count);

            // get the item at the random index and hide it
            Word hiddenWord = _wordsInScripture[randomIndex];
            hiddenWord.Hide(); //sets _isHidden to True 
            hiddenWord.setWord(hiddenWord.Display());
                     
        }
        List<string> verseWithStuffMissing = new List<string>();
        foreach (Word word in _wordsInScripture)
        {
            verseWithStuffMissing.Add(word.ToString());
        }

        string final = string.Join("", verseWithStuffMissing);
        return final;

    }
}