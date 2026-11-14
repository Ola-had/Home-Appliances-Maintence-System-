using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceMaintenanceSystem
{


    // 2. Washing Machine

    class WashingMachine : Appliance
    {
        public bool NeedsMotorReplacement { get; set; }

        public WashingMachine(string serialNumber, string brand, bool needsMotorReplacement)
            : base(serialNumber, brand)
        {
            NeedsMotorReplacement = needsMotorReplacement;
        }

        public override double CalculateRepairCost()
        {
            double baseCost = 100;
            if (NeedsMotorReplacement)
            {
                baseCost += 300; // Additional cost for the motor
            }
            return baseCost;
        }
    }


}
