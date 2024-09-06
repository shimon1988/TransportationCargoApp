using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCargoApp.Classes
{
    public class Driver
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ID { get; set; }
        public CargoType CargoType { get; set; } // Enum representing different types of cargo

        public void Approve(CargoVehicle vehicle)
        {
            if (vehicle != null && vehicle.IsHaveRoom())
            {
                vehicle.CanDrive = true;
            }
        }
    }

}
