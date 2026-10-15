/// <summary>
/// Молочный продукт. Реализует IExpirable.
/// </summary>
public class Dairy : Food, IExpirable
{
    public DateTime ExpirationDate { get; set; }

    public int DaysLeft => (ExpirationDate - DateTime.Now).Days;

    public Dairy(int id, string name, int calories, DateTime expirationDate)
        : base(id, name, calories)
    {
        ExpirationDate = expirationDate;
    }

    public Dairy(string name) : base(name)
    {
        ExpirationDate = DateTime.Now.AddDays(7);
    }

    public bool IsExpired()
    {
        return DateTime.Now > ExpirationDate;
    }

    public override void Consume()
    {
        Console.WriteLine($"{Name} consumed.");
    }

    public override string ToString()
    {
        return $"[Dairy] {Name}, {Calories} cal, storage: {Storage}";
    }
}