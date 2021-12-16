using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class BankBranchRepository : RepositoryBase<BankBranch>, IBankBranchRepository
    {
        public BankBranchRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
