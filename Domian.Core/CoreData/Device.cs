using Domain.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.CoreData
{
    public class Device :Entity, IDevice
    {
        public int UID { get; set; }


        public string Vendor { get; set; }


        public DateTime DateCreate { get; set ; }

        public int GatewayId { get; set ; }
        public IGateway Gateway { get; set; }

        public int StatusId { get; set; }
        public IStatus Status { get; set; }
    
    }
}
