using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceMaintenanceSystem
{
    class Program
    {

        // 4. Create a method to handle the event (Subscriber)
        static void HandleStatusChange(Appliance sender, string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        // ==========================================
        // Main Program to test the system
        // ========================================== 

        static void Main(string[] args)
        {
            MaintenanceCenter center = new MaintenanceCenter();

            Appliance[] appliances =
            {
              new Refrigerator("REF-1001", "LG", 80),
              new WashingMachine("WSH-2002", "Samsung", true),
              new AirConditioner("AIR-3003", "Carrier", 120, true)
             };

            // Add each appliance to the center and subscribe to its event (written once)
            foreach (Appliance appliance in appliances)
            {
                appliance.OnStatusChanged += HandleStatusChange;
                center.AddAppliance(appliance);
            }

            Console.WriteLine("--- List of Appliances in the Maintenance Center with its status before changing ---\n");
            center.DisplayAll();

            // Change repair status (the IsRepaired setter triggers the event)
            center.MarkAllAsRepaired();

            Console.WriteLine("--- List of Appliances in the Maintenance Center with its status after changing ---\n");
            center.DisplayAll();

            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Total Maintenance Cost: {center.CalculateTotalCost()} SAR");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

