using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCargoApp.Classes
{
    public interface IPortable
    {
        decimal GetArea(); // Surface area
        int[] GetSize(); // Dimensions: width, length, height
        decimal GetVolume(); // Volume in cubic cm
        decimal GetWeight(); // Weight in kg
        void PackageItem();
        void UnPackage();
        bool IsPackaged();
        bool IsFragile();
        StorageStructure GetLocation();
        bool IsLoaded();
    }
}
