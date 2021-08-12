using System.Collections.Generic;
using Domain.Core.Interface;

namespace Domain.Core.CoreData
{
    public class Status : Entity, IStatus
    {
        public virtual ICollection<IDevice> Devices { get; set; }
    }
}
