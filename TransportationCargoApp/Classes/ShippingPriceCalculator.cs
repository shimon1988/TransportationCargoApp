using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCargoApp.Classes
{
    public class ShippingPriceCalculator : IShippingPriceCalculator
    {
        private const decimal TrainRate = 5m;
        private const decimal ShipRate = 20m;
        private const decimal PlaneRate = 50m;

        public decimal CalculatePrice(IPortable item, int travelDistance)
        {
            decimal unitCount = item.GetVolume() / 100 + item.GetWeight(); // Volume (cm³) and weight (kg)
            if (item.IsFragile())
            {
                unitCount *= 2; // Double if fragile
            }
            return unitCount * travelDistance * GetRateForVehicle(item.GetLocation());
        }

        public decimal CalculatePrice(List<IPortable> items, int travelDistance)
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += CalculatePrice(item, travelDistance);
            }
            return total;
        }

        private decimal GetRateForVehicle(StorageStructure location)
        {
            switch (location)
            {
                case Port p when p.PortType == CargoType.Train:
                    return TrainRate;
                case Port p when p.PortType == CargoType.Ship:
                    return ShipRate;
                case Port p when p.PortType == CargoType.Airplane:
                    return PlaneRate;
                default:
                    return 0;
            }
        }
    }

}
