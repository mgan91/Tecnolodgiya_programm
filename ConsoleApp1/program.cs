namespace Airoport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {


                Console.Write("Please enter a number: 1 - InMemory, 2 - CSV\n");
                string input = Console.ReadLine();
                List<Airline> airlines;
                List<Flight> flights;
                List<Plane> planes;

                switch (input)
                {
                    case "1":
                        InMemoryRepository mem = new InMemoryRepository();
                        airlines = mem.GetAirlines();
                        flights = mem.GetFlights();
                        planes = mem.GetPlans();
                        break;
                    case "2":
                        CsvRepository csv = new CsvRepository("data");
                        airlines = csv.GetAirlines();
                        flights = csv.GetFlights();
                        planes = csv.GetPlanes();
                        break;
                    default:
                        Console.WriteLine("Неверный выбор");
                        return;
                }

                ///найти самолет по направлению 
                Plane p1 = FindPlane(flights, planes, "Москва");
                Console.WriteLine("1. FindPlane(\"Москва\"): " + (p1 != null ? p1.GetInfo() : "null"));


                Airline a1 = FindAirline(planes, airlines, "Boing 737");
                Console.WriteLine("2. FindAirline(plane \"Boing 737\"):" + (a1 != null ? a1.GetInfo() : "null"));


                int total = GetTotalCapacity(planes);
                Console.WriteLine("3. GetTotalCapacity: " + total + " пассажиров");


                Airline busy = GetBusiestAirline(airlines, planes, flights);
                if (busy != null)
                {
                    int cnt = CountFlightsForAirline(airlines, planes, flights, busy.Id);
                    Console.WriteLine("4. GetBusiestAirline: " + busy.Name +
                                      " (" + cnt + " рейса)");
                }
                else
                {
                    Console.WriteLine("4. GetBusiestAirline: null");
                }

                Console.WriteLine("5. PrintAllFlights: ");
                PrintALLflights(flights, planes, airlines);

                Plane pNotFound = FindPlane(flights, planes, "Неизвестное направление");
                Console.WriteLine("Не найдено: FindPlane(\"Неизвестное направление\") → " +
                                  (pNotFound != null ? pNotFound.GetInfo() : "null"));



            }
            
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex.Message);
                return;
            }
        }

        
        
        
        



        public static void PrintALLflights(List<Flight> flights, List<Plane> planes,
            List<Airline> airlines)
        {
            if (flights == null || flights.Count == 0)
            {
                Console.WriteLine("nety");
                return;
            }

            for (int i = 0; i < flights.Count; i++)
            {
                Flight f =  flights[i];
                Plane p = FindPlaneById(planes, f.planeId);

                string planemodel = "-";
                string airlinename = "-";
                if (p != null)
                {
                    planemodel = p.Model;
                    Airline a = FindAirById(airlines, p.AirlinedID);
                    if (a != null)
                        airlinename = a.Name;
                }
               Console.WriteLine("\"" + f.GetInfo() + "\"-" + planemodel + ", авиакомпания \"" + 
                                 airlinename + "\"");
            }
        }
        
        
        
        
        
        
        
        
        
        public static Plane FindPlane(List<Flight> flights, List<Plane> planes, string dotB)
        {
            for (int i = 0; i < flights.Count; i++)
            {
                if (flights[i].Destination == dotB)
                {
                    Plane p = FindPlaneById(planes, flights[i].planeId);
                    if (p != null) return p;
                }
            }
            return null;
        }
        
        
        
        
        

        public static Airline FindAirline(List<Plane> planes, List<Airline> airlines, string modl)
        {
            for (int i = 0; i < airlines.Count; i++)
            {
                if (planes[i].Model == modl)
                {
                    Airline a = FindAirById(airlines, planes[i].AirlinedID);
                    if (a != null) return a;
                }
            }
            return null;
        }
        
        
        

        private static Plane FindPlaneById(List<Plane> planes , int id)
        {
            for (int i = 0; i < planes.Count; i++)
            {
                if (planes[i].Id == id) return planes[i];
            }
            return null;
        }

        private static Airline FindAirById(List<Airline> airlines, int id)
        {
            for (int i = 0; i < airlines.Count; i++)
            {
                if (airlines[i].Id == id) return airlines[i];
            }
            
            return null;
        }
        
        public static int GetTotalCapacity(List<Plane> planes)
        {
            int sum = 0;
            for (int i = 0; i < planes.Count; i++)
            {
                sum += planes[i].Capacity;
            }
            return sum;
        }





        public static int CountFlightsForAirline(List<Airline> airlines,
            List<Plane> planes,
            List<Flight> flights,
            int airlineId)
        {
            int count = 0;
            for (int i = 0; i < flights.Count; i++)
            {
                Plane p = FindPlaneById(planes, flights[i].planeId);
                if (p != null && p.AirlinedID == airlineId)
                    count++;
            }
            return count;
        }
        
        
        
        public static Airline GetBusiestAirline(List<Airline> airlines,
            List<Plane> planes,
            List<Flight> flights)
        {
            if (airlines.Count == 0 || flights.Count == 0)
                return null;

            Airline best = null;
            int bestCount = -1;

            for (int i = 0; i < airlines.Count; i++)
            {
                int count = CountFlightsForAirline(airlines, planes, flights,
                    airlines[i].Id);
                if (count > bestCount)
                {
                    bestCount = count;
                    best = airlines[i];
                }
            }
            return best;
        }
        
    }
}



