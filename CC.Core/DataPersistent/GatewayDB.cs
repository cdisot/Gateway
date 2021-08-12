using Domain.Core.CoreData;
using Domain.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CC.Core.DataPersistent
{
    public class GatewayDB
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


        public string SerialNumber { get ; set; }
    public string IPv4Address { get; set; }

     public virtual ICollection<IDevice> Devices { get; set; }
  


}
}
