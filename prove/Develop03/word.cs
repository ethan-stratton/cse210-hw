using System;
using System.Collections.Generic;

public class Word {

    private string _word;
    private bool _isHidden;

    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }
    public override string ToString()
    {
        return $"{_word}";
    }
    public void setWord(string word){
        _word = word;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public string Display(){
        if (_isHidden == true) {
            return "_____";
        }
        else{
            return _word;
        }
    }

}