using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class OwnerStatusRepository : RepositoryBase<OwnerStatus>, IOwnerStatusRepository
    {
        public OwnerStatusRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
