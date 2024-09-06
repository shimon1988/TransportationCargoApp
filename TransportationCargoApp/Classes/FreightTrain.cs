using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCargoApp.Classes
{
    public class FreightTrain : CargoVehicle
    {
        public int NumberOfCarriages { get; set; }

        public override bool Load(IPortable item)
        {
            if (CanLoadItem(item))
            {
                Items.Add(item);
                CurrentWeight += item.GetWeight();
                CurrentVolume += item.GetVolume();
                return true;
            }
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
            if (Items.Contains(item))
            {
                Items.Remove(item);
                CurrentWeight -= item.GetWeight();
                CurrentVolume -= item.GetVolume();
                return true;
            }
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

        public override bool IsHaveRoom()
        {
            return CurrentVolume < MaxVolume && CurrentWeight < MaxWeight;
        }

        public override bool IsOverload()
        {
            return CurrentVolume > MaxVolume || CurrentWeight > MaxWeight;
        }
    }

}
