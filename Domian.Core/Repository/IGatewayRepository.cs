

using Domain.Core.CoreData;
using Domain.Core.Interface;

namespace Domain.Core.Repository
{
    public interface IGatewayRepository :IRepository<Gateway>
    {
        IGateway GetBySerialNumber(string serialNumber);
    }
      
}
