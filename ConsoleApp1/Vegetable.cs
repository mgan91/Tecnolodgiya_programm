/// <summary>
/// Овощ. Не реализует IExpirable — овощи не всегда скоропортящиеся.
/// </summary>
public class Vegetable : Food
{
    public bool IsOrganic { get; set; }

    public bool IsLowCalorie => Calories < 50;

    public Vegetable(int id, string name, int calories, bool isOrganic)
        : base(id, name, calories)
    {
        IsOrganic = isOrganic;
    }

    public Vegetable(string name) : base(name)
    {
        IsOrganic = false;
    }

    public override void Consume()
    {
        Console.WriteLine($"{Name} consumed.");
    }

    public override string ToString()
    {
        return $"[Vegetable] {Name}, {Calories} cal, storage: {Storage}";
    }
}