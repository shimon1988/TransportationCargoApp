using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationCargoApp.Classes
{
    public class RunApplication
    {
        public static void Run()
        {
            // Create a new port for Ships in New York
            Port port = new Port("USA", "New York", "Harbor St.", 101, 10000m, 20000m, CargoType.Ship);

            // Create some IPortable items (furniture, general items, etc.)
            IPortable table = new GeneralItem
            {
                Name = "Table",
                Weight = 150m,
                Volume = 1200m,
                Fragile = false
            };

            IPortable fridge = new GeneralItem
            {
                Name = "Fridge",
                Weight = 300m,
                Volume = 2000m,
                Fragile = true
            };

            IPortable chair = new GeneralItem
            {
                Name = "Chair",
                Weight = 50m,
                Volume = 300m,
                Fragile = false
            };

            // Test loading items into the port
            Console.WriteLine("Loading items into the port...");

            bool isTableLoaded = port.Load(table);
            Console.WriteLine($"Table loaded: {isTableLoaded} (Current Weight: {port.GetCurrentWeight()}, Current Volume: {port.GetCurrentVolume()})");

            bool isFridgeLoaded = port.Load(fridge);
            Console.WriteLine($"Fridge loaded: {isFridgeLoaded} (Current Weight: {port.GetCurrentWeight()}, Current Volume: {port.GetCurrentVolume()})");

            bool isChairLoaded = port.Load(chair);
            Console.WriteLine($"Chair loaded: {isChairLoaded} (Current Weight: {port.GetCurrentWeight()}, Current Volume: {port.GetCurrentVolume()})");

            // Test overloading
            IPortable heavyItem = new GeneralItem
            {
                Name = "Heavy Machine",
                Weight = 10000m, // Exceeds max weight
                Volume = 5000m,
                Fragile = false
            };

            bool isHeavyItemLoaded = port.Load(heavyItem);
            Console.WriteLine($"Heavy Machine loaded: {isHeavyItemLoaded} (Current Weight: {port.GetCurrentWeight()}, Current Volume: {port.GetCurrentVolume()})");

            // Test unloading items from the port
            Console.WriteLine("\nUnloading items from the port...");

            bool isTableUnloaded = port.Unload(table);
            Console.WriteLine($"Table unloaded: {isTableUnloaded} (Current Weight: {port.GetCurrentWeight()}, Current Volume: {port.GetCurrentVolume()})");

            bool isFridgeUnloaded = port.Unload(fridge);
            Console.WriteLine($"Fridge unloaded: {isFridgeUnloaded} (Current Weight: {port.GetCurrentWeight()}, Current Volume: {port.GetCurrentVolume()})");

            bool isChairUnloaded = port.Unload(chair);
            Console.WriteLine($"Chair unloaded: {isChairUnloaded} (Current Weight: {port.GetCurrentWeight()}, Current Volume: {port.GetCurrentVolume()})");

            // Test overloading protection after unloading
            isHeavyItemLoaded = port.Load(heavyItem);
            Console.WriteLine($"Heavy Machine loaded after unloading: {isHeavyItemLoaded} (Current Weight: {port.GetCurrentWeight()}, Current Volume: {port.GetCurrentVolume()})");
        }
    }
}
