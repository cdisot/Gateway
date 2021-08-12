using System.Collections.Generic;

namespace Domain.Core.Interface
{
    public interface IGateway: IEntity
    {
        /// <summary>
        /// unique serial number 
        /// </summary>
        string SerialNumber { get; set; }

        ICollection<IDevice> Devices { get; set; }  

        /// <summary>
        /// IPv4 address 
        /// </summary>
        string IPv4Address { get; set; }



        /// <summary>
        /// Validate IPv4
        /// </summary>
        /// <returns>return true or false if this correctly address</returns>
        bool IsValidIP();


        /// <summary>
        /// No More Device Allowed if Device associated is >= 10
        /// </summary>
        /// <returns>return true or false</returns>
        bool DeviceAllowed();
    }
}
