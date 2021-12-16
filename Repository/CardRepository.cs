using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    class CardRepository : RepositoryBase<Card>, ICardRepository
    {
        public CardRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
