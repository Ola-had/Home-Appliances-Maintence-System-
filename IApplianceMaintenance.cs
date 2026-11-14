using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceMaintenanceSystem
{


    // 4. Define a Delegate for notification
    // This delegate defines the signature of the method that will handle the event
    public delegate void DeviceStatusChangedHandler(Appliance sender, string message);


    // ==========================================
    // 1. Abstraction
    // ==========================================

    // Interface containing the shared core operations for all appliances
    public interface IApplianceMaintenance
    {

        string GetDeviceInfo();
        double CalculateRepairCost();
    }

}


