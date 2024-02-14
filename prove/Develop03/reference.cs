class Reference {
    private string _book;
    private string _chapter;
    private string _verse;

    public Reference(){
        _book = "John";
        _chapter = "3";
        _verse = "16";
    }

    public Reference(string book, string chapter, string verse){
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public Reference(string book, string chapter, string averse, string bverse){
        _book = book;
        _chapter = chapter;
        _verse = $"{averse} - {bverse}";
    }

    public string DisplayReference()
    {
        //to string everything for the reference
        return $"{_book} {_chapter}:{_verse}";
    }

}