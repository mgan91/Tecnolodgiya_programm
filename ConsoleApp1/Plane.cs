namespace Airoport;

public class Plane
{
    public int Id  { get; set; }
    public string Model { get; set; }
    public int AirlinedID { get; set; }
    public int Capacity { get; set; }
    public bool Isbig
    
    
    
    
    
    {
        get { return Capacity > 200; }
    }

    public string GetInfo()
    {return Model + " (" + Capacity + "мест)";}
}