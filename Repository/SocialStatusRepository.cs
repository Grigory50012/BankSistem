using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class SocialStatusRepository : RepositoryBase<SocialStatus>, ISocialStatusRepository
    {
        public SocialStatusRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
