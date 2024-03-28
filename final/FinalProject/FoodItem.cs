public class FoodItem
{
    public string Name { get; }
    public int NutritionValue { get; }
    public decimal Price { get; }
    public FoodType Type { get; }

    public FoodItem(string name, decimal price, FoodType type)
    {
        Name = name;
        Price = price;
        Type = type;

        // Set nutritional value based on food type
        switch (type)
        {
            case FoodType.DryFood:
                NutritionValue = 50; 
                break;
            case FoodType.WetFood:
                NutritionValue = 80; 
                break;
            case FoodType.Treat:
                NutritionValue = 20; 
                break;
            case FoodType.SpecialDiet:
                NutritionValue = 100; 
                break;
            default:
                NutritionValue = 0; // Default nutritional value
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
