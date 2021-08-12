
using CC.Core.DataPersistent;
using Domain.Core.CoreData;
using Domain.Core.Repository;

namespace CC.Core.Repositories
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        public StatusRepository(AppDbContext context) : base(context)
        {
        }
    }
}
