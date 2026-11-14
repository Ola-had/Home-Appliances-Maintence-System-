using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceMaintenanceSystem
{

    // 1. Base Abstract Class
    public abstract class Appliance : IApplianceMaintenance
    {

        private string serialNumber; // Serial number 
        private string brand;        // Brand
        private bool isRepaired;     // Repair status

        // Constructor to initialize basic data
        protected Appliance(string serialNumber, string brand)
        {

            this.serialNumber = serialNumber;
            this.brand = brand;
            isRepaired = false; // By default, the appliance is not repaired
        }
        // Abstract method that every subclass must implement in its own way
        public abstract double CalculateRepairCost();

        // Shared virtual method that subclasses can override if needed
        public virtual string GetDeviceInfo()
        {
            return $"Device: {this.GetType().Name} | Brand: {brand}, Serial: {serialNumber}";
        }
    }
}

