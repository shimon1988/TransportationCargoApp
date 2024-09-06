using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCargoApp.Classes
{
    public class Port : StorageStructure
    {
        public CargoType PortType { get; set; }

        public Port(string country, string city, string street, int number, decimal maxWeight, decimal maxVolume, CargoType portType)
            : base(country, city, street, number, maxWeight, maxVolume)
        {
            PortType = portType;
        }

        public override bool Load(IPortable item)
        {
            if (CanStoreItem(item))
            {
                // Add the item to the port's storage
                CurrentWeight += item.GetWeight();
                CurrentVolume += item.GetVolume();
                Console.WriteLine($"Item loaded to {PortType} port at {City}, {Country}");
                return true;
            }
            Console.WriteLine("Not enough space to load the item.");
            return false;
        }

        public override bool Load(List<IPortable> items)
        {
            bool allLoaded = true;
            foreach (var item in items)
            {
                if (!Load(item))
                {
                    allLoaded = false;
                    break;
                }
            }
            return allLoaded;
        }

        public override bool Unload(IPortable item)
        {
            if (CurrentWeight >= item.GetWeight() && CurrentVolume >= item.GetVolume())
            {
                // Remove the item from the port's storage
                CurrentWeight -= item.GetWeight();
                CurrentVolume -= item.GetVolume();
                Console.WriteLine($"Item unloaded from {PortType} port at {City}, {Country}");
                return true;
            }
            Console.WriteLine("Item not found or can't be unloaded.");
            return false;
        }

        public override bool Unload(List<IPortable> items)
        {
            bool allUnloaded = true;
            foreach (var item in items)
            {
                if (!Unload(item))
                {
                    allUnloaded = false;
                    break;
                }
            }
            return allUnloaded;
        }

        private bool CanStoreItem(IPortable item)
        {
            return GetCurrentWeight() + item.GetWeight() <= GetMaxWeight() &&
                   GetCurrentVolume() + item.GetVolume() <= GetMaxVolume();
        }
    }

}
