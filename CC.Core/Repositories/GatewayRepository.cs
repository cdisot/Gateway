
using CC.Core.DataPersistent;
using Domain.Core.CoreData;
using Domain.Core.Interface;
using Domain.Core.Repository;
using System.Linq;

namespace CC.Core.Repositories
{
    public class GatewayRepository : BaseRepository<Gateway>, IGatewayRepository
    {
        public GatewayRepository(AppDbContext context) : base(context)
        {
        }

        public IGateway GetBySerialNumber(string serialNumber)
        {
            return GetAll().FirstOrDefault(i => i.SerialNumber== serialNumber);
        }
    }
}
