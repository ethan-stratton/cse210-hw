class Eternal : Goal
{
    public Eternal(string name, int value, string description) : base(name, value, description)
    {
    }

    public override void RecordEvent()
    {
        //nothing happens because it can't be 'completed'. it goes on forever...
    }

    public override string DisplayStatus()
    {
        return $"[∞] - {_name} : {_description}";
    }

    public override string GetClassName(){
        return typeof(Eternal).Name;
    }


}