using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class TownRepository : RepositoryBase<Town>, ITownRepository
    {
        public TownRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
