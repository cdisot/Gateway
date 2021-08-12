using Domain.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CC.Core.DataPersistent
{
    public class DeviceDB
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int UID { get; set; }

        public string Vendor { get; set; }
        public DateTime DateCreate { get; set ; }

        public int GatewayId { get; set; }
        public IGateway Gateway { get; set; }

        public int StatusId { get; set; }
        public IStatus Status { get; set; }
        
    }
}
