using Domain.Core.CoreData;
using Domain.Core.Interface;
using System;
using System.Collections.Generic;

namespace Domain.Core.CoreData
{
    public class Gateway :Entity, IGateway
{
    public string SerialNumber { get ; set; }


    public string IPv4Address { get; set; }

     public virtual ICollection<IDevice> Devices { get; set; }

        public bool DeviceAllowed()
    {
            return false;
         //return (Devices.Count < 10 || Devices==null ) ? true : false;
       
    }


    /// <summary>
    /// Validate IPv4
    /// </summary>
    /// <returns>return true or false if this correctly address</returns>
    public bool IsValidIP()
    {
        var segments = IPv4Address.Split('.');
            if (segments.Length == 4)
            {
                foreach (var item in segments)
                {
                    int number;

                    if (!Int32.TryParse(item, out number)
                        || !number.ToString().Length.Equals(item.Length)
                        || number < 0
                        || number > 255)
                    { return false; }
                }
            }
            else
            {
                return false;
            }

        return true;
    }

}
}
