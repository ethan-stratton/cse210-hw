public class Goal
{
    public string _name { get; set; }
    public int _value { get; set; }
    public bool _completed { get; set; }
    public string _description { get; set; }


    public Goal(string name, int value, string description)
    {
        _name = name;
        _value = value;
        _completed = false;
        _description = description;
    }

    public virtual void RecordEvent()
    {
        _completed = true;
    }

    public virtual string DisplayStatus()
    {
        string status = _completed ? "[X]" : "[ ]"; 
        return $"{_name} - {status} : {_description}";
    }

    public virtual string getClassName(){
        return typeof(Goal).Name;
    }
}