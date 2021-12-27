using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync(bool trackChenges)
            => await FindAll(trackChenges).ToListAsync();

        public async Task<Account> GetAccountAsync(Guid idAccount, bool trackChenges)
            => await FindByCondition(account => account.Id.Equals(idAccount), trackChenges).SingleOrDefaultAsync();
    }
}
