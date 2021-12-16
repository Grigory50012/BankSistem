using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class CardOwnerRepository : RepositoryBase<CardOwner>, ICardOwnerRepository
    {
        public CardOwnerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
