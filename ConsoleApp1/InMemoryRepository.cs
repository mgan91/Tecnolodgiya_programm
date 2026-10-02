namespace Airoport;

public class InMemoryRepository
{
    private List<Airline> _airlines;
    private List<Plane>  _planes;
    private  List<Flight> _flights;

    public InMemoryRepository()
    {
        _airlines = new List<Airline>
        {
            new Airline (1, "Аэрофлот", "Россия"),
            new Airline (2,"S7", "Рооссия"),
            new Airline (3, "Air France", "Франция"),
            new Airline(4,"Emirates", "ОАЭ"),
            new Airline (5,"Martinair","Нидерланды")
        };
        _planes = new List<Plane>
        {
            new Plane { Id = 1, Model = "Boeing 737", AirlinedID = 1,Capacity = 180 },
            new Plane { Id = 2, Model = "SJ-100", AirlinedID = 1, Capacity = 720 },
            new Plane { Id = 3, Model = "Airbus A320",AirlinedID = 2, Capacity = 220 },
            new Plane { Id = 4, Model = "Airbus A380",AirlinedID = 4, Capacity = 190 },
            new Plane { Id = 5, Model = "Boeing 737", AirlinedID = 3, Capacity = 410 },

        };
        _flights = new List<Flight>
        {
            new Flight(1,1,"Москва",new TimeSpan(8,30,0), 5500m),
            
            new Flight(2,2,"Берлин", new TimeSpan(12,10,0), 12000m),
            
            new Flight(3,3, "Париж", new TimeSpan(20,0,0), 3800m ),
            new Flight(4,4, "Амстердам",new  TimeSpan(4,0,0), 35000m ),
           
            new Flight(5,5,"Москвы", new TimeSpan(14,15,0), 7200m)
            
        };
    }
    public List<Airline> GetAirlines()
    { return _airlines; }
    
    public List<Plane> GetPlans()
    { return _planes; }
    
    public List<Flight> GetFlights()
    { return _flights; }
    
}