public class FoodShop
{
    public void DisplayAvailableFoodItems()
    {
        Console.WriteLine("Available Food Items:");
        Console.WriteLine("1. Dry Food - $5.00");
        Console.WriteLine("2. Wet Food - $8.00");
        Console.WriteLine("3. Treat - $3.00");
        Console.WriteLine("4. Special Diet - $10.00");
    }

    public FoodItem PurchaseFoodItem(int choice)
    {
        switch (choice)
        {
            case 1:
                return new FoodItem("Dry Food", 5.00, FoodType.DryFood);
            case 2:
                return new FoodItem("Wet Food", 8.00, FoodType.WetFood);
            case 3:
                return new FoodItem("Treat", 3.00, FoodType.Treat);
            case 4:
                return new FoodItem("Special Diet", 10.00, FoodType.SpecialDiet);
            default:
                Console.WriteLine("Invalid choice.");
                return null;
        }
    }
}
