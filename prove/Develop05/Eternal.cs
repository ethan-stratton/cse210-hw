class Eternal : Goal
{
    public Eternal(string name, int value, string description) : base(name, value, description)
    {
    }

    public override void RecordEvent()
    {
        _value += 100;
    }
}