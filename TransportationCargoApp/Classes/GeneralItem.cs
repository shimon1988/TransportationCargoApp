using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCargoApp.Classes
{
    public class GeneralItem : IPortable
    {
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public bool Packaged { get; set; }
        public bool Fragile { get; set; }
        public bool Loaded { get; set; }
        public StorageStructure Location { get; set; }

        public decimal GetArea() => Volume; // Simplified for demo purposes
        public int[] GetSize() => new int[3]; // Placeholder for actual sizes
        public decimal GetVolume() => Volume;
        public decimal GetWeight() => Weight;
        public void PackageItem() => Packaged = true;
        public void UnPackage() => Packaged = false;
        public bool IsPackaged() => Packaged;
        public bool IsFragile() => Fragile;
        public StorageStructure GetLocation() => Location;
        public bool IsLoaded() => Loaded;
    }

}
