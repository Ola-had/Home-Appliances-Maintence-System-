using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceMaintenanceSystem
{

    // ==========================================
    // 2. Inheritance & Polymorphism
    // ==========================================

    // --- Subclasses ---

    // 1. Refrigerator

    class Refrigerator : Appliance
    {

        public double GasRefillCost { get; set; } // Gas refill cost

        public Refrigerator(string serialNumber, string brand, double gasRefillCost)
            : base(serialNumber, brand)
        {
            GasRefillCost = gasRefillCost;
        }

        // Polymorphism: specific implementation for calculating refrigerator cost
        public override double CalculateRepairCost()
        {
            double baseCost = 150; // Basic inspection cost
            return baseCost + GasRefillCost;
        }
    }
}
