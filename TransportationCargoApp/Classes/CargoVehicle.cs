using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCargoApp.Classes
{
    public abstract class CargoVehicle : IContainable
    {
        public Driver Driver { get; set; }
        public decimal MaxWeight { get; set; }
        public decimal MaxVolume { get; set; }
        public bool CanDrive { get; set; }
        public bool IsOverloaded { get; set; }
        public Port NextPort { get; set; }
        public Port CurrentPort { get; set; }
        public int CurrentTripID { get; set; }
        public List<IPortable> Items { get; set; } = new List<IPortable>();
        public Dictionary<int, decimal> TripHistory { get; set; } = new Dictionary<int, decimal>();
        public decimal CurrentWeight { get;  set; } = 0;
        public decimal CurrentVolume { get;  set; } = 0;

        public abstract bool Load(IPortable item);
        public abstract bool Load(List<IPortable> items);
        public abstract bool Unload(IPortable item);
        public abstract bool Unload(List<IPortable> items);
        public abstract bool IsHaveRoom();
        public abstract bool IsOverload();

        public virtual string GetPricingList()
        {
            // Return trip history as a formatted receipt
            return string.Join(Environment.NewLine, TripHistory.Select(x => $"Trip {x.Key}: ${x.Value}"));
        }

        protected bool CanLoadItem(IPortable item)
        {
            return !IsOverload() && GetCurrentWeight() + item.GetWeight() <= GetMaxWeight() &&
                   GetCurrentVolume() + item.GetVolume() <= GetMaxVolume();
        }

        public decimal GetCurrentWeight() => CurrentWeight;
        public decimal GetCurrentVolume() => CurrentVolume;
        public decimal GetMaxWeight() => MaxWeight;
        public decimal GetMaxVolume() => MaxVolume;
    }

}
