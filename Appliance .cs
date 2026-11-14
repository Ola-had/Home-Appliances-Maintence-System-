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
        // 3. Encapsulation
        // All fields are private and cannot be accessed directly
        private string serialNumber; // Serial number (sensitive, cannot be modified)
        private string brand;        // Brand
        private bool isRepaired;     // Repair status


        // Properties to control data access
        public string SerialNumber
        {
            get { return serialNumber; }
            // No Setter because the serial number cannot be modified after creation
        }

        public string Brand
        {
            get { return brand; }
            set
            {

                brand = value;
            }
        }

        public bool IsRepaired
        {
            get { return isRepaired; }
            set { isRepaired = value; }
        }


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
            string status = IsRepaired ? "Repaired" : "Under Maintenance";
            return $"Device: {this.GetType().Name} | Brand: {brand}, Serial: {serialNumber} | Status: {status}";
        }
    }
}

