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
    public void setWord(string word){
        _word = word;
    }
    public void Hide()
    {
        _isHidden = true;
    }
    public bool getIsHidden {
        get{return _isHidden;} 
    }

    public string Display(){
        if (_isHidden) {
            return "_____";
        }
        else{
            return _word;
        }
    }

}