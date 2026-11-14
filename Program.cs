using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceMaintenanceSystem
{
    class Program
    {
        // Helper to print a colored message (avoids repeating color/reset code)
        static void PrintColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        // 4. Create a method to handle the event (Subscriber)
        static void HandleStatusChange(Appliance sender, string message)
        {
            PrintColored(message, ConsoleColor.Green);
        }

        // Create an appliance safely: if the serial number is invalid, the
        // constructor throws ArgumentException and the appliance is rejected
        static void TryAddAppliance(MaintenanceCenter center, Func<Appliance> createAppliance)
        {
            try
            {
                Appliance appliance = createAppliance();
                appliance.OnStatusChanged += HandleStatusChange;
                center.AddAppliance(appliance);
            }
            catch (ArgumentException ex)
            {
                PrintColored($"Validation Error: {ex.Message}", ConsoleColor.Red);
            }
        }

        // ==========================================
        // Main Program to test the system
        // ==========================================

        static void Main(string[] args)
        {
            MaintenanceCenter center = new MaintenanceCenter();

            Func<Appliance>[] applianceFactories =
            {
                () => new Refrigerator("REF-1001", "LG", 80),          // Valid Serial Number
                () => new WashingMachine("WSH2002", "Samsung", true),  // Invalid Serial Number (missing hyphen) Will throw exception from Static Helper)
                () => new AirConditioner("AIR-3003", "Carrier", 120, true) // Valid Serial Number
            };

            Console.WriteLine("--- Initializing Appliances (Testing Static Validation) ---\n");

            foreach (Func<Appliance> createAppliance in applianceFactories)
            {
                TryAddAppliance(center, createAppliance);
            }

            Console.WriteLine("\n--- List of Appliances in the Maintenance Center with its status before changing ---\n");
            center.DisplayAll();

            // Change repair status (the IsRepaired setter triggers the event)
            center.MarkAllAsRepaired();

            Console.WriteLine("\n--- List of Appliances in the Maintenance Center with its status after changing ---\n");
            center.DisplayAll();

            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Total Maintenance Cost: {center.CalculateTotalCost()} SAR");

            // 5. Display Static Property Result
            PrintColored("--- System Statistics ---", ConsoleColor.Cyan);
            Console.WriteLine($"Total number of devices repaired: {Appliance.TotalRepairedDevices}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}