class Program
{
    static void Main()
    {
        List<Food> foods = new List<Food>
        {
            new Vegetable(1, "Cucumber", 15, isOrganic: true),
            new Dairy(2, "Milk", 60, DateTime.Now.AddDays(-1)),
            new Meat(3, "Beef", 250, isFrozen: true)
        };

        foods[0].Storage = StorageType.Room;
        foods[1].Storage = StorageType.Fridge;
        foods[2].Storage = StorageType.Freezer;

        foreach (Food food in foods)
        {
            Console.WriteLine(food.ToString());
            Console.WriteLine($"  cal/100g: {food.CaloriesPer100g}");
            food.Consume();

            if (food is IExpirable expirable)
            {
                Console.WriteLine($"{food.Name} expired: {expirable.IsExpired()}");
            }
            else
            {
                Console.WriteLine($"{food.Name} is not expirable.");
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}