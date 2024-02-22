public class MathAssignment : Assignment
{   
    private string _textbookSection;
    private string _problems;
    public MathAssignment(string name, string topic, string textbookSection, string problems){
        _studentName = name;
        _topic = topic;
        _textbookSection = textbookSection;
        _problems = problems;
    }
    public string GetHomeworkList()
    {
        return $"{_textbookSection} {_problems}";
    }
}


// public MathAssignment(string studentName, string topic, string textbookSection, string problems)
//         : base(studentName, topic)
//     {
//         // Here we set the MathAssignment specific variables
//         _textbookSection = textbookSection;
//         _problems = problems;
//     }