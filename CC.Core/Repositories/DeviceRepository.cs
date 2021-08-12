
using CC.Core.DataPersistent;
using Domain.Core.CoreData;
using Domain.Core.Interface;
using Domain.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Core.Repositories
{
    public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(AppDbContext context) : base(context)
        {
        }
    }
}
