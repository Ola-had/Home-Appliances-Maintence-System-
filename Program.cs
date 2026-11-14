using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceMaintenanceSystem
{
    class Program
    {

        // ==========================================
        // Main Program to test the system
        // ========================================== 

        static void Main(string[] args)
        {

            MaintenanceCenter center = new MaintenanceCenter();
            // Add different appliances
            center.AddAppliance(new Refrigerator("REF-1001", "LG", 80));
            center.AddAppliance(new WashingMachine("WSH-2002", "Samsung", true));
            center.AddAppliance(new AirConditioner("AIR-3003", "Carrier", 120, true));

            Console.WriteLine("--- List of Appliances in the Maintenance Center with its status ---\n");
            center.DisplayAll();

            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Total Maintenance Cost: {center.CalculateTotalCost()} SAR");
            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
    }
}

