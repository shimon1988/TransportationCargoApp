using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCargoApp.Classes
{
    public interface IShippingPriceCalculator
    {
        decimal CalculatePrice(IPortable item, int travelDistance);
        decimal CalculatePrice(List<IPortable> items, int travelDistance);
    }

}
