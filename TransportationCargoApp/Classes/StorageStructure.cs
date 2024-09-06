using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCargoApp.Classes
{
    public abstract class StorageStructure : IContainable
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }

        public decimal MaxWeight { get; set; }
        public decimal MaxVolume { get; set; }
        public decimal CurrentWeight { get; protected set; }
        public decimal CurrentVolume { get; protected set; }

        // Constructor to initialize location
        public StorageStructure(string country, string city, string street, int number, decimal maxWeight, decimal maxVolume)
        {
            Country = country;
            City = city;
            Street = street;
            Number = number;
            MaxWeight = maxWeight;
            MaxVolume = maxVolume;
            CurrentWeight = 0;
            CurrentVolume = 0;
        }

        // Methods that derived classes must implement
        public abstract bool Load(IPortable item);
        public abstract bool Load(List<IPortable> items);
        public abstract bool Unload(IPortable item);
        public abstract bool Unload(List<IPortable> items);

        public virtual bool IsHaveRoom()
        {
            return CurrentWeight < MaxWeight && CurrentVolume < MaxVolume;
        }

        public virtual bool IsOverload()
        {
            return CurrentWeight > MaxWeight || CurrentVolume > MaxVolume;
        }

        public decimal GetMaxWeight() => MaxWeight;
        public decimal GetMaxVolume() => MaxVolume;
        public decimal GetCurrentWeight() => CurrentWeight;
        public decimal GetCurrentVolume() => CurrentVolume;
    }

}
