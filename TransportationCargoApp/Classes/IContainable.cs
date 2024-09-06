using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCargoApp.Classes
{
    public interface IContainable
    {
        bool Load(IPortable item);
        bool Load(List<IPortable> items);
        bool Unload(IPortable item);
        bool Unload(List<IPortable> items);
        bool IsHaveRoom();
        bool IsOverload();
        decimal GetMaxVolume();
        decimal GetMaxWeight();
        decimal GetCurrentVolume();
        decimal GetCurrentWeight();
    }

}
