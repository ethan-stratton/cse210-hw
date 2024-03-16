class Simple : Goal
{
    public Simple(string name, int value, string description) : base(name, value, description)
    {
    }
    
    public override string getClassName(){
        return typeof(Simple).Name;
    }
}