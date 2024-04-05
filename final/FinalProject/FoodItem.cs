public class FoodItem
{

    private string _name;
    private int _nutritionValue;
    private double _price;
    private FoodType _type;
    public string Name { get {return _name;} }
    public int NutritionValue {get {return _nutritionValue;}}
    public double Price { get {return _price;} }
    public FoodType Type { get {return _type;} }
    public FoodItem(string name, double price, FoodType type)
    {
        _name = name;
        _price = price;
        _type = type;

        // Set nutritional value based on food type
        switch (type)
        {
            case FoodType.DryFood:
                _nutritionValue = 40; 
                break;
            case FoodType.WetFood:
                _nutritionValue = 30; 
                break;
            case FoodType.Treat:
                _nutritionValue = 20; 
                break;
            case FoodType.SpecialDiet:
                _nutritionValue = 45; 
                break;
            default:
                _nutritionValue = 10; // placeholder...
                break;
        }
    }
}
public enum FoodType
{
    DryFood,
    WetFood,
    Treat,
    SpecialDiet
}
