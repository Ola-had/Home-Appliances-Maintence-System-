using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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


        // 4. Define the Event using the Delegate
        public event DeviceStatusChangedHandler OnStatusChanged;

        // 5.Static Property to count repaired devices
        public static int TotalRepairedDevices { get; private set; } = 0;



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

        // Modify the setter to trigger the event when status changes
        public bool IsRepaired
        {
            get { return isRepaired; }
            set
            {
                // Check if the status is actually changing to avoid multiple triggers
                if (isRepaired != value)
                {
                    isRepaired = value;

                    // 4. Raise the Event if the condition is met
                    // Example condition: Trigger event when the device becomes repaired
                    if (isRepaired)
                    {
                        RaiseStatusChangedEvent($"[NOTIFICATION] Appliance {this.GetType().Name} with Serial {this.SerialNumber} has been fully repaired and is ready for delivery.");
                        TotalRepairedDevices++;   // 5. Update Static Counter based on status
                    }
                    else
                    {
                        RaiseStatusChangedEvent($"[NOTIFICATION] Appliance {this.GetType().Name} with Serial {this.SerialNumber} has been returned to maintenance.");
                    }
                }
            }
        }

        // Helper method to safely raise the event
        protected virtual void RaiseStatusChangedEvent(string message)
        {
            // If there are subscribers to the event, invoke them
            OnStatusChanged?.Invoke(this, message);
        }


        public Appliance(string serialNumber, string brand)
        {
            // 5. Use the Static Validation Method
            if (!MaintenanceHelper.IsValidSerialNumber(serialNumber))
                throw new ArgumentException($"Invalid Serial Number: '{serialNumber}'. Format must be XXX-1234 (e.g., REF-1001).");

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
            return $"Device: {this.GetType().Name} | Brand: {brand} | Serial: {serialNumber} | Status: {status}";
        }

    }


    // Static class for data validation
    public static class MaintenanceHelper
    {
        // Format: 3 uppercase letters + hyphen + 4 digits (e.g., REF-1234)
        public static bool IsValidSerialNumber(string serialNumber)
        {
            if (string.IsNullOrWhiteSpace(serialNumber)) return false;

            string pattern = @"^[A-Z]{3}-\d{4}$";
            return Regex.IsMatch(serialNumber, pattern);
        }
    }
}