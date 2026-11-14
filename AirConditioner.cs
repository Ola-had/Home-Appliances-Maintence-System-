using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceMaintenanceSystem
{
    // 3. Air Conditioner

    class AirConditioner : Appliance
    {
        public double GasRefillCost { get; set; }
        public bool NeedsDeepCleaning { get; set; }

        public AirConditioner(string serialNumber, string brand, double gasRefillCost, bool needsDeepCleaning)
            : base(serialNumber, brand)
        {
            GasRefillCost = gasRefillCost;
            NeedsDeepCleaning = needsDeepCleaning;
        }

        public override double CalculateRepairCost()
        {
            double baseCost = 200; // Inspection cost
            double cleaningCost = NeedsDeepCleaning ? 50 : 0; // Cleaning cost
            return baseCost + GasRefillCost + cleaningCost;
        }
    }
}