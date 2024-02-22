public class Assignment
{
    protected string _studentName;
    protected string _topic;

    public void SetName(string name){
        _studentName = name;
    }

    public void SetTopic(string topic){
        _topic = topic;
    }

    public string GetSummary(){
        return $"{_studentName} -- {_topic}";
    }
}