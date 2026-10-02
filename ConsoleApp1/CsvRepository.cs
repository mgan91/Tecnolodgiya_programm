using System.Globalization;


namespace Airoport
{
    public class CsvRepository
    {
        private readonly string _filePath;

        public CsvRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<Plane> GetPlanes()
        {
            List<Plane> result = new List<Plane>();
            string fullPath = Path.Combine(_filePath, "planes.csv");

            if (!File.Exists(fullPath)) return result;

            string[] lines = File.ReadAllLines(fullPath);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(',');
                if (parts.Length < 4) continue;

                Plane p = new Plane();
                p.Id = int.Parse(parts[0].Trim());
                p.Model = parts[1].Trim();
                p.AirlinedID = int.Parse(parts[2].Trim());
                p.Capacity = int.Parse(parts[3].Trim());

                result.Add(p);
            }

            return result;
        }

        public List<Airline> GetAirlines()
        {
            List<Airline> result = new List<Airline>();
            string fullPath = Path.Combine(_filePath, "airlines.csv");

            if (!File.Exists(fullPath)) return result;

            string[] lines = File.ReadAllLines(fullPath);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(',');
                if (parts.Length < 3) continue;

                Airline a = new Airline
                    (int.Parse(parts[0].Trim()),(parts[1].Trim()), parts[2].Trim());
               

                result.Add(a);
            }

            return result;
        }

        public List<Flight> GetFlights()
        {
            List<Flight> result = new List<Flight>();
            string fullPath = Path.Combine(_filePath, "flights.csv");

            if (!File.Exists(fullPath)) return result;

            string[] lines = File.ReadAllLines(fullPath);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(',');
                if (parts.Length < 5) continue;

                Flight f = new Flight(int.Parse(parts[0].Trim()),  int.Parse(parts[1].Trim()), 
                    parts[2].Trim(), 
                    TimeSpan.Parse(parts[3].Trim()), decimal.Parse(parts[4].Trim()));
                result.Add(f);
            }

            return result;
        }
    }
}