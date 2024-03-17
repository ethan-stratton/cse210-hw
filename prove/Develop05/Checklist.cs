class Checklist : Goal
{
    public int _targetCount { get; set; }
    public int _currentCount { get; set; }
    public int _bonusValue { get; set; }

    public Checklist(string name, int value, string description, int targetCount, int bonusValue) : base(name, value, description)
    {
        _targetCount = targetCount;
        _bonusValue = bonusValue;
        _currentCount = 0;
    }

    //needs a class which asks for bonus points @ 3;11

    public override void RecordEvent()
    {
        _currentCount++;

        if (_currentCount == _targetCount && _currentCount !>= _targetCount)
        {
            _value += _bonusValue;
            base.RecordEvent();
        }
    }

    public override string DisplayStatus()
    {
        return $"{base.DisplayStatus()} -- Completed {_currentCount}/{_targetCount} times";
    }

    public override string GetClassName(){
        return typeof(Checklist).Name;
    }
}
