using System;

namespace Airoport
{
    public class Airline
    {

        public int Id { get; }
        public string Name { get; set; }
        public string Country { get; set; }

        public Airline(int id, string Name, string Country)
        {
            if (id <= 0){throw new ArgumentException("АЙДИШНИК НЕ 0"); }

            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("строка не пустая");
            }

            if (string.IsNullOrWhiteSpace(Country))
            {
                throw new ArgumentException("Привет я максим");
            }
            Id = id;
            this.Name = Name;
            this.Country = Country;
            

        }
        
        public bool IsInternetional {get { return Country != "Россия"; }}
        public string GetInfo()
        {return Name + " (" + Country + ") ";}
    }
}