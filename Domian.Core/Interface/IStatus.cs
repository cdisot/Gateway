using System.Collections.Generic;

namespace Domain.Core.Interface
{
    public interface IStatus:IEntity
    {
        ICollection<IDevice> Devices { get; set; }
    }
}
