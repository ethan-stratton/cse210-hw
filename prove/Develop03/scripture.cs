class Scripture 
{ 
    private List <Word> _wordsInScripture;
    private int _difficulty = 1;
    private string _verse;
    private Reference _reference;


    public Scripture()
    {
        List <Word> _wordsInScripture = SplitString("Your scripture was empty.");
    }

    public Scripture(Reference reference, string text)
    {
        _wordsInScripture = SplitString(text);
        _reference = reference;
        _verse = text;
    }

    public bool checkIfHidden{ 
        get {
        //loop that checks and sees if each word is hidden
        foreach (Word word in _wordsInScripture)
        {
            //if there is one that is not hidden, return false
            if (!word.getIsHidden){
                return false;
            }
        }
        return true;
    }
    }

    public string DisplayScripture(){
        //new list
        //for each word in thingy
        // join 
        //return
        List<string> displayed = new List<string>();
        foreach (Word word in _wordsInScripture){
            displayed.Add(word.Display());
        }
        string words = string.Join(" ", displayed);
        return ($"{_reference.ToString()} {words}");
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

    private List<Word> SplitString(string sentence)
    {
        List<Word> listOfWords = new List<Word>();
        //break the string up into individual words
        string[] wordsArray = sentence.Split(' ');

        //select each word and create a new word
        //for each word in array, create new word object

        foreach (string word in wordsArray)
        {
            // Create a new Word object named Part (Part of Scripture)
            Word Part = new Word(word);
            listOfWords.Add(Part);
        }
        return listOfWords;
    }

    // public override string ToString()
    // {
    //     //returns list of Words as a string
    //     return _verse;
    // }
    
    public void Hide()
    {
        Random random = new Random();

        int count = _difficulty; // get "easy", "medium", "hard", or "impossible" at the start.

        for (int i = 0; i < count; i++)
        {
            //get random index in range of the list
            int randomIndex = random.Next(_wordsInScripture.Count);
            // get the item at the random index and hide it
            _wordsInScripture[randomIndex].Hide();
            //hiddenWord.Hide(); //sets _isHidden to True 
            //hiddenWord.setWord(hiddenWord.Display());
        }
        
        // List<string> verseWithStuffMissing = new List<string>();
        // foreach (Word word in _wordsInScripture)
        // {
        //     verseWithStuffMissing.Add(word.Display());
        // }

        // string final = string.Join("", verseWithStuffMissing);
        // return final;

    }

}