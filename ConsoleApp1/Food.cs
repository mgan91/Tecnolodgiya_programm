/// <summary>
/// Базовый класс для всех продуктов.
/// </summary>
public abstract class Food
{
    private readonly int _id;

    public string Name { get; set; }
    public int Calories { get; set; }

    public StorageType Storage { get; set; } = StorageType.Room;

    public double CaloriesPer100g => Calories / 100.0;

    public int Id => _id;

    protected Food(int id, string name, int calories)
    {
        _id = id;
        Name = name;
        Calories = calories;
    }

    public Food(string name) : this(0, name, 0)
    {
    }

    public abstract void Consume();

    public override string ToString()
    {
        return $"[Food] {Name}, {Calories} cal, storage: {Storage}";
    }
}