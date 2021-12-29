using Contracts;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class TownRepository : RepositoryBase<Town>, ITownRepository
    {
        public TownRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Town> GetTowns(bool trackChanges)
            => FindAll(trackChanges).OrderBy(town => town.Name);
    }
}
