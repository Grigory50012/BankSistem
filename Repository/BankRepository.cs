using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class BankRepository : RepositoryBase<Bank>, IBankRepository
    {
        public BankRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
