class Reference {
    private string _book;
    private string _chapter;
    private string _verse;

    public Reference(){
        //constructor if empty
        _book = "No Book";
        _chapter = "0";
        _verse = "00";
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

    public override string ToString()
    {
        //to string everything for the reference
        return $"{_book} {_chapter}:{_verse}";
    }

}