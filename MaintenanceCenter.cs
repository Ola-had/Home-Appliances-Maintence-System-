using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceMaintenanceSystem
{
    class MaintenanceCenter
    {

        // Create a list of appliances (Polymorphism)
        private List<Appliance> appliances = new List<Appliance>();

        public void AddAppliance(Appliance appliance)
        {
            appliances.Add(appliance);
        }

        // Loop through all appliances and calculate the total cost 
        public double CalculateTotalCost()
        {
            double total = 0;
            foreach (Appliance appliance in appliances)
            {
                total += appliance.CalculateRepairCost();
            }
            return total;
        }

        public void DisplayAll()
        {
            // Loop through all appliances and calculate the cost (Polymorphism in Action)
            foreach (Appliance appliance in appliances)
            {
                Console.WriteLine(appliance.GetDeviceInfo());
                Console.WriteLine($"Repair Cost: {appliance.CalculateRepairCost()} SAR\n");
            }
        }
    }
}
