using System.Collections.Generic;
using Domain.Core.Interface;

namespace CC.Core.DataPersistent
{
    public class StatusBD
    {
        public virtual ICollection<IDevice> Devices { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
