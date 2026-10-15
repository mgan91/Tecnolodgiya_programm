/// <summary>
/// Мясо. Не реализует IExpirable.
/// </summary>
public class Meat : Food
{
    public bool IsFrozen { get; set; }

    public bool IsSafeToEat => !IsFrozen || Storage == StorageType.Freezer;

    public Meat(int id, string name, int calories, bool isFrozen)
        : base(id, name, calories)
    {
        IsFrozen = isFrozen;
    }

    public Meat(string name) : base(name)
    {
        IsFrozen = false;
    }

    public override void Consume()
    {
        Console.WriteLine($"{Name} consumed.");
    }

    public override string ToString()
    {
        return $"[Meat] {Name}, {Calories} cal, storage: {Storage}";
    }
}