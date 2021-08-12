using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Interface
{
    public interface IDevice:IEntity
    {
        int UID { get; }


        string Vendor { get; set; }


        DateTime DateCreate { get; set; }


        int StatusId { get; set; }


        int GatewayId { get; set; }


        IGateway Gateway { get; set; }

        IStatus Status { get; set; }



      


    }
}
