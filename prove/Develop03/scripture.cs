class Scripture 
{ 
    private string _verse;
    private string _reference;
    List <string> wordsInScripture;

    Word testingWords = new Word();

    public Scripture()
    {
        _verse = "empty verse";
        _reference = "empty reference";
    }

    public Scripture(string reference, string verse)
    {
        _verse = verse;
        _reference = reference;
    }
    
    public string getVerse()
    {
        return _verse;
    }
    public string getReference(){
        return _reference;
    }
    public string Display()
    {
        return @$"{_reference} : 
        {_verse}";
    }

    public string Hide()
    {
        //randomly select from only those words that are not already hidden, and remove them
        wordsInScripture = testingWords.SplitString(_verse);
        testingWords.RemoveWords(wordsInScripture, 3);

        string scriptureWithHiddenWords = string.Join("", wordsInScripture);

        return scriptureWithHiddenWords;
    }
}