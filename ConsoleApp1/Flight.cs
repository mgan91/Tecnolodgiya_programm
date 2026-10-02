namespace Airoport;

public class Flight
{
    public int Id { get; }
    public int planeId { get; }
    public string Destination { get; private set; }
    public TimeSpan Departure { get; set; }
    public decimal Price { get; set; }

    public Flight(int id, int planeId, string destination, TimeSpan departure, decimal price)
    {
        if (id <= 0){throw new ArgumentException("id должен быть > 0");}

        if (planeId <= 0) { throw new ArgumentException("planeId должен быть > 0"); }

        if (string.IsNullOrWhiteSpace(destination))
        { throw new ArgumentException("строка не должна быть пустой"); }

        if (departure < TimeSpan.Zero || departure >= TimeSpan.FromHours(24))
        { throw new ArgumentException("в сутках 24 часа");}

        if (price <= 0)
        { throw new ArgumentException("цена должна быть больше 0"); }
        
        Id = id;
        this.planeId = planeId;
        Destination = destination;
        Departure = departure;
        Price = price;

    }
    
    
    public bool isMorning
    {
        get { return Departure < new TimeSpan(12, 0, 0); }
    }

    public string GetInfo()
    {
        string time = Departure.Hours.ToString("00") + ":" + Departure.Minutes.ToString("00");
        return Destination + ", " + time + ", " + Price + "руб.";
    }
}